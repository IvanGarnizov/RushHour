namespace RushHour.App.Controllers
{
    using System.Web.Mvc;

    using Data.UnitOfWork;

    public class BaseController : Controller
    {
        protected IRushHourData data;

        public BaseController(IRushHourData data)
        {
            this.data = data;
        }
    }
}