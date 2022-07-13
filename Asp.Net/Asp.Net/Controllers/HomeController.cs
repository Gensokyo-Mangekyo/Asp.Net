
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.Net.Controllers
{
    public class HomeController : Controller
    {

        
        [HttpGet]
        public JsonResult Index([FromServices] IRepository repository)
        {
            return new JsonResult(repository.rep);
        }

        

        [HttpPost]
        [Route("add")]
        public JsonResult AddNumberList([FromServices] IRepository repository, int num)
        {
            repository.rep.Add(num);
            return new JsonResult(repository.rep);
        }

        [HttpPut]
        [Route("update")]
        public JsonResult UpdateNumberList([FromServices] IRepository repository, int oldnum,int newnum)
        {
            if (repository.rep.Contains(oldnum))
            {
                repository.rep[repository.rep.IndexOf(oldnum)] = newnum;
                return new JsonResult(repository.rep);
            }
            throw new System.ArgumentException();
        }

        [HttpDelete]
        [Route("delete")]
        public JsonResult DeleteNumberList([FromServices] IRepository repository, int num)
        {
            if (repository.rep.Remove(num))
            {
                return new JsonResult(repository.rep);
            }
            throw new System.ArgumentException();
        }
        [Route("async")]
        public async Task<ActionResult> Index() //Асинхронные операции в контроллере 
        {
            //Асинхронные методы позволяют оптимизировать производительность приложения
            //Могут занять довольно продолжительное время, например, обращение к базе данных
            //Применение асинхронных методов позволяет приложению параллельно с выполнением асинхронного кода выполнять также другие запросы.
            var lst = new List<int>() { 1, 2, 3, 4 };
            await Task.Run(() => lst.ToArray()); //Если есть await то это всегда будет возрат Task если есть рядом Async с названием то он точно возращает Task
            //В первую очередь их предпочтительно использовать при запросах к БД, к внешнем сетевым ресурсам 
            return View();
        }

    }
}