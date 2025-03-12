using Common.Repositories;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class JeuxUtilisateurService : IJeuxUtilisateurRepository<BLL.Entities.JeuxUtilisateur>
    {
        private readonly IJeuxUtilisateurRepository<DAL.Entities.Jeux_Utilisateur> _jeuxUtilisateurRepository;

        public JeuxUtilisateurService(IJeuxUtilisateurRepository<DAL.Entities.Jeux_Utilisateur> jeuxUtilisateurRepository)
        {
            _jeuxUtilisateurRepository = jeuxUtilisateurRepository;
        }

        // Méthode pour récupérer les jeux associés à un utilisateur
        public IEnumerable<BLL.Entities.JeuxUtilisateur> GetFromUtilisateur(Guid utilisateurId)
        {
            // Appeler la méthode GetFromUtilisateur de la DAL
            var jeuxDal = _jeuxUtilisateurRepository.GetFromUtilisateur(utilisateurId);

            // Mapper les objets DAL en objets BLL
            return jeuxDal.Select(jeu => new BLL.Entities.JeuxUtilisateur(
                jeu.Jeux_Utilisateur_Id,  // Passer l'ID de la relation jeux-utilisateur
                jeu.Utilisateur_Id,        // ID de l'utilisateur
                jeu.Jeu_Id,                // ID du jeu
                jeu.DateAcquisition,       // Date d'acquisition du jeu
                jeu.Etat                   // État du jeu
            )).ToList();
        }
    }
}
