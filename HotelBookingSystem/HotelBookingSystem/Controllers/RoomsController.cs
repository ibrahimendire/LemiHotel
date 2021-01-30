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
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext Context;

        public RoomsController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = Context.Room.Include(r => r.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await Context.Room
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(Context.Set<RoomCategory>(), "Id", "Id");
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,CategoryId,Id")] Room room)
        {
            if (ModelState.IsValid)
            {
                Context.Add(room);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(Context.Set<RoomCategory>(), "Id", "Id", room.CategoryId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await Context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(Context.Set<RoomCategory>(), "Id", "Id", room.CategoryId);
            return View(room);
        }

        // POST: Rooms/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,CategoryId,Id")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(room);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            ViewData["CategoryId"] = new SelectList(Context.Set<RoomCategory>(), "Id", "Id", room.CategoryId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await Context.Room
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await Context.Room.FindAsync(id);
            Context.Room.Remove(room);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return Context.Room.Any(e => e.Id == id);
        }




        public async Task<IActionResult> ShowSearchForm()
        {

            return View();
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await Context.Room.Where(e => e.Name.Contains(SearchPhrase)).ToListAsync());
        }
    }
}
