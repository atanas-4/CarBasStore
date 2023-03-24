using CarBasStore.Data;
using CarBasStore.Data.Services;
using CarBasStore.Data.Static;
using CarBasStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class BrandsController : Controller
    {
        private readonly IBrandsService _service;

        public BrandsController(IBrandsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBrand = await _service.GetAllAsync();
            return View(allBrand);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var BrandDetails = await _service.GetByIdAsync(id);
            if (BrandDetails == null) return View("NotFound");
            return View(BrandDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Brand producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var BrandDetails = await _service.GetByIdAsync(id);
            if (BrandDetails == null) return View("NotFound");
            return View(BrandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Brand producer)
        {
            if (!ModelState.IsValid) return View(brand);

            if (id == brand.Id)
            {
                await _service.UpdateAsync(id, brand);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) return View("NotFound");
            return View(brandDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
