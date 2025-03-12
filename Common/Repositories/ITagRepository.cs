using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ITagRepository<TTag> : ICRUDRepository<TTag, Guid>
    {
        IEnumerable<TTag> GetFromUser(Guid utilisateur_id);
    }
}