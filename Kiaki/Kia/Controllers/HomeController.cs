using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Kia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           string[] str =  Directory.GetFiles("wwwroot/Images"); //Начальная директория это папка проекта
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].Remove(0, str[i].LastIndexOf('\\') + 1); //Возращает полный wwwroot/Images/name.jpg а нужено только name.jpg
            }
            return View(str);
        }
    }
}
