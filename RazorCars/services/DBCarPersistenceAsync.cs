using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RazorCars.model;

namespace RazorCars.services
{
    public class DBCarPersistenceAsync:ICarPersistenceAsync
    {
        private const String ConnString = @"Data Source=pele-zealand-dk-dbserver.database.windows.net;Initial Catalog=pele-zealand-dk-db;User ID=peleAdm;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public async Task<List<Car>> GetAll()
        {
            List<Car> liste = new List<Car>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Car", conn))
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Car c = new Car();
                        c.Id = reader.GetInt32(0);
                        c.Model = reader.GetString(1);
                        c.Color = reader.GetString(2);
                        liste.Add(c);
                    }
                }

                return liste;
            }
        }

        public async Task<Car> GetCarById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Car where Id = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.Read())
                    {
                        Car c = new Car();
                        c.Id = reader.GetInt32(0);
                        c.Model = reader.GetString(1);
                        c.Color = reader.GetString(2);
                        return c;
                    }
                }

                throw new KeyNotFoundException("Der var ingen bil med id = " + id);
            }
        }


        private const String InsertCar = "insert into Car (Model, Color) Values (@MODEL, @COLOR)";
        public async Task<bool> CreateCar(Car car)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(InsertCar, conn))
                {
                    cmd.Parameters.AddWithValue("@MODEL", car.Model);
                    cmd.Parameters.AddWithValue("@COLOR", car.Color);

                    int rows = await cmd.ExecuteNonQueryAsync();

                    return rows == 1;
                }
            }
        }

        private const String UpdateCar = "Update Car set Model=@MODEL, Color=@COLOR where Id = @ID";
        public async Task<bool> UpdatCar(int id, Car car)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateCar, conn))
                {
                    cmd.Parameters.AddWithValue("@MODEL", car.Model);
                    cmd.Parameters.AddWithValue("@COLOR", car.Color);
                    cmd.Parameters.AddWithValue("@ID", id);

                    int rows = await cmd.ExecuteNonQueryAsync();

                    return rows == 1;
                }
            }
        }

        public async Task<Car> DeleteCar(int id)
        {
            Car c = await GetCarById(id);

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Car where Id = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    int rows = await cmd.ExecuteNonQueryAsync();
                }
            }

            return c;
        }
    }
}
