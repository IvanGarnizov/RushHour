namespace RushHour.Data
{
    using System.Data.Entity;

    using Entities;

    public interface IRushHourContext
    {
        IDbSet<Appointment> Appointments { get; set; }

        IDbSet<Activity> Activities { get; set; }
    }
}
