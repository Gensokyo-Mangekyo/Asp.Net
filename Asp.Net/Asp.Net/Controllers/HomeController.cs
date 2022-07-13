
using Microsoft.AspNetCore.Mvc;


namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITime timeService; 
        //Передача DI через конструктор
        public HomeController(ITime timeServ)
        {
            timeService = timeServ;
        }

        public IActionResult Index() //Можно через параметр
        {
            return View();
        }
        [Route("Sakuya")]
        public string GetTime([FromServices] ITime time) //Так тоже можно через параметр
        {
            //Есть ещё способ вот такой HttpContext.RequestServices.GetService<ITime>();
            return $"Sakuya time = {time.Time}";
        }

        [Route("errorcode")]
        public IActionResult ErrorCode(string code)
        {
           return View("Error", code);
        }


        [HttpPost]
        public string Index(string[] lang)
        {
            string result = "";
            foreach (var item in lang)
            {
                result = $"{result} {item}";
            }
            return result;
        }
    }
}