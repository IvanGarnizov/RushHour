namespace RushHour.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;
    
    using Entities;

    using Microsoft.AspNet.Identity;

    using Models.BindingModels;
    using Models.ViewModels;

    using Services;

    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        public UserController(IAppointmentService appointmentService, IService<Activity> activityService, IService<User> userService)
            : base(appointmentService, activityService, userService)
        {
        }

        public ActionResult Index()
        {
            var users = userService.Get();
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

            var user = userService.Get(id);

            user.UserName = model.Name;
            userService.Update(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var user = userService.Get(id);

            userService.Delete(user);

            return RedirectToAction("Index");
        }

        public new ActionResult Profile()
        {
            string userId = User.Identity.GetUserId();
            var user = userService.Get(userId);
            var userModel = Mapper.Map<User, UserViewModel>(user);

            return View(userModel);
        }
    }
}