using BLL.Entities;
using ASP_MVC.Models.Jeu;
using ASP_MVC.Models.Utilisateur;
using ASP_MVC.Models.Tag;

namespace ASP_MVC.Mappers
{
    public static class Mapper
    {
        // Conversion de l'entité BLL.Jeu vers le modèle de vue JeuListItem
        public static JeuListItem ToListItem(this Jeu jeu)
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

        public static UtilisateurListItem ToListItem(this Utilisateur utilisateur)
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
    }
}
