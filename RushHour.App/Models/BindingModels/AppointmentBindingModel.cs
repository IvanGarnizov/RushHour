namespace RushHour.App.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentBindingModel
    {
        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
    }
}