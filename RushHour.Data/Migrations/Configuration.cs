namespace RushHour.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Entities;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<RushHourContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RushHourContext context)
        {
            if (context.Users.Count() == 0)
            {
                var admin = new User()
                {
                    UserName = "admin",
                    Email = "admin@rush.hour.com"
                };
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(admin, "adminPass123");

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("Admin"));

                var adminUser = context.Users
                    .First(u => u.UserName == "admin");

                userManager.AddToRole(adminUser.Id, "Admin");

                var firstAppointment = new Appointment()
                {
                    StartDateTime = new DateTime(2017, 12, 5, 13, 30, 0),
                    EndDateTime = new DateTime(2017, 12, 5, 14, 0, 0),
                    UserId = adminUser.Id
                };
                var secondAppointment = new Appointment()
                {
                    StartDateTime = new DateTime(2017, 12, 5, 15, 0, 0),
                    EndDateTime = new DateTime(2017, 12, 5, 17, 0, 0),
                    UserId = adminUser.Id
                };

                context.Appointments.Add(firstAppointment);
                context.Appointments.Add(secondAppointment);
                context.SaveChanges();

                var firstActivity = new Activity()
                {
                    Name = "First activity",
                    Duration = 15,
                    Price = 20,
                    Appointment = firstAppointment
                };
                var secondActivity = new Activity()
                {
                    Name = "Second activity",
                    Duration = 15,
                    Price = 14,
                    Appointment = secondAppointment
                };

                context.Activities.Add(firstActivity);
                context.Activities.Add(secondActivity);
                context.SaveChanges();
            }
        }
    }
}
