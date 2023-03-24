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

        }

        public List<Brand> Brands { get; set; }

    }
}
