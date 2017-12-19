namespace RushHour.App.Services
{
    using System.Collections.Generic;

    using Data.Repositories;

    using Entities;

    using Models.BindingModels;

    public class UserService
    {
        private IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public User Get(string id)
        {
            return repository.Find(id);
        }

        public IEnumerable<User> Users()
        {
            return repository.All();
        }

        public void Update(UserBindingModel model, string id)
        {
            var user = Get(id);

            user.UserName = model.Name;
            repository.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = Get(id);

            repository.Remove(user);
            repository.SaveChanges();
        }
    }
}