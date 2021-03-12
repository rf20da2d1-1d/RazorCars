using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCars.model;

namespace RazorCars.services
{
    public interface ICarPersistence
    {
        List<Car> GetAll();
        Car GetCarById(int id);
        bool CreateCar(Car car);
        bool UpdatCar(int id, Car car);
        Car DeleteCar(int id);

    }
}
