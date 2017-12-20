namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Entities;

    using Microsoft.AspNet.Identity;

    using Models.BindingModels;
    using Models.ViewModels;

    using Services;

    [Authorize]
    public class AppointmentController : BaseController
    {
        public AppointmentController(IAppointmentService appointmentService, IService<Activity> activityService, IService<User> userService)
            : base(appointmentService, activityService, userService)
        {
        }
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var appointments = appointmentService.Get();

            if (!User.IsInRole("Admin"))
            {
                appointments = appointments
                    .Where(a => a.UserId == userId);
            }

            var appointmentModels = Mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentViewModel>>(appointments);
            
            return View(appointmentModels);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(AppointmentBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string userId = User.Identity.GetUserId();
            var appointment = new Appointment()
            {
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                UserId = userId
            };

            appointmentService.Create(appointment);

            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPut]
        public ActionResult Edit(AppointmentBindingModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;

                return View();
            }

            var appointment = appointmentService.Get(id);

            appointment.StartDateTime = model.StartDateTime;
            appointment.EndDateTime = model.EndDateTime;
            appointmentService.Update(appointment);

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var appointment = appointmentService.Get(id);

            appointmentService.Delete(appointment);

            return RedirectToAction("Index");
        }

        public ActionResult Cancel(int id)
        {
            var appointment = appointmentService.Get(id);

            appointmentService.Cancel(appointment);

            return RedirectToAction("Index");
        }
    }
}