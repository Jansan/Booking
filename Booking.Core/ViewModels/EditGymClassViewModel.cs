using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.ViewModels
{
    public class EditGymClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
    }
}
