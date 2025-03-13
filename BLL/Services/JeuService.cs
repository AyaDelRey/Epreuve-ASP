using Common.Repositories;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;

namespace BLL.Services
{
    public class JeuService : IJeuRepository<Jeu>
    {
        private readonly IJeuRepository<DAL.Entities.Jeu> _jeuRepository;
        private readonly ITagRepository<DAL.Entities.Tag> _tagRepository; // Ajouter le repository pour les tags

        // Constructeur qui injecte le repository DAL pour Jeu et Tag
        public JeuService(IJeuRepository<DAL.Entities.Jeu> jeuRepository, ITagRepository<DAL.Entities.Tag> tagRepository)
        {
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        // Implémentation des méthodes CRUD de l'interface IJeuRepository<Jeu>
        public IEnumerable<Jeu> Get()
        {
            // Appel du repository DAL et conversion des entités DAL en entités BLL
            return _jeuRepository.Get().Select(dal => dal.ToBLL());
        }

        public Jeu Get(Guid jeu_id)
        {
            // Appel du repository DAL et conversion de l'entité DAL en entité BLL
            return _jeuRepository.Get(jeu_id).ToBLL();
        }

        public IEnumerable<Jeu> GetFromUser(Guid utilisateur_id)
        {
            // Récupère les jeux associés à un utilisateur et les convertit en entités BLL
            return _jeuRepository.GetFromUser(utilisateur_id).Select(dal => dal.ToBLL());
        }

        public Guid Insert(Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL et insertion via le repository DAL
            return _jeuRepository.Insert(jeu.ToDAL());
        }

        public void Update(Guid jeu_id, Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL et mise à jour via le repository DAL
            _jeuRepository.Update(jeu_id, jeu.ToDAL());
        }

        public void Delete(Guid jeu_id)
        {
            // Suppression via le repository DAL
            _jeuRepository.Delete(jeu_id);
        }

        // Nouvelle méthode de recherche par nom ou par tag
        public IEnumerable<Jeu> Search(string searchQuery)
        {
            // Si la recherche est vide, on retourne tous les jeux
            if (string.IsNullOrEmpty(searchQuery))
            {
                return _jeuRepository.Get().Select(dal => dal.ToBLL());
            }

            // Recherche par nom de jeu uniquement
            return _jeuRepository.Get()
                .Where(j => j.Nom.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .Select(dal => dal.ToBLL());
        }
    }
}

