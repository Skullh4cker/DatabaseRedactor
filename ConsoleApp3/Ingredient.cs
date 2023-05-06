using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Ingredient
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public float Measurement { get; set; }
        public Ingredient(string name, string type, float measurement)
        {
            Name = name;
            Type = type;
            Measurement = measurement;
        }
    }
}
