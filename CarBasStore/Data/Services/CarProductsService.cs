using CarBasStore.Data.Base;
using CarBasStore.Data.ViewModels;
using CarBasStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Data.Services
{
    public class CarProductsService : EntityBaseRepository<CarProduct>, ICarProductsService
    {
        private readonly AppDbContext _context;
        public CarProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewCarProductAsync(NewCarProductVM data)
        {
            var newCarProduct = new CarProduct()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CategoryId = data.CategoryId,
                CarProductCategory = data.CarProductCategory,
                BrandId = data.BrandId
            };
            await _context.CarProducts.AddAsync(newCarProduct);
            await _context.SaveChangesAsync();

            foreach (var carproductId in data.CarProduct)
            {
                var newActorMovie = new Brand_CarProduct()
                {
                    CarProductId = newCarProduct.Id,
                    BrandId = brandId
                };
                await _context.Brand_CarProducts.AddAsync(newBrandCarProduct);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CarProduct> GetCarProductByIdAsync(int id)
        {
            var carProductDetails = await _context.CarProducts

                .Include(p => p.Brand)

                .FirstOrDefaultAsync(n => n.Id == id);

            return carProductDetails;
        }

        public async Task<NewCarProductDropdownsVM> GetNewCarProductDropdownsValues()
        {
            var response = new NewCarProductDropdownsVM()
            {

                Brands = await _context.Brands.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateCarProductAsync(NewCarProductVM data)
        {
            var dbCarProduct = await _context.CarProducts.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbCarProduct != null)
            {
                dbCarProduct.Name = data.Name;
                dbCarProduct.Description = data.Description;
                dbCarProduct.Price = data.Price;
                dbCarProduct.ImageURL = data.ImageURL;

                dbCarProduct.CarProductCategory = data.CarProductCategory;
                dbCarProduct.BrandId = data.BrandId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Brand_CarProducts.Where(n => n.CarProductId == data.Id).ToList();
            _context.Brand_CarProducts.RemoveRange(existingBrandsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.BrandId)
            {
                var newActorMovie = new Brand_CarProduct()
                {
                    CarProductId = data.Id,
                    BrandId = brandId
                };
                await _context.Brand_CarProducts.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
