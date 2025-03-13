using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Jeu
    {
        public Guid Jeu_Id { get; set; } 
        public string Nom { get; set; } 
        public string Description { get; set; } 
        public int MinAge { get; set; } 
        public int MaxAge { get; set; } 
        public int MinPlayers { get; set; } 
        public int MaxPlayers { get; set; } 
        public decimal? DurationMinutes { get; set; } // Correspond à [DureeMinute], nullable car non obligatoire
        public DateTime CreationDate { get; set; }

        // Relation avec les tags à travers la table de liaison
        public ICollection<JeuxTag> JeuxTags { get; set; }

        // Les tags associés à ce jeu
        public ICollection<Tag> Tags { get; set; }
    }
}

