namespace RushHour.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private DbContext context;
        private IDbSet<T> entitySet;

        public GenericRepository(DbContext context)
        {
            this.context = context;

            entitySet = context.Set<T>();
        }

        public IDbSet<T> EntitySet
        {
            get
            {
                return entitySet;
            }
        }

        public IQueryable<T> All()
        {
            return entitySet;
        }

        public T Find(object id)
        {
            return entitySet.Find(id);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public void Remove(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public T Remove(object id)
        {
            var entity = Find(id);

            Remove(entity);

            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void ChangeState(T entity, EntityState state)
        {
            var entry = context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                entitySet.Attach(entity);
            }

            entry.State = state;
            {

            }
        }
    }
}
