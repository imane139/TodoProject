using System.ComponentModel.DataAnnotations;
using WebApplication5.Enums;

namespace WebApplication5.ViewModels
{
    public class TodoEditVM
    {
        public string Libelle { get; set; }

        [StringLength(1000, ErrorMessage = "la description est trop longue !")]
        public string Description { get; set; }

        [Required(ErrorMessage = "l'état est obligatoire !")]
        public State State { get; set; }  //doing /done /todo

        [Required(ErrorMessage = "la date limite est obligatoire !")]
        [DataType(DataType.Date)]

        public DateTime DateLimite { get; set; }
    }
}
