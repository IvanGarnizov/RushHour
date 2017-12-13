namespace RushHour.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ActivityBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Duration { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}