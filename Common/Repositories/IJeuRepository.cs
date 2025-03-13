using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IJeuRepository<TJeu> : ICRUDRepository<TJeu, Guid>
    {
        IEnumerable<TJeu> GetFromUser(Guid utilisateur_id);
        
    }
}