using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuestApp.Models;
using System.ComponentModel.DataAnnotations;

namespace GuestApp.ViewModels
{
    public class GuestFormViewModel
    {
        [Display(Name ="Table")]
        public IEnumerable<Tables> Tables { get; set; }

        public IEnumerable<Guests> GetGuests { get; set; }

        public Guests Guests { get; set; }
        
        public string Title
        {
            get
            {
                if (Guests != null && Guests.ID != 0)
                {
                    return "Edit Guest";
                }
                else
                {
                    return "New Guest";
                }
            }
        }
    }
}