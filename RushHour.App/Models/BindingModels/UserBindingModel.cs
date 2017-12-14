namespace RushHour.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}