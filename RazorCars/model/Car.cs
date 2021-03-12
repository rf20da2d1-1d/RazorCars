using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCars.model
{
    public class Car
    {
        private int _id;
        private string _model;
        private string _color;


        public Car()
        {
        }

        public Car(int id, string model, string color)
        {
            _id = id;
            _model = model;
            _color = color;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Model)}: {Model}, {nameof(Color)}: {Color}";
        }
    }
}
