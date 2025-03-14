using BLL.Entities;
using ASP_MVC.Models.Jeu;
using ASP_MVC.Models.Utilisateur;
using ASP_MVC.Models.Tag;
using DAL.Entities;
using Tag = BLL.Entities.Tag;
using ASP_MVC.Models.Jeux;
using BLLJeu = BLL.Entities.Jeu;

namespace ASP_MVC.Mappers
{
    public static class Mapper
    {
        // Conversion de l'entité BLL.Jeu vers le modèle de vue JeuListItem
        public static JeuListItem ToListItem(this BLL.Entities.Jeu jeu)
        {
            if (jeu == null) throw new ArgumentNullException(nameof(jeu));

            return new JeuListItem
            {
                Jeu_Id = jeu.Jeu_Id,
                Nom = jeu.Nom,
                Description = jeu.Description,
                MinAge = jeu.MinAge,
                MaxAge = jeu.MaxAge,
                MinPlayers = jeu.MinPlayers,
                MaxPlayers = jeu.MaxPlayers,
                DurationMinutes = jeu.DurationMinutes
            };
        }

        public static UtilisateurListItem ToListItem(this BLL.Entities.Utilisateur utilisateur)
        {
            if (utilisateur == null) throw new ArgumentNullException(nameof(utilisateur));

            return new UtilisateurListItem
            {
                Utilisateur_Id = utilisateur.Utilisateur_Id,
                Pseudo = utilisateur.Pseudo,
                Email = utilisateur.Email
            };
        }

        // Conversion de l'entité BLL.Tag vers le modèle de vue TagListItem
        public static TagListItem ToListItem(this Tag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));

            return new TagListItem
            {
                Tag_Id = tag.Tag_Id,
                Nom = tag.Nom
            };
        }

        public static BLL.Entities.Utilisateur ToBLL(this UtilisateurCreateForm utilisateur)
        {
            if (utilisateur is null) throw new ArgumentNullException(nameof(utilisateur));
            return new BLL.Entities.Utilisateur(
                Guid.Empty,
                utilisateur.Pseudo,
                utilisateur.Email,
                utilisateur.Password,
                DateTime.Now
                );
        }

        // Nouvelle méthode pour convertir JeuCreateForm en Jeu (BLL)
        public static BLLJeu ToBLL(this JeuCreateForm jeuCreateForm)
        {
            if (jeuCreateForm == null) throw new ArgumentNullException(nameof(jeuCreateForm));

            return new BLLJeu(
                Guid.NewGuid(),            // Création d'un nouvel identifiant pour le jeu
                jeuCreateForm.Nom,         // Nom du jeu
                jeuCreateForm.Description, // Description du jeu
                jeuCreateForm.MinAge,      // Âge minimum
                jeuCreateForm.MaxAge,      // Âge maximum
                jeuCreateForm.MinPlayers,  // Nombre minimum de joueurs
                jeuCreateForm.MaxPlayers,  // Nombre maximum de joueurs
                jeuCreateForm.DurationMinutes, // Durée en minutes
                DateOnly.FromDateTime(DateTime.Now) // Date de création (actuelle)
            );
        }
    }
}
