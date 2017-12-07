namespace RushHour.App.Controllers
{
    using System.Web.Mvc;

    using Data.UnitOfWork;
    
    public class HomeController : BaseController
    {
        public HomeController(IRushHourData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}