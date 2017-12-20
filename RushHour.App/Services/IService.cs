namespace RushHour.App.Services
{
    using System.Collections.Generic;

    public interface IService<T>
    {
        IEnumerable<T> Get();

        T Get(object id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
