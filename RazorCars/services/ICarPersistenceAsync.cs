using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCars.model;

namespace RazorCars.services
{
    public interface ICarPersistenceAsync
    {
        Task<List<Car>> GetAll();
        Task<Car> GetCarById(int id);
        Task<bool> CreateCar(Car car);
        Task<bool> UpdatCar(int id, Car car);
        Task<Car> DeleteCar(int id);
    }
}
