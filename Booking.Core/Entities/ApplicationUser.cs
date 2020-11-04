using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime TimeOfRegistration { get; set; }

        //Navigation property
        public ICollection<ApplicationUserGymClass> AttendedClasses { get; set; }



    }
}
