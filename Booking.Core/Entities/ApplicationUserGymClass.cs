using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.Entities
{
    public class ApplicationUserGymClass
    {
        public int GymClassId { get; set; }
        public string ApplicationUserId { get; set; }

        //Navigation property
        public GymClass GymClass { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
