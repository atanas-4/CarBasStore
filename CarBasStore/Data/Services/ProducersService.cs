using CarBasStore.Data.Base;
using CarBasStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Data.Services
{
    public class ProducersService: EntityBaseRepository<Brand>, IBrandsService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
