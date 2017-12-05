namespace RushHour.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Entities;

    using Repositories;

    public class RushHourData : IRushHourData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories;

        public RushHourData()
            : this(new RushHourContext())
        {
        }

        public RushHourData(DbContext context)
        {
            this.context = context;

            repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return GetRepository<User>();
            }
        }

        public IRepository<Appointment> Appointments
        {
            get
            {
                return GetRepository<Appointment>();
            }
        }

        public IRepository<Activity> Activities
        {
            get
            {
                return GetRepository<Activity>();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                repositories.Add(typeof(T), Activator.CreateInstance(type, context));
            }

            return (IRepository<T>)repositories[typeof(T)];
        }
    }
}
