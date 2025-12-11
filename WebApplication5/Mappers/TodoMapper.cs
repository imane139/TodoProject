using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Mappers
{
    public class TodoMapper
    {
        //class sans etat 

        public static Todo GetTodoFromTodoVM(TodoVM vm)
        {
            Todo todo = new Todo();
            todo.Libelle = vm.Libelle;
            todo.DateLimite = vm.DateLimite;
            todo.State = vm.State;
            todo.Description = vm.Description;
            return todo; 
        }

        public static TodoVM GetTodoVMFromTodo(Todo todo)
        {
            TodoVM vm = new TodoVM();
            vm.Libelle = todo.Libelle;
            vm.DateLimite = todo.DateLimite;
            vm.State = todo.State;
            vm.Description = todo.Description;
            return vm;
        }

        public static Todo GetTodoFromTodoEditVM(TodoEditVM vm)
        {
            Todo todo = new Todo();
            todo.Libelle = vm.Libelle;
            todo.DateLimite = vm.DateLimite;
            todo.State = vm.State;
            todo.Description = vm.Description;
            return todo;
        }

        public static TodoEditVM GetTodoEditVMFromTodo(Todo todo)
        {
            TodoEditVM vm = new TodoEditVM();
            vm.Libelle = todo.Libelle;
            vm.DateLimite = todo.DateLimite;
            vm.State = todo.State;
            vm.Description = todo.Description;
            return vm;
        }
    }
}
