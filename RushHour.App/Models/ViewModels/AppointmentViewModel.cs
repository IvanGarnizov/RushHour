namespace RushHour.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<ActivityViewModel> Activities { get; set; }
    }
}