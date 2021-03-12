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
    public class DeleteCarModel : PageModel
    {
        

        private ICarPersistence _cars;

        public DeleteCarModel(ICarPersistence cars)
        {
            _cars = cars;
        }
        public IActionResult OnGet(int id)
        {
            

            _cars.DeleteCar(id);

            return RedirectToPage("Index");
        }
    }
}
