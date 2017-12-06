namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.UnitOfWork;

    using Entities;

    using Models.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IRushHourData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var appointments = data.Appointments.All();
            var appointmentModels = Mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentViewModel>>(appointments);

            return View(appointmentModels);
        }
    }
}