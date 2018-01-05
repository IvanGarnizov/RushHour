namespace RushHour.Services
{
    using System.Collections.Generic;

    using Data.Repositories;

    public abstract class BaseService<T> : IService<T>
    {
        protected IRepository<T> repository;

        public BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public abstract bool OnBeforeCreate(T entity, string userId = null);

        public IEnumerable<T> Get()
        {
            return repository.All();
        }

        public T Get(object id)
        {
            return repository.Find(id);
        }

        public bool Create(T entity, string userId =  null)
        {
            if (!string.IsNullOrEmpty(userId) && OnBeforeCreate(entity, userId))
            {
                repository.Add(entity);
                repository.SaveChanges();

                return true;
            }
            else if (string.IsNullOrEmpty(userId))
            {
                repository.Add(entity);
                repository.SaveChanges();

                return true;
            }

            return false;
        }

        public void Update(T entity)
        {
            repository.Update(entity);
            repository.SaveChanges();
        }

        public void Delete(T entity)
        {
            repository.Remove(entity);
            repository.SaveChanges();
        }
    }
}