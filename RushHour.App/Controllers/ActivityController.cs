namespace RushHour.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.UnitOfWork;

    using Entities;

    using Models.BindingModels;

    public class ActivityController : BaseController
    {
        public ActivityController(IRushHourData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.AppointmentId = id;

            return View();
        }

        [Authorize]
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [Authorize]
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


    }
}