using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.ViewModels
{
    public class AuthVM
    {
        [Required(ErrorMessage="le nom est obligatoir ")]
        public String Nom { get; set; }
        [Required (ErrorMessage="le mot de passe obligatoir ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
