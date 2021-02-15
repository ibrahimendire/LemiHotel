using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.ViewModels;

namespace HotelBookingSystem.Controllers
{
    public class GuestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Guest.Include(g => g.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .Include(g => g.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            List<Room> rooms = _context.Room.ToList();
            AddGuestViewModel addRoomViewModel = new AddGuestViewModel(rooms);
            //ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            return View(addRoomViewModel);
        }

        // POST: Guests/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddGuestViewModel addGuestViewModel)
        {
            if (ModelState.IsValid)
            {
                Room theRoom = _context.Room.Find(addGuestViewModel.RoomId);
                Guest newGuest = new Guest

                {
                    FirstName = addGuestViewModel.FirstName,
                    LastName = addGuestViewModel.LastName,
                    Phone =addGuestViewModel.Phone,
                    Email = addGuestViewModel.Email,
                    Address = addGuestViewModel.Address,
                    CheckinDate = addGuestViewModel.CheckinDate,
                    CheckoutDate = addGuestViewModel.CheckoutDate,
                    Room = theRoom,

                };

                _context.Guest.Add(newGuest);
                _context.SaveChanges();

                return Redirect("/Guests");
            }
            return View(addGuestViewModel);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", guest.RoomId);
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Phone,Email,Address,CheckinDate,CheckoutDate,RoomId,Id")] Guest guest)
        {
            if (id != guest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", guest.RoomId);
            return View(guest);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .Include(g => g.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guest = await _context.Guest.FindAsync(id);
            _context.Guest.Remove(guest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.Id == id);
        }

      

    }
}
