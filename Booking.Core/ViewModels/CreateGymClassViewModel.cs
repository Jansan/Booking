using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.ViewModels
{
    public class CreateGymClassViewModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
    }
}
