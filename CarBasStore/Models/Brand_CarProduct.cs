using CarBasStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Models
{
    public class Brand_CarProduct
    {
        public int CarProductId { get; set; }
        public CarProduct CarProduct { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
