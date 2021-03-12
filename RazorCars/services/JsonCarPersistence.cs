using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCars.model;

namespace RazorCars.services
{
    public class JsonCarPersistence:ICarPersistence
    {
        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool UpdatCar(int id, Car car)
        {
            throw new NotImplementedException();
        }

        public Car DeleteCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
