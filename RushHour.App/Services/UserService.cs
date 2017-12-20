namespace RushHour.App.Services
{
    using Data.Repositories;

    using Entities;

    public class UserService : BaseService<User>
    {
        public UserService(IRepository<User> repository)
            : base(repository)
        {
        }
    }
}