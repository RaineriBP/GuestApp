using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using GuestApp.Models;
using GuestApp.ViewModels;


namespace GuestApp.Controllers
{
    public class GuestController : Controller
    {
        private ApplicationDbContext _context;

        public GuestController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult New()
        {
            var guest = _context.Guest.ToList();
            var table = _context.Table.ToList();

            var viewModel = new GuestFormViewModel()
            {
                GetGuests = guest,
                Tables = table
            };

            return View("GuestForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Guests guests)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GuestFormViewModel()
                {
                    Guests = guests,
                    GetGuests = _context.Guest.ToList(),
                    Tables = _context.Table.ToList()
                };

                return View("GuestForm", viewModel);
            }

            if (guests.ID == 0)
            {
                _context.Guest.Add(guests);
            }
            else
            {
                var guestInDb = _context.Guest.Single(g => g.ID == guests.ID);

                guestInDb.FirstName = guests.FirstName;
                guestInDb.LastName = guests.LastName;
                guestInDb.OptRaffle = guests.OptRaffle;
                guestInDb.RSVP = guests.RSVP;
                guestInDb.SecondGuest = guests.SecondGuest;
                guestInDb.GuestId = guests.GuestId;
                guestInDb.TablesId = guests.TablesId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Guest");
        }

        //GET: Guest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var guest = _context.Guest.Include(g => g.GuestMember).ToList().SingleOrDefault(g => g.ID == id);

            if (guest == null)
            {
                HttpNotFound();
            }

            return View(guest);
        }

        public ActionResult Edit(int id)
        {
            var guest = _context.Guest.SingleOrDefault(g => g.ID == id);

            if (guest == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new GuestFormViewModel()
                {
                    Guests = guest,
                    GetGuests = _context.Guest.ToList(),
                    Tables = _context.Table.ToList()
                };

                return View("GuestForm", viewModel);
            }

        }
    }
}