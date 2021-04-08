using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCars.model;
using RazorCars.services;

namespace RazorCars.Pages.Cars
{
    public class IndexModel : PageModel
    {
        //public static List<Car> _cars = new List<Car>()
        //{
        //    new Car(1, "VW", "R�d"),
        //    new Car(2, "Skoda", "Gr�n"),
        //    new Car(3, "Seat", "Gr�"),
        //    new Car(4, "BMW", "Stort"),
        //    new Car(5, "AUDI", "Lysegr�"),
        //};


        //private ICarPersistence _cars;
        private ICarPersistenceAsync _cars;

        
        public IndexModel(ICarPersistenceAsync cars)
        {
            _cars = cars;
        }

        /*
         * properties til view
         */

        public List<Car> Cars { get; private set; }

        //public Car ACar { get; private set; }
        public  void OnGet()
        {
            Task<List<Car>> task = _cars.GetAll();
            Cars = task.Result;
        }
    }
}
