using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;
using WebApplication5.Filters;
using WebApplication5.Mappers;
using WebApplication5.Models;
using WebApplication5.Services;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
    [AuthFilter]
    public class TodoController : Controller
    {
        private ITodoService serviceTodo;
        public TodoController(ITodoService serviceTodo)
        {
            this.serviceTodo = serviceTodo;
            
        }
        public IActionResult Index()
        {
            var list = serviceTodo.GetAll(HttpContext);
            //List<Todo> list = session.Get<List<Todo>>("todos", HttpContext);
            //ViewBag.list=list;
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TodoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            //List<Todo> list;
            //var list= session.Get<List<Todo>>("todos", HttpContext);

            var list=serviceTodo.GetAll(HttpContext);

            serviceTodo.addTo(vm, list, HttpContext);


            //if (HttpContext.Session.GetString("todos") == null)
            //{
            //    list = new List<Todo>();
            //}
            //else {
            //    list = JsonSerializer.Deserialize<List<Todo>>(HttpContext.Session.GetString("todos"));
            //}
            //addTo(list,vm,Httpcontext);void
            //int nextId = (list.Count > 0) ? list.Max(t => t.Id) + 1 : 1;

            //Todo todo = TodoMapper.GetTodoFromTodoVM(vm);
            //todo.Id = nextId;

            //list.Add(todo);
            ////SessionManagerService session = new SessionManagerService();
            //session.Add("todos", list, HttpContext);


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) { 
            var list= serviceTodo.GetAll(HttpContext);
            var todo = list.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            var vm=TodoMapper.GetTodoEditVMFromTodo(todo);
            ViewBag.id=id;
            
                
            
            return View(vm);
       }


        [HttpPost]
        public IActionResult Edit(int id,TodoEditVM vm)
        {
            //var list = serviceTodo.GetAll(HttpContext);

            //Update(list,id,vm,Httpcontext) return boolean
            //var index = list.FindIndex(t => t.Id == id);
            //list[index] = TodoMapper.GetTodoFromTodoEditVM(vm);
            //list[index].Id = id;

            //session.Add("todos", list, HttpContext);

            var valid=serviceTodo.Updates(id, vm,HttpContext);
            if (!valid) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // recuperer la liste depuis la session
            //var list = session.Get<List<Todo>>("todos", HttpContext) ?? [];

            // chercher l index du todo a supprimer
            //var index = list.FindIndex(t => t.Id == id);
            var valid=serviceTodo.Deletes(id,HttpContext);
            if (!valid) return NotFound();

            // supprimer le todo
            //list.RemoveAt(index);

           
            //session.Add("todos", list, HttpContext);

            // rediriger vers l'index
            return RedirectToAction(nameof(Index));
        }




    }
}
