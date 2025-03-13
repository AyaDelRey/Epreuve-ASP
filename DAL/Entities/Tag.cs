using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tag
    {
        public Guid Tag_Id { get; set; } 
        public string Nom { get; set; }

        // Relation inverse avec les jeux à travers la table de liaison
        public ICollection<JeuxTag> JeuxTags { get; set; }
    }
}
