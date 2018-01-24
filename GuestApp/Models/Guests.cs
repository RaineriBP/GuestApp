using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GuestApp.Models
{
    public class Guests
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool OptRaffle { get; set; }

        public bool RSVP { get; set; }

        public bool SecondGuest { get; set; }

        public Guests GuestMember { get; set; }

        public int GuestId { get; set; }

        public Tables Tables { get; set; }

        public int TablesId { get; set; }
    }

}