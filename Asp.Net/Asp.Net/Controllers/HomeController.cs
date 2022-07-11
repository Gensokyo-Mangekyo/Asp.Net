using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Controllers
{
    //[NonController] говорит что класс не является конроллером
    public class HomeController : Controller
    {
        [ActionName("Sakuya")] //Теперь перейди по этому адресу /Home/Sakuya и он тебе не найдёт такое представление
        public IActionResult Index()
        {
            return View();
        }
        [NonAction] //Метод не является действием контроллера
        public IActionResult Action()
        {
            return View();
        }

        //Типы http запросов  [HttpGet], [HttpPost], [HttpPut], [HttpPatch], [HttpDelete] и [HttpHead]
    }
}
