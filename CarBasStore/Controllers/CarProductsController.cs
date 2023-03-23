using CarBasStore.Data;
using CarBasStore.Data.Services;
using CarBasStore.Data.Static;
using CarBasStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CarProductsController : Controller
    {
        private readonly ICarProductsService _service;

        public CarProductsController(ICarProductsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Category);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCarProducts = await _service.GetAllAsync(n => n.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allCarProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allCarProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allCarProducts);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var CarProductDetail = await _service.GetCarProductByIdAsync(id);
            return View(CarProductDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewCarProductDropdownsValues();

            ViewBag.Cateroies = new SelectList(movieDropdownsData.Cateroies, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Brands, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCarProductVM movie)
        {
            if (!ModelState.IsValid)
            {
                var CarProductDropdownsData = await _service.GetNewCarProductDropdownsValues();

                ViewBag.Cateroies = new SelectList(CarProductDropdownsData.Cateroies, "Id", "Name");
                ViewBag.Producers = new SelectList(CarProductDropdownsData.Brands, "Id", "FullName");
                //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewCarProductAsync(carproduct);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var CarProuctDetails = await _service.GetCarProductByIdAsync(id);
            if (CarProuctDetails == null) return View("NotFound");

            var response = new NewCarProductVM()
            {
                Id = CarProuctDetails.Id,
                Name = CarProuctDetails.Name,
                Description = CarProuctDetails.Description,
                Price = CarProuctDetails.Price,
                //StartDate = movieDetails.StartDate,
                //EndDate = movieDetails.EndDate,
                ImageURL = CarProuctDetails.ImageURL,
                CarProductCategory = CarProuctDetails.CarProductCategory,
                CategoryId = CarProuctDetails.CategoryId,
                BrandId = CarProuctDetails.BrandId,
                //ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var CarProductDropdownsData = await _service.GetNewCarProductDropdownsValues();
            ViewBag.Categories = new SelectList(CarProductDropdownsData.Categories, "Id", "Name");
            ViewBag.Producers = new SelectList(CarProductDropdownsData.Brands, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCarProductVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var CarProductDropdownsData = await _service.GetNewCarProductDropdownsValues();

                ViewBag.Categories = new SelectList(CarProductDropdownsData.Categories, "Id", "Name");
                ViewBag.Producers = new SelectList(CarProductDropdownsData.Brands, "Id", "FullName");
                //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateCarProductAsync(carproduct);
            return RedirectToAction(nameof(Index));
        }
    }
}