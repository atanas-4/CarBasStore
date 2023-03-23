using CarBasStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Data.ViewModels
{
    public class NewCarProductDropdownsVM
    {
        public NewCarProductDropdownsVM()
        {
            Brands = new List<Brand>();
            //Cinemas = new List<Cinema>();
            //Actors = new List<Actor>();
        }

        public List<Brand> Brands { get; set; }
        //public List<Cinema> Cinemas { get; set; }
        //public List<Actor> Actors { get; set; }
    }
}
