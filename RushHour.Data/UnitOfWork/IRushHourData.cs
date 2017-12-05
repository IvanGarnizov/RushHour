namespace RushHour.Data.UnitOfWork
{
    using Entities;

    using Repositories;

    public interface IRushHourData
    {
        IRepository<User> Users { get; }

        IRepository<Appointment> Appointments { get; }

        IRepository<Activity> Activities { get; }

        void SaveChanges();
    }
}
