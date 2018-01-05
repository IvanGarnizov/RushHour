namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Entities;
    
    using Models.BindingModels;

    using Services;

    [Authorize]
    public class ActivityController : BaseController<Activity, IService<Activity>>
    {
        public ActivityController(IService<Activity> activityService)
            : base(activityService)
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

            service.Create(activity);

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

            var activity = service.Get(id);

            activity.Name = model.Name;
            activity.Duration = model.Duration;
            activity.Price = model.Price;
            service.Update(activity);

            return RedirectToAction("Index", "Appointment");
        }
        
        public ActionResult Delete(int id)
        {
            var activity = service.Get(id);

            service.Delete(activity);

            return RedirectToAction("Index", "Appointment");
        }
    }
}