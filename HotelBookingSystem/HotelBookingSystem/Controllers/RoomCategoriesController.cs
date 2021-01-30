using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using LemiHotel.Models;

namespace HotelBookingSystem.Controllers
{
    public class RoomCategoriesController : Controller
    {
        private readonly ApplicationDbContext Context;

        public RoomCategoriesController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: RoomCategories
        public async Task<IActionResult> Index()
        {
            return View(await Context.RoomCategory.ToListAsync());
        }

        // GET: RoomCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCategory = await Context.RoomCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        // GET: RoomCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] RoomCategory roomCategory)
        {
            if (ModelState.IsValid)
            {
                Context.Add(roomCategory);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomCategory);
        }

        // GET: RoomCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCategory = await Context.RoomCategory.FindAsync(id);
            if (roomCategory == null)
            {
                return NotFound();
            }
            return View(roomCategory);
        }

        // POST: RoomCategories/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] RoomCategory roomCategory)
        {
            if (id != roomCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(roomCategory);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomCategoryExists(roomCategory.Id))
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
            return View(roomCategory);
        }

        // GET: RoomCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomCategory = await Context.RoomCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        // POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomCategory = await Context.RoomCategory.FindAsync(id);
            Context.RoomCategory.Remove(roomCategory);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomCategoryExists(int id)
        {
            return Context.RoomCategory.Any(e => e.Id == id);
        }
    }
}
