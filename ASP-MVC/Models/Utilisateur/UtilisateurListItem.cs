
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Utilisateur
{
    public class UtilisateurListItem
    {
        [ScaffoldColumn(false)]
        public Guid Utilisateur_Id { get; set; }

        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
