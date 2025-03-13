using DAL.Entities;

namespace BLL.Entities
{
    public class Tag
    {
        public Guid Tag_Id { get; set; }
        public string Nom { get; set; }

        // Relation avec les jeux via la table de liaison
        public ICollection<JeuxTag> JeuxTags { get; set; }
    }
}

