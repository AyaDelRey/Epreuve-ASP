using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Emprunt
    {
        public Guid Emprunt_Id { get; set; } 
        public Guid Jeu_Utilisateur_Id { get; set; } 
        public Guid Emprunteur_Id { get; set; } 
        public DateTime DateEmprunt { get; set; } 
        public DateTime? DateRetour { get; set; } 
        public decimal? EvaluationPreteur { get; set; } 
        public decimal? EvaluationEmprunteur { get; set; } 
    }
}
