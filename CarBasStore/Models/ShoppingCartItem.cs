﻿using CarBasStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public CarProduct CarProduct { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
