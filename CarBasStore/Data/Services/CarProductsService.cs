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
                //CinemaId = data.CinemaId,
                //StartDate = data.StartDate,
                //EndDate = data.EndDate,
                CarProductCategory = data.CarProductCategory,
                BrandId = data.BrandId
            };
            await _context.Movies.AddAsync(newCarProduct);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            //foreach (var actorId in data.ActorIds)
            //{
            //    var newActorMovie = new Actor_Movie()
            //    {
            //        MovieId = newMovie.Id,
            //        ActorId = actorId
            //    };
            //    await _context.Actors_Movies.AddAsync(newActorMovie);
            //}
            //await _context.SaveChangesAsync();
        }

        public async Task<CarProduct> GetCarProductByIdAsync(int id)
        {
            var carProductDetails = await _context.Movies
                //.Include(c => c.Cinema)
                .Include(p => p.Brand)
                //.Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return carProductDetails;
        }

        public async Task<NewCarProductDropdownsVM> GetNewCarProductDropdownsValues()
        {
            var response = new NewCarProductDropdownsVM()
            {
                //Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                //Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Brands = await _context.Brands.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateCarProductAsync(NewCarProductVM data)
        {
            var dbCarProduct = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbCarProduct != null)
            {
                dbCarProduct.Name = data.Name;
                dbCarProduct.Description = data.Description;
                dbCarProduct.Price = data.Price;
                dbCarProduct.ImageURL = data.ImageURL;
                //dbMovie.CinemaId = data.CinemaId;
                //dbMovie.StartDate = data.StartDate;
                //dbMovie.EndDate = data.EndDate;
                dbCarProduct.CarProductCategory = data.CarProductCategory;
                dbCarProduct.BrandId = data.BrandId;
                await _context.SaveChangesAsync();
            }

            ////Remove existing actors
            //var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            //_context.Actors_Movies.RemoveRange(existingActorsDb);
            //await _context.SaveChangesAsync();

            //Add Movie Actors
            //foreach (var actorId in data.ActorIds)
            //{
            //    var newActorMovie = new Actor_Movie()
            //    {
            //        MovieId = data.Id,
            //        ActorId = actorId
            //    };
            //    await _context.Actors_Movies.AddAsync(newActorMovie);
            //}
            //await _context.SaveChangesAsync();
        }
    }
}
