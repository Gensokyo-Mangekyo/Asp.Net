
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Json")]
        public JsonResult Json()
        {
            return Json(new Person { name = "Flan", age = 666 }, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true //Учитываем регистр
                , WriteIndented = true //Делаем отступы
            });
        }

        [Route("Local")]
        public IActionResult localredirect()
        {
            return LocalRedirect("~/Home/Index"); //LocalRedirect может только перемещаться url которые есть в проекте. МЕТОД INDEX ТАКЖЕ ВЕРНЁТ ПРЕДСТАВЛЕНИЕ INDEX
        }
        [Route("Redirect")]
        public IActionResult redirect()
        {
            return Redirect("https://ru.touhouwiki.net/wiki/Заглавная_страница"); 
        }

        //Теперь сделаем переадресацию на методах контроллера 
        [Route("Action")]
       public IActionResult MyAction()
        {
            return RedirectToAction("Json", "Home"); //Также ещё можно передать значения в контроллер
        }

        [Route("Route")]
        public IActionResult Route()
        {
            return RedirectToRoute("default", new { controller = "Home", action = "Index"}); //По маршруту который задан в классе Startup
        }
        class Person
        {
            public string name { get; set; }
            public int age { get; set; }
        }









    }



}
