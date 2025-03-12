using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Utilisateur
    {
        public Guid Utilisateur_Id { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } // Correspond à [Password]
        public string Pseudo { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? DisabledAt { get; set; } 
        
    }


}

