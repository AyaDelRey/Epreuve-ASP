using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Models.Jeux
{
    public class JeuCreateForm
    {
        [Required]
        [StringLength(255, ErrorMessage = "Le nom du jeu ne doit pas dépasser 255 caractères.")]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "L'âge minimum doit être supérieur ou égal à 0.")]
        public int MinAge { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "L'âge maximum doit être supérieur ou égal à l'âge minimum.")]
        public int MaxAge { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Le nombre minimum de joueurs doit être supérieur à 0.")]
        public int MinPlayers { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Le nombre maximum de joueurs doit être supérieur ou égal au nombre minimum de joueurs.")]
        public int MaxPlayers { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "La durée doit être supérieure à 0.")]
        public decimal DurationMinutes { get; set; }


    }

}
