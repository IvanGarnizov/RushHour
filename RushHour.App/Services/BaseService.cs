namespace RushHour.App.Services
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

        public IEnumerable<T> Get()
        {
            return repository.All();
        }

        public T Get(object id)
        {
            return repository.Find(id);
        }

        public virtual void Create(T entity)
        {
            repository.Add(entity);
            repository.SaveChanges();
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