using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCars.model;
using RazorCars.services;

namespace RazorCars.Pages.Cars
{
    public class CreateCarModel : PageModel
    {
        private ICarPersistence _cars;

        public CreateCarModel(ICarPersistence cars)
        {
            _cars = cars;
        }


        [BindProperty]
        public Car NewCar { get; set; }

        public void OnGet()
        {
            
        }


        public IActionResult OnPost()
        {
            _cars.CreateCar(NewCar);

            return RedirectToPage("Index");

        }
    }
}
