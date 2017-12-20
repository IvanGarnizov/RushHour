namespace RushHour.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Activity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Duration { get; set; }

        public decimal Price { get; set; }

        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
