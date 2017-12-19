namespace RushHour.App.Controllers
{
    using System.Web.Mvc;

    using Data;
    using Data.Repositories;

    using Entities;

    using Services;

    public class BaseController : Controller
    {
        protected AppointmentService appointmentService;
        protected ActivityService activityService;
        protected UserService userService;

        public BaseController(RushHourContext context)
        {
            appointmentService = new AppointmentService(new GenericRepository<Appointment>(context));
            activityService = new ActivityService(new GenericRepository<Activity>(context));
            userService = new UserService(new GenericRepository<User>(context));
        }
    }
}