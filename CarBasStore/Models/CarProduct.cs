﻿using CarBasStore.Models;
using CarBasStore.Data;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Models
{
    public class CarProduct
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public CarProductCategory CarProductCategory { get; set; }

        public List<Brand_CarProduct> Brand_CarProducts { get; set; }


        public int CategoryId { get; set; }

        public int BrandId { get; internal set; }



    }
}
