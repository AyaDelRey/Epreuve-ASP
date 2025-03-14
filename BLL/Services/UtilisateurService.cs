using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using D = DAL.Entities;

namespace BLL.Services
{
    public class UtilisateurService : IUtilisateurRepository<Utilisateur>
    {
        private readonly IUtilisateurRepository<D.Utilisateur> _utilisateurRepository;
        private readonly IJeuxUtilisateurRepository<D.Jeux_Utilisateur> _jeuxUtilisateurRepository;
        private readonly IJeuRepository<D.Jeu> _jeuRepository;

        public UtilisateurService(
            IUtilisateurRepository<D.Utilisateur> utilisateurRepository,
            IJeuxUtilisateurRepository<D.Jeux_Utilisateur> jeuxUtilisateurRepository,
            IJeuRepository<D.Jeu> jeuRepository
        )
        {
            _utilisateurRepository = utilisateurRepository ?? throw new ArgumentNullException(nameof(utilisateurRepository));
            _jeuxUtilisateurRepository = jeuxUtilisateurRepository ?? throw new ArgumentNullException(nameof(jeuxUtilisateurRepository));
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
        }

        public IEnumerable<Utilisateur> Get()
        {
            return _utilisateurRepository.Get().Select(u => u.ToBLL());
        }

        public Utilisateur Get(Guid utilisateurId)
        {
            var utilisateurDal = _utilisateurRepository.Get(utilisateurId);
            if (utilisateurDal == null) return null;

            var utilisateur = utilisateurDal.ToBLL();

            // Récupérer les entrées de la table Jeux_Utilisateur pour l'utilisateur donné
            var jeuxUtilisateur = _jeuxUtilisateurRepository.GetFromUtilisateur(utilisateurId);

            // Récupérer les jeux associés à l'utilisateur via l'entité Jeux_Utilisateur
            var jeux = jeuxUtilisateur.Select(ju =>
            {
                var jeuDal = _jeuRepository.Get(ju.Jeu_Id); // Récupérer le jeu associé
                return jeuDal.ToBLL(); // Mapper le jeu DAL vers BLL
            }).ToList(); // Convertir le résultat en liste

            return utilisateur;
        }


        public Guid Insert(Utilisateur utilisateur)
        {
            if (utilisateur == null) throw new ArgumentNullException(nameof(utilisateur));
            return _utilisateurRepository.Insert(utilisateur.ToDAL());
        }

        public void Update(Guid utilisateurId, Utilisateur utilisateur)
        {
            if (utilisateur == null) throw new ArgumentNullException(nameof(utilisateur));
            _utilisateurRepository.Update(utilisateurId, utilisateur.ToDAL());
        }

        public void Delete(Guid utilisateurId)
        {
            _utilisateurRepository.Delete(utilisateurId);
        }

        public Utilisateur GetByEmailAndPassword(string email, string password)
        {
            // Appel à la méthode DAL pour récupérer l'utilisateur
            var utilisateurDAL = _utilisateurRepository.GetByEmailAndPassword(email, password);

            if (utilisateurDAL == null) return null; // Si aucun utilisateur n'est trouvé

            // Mapping explicite de l'entité DAL à l'entité BLL
            return utilisateurDAL.ToBLL(); // Utilisation du Mapper pour convertir l'entité
        }
    }
}