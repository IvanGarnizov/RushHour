namespace RushHour.App.Services
{
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;

    using Data.Repositories;

    using Entities;

    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        public AppointmentService(IRepository<Appointment> repository)
            : base(repository)
        {
        }

        public override bool OnBeforeCreate(Appointment entity, string userId)
        {
            int allowedAppointments = int.Parse(File.ReadAllText(HostingEnvironment.MapPath("~/") + "applicationSettings.txt"));

            return CalculateOvberlappingDates(entity, userId) < allowedAppointments;
        }

        public void Cancel(Appointment appointment)
        {
            appointment.IsCancelled = true;
            repository.SaveChanges();
        }

        private int CalculateOvberlappingDates(Appointment entity, string userId)
        {
            var appointments = repository.All()
                .Where(a => a.UserId == userId);
            int overlappingAppointments = 0;

            foreach (var appointment in appointments)
            {
                if (appointment.StartDateTime <= entity.StartDateTime && entity.EndDateTime <= appointment.EndDateTime)
                {
                    overlappingAppointments++;
                }
            }

            return overlappingAppointments;
        }
    }
}