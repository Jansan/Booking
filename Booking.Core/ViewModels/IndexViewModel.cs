using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<GymClassesViewModel> GymClasses { get; set; }
        public bool ShowHistory { get; set; }

    }
}
