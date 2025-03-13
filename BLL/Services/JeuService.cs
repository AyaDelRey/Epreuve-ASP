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

        // Constructeur qui injecte le repository DAL
        public JeuService(IJeuRepository<DAL.Entities.Jeu> jeuRepository)
        {
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
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
    }
}
