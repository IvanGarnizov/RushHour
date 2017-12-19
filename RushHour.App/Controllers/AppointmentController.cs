namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Data;
    using Data.Repositories;

    using Entities;

    using Microsoft.AspNet.Identity;

    using Models.BindingModels;
    using Models.ViewModels;

    using Services;

    [Authorize]
    public class AppointmentController : BaseController
    {
        public AppointmentController(RushHourContext context)
            : base(context)
        {
        }
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var appointments = appointmentService.Appointments();

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

            appointmentService.Create(model, userId);

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

            appointmentService.Update(model, id);

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            appointmentService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Cancel(int id)
        {
            appointmentService.Cancel(id);

            return RedirectToAction("Index");
        }
    }
}