using Microsoft.AspNetCore.Mvc;

namespace MyResume.Controllers
{
    public class APIToDoListController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
