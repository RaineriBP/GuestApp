using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GuestApp.Models;

namespace GuestApp.Controllers.Api
{
    public class TableController : ApiController
    {
        private ApplicationDbContext _context;

        public TableController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /Api/Table
        public IHttpActionResult GetTable()
        {
            var tables = _context.Table.ToList();

            return Ok(tables);
        }

        //GET /Api/Table/1
        public IHttpActionResult GetTable(int id)
        {
            var tables = _context.Table.SingleOrDefault(t => t.ID == id);

            if (tables == null)
            {
                return NotFound();
            }

            return Ok(tables);
        }

        //POST /Api/Guest
        [HttpPost]
        public Tables CreateGuest(Tables tables)
        {
            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Table.Add(tables);
            _context.SaveChanges();

            return (tables);
        }

        //PUT /Api/Guest/1
        [HttpPut]
        public void UpdateGuest(int id, Tables tables)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var tablesIndDb = _context.Table.SingleOrDefault(t => t.ID == id);

            if (tablesIndDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            tablesIndDb.Position = tables.Position;
            tablesIndDb.TableNumber = tables.TableNumber;

            _context.SaveChanges();

        }

        //DELETE /Api/Guest/1
        [HttpDelete]
        public void DeleteGuest(int id)
        {
            var tableInDb = _context.Table.SingleOrDefault(g => g.ID == id);

            if (tableInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Table.Remove(tableInDb);
            _context.SaveChanges();
        }
    }
    
}
