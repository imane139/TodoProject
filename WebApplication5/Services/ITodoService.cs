using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Services
{
    public interface ITodoService
    {
         List<Todo> GetAll(HttpContext context);
         void addTo(TodoVM vm, List<Todo> list, HttpContext context);
        bool Updates(int id, TodoEditVM vm, HttpContext context);
        bool Deletes(int id, HttpContext context);
    }
}
