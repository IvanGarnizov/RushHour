namespace RushHour.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.UnitOfWork;

    using Entities;

    using Models.BindingModels;

    [Authorize]
    public class ActivityController : BaseController
    {
        public ActivityController(IRushHourData data)
            : base(data)
        {
        }
        
        public ActionResult Create(int id)
        {
            ViewBag.AppointmentId = id;

            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ActivityBindingModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AppointmentId = id;

                return View();
            }

            var appointment = data.Appointments.All()
                .First(a => a.Id == id);
            var activity = new Activity()
            {
                Name = model.Name,
                Duration = model.Duration,
                Price = model.Price
            };

            appointment.Activities.Add(activity);
            data.SaveChanges();

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

            var activity = data.Activities.All()
                .First(a => a.Id == id);

            activity.Name = model.Name;
            activity.Duration = model.Duration;
            activity.Price = model.Price;
            data.SaveChanges();

            return RedirectToAction("Index", "Appointment");
        }
        
        public ActionResult Delete(int id)
        {
            var activity = data.Activities.All()
                .First(a => a.Id == id);

            data.Activities.Remove(activity);
            data.SaveChanges();

            return RedirectToAction("Index", "Appointment");
        }
    }
}