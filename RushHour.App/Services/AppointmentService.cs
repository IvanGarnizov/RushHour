namespace RushHour.App.Services
{
    using System.Collections.Generic;

    using Data.Repositories;

    using Entities;

    using Models.BindingModels;

    public class AppointmentService
    {
        private IRepository<Appointment> repository;

        public AppointmentService(IRepository<Appointment> repository)
        {
            this.repository = repository;
        }

        public Appointment Get(int id)
        {
            return repository.Find(id);
        }

        public IEnumerable<Appointment> Appointments()
        {
            return repository.All();
        }

        public void Create(AppointmentBindingModel model, string userId)
        {
            repository.Add(new Appointment()
            {
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                UserId = userId
            });
            repository.SaveChanges();
        }

        public void Update(AppointmentBindingModel model, int id)
        {
            var appointment = Get(id);

            appointment.StartDateTime = model.StartDateTime;
            appointment.EndDateTime = model.EndDateTime;
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = Get(id);

            repository.Remove(appointment);
            repository.SaveChanges();
        }

        public void Cancel(int id)
        {
            var appointment = Get(id);

            appointment.IsCancelled = true;
            repository.SaveChanges();
        }
    }
}