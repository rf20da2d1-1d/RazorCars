using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorCars.model;

namespace RazorCars.mock
{
    public class MockData
    {
        public static List<Car> _cars = new List<Car>()
        {
            new Car(1, "VW", "Rød"),
            new Car(2, "Skoda", "Grøn"),
            new Car(3, "Seat", "Grå"),
            new Car(4, "BMW", "Stort"),
            new Car(5, "AUDI", "Lysegrå"),
        };

        public static List<Car> Cars => _cars;
    }
}
