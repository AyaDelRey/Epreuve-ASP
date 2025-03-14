using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Auth
{
    public class AuthLoginForm
    {
        [DisplayName("E-mail : ")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Mot de passe : ")]
        [Required(ErrorMessage = "Le champ 'Mot de passe' est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}