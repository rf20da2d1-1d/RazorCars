using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCars.mock;
using RazorCars.model;

namespace RazorCars.services
{
    public class MockCarPersistence: ICarPersistence
    {
        private List<Car> liste;

        public MockCarPersistence()
        {
            liste = MockData.Cars;
        }

        public List<Car> GetAll()
        {
            return liste;
        }

        public Car GetCarById(int id)
        {
            return liste.Find(c => c.Id == id);
        }

        public bool CreateCar(Car car)
        {
            if (car == null) return false;
            liste.Add(car);
            return true;
        }

        public bool UpdatCar(int id, Car car)
        {
            Car c = GetCarById(id);
            if (c == null) return false;

            c.Id = car.Id; // overvej om ID må ændres
            c.Model = car.Model;
            c.Color = car.Color;

            return true;
        }

        public Car DeleteCar(int id)
        {
            Car c = GetCarById(id);
            if (c == null) return null;

            liste.Remove(c);

            return c;
        }
    }
}
