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
    public class HelpsController : Controller
    {
        private readonly ApplicationDbContext Context;

        public HelpsController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: Helps
        public async Task<IActionResult> Index()
        {
            return View(await Context.Help.ToListAsync());
        }

        // GET: Helps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await Context.Help
                .FirstOrDefaultAsync(m => m.Id == id);
            if (help == null)
            {
                return NotFound();
            }

            return View(help);
        }

        // GET: Helps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helps/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddHelpViewModel addHelpViewModel)
        {
            if (ModelState.IsValid)
            {
                Help newHelp = new Help
                {
                    FirstName = addHelpViewModel.FirstName,
                    LastName = addHelpViewModel.LastName,
                    Phone = addHelpViewModel.Phone,
                    Email = addHelpViewModel.Email,
                    Issue = addHelpViewModel.Issue,
                    HelpText = addHelpViewModel.HelpText,
                };

                Context.Add(newHelp);
                await Context.SaveChangesAsync();
                string html = "<h1>" + "Thank you for contacting Us!" + "<h1>";
                return Content(html, "text/html");
            }
            return View(addHelpViewModel);
        }

        // GET: Helps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await Context.Help.FindAsync(id);
            if (help == null)
            {
                return NotFound();
            }
            return View(help);
        }

        // POST: Helps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,Issue,HelpText")] Help help)
        {
            if (id != help.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(help);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpExists(help.Id))
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
            return View(help);
        }

        // GET: Helps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await Context.Help
                .FirstOrDefaultAsync(m => m.Id == id);
            if (help == null)
            {
                return NotFound();
            }

            return View(help);
        }

        // POST: Helps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var help = await Context.Help.FindAsync(id);
            Context.Help.Remove(help);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpExists(int id)
        {
            return Context.Help.Any(e => e.Id == id);
        }
    }
}
