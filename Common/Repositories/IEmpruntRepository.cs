using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IEmpruntRepository<TEmprunt> : ICRUDRepository<TEmprunt, Guid>
    {
        IEnumerable<TEmprunt> GetFromUser(Guid utilisateur_id);
    }
}