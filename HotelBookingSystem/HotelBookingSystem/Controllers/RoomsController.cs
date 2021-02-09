using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;

using HotelBookingSystem.ViewModels;
using HotelBookingSystem.Models;

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
            List<RoomCategory> categories = Context.RoomCategory.ToList();
            AddRoomViewModel addRoomViewModel = new AddRoomViewModel(categories);
          
            return View(addRoomViewModel);
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public IActionResult Create(AddRoomViewModel addRoomViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomCategory theCategory = Context.RoomCategory.Find(addRoomViewModel.CategoryId);
                Room newRoom = new Room
                {
                    Name = addRoomViewModel.Name,
                    Price = addRoomViewModel.Price,
                    Category = theCategory,

                };

                Context.Room.Add(newRoom);
                Context.SaveChanges();

                return Redirect("/Rooms");
            }
            return View(addRoomViewModel);
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




        public IActionResult ShowSearchForm()
        {

            return View();
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index",await Context.Room.Where(e => e.Category.Name.Contains(SearchPhrase)).ToListAsync());
        }
    }
}
