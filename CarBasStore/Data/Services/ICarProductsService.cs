using CarBasStore.Data.Base;
using CarBasStore.Data.ViewModels;
using CarBasStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Data.Services
{
    public interface ICarProductsService:IEntityBaseRepository<CarProduct>
    {
        Task<CarProduct> GetCarProductByIdAsync(int id);
        Task<NewCarProductDropdownsVM> GetNewCarProductDropdownsValues();
        Task AddNewCarProductAsync(NewCarProductVM data);
        Task UpdateCarProductAsync(NewCarProductVM data);
    }
}
