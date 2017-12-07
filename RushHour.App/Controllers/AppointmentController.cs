namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.UnitOfWork;

    using Entities;

    using Microsoft.AspNet.Identity;

    using Models.BindingModels;
    using Models.ViewModels;

    public class AppointmentController : BaseController
    {
        public AppointmentController(IRushHourData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var appointments = data.Appointments.All()
                .Where(a => a.UserId == userId);
            var appointmentModels = Mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentViewModel>>(appointments);

            return View(appointmentModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppointmentBindingModel model)
        {
            string userId = User.Identity.GetUserId();
            var appointment = new Appointment()
            {
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                UserId = userId
            };

            data.Appointments.Add(appointment);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}