using System;
using System.Collections.Generic;

namespace Common.Repositories
{
    public interface IJeuxUtilisateurRepository<TEntity>
    {
        IEnumerable<TEntity> GetFromUtilisateur(Guid utilisateurId);
    }
}
