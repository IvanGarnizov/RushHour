namespace RushHour.App.Services
{
    using Data.Repositories;

    using Entities;

    public class ActivityService : BaseService<Activity>
    {
        public ActivityService(IRepository<Activity> repository)
            : base(repository)
        {
        }

        public override bool OnBeforeCreate(Activity entity, string userId)
        {
            return true;
        }
    }
}