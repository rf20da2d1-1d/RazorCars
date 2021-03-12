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
    public class EditCarModel : PageModel
    {
        [BindProperty]
        public Car ACar { get; set; }


        private ICarPersistence _cars;

        public EditCarModel(ICarPersistence cars)
        {
            _cars = cars;
        }

        public IActionResult OnGet(int id)
        {
            ACar = _cars.GetCarById(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Car c = _cars.GetCarById(id);
            c.Model = ACar.Model;
            c.Color = ACar.Color;

            return RedirectToPage("Index");
        }
    }
}
