using System.Collections.Generic;
using WebApplication5.Mappers;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Services
{
    public class TodoService : ITodoService
    {
        private ISessionManagerService session;
        public TodoService( ISessionManagerService session)
        {
            this.session = session;
            
        }
        public List<Todo> GetAll(HttpContext context)
        {
            return  session.Get<List<Todo>>("todos", context) ?? [];
        }
        public void addTo(TodoVM vm, List<Todo> list,HttpContext context) {
            int nextId = (list.Count > 0) ? list.Max(t => t.Id) + 1 : 1;

            Todo todo = TodoMapper.GetTodoFromTodoVM(vm);
            todo.Id = nextId;

            list.Add(todo);
            //SessionManagerService session = new SessionManagerService();
            session.Add("todos", list, context);

        }
        public bool Updates(int id ,TodoEditVM vm, HttpContext context)
        {
            var list=GetAll(context);
            var index = list.FindIndex(t => t.Id == id);
            if (index == -1) return false;

            list[index] = TodoMapper.GetTodoFromTodoEditVM(vm);
            list[index].Id = id;

            session.Add("todos", list, context);

            return true;
        }

        public bool Deletes(int id, HttpContext context)
        {
            var list = GetAll(context);
            var index = list.FindIndex(t => t.Id == id);
            if (index == -1) return false;

            list.RemoveAt(index);


            session.Add("todos", list, context);

            return true;
        }
    }
}
