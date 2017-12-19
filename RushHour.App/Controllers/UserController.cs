namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Data;

    using Entities;

    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        public UserController(RushHourContext context)
            : base(context)
        {
        }

        public ActionResult Index()
        {
            var users = userService.Users();
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

            userService.Update(model, id);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}