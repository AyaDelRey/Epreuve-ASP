using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IUtilisateurRepository<TUtilisateur> : ICRUDRepository<TUtilisateur, Guid>
    {
        Guid CheckPassword(string email, string password);
    }
}
