namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Entities;
    
    using Models.BindingModels;

    using Services;

    [Authorize]
    public class ActivityController : BaseController
    {
        public ActivityController(IAppointmentService appointmentService, IService<Activity> activityService, IService<User> userService)
            : base(appointmentService, activityService, userService)
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

            var activity = new Activity()
            {
                Name = model.Name,
                Duration = model.Duration,
                Price = model.Price,
                AppointmentId = appointmentId
            };

            activityService.Create(activity);

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

            var activity = activityService.Get(id);

            activity.Name = model.Name;
            activity.Duration = model.Duration;
            activity.Price = model.Price;
            activityService.Update(activity);

            return RedirectToAction("Index", "Appointment");
        }
        
        public ActionResult Delete(int id)
        {
            var activity = activityService.Get(id);

            activityService.Delete(activity);

            return RedirectToAction("Index", "Appointment");
        }
    }
}