using BLL.Entities;
using D = DAL.Entities;

namespace BLL.Mappers
{
    internal static class Mapper
    {
        #region Jeux
        // Conversion de l'entité DAL.Jeu vers BLL.Jeu
        public static Jeu ToBLL(this D.Jeu jeu)
        {
            if (jeu is null) throw new ArgumentNullException(nameof(jeu));

            return new Jeu(
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
        public static D.Jeu ToDAL(this Jeu jeu)
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
    }
}
