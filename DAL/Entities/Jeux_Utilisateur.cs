using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Jeux_Utilisateur
    {
        public Guid Jeux_Utilisateur_Id { get; set; } 
        public Guid Utilisateur_Id { get; set; } 
        public Guid Jeu_Id { get; set; } 
        public DateTime? DateAcquisition { get; set; } 
        public required string Etat { get; set; } 
    }
}
