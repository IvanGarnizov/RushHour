namespace RushHour.Services
{
    using System.Collections.Generic;

    public interface IService<T>
    {
        IEnumerable<T> Get();

        T Get(object id);

        bool Create(T entity, string userId = null);

        void Update(T entity);

        void Delete(T entity);

        bool OnBeforeCreate(T entity, string userId = null);
    }
}
