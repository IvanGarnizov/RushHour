namespace RushHour.App.Controllers
{
    using System.Web.Mvc;

    using Entities;

    using Services;

    public class BaseController : Controller
    {
        protected IAppointmentService appointmentService;
        protected IService<Activity> activityService;
        protected IService<User> userService;

        public BaseController(IAppointmentService appointmentService, IService<Activity> activityService, IService<User> userService)
        {
            this.appointmentService = appointmentService;
            this.activityService = activityService;
            this.userService = userService;
        }
    }
}