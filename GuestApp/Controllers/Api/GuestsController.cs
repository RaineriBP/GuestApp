using GuestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace GuestsApp.Controllers.Api
{
    public class GuestController : ApiController
    {
        private ApplicationDbContext _context;

        public GuestController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /Api/Guest
        public IHttpActionResult GetGuest()
        {
            var guests = _context.Guest.ToList();

            return Ok(guests);
        }

        //GET /Api/Guest/1
        public IHttpActionResult GetGuest(int id)
        {
            var guest = _context.Guest.SingleOrDefault(g => g.ID == id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        //POST /Api/Guest
        [HttpPost]
        public Guests CreateGuest(Guests guest)
        {
            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Guest.Add(guest);
            _context.SaveChanges();

            return (guest);
        }

        //PUT /Api/Guest/1
        [HttpPut]
        public void UpdateGuest(int id, Guests guest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var guestIndDb = _context.Guest.SingleOrDefault(g => g.ID == id);

            if (guestIndDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            guestIndDb.FirstName = guest.FirstName;
            guestIndDb.LastName = guest.LastName;
            guestIndDb.OptRaffle = guest.OptRaffle;
            guestIndDb.RSVP = guest.RSVP;
            guestIndDb.SecondGuest = guest.SecondGuest;
            guestIndDb.GuestId = guest.GuestId;
            guestIndDb.TablesId = guest.TablesId;

            _context.SaveChanges();

        }

        //DELETE /Api/Guest/1
        [HttpDelete]
        public void DeleteGuest(int id)
        {
            var guestInDb = _context.Guest.SingleOrDefault(g => g.ID == id);

            if (guestInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Guest.Remove(guestInDb);
            _context.SaveChanges();
        }
    }
}

