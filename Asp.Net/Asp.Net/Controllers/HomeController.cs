using Microsoft.AspNetCore.Mvc;


namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() //Интрефейс результата действия
        {
            return View(); //Чисто вернуть представление Index()
        }
    }
}