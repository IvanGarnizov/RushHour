namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.UnitOfWork;

    using Entities;

    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        public UserController(IRushHourData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var users = data.Users.All();
            var userModels = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

            return View(userModels);
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPut]
        public ActionResult Edit(UserBindingModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;

                return View();
            }

            var user = data.Users.All()
                .First(u => u.Id == id);

            user.UserName = model.Name;
            data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var user = data.Users.All()
                .First(u => u.Id == id);

            data.Users.Remove(user);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}