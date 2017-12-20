namespace RushHour.App.Services
{
    using Data.Repositories;

    using Entities;

    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        public AppointmentService(IRepository<Appointment> repository)
            : base(repository)
        {
        }

        public void Cancel(Appointment appointment)
        {
            appointment.IsCancelled = true;
            repository.SaveChanges();
        }
    }
}