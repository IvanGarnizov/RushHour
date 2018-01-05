namespace RushHour.Services
{
    using Data.Repositories;

    using Entities;

    public class UserService : BaseService<User>
    {
        public UserService(IRepository<User> repository)
            : base(repository)
        {
        }

        public override bool OnBeforeCreate(User entity, string userId)
        {
            return true;
        }
    }
}