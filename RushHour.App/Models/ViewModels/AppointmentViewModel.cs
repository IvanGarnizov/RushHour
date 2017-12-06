namespace RushHour.App.Models.ViewModels
{
    using System;

    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}