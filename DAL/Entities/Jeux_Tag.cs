using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class JeuxTag
    {
        public Guid Jeu_Tag_Id { get; set; } 
        public Guid Jeu_Id { get; set; } 
        public Guid Tag_Id { get; set; } 
    }
}
