namespace RushHour.App.Controllers
{
    using System.Web.Mvc;
    
    using Services;

    public class BaseController<TEntity, TService> : Controller where TService : IService<TEntity>
    {
        protected TService service;

        public BaseController(TService service)
        {
            this.service = service;
        }
    }
}