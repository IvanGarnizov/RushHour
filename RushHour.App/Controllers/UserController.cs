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
    public class UserController : BaseController<User, IService<User>>
    {
        public UserController(IService<User> userService)
            : base(userService)
        {
        }

        public ActionResult Index()
        {
            var users = service.Get();
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

            var user = service.Get(id);

            user.UserName = model.Name;
            service.Update(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var user = service.Get(id);

            service.Delete(user);

            return RedirectToAction("Index");
        }

        public new ActionResult Profile()
        {
            string userId = User.Identity.GetUserId();
            var user = service.Get(userId);
            var userModel = Mapper.Map<User, UserViewModel>(user);

            return View(userModel);
        }
    }
}