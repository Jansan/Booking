using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking.Core.Entities;
using Booking.Data.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Booking.Core.ViewModels;
using Booking.Web.Filters;

namespace Booking.Web.Controllers
{

    public class GymClassesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public GymClassesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            db = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        // GET: GymClasses
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await db.GymClasses.ToListAsync());
        }

        // BookingToggle
        public async Task<IActionResult> BookingToggle(int? id)
        {
            if (id is null) return BadRequest();

            var userId = userManager.GetUserId(User);


            //var currentGymClass = await db.GymClasses.Include(g => g.AttendedMembers)
            //       .FirstOrDefaultAsync(a => a.Id == id);

            //var attending = currentGymClass?.AttendedMembers
            //     .FirstOrDefault(a => a.ApplicationUserId == userId);

            var attending = db.ApplicationUserGymClasses.Find(userId, id);

            if (attending is null)
            {
                var booking = new ApplicationUserGymClass
                {
                    ApplicationUserId = userId,
                    GymClassId = (int)id
                    //GymClassId = currentGymClass.Id
                };

                db.ApplicationUserGymClasses.Add(booking);
                await db.SaveChangesAsync();
            }
            else
            {
                db.ApplicationUserGymClasses.Remove(attending);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));


        }

        // GET: GymClasses/Details/5
        [RequiredIdRequiredModelFilter("id")]
        public async Task<IActionResult> Details(int? id)
        {


            var gymClass = await db.GymClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);


            return View(gymClass);
        }

        // GET: GymClasses/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GymClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateGymClassViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var gymClass = mapper.Map<GymClass>(viewModel);
                db.Add(gymClass);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: GymClasses/Edit/5
        [Authorize(Roles = "Admin")]
        [RequiredIdRequiredModelFilter("Id")]
        public async Task<IActionResult> Edit(int? id)
        {

            

            var model = mapper.Map<EditGymClassViewModel>(await db.GymClasses.FindAsync(id));


            return View(model);
        }

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id, EditGymClassViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                var gymClass = mapper.Map<GymClass>(viewModel);

                try
                {
                    db.Update(gymClass);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GymClassExists(viewModel.Id))
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
            return View(viewModel);
        }

        // GET: GymClasses/Delete/5
        [Authorize(Roles = "Admin")]
        [RequiredIdRequiredModelFilter("id")]
        public async Task<IActionResult> Delete(int? id)
        {
            
            var gymClass = await db.GymClasses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
           

            return View(gymClass);
        }

        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gymClass = await db.GymClasses.FindAsync(id);
            db.GymClasses.Remove(gymClass);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GymClassExists(int id)
        {
            return db.GymClasses.Any(e => e.Id == id);
        }
    }
}
