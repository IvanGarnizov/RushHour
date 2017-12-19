namespace RushHour.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data;
    using Data.Repositories;

    using Entities;

    using Models.BindingModels;

    using Services;

    [Authorize]
    public class ActivityController : BaseController
    {
        public ActivityController(RushHourContext context)
            : base(context)
        {
        }
        
        public ActionResult Create(int id)
        {
            ViewBag.AppointmentId = id;

            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ActivityBindingModel model, int appointmentId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AppointmentId = appointmentId;

                return View();
            }

            var appointment = appointmentService.Get(appointmentId);

            activityService.Create(model, appointment);

            return RedirectToAction("Index", "Appointment");
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPut]
        public ActionResult Edit(ActivityBindingModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;

                return View();
            }

            activityService.Update(model, id);

            return RedirectToAction("Index", "Appointment");
        }
        
        public ActionResult Delete(int id)
        {
            activityService.Delete(id);

            return RedirectToAction("Index", "Appointment");
        }
    }
}