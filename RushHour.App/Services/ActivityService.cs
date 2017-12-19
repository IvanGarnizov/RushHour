namespace RushHour.App.Services
{
    using System.Collections.Generic;

    using Data.Repositories;

    using Entities;

    using Models.BindingModels;

    public class ActivityService
    {
        private IRepository<Activity> repository;

        public ActivityService(IRepository<Activity> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Activity> Activity()
        {
            return repository.All();
        }

        public void Create(ActivityBindingModel model, Appointment appointment)
        {
            var activity = new Activity()
            {
                Name = model.Name,
                Duration = model.Duration,
                Price = model.Price,
            };

            appointment.Activities.Add(activity);
            repository.SaveChanges();
        }

        public void Update(ActivityBindingModel model, int id)
        {
            var activity = repository.Find(id);

            activity.Name = model.Name;
            activity.Duration = model.Duration;
            activity.Price = model.Price;
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var activity = repository.Find(id);

            repository.Remove(activity);
            repository.SaveChanges();
        }
    }
}