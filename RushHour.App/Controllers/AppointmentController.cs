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

    [Authorize]
    public class AppointmentController : BaseController
    {
        public AppointmentController(IRushHourData data)
            : base(data)
        {
        }
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var appointments = data.Appointments.All();

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

            data.Appointments.Add(appointment);
            data.SaveChanges();

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

            var appointment = data.Appointments.All()
                .First(a => a.Id == id); 

            appointment.StartDateTime = model.StartDateTime;
            appointment.EndDateTime = model.EndDateTime;
            data.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var appointment = data.Appointments.All()
                .First(a => a.Id == id);

            data.Appointments.Remove(appointment);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Cancel(int id)
        {
            var appointment = data.Appointments.All()
                .First(a => a.Id == id);

            appointment.IsCancelled = true;
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}