﻿using CarBasStore.Data;
using CarBasStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Models
{
    public class NewCarProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL { get; set; }



        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public CarProductCategory CarProductCategory { get; set; }


        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int BrandId { get; set; }
    }
}
