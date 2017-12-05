namespace RushHour.Data
{
    using System.Data.Entity;

    using Entities;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;

    public class RushHourContext : IdentityDbContext<User>, IRushHourContext
    {
        public RushHourContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RushHourContext, Configuration>());
        }

        public IDbSet<Appointment> Appointments { get; set; }

        public IDbSet<Activity> Activities { get; set; }

        public static RushHourContext Create()
        {
            return new RushHourContext();
        }
    }
}
