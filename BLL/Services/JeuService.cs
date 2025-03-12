using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JeuService : IJeuRepository<Jeu>
    {
        private IJeuRepository<DAL.Entities.Jeu> _jeuService;
        private IUtilisateurRepository<DAL.Entities.Utilisateur> _userService;

        public JeuService(
            IJeuRepository<DAL.Entities.Jeu> jeuService,
            IUtilisateurRepository<DAL.Entities.Utilisateur> userService
            )
        {
            _jeuService = jeuService;
            _userService = userService;
        }

        // Méthode pour supprimer un jeu
        public void Delete(Guid jeu_id)
        {
            _jeuService.Delete(jeu_id);
        }

        // Récupérer tous les jeux
        public IEnumerable<Jeu> Get()
        {
            // Mappage des jeux DAL vers BLL
            return _jeuService.Get().Select(dal => dal.ToBLL());
        }

        // Récupérer un jeu par son identifiant
        public Jeu Get(Guid jeu_id)
        {
            return _jeuService.Get(jeu_id).ToBLL();
        }

        // Récupérer les jeux d'un utilisateur spécifique
        public IEnumerable<Jeu> GetFromUser(Guid utilisateur_id)
        {
            // Vérifie que la méthode GetFromUser existe dans ton repository DAL.
            // Elle doit retourner les jeux associés à cet utilisateur.
            var dalJeux = _jeuService.GetFromUser(utilisateur_id);

            // Mappage des jeux DAL vers BLL
            return dalJeux.Select(dal => dal.ToBLL());
        }

        // Insérer un nouveau jeu
        public Guid Insert(Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL avant l'insertion
            return _jeuService.Insert(jeu.ToDAL());
        }

        // Mettre à jour un jeu existant
        public void Update(Guid jeu_id, Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL avant la mise à jour
            _jeuService.Update(jeu_id, jeu.ToDAL());
        }
    }
}
