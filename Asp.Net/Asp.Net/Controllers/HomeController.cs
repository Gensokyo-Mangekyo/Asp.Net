using Asp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {

            return View();
        }

        [HttpPost] //HttpPost нужен для post запросов
        public ViewResult Index(Person pers) //обычный string name,string age
        {
            ViewBag.Messeage = "Marisa"; 
            return View("Marisa", pers); //Обратим внимание что не нужен метод обработки представления Marisa
        }






    }



}
