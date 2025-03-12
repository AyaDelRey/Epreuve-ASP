using BLL.Entities;
using BLL.Mappers;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using D = DAL.Entities;  // Alias pour DAL.Entities

namespace BLL.Services
{
    public class JeuService : IJeuRepository<Jeu>
    {
        private readonly IJeuRepository<D.Jeu> _jeuRepository;  // Utilisation de D.Jeu pour spécifier le type DAL
        private readonly IJeuxUtilisateurRepository<D.Jeux_Utilisateur> _jeuxUtilisateurRepository;  // Utilisation de D.Jeux_Utilisateur pour spécifier le type DAL

        // Constructeur avec les repositories nécessaires
        public JeuService(
            IJeuRepository<D.Jeu> jeuRepository,  // Références avec l'alias D
            IJeuxUtilisateurRepository<D.Jeux_Utilisateur> jeuxUtilisateurRepository  // Références avec l'alias D
        )
        {
            _jeuRepository = jeuRepository ?? throw new ArgumentNullException(nameof(jeuRepository));
            _jeuxUtilisateurRepository = jeuxUtilisateurRepository ?? throw new ArgumentNullException(nameof(jeuxUtilisateurRepository));
        }

        // Méthode pour supprimer un jeu
        public void Delete(Guid jeu_id)
        {
            _jeuRepository.Delete(jeu_id);
        }

        // Récupérer tous les jeux
        public IEnumerable<Jeu> Get()
        {
            // Mappage des jeux DAL vers BLL
            return _jeuRepository.Get().Select(dal => dal.ToBLL());  // Utilisation de dal.ToBLL() pour convertir
        }

        // Récupérer un jeu par son identifiant
        public Jeu Get(Guid jeu_id)
        {
            return _jeuRepository.Get(jeu_id).ToBLL();  // Utilisation de dal.ToBLL() pour convertir
        }

        // Récupérer les jeux associés à un utilisateur spécifique
        public IEnumerable<Jeu> GetFromUser(Guid utilisateur_id)
        {
            // Récupérer les entrées de la table Jeux_Utilisateur pour l'utilisateur donné
            var jeuxUtilisateur = _jeuxUtilisateurRepository.GetFromUtilisateur(utilisateur_id);

            // Pour chaque entrée, récupérer le jeu associé et le mapper vers BLL
            var jeux = jeuxUtilisateur.Select(ju => _jeuRepository.Get(ju.Jeu_Id).ToBLL());
            return jeux;
        }

        // Insérer un nouveau jeu
        public Guid Insert(Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL avant l'insertion
            return _jeuRepository.Insert(jeu.ToDAL());  // Conversion vers DAL avec jeu.ToDAL()
        }

        // Mettre à jour un jeu existant
        public void Update(Guid jeu_id, Jeu jeu)
        {
            // Conversion de l'entité BLL en DAL avant la mise à jour
            _jeuRepository.Update(jeu_id, jeu.ToDAL());  // Conversion vers DAL avec jeu.ToDAL()
        }
    }
}
