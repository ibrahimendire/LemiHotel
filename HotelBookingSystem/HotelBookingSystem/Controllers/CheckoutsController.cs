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
    public class CheckoutsController : Controller
    {
        private readonly ApplicationDbContext Context;

        public CheckoutsController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: Checkouts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = Context.Checkout.Include(c => c.Guest);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Checkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await Context.Checkout
                .Include(c => c.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // GET: Checkouts/Create
        public IActionResult Create()
        {
            List<Guest> guests = Context.Guest.ToList();
            AddCheckoutViewModel addCheckoutViewModel = new AddCheckoutViewModel(guests);         
            return View(addCheckoutViewModel);
        }

        // POST: Checkouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(AddCheckoutViewModel addCheckoutViewModel)
        {
            if (ModelState.IsValid)
            {
                Guest theGuest = Context.Guest.Find(addCheckoutViewModel.GuestId);
                Checkout newCheckout = new Checkout
                {
                    Note = addCheckoutViewModel.Note,
                    Guest = theGuest,

                };

                Context.Checkout.Add(newCheckout);
                Context.SaveChanges();

                return Redirect("/Checkouts");
            }
            return View(addCheckoutViewModel);
        }

      

        // GET: Checkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkout = await Context.Checkout
                .Include(c => c.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // POST: Checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkout = await Context.Checkout.FindAsync(id);
            Context.Checkout.Remove(checkout);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckoutExists(int id)
        {
            return Context.Checkout.Any(e => e.Id == id);
        }


    }
}
