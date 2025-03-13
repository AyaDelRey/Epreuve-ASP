using Common.Repositories;
using BLL.Entities; // BLL Tag
using DAL.Entities; // DAL Tag
using D = DAL.Entities;  // Alias pour DAL.Entities
using B = BLL.Entities;  // Alias pour BLL.Entities
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;

namespace BLL.Services
{
    public class TagService : ITagRepository<B.Tag>  // Utilisation de B.Tag pour faire référence au BLL Tag
    {
        private readonly ITagRepository<D.Tag> _tagRepository;  // Utilisation de D.Tag pour faire référence au DAL Tag

        // Constructeur qui injecte le repository DAL
        public TagService(ITagRepository<D.Tag> tagRepository)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        // Implémentation de la méthode GetAll() pour récupérer tous les tags
        public IEnumerable<B.Tag> GetAll()  // Retourne un IEnumerable<B.Tag>
        {
            return _tagRepository.GetAll().Select(dal => dal.ToBLL());  // Conversion de DAL en BLL
        }

        // Implémentation de la méthode Get() pour récupérer un tag par son identifiant
        public B.Tag Get(Guid tag_id)  // Retourne un B.Tag
        {
            var dalTag = _tagRepository.Get(tag_id);
            return dalTag != null ? dalTag.ToBLL() : null;  // Conversion de DAL en BLL
        }

        // Implémentation de GetFromUser() - à personnaliser selon la logique spécifique
        public IEnumerable<B.Tag> GetFromUser(Guid utilisateur_id)  // Retourne un IEnumerable<B.Tag>
        {
            // Logique à ajouter pour récupérer les tags d'un utilisateur spécifique
            throw new NotImplementedException();
        }

        // Méthode Insert pour insérer un nouveau tag
        public Guid Insert(B.Tag tag)  // Prend un B.Tag en paramètre
        {
            var dalTag = tag.ToDAL();  // Conversion de BLL en DAL
            return _tagRepository.Insert(dalTag);  // Insérer dans le repository DAL
        }

        // Méthode Update pour mettre à jour un tag existant
        public void Update(Guid tag_id, B.Tag tag)  // Prend un B.Tag et un GUID
        {
            var dalTag = tag.ToDAL();  // Conversion de BLL en DAL
            _tagRepository.Update(tag_id, dalTag);  // Mettre à jour via DAL
        }

        // Méthode Delete pour supprimer un tag par son identifiant
        public void Delete(Guid tag_id)  // Supprime le tag par son GUID
        {
            _tagRepository.Delete(tag_id);  // Supprimer via DAL
        }

        // Implémentation de ICRUDRepository<Tag, Guid>
        IEnumerable<B.Tag> ICRUDRepository<B.Tag, Guid>.Get()
        {
            return GetAll();
        }
    }
}
