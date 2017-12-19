namespace RushHour.App.Controllers
{
    using System.Web.Mvc;

    using Data;
    
    public class HomeController : BaseController
    {
        public HomeController(RushHourContext context)
            : base(context)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}