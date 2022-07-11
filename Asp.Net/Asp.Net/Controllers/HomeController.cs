using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {
        //Request Response получают данные из HttpContexta
        [Route("Cookie")] //Маршрут URL /Cookie
        public string Cookie()
        {
            if (Request.Cookies.ContainsKey("name"))
            {
                string name = Request.Cookies["name"];
                return name;
            }
            Response.Cookies.Append("name", "Rumia");
            return "Печеньки хочешь?";

        }

        [Route("Code")]
        public string StatusCode()
        {
            return "Статус кода " + Response.StatusCode + " " + "Метод запроса " + Request.Method + ";" + HttpContext.User.Identity.Name + " Авторизован = " + HttpContext.User.Identity.IsAuthenticated + " админ = " + HttpContext.User.IsInRole("admin");
        }


        //Для того чтобы передать объект через url рассматриваются разные способы

        //Первый ?name=имя&age=27
        //public string Index(string name,int age)
        //{
        //    return "Привет " + name + "," + age;
        //}

        //Второй ?поле=значение&поле=значение
        //public string Index(Person pers)
        //{
        //    return "Привет " + pers.name + " тебе " + pers.age;
        //}
        //Третий ?[0]=значение&[2]=значение&[1]=значение
        //public string Index(string[] strs)
        //{
        //    string result = "";

        //    foreach (var item in strs)
        //    {
        //        foreach (var person in strs)
        //            result = $"{result}{person}; ";
        //        return result;
        //    }
        //    return result;

        //}
        //Ну и так далее c массивом класса https://localhost:7288/Home/Index?[0].name=Tom&[0].age=37&[1].name=Bob&[1].age=41
        //Со словарём  https://localhost:7288/Home/Index?items[germany]=berlin&items[france]=paris&items[spain]=madrid
        //Более сложный способ без параметров -> Request.Query["ключ"]
    }

    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
    }

}