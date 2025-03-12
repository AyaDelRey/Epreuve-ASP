using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Jeu
{
    public class JeuListItem
    {
        [ScaffoldColumn(false)] // Ne pas inclure cette propriété dans le formulaire de vue
        public Guid Jeu_Id { get; set; }

        [DisplayName("Nom du jeu : ")] // Label personnalisé pour l'affichage du nom
        public string Nom { get; set; }

        [DisplayName("Description : ")] // Label personnalisé pour la description
        public string? Description { get; set; }

        [DisplayName("Âge minimum : ")] // Label pour l'âge minimum
        public int MinAge { get; set; }

        [DisplayName("Âge maximum : ")] // Label pour l'âge maximum
        public int MaxAge { get; set; }

        [DisplayName("Nombre de joueurs minimum : ")] // Label pour le nombre de joueurs minimum
        public int MinPlayers { get; set; }

        [DisplayName("Nombre de joueurs maximum : ")] // Label pour le nombre de joueurs maximum
        public int MaxPlayers { get; set; }

        [DisplayName("Durée d'une partie : ")] // Label pour la durée de la partie
        public decimal? DurationMinutes { get; set; }
    }
}
