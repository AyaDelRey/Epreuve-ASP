using BLL.Entities;
using DAL.Entities;
using D = DAL.Entities;  // Alias pour DAL.Entities
using B = BLL.Entities;  // Alias pour BLL.Entities

namespace BLL.Mappers
{
    internal static class Mapper
    {
        #region Jeux
        // Conversion de l'entité DAL.Jeu vers BLL.Jeu
        public static B.Jeu ToBLL(this D.Jeu jeu)
        {
            if (jeu is null) throw new ArgumentNullException(nameof(jeu));

            return new B.Jeu(
                jeu.Jeu_Id,                // Identifiant du jeu
                jeu.Nom,                   // Nom du jeu
                jeu.Description,           // Description du jeu
                jeu.MinAge,                // Âge minimum recommandé
                jeu.MaxAge,                // Âge maximum recommandé
                jeu.MinPlayers,            // Nombre minimum de joueurs
                jeu.MaxPlayers,            // Nombre maximum de joueurs
                jeu.DurationMinutes,       // Durée d'une partie (en minutes)
                DateOnly.FromDateTime(jeu.CreationDate)  // Conversion de DateTime en DateOnly
            );
        }

        // Conversion de l'entité BLL.Jeu vers DAL.Jeu
        public static D.Jeu ToDAL(this B.Jeu jeu)
        {
            if (jeu is null) throw new ArgumentNullException(nameof(jeu));

            return new D.Jeu()
            {
                Jeu_Id = jeu.Jeu_Id,                  // Identifiant du jeu
                Nom = jeu.Nom,                        // Nom du jeu
                Description = jeu.Description,        // Description du jeu
                MinAge = jeu.MinAge,                  // Âge minimum recommandé
                MaxAge = jeu.MaxAge,                  // Âge maximum recommandé
                MinPlayers = jeu.MinPlayers,          // Nombre minimum de joueurs
                MaxPlayers = jeu.MaxPlayers,          // Nombre maximum de joueurs
                DurationMinutes = jeu.DurationMinutes, // Durée d'une partie (en minutes)
                CreationDate = jeu.CreationDate.ToDateTime(new TimeOnly()) // Conversion de DateOnly en DateTime
            };
        }
        #endregion

        #region Utilisateurs
        // Conversion de l'entité DAL.Utilisateur vers BLL.Utilisateur
        public static B.Utilisateur ToBLL(this D.Utilisateur utilisateur)
        {
            if (utilisateur is null) throw new ArgumentNullException(nameof(utilisateur));

            return new B.Utilisateur(
                utilisateur.Utilisateur_Id,         // Identifiant unique
                utilisateur.Email,                  // Adresse email
                utilisateur.Password,               // Mot de passe (doit être haché et sécurisé)
                utilisateur.Pseudo,                 // Pseudonyme
                utilisateur.CreatedAt,              // Date de création
                utilisateur.DisabledAt              // Date de désactivation (nullable)
            );
        }

        // Conversion de l'entité BLL.Utilisateur vers DAL.Utilisateur
        public static D.Utilisateur ToDAL(this B.Utilisateur utilisateur)
        {
            if (utilisateur is null) throw new ArgumentNullException(nameof(utilisateur));

            return new D.Utilisateur()
            {
                Utilisateur_Id = utilisateur.Utilisateur_Id, // Identifiant unique
                Email = utilisateur.Email,                   // Adresse email
                Password = utilisateur.Password,             // Mot de passe (doit être sécurisé)
                Pseudo = utilisateur.Pseudo,                 // Pseudonyme
                CreatedAt = utilisateur.CreatedAt,           // Date de création
                DisabledAt = utilisateur.DisabledAt          // Date de désactivation (nullable)
            };
        }
        #endregion

        // Mapping Jeux_Utilisateur DAL -> BLL
        public static JeuxUtilisateur ToBLL(this D.Jeux_Utilisateur entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return new JeuxUtilisateur(
                entity.Jeux_Utilisateur_Id,
                entity.Utilisateur_Id,
                entity.Jeu_Id,
                entity.DateAcquisition,
                entity.Etat
            );
        }

        // Mapping Jeux_Utilisateur BLL -> DAL
        public static D.Jeux_Utilisateur ToDAL(this JeuxUtilisateur entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return new D.Jeux_Utilisateur
            {
                Jeux_Utilisateur_Id = entity.Jeux_Utilisateur_Id,
                Utilisateur_Id = entity.Utilisateur_Id,
                Jeu_Id = entity.Jeu_Id,
                DateAcquisition = entity.DateAcquisition,
                Etat = entity.Etat
            };
        }

        #region Tags
        // Conversion de l'entité DAL.Tag vers BLL.Tag
        public static B.Tag ToBLL(this D.Tag dalTag)
        {
            if (dalTag is null) throw new ArgumentNullException(nameof(dalTag));

            return new B.Tag
            {
                Tag_Id = dalTag.Tag_Id,          // Identifiant du tag
                Nom = dalTag.Nom,                // Nom du tag
                JeuxTags = dalTag.JeuxTags       // Assurez-vous de gérer correctement la relation avec les jeux
            };
        }

        // Conversion de l'entité BLL.Tag vers DAL.Tag
        public static D.Tag ToDAL(this B.Tag bllTag)
        {
            if (bllTag is null) throw new ArgumentNullException(nameof(bllTag));

            return new D.Tag
            {
                Tag_Id = bllTag.Tag_Id,          // Identifiant du tag
                Nom = bllTag.Nom,                // Nom du tag
                JeuxTags = bllTag.JeuxTags       // Assurez-vous de gérer correctement la relation avec les jeux
            };
        }
        #endregion
    }
}
