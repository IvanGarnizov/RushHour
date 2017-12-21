namespace RushHour.App.Controllers
{
    using System.Web.Hosting;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class ApplicationController : Controller
    {
        public ActionResult Edit()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPut]
        public ActionResult Edit(string value)
        {
            string root = HostingEnvironment.MapPath("~/");

            System.IO.File.WriteAllText(root + "applicationSettings.txt", value);

            return RedirectToAction("Index", "Home");
        }
    }
}