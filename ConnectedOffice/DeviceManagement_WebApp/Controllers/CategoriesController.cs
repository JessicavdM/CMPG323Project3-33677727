using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        //creating an instance of ICategoryRepository
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get all Categories
        public async Task<IActionResult> Index()
        {
            return View(_categoryRepository.GetAll());
        }

        // Gat a Category by ID
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id);
            
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Get Category to create
        public IActionResult Create()
        {
            return View();
        }

        // Create a new Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Get Category to edit by ID
        public async Task<IActionResult> Edit(Guid? id)
        {
            return await Details(id);
        }

        // Update Category by ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            try
            {
                _categoryRepository.Update(category);
                await _categoryRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // Get Category to be deleted by ID
        public async Task<IActionResult> Delete(Guid? id)
        {
            return await Details(id);
        }

        // Delete a Category by ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Remove(category);
            await _categoryRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Check to see if a Category exists for the given ID
        private bool CategoryExists(Guid id)
        {
            if (_categoryRepository.Find(e => e.CategoryId == id) != null)
                return true;

            return false;
        }
    }
}
