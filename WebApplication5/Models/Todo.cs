using System.ComponentModel.DataAnnotations;
using WebApplication5.Enums;

namespace WebApplication5.Models
{
    public class Todo
    {


        public int Id { get; set; }
        public string? Libelle { get; set; }

        public string? Description { get; set; }

        public State State { get; set; }  //doing /done /todo

        public DateTime DateLimite { get; set; }
    }
}
