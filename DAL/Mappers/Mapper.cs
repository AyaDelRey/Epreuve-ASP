using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    internal static class Mapper
    {
        // Mapper pour l'entité Jeu
        public static Jeu ToJeu(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Jeu()
            {
                Jeu_Id = (Guid)record[nameof(Jeu.Jeu_Id)],
                Nom = (string)record[nameof(Jeu.Nom)],
                Description = (string)record[nameof(Jeu.Description)],
                MinAge = (int)record[nameof(Jeu.MinAge)],
                MaxAge = (int)record[nameof(Jeu.MaxAge)],
                MinPlayers = (int)record[nameof(Jeu.MinPlayers)],
                MaxPlayers = (int)record[nameof(Jeu.MaxPlayers)],
                DurationMinutes = (record[nameof(Jeu.DurationMinutes)] is DBNull) ? null : (decimal?)record[nameof(Jeu.DurationMinutes)],
                CreationDate = (DateTime)record[nameof(Jeu.CreationDate)]
            };
        }
        // Mapper pour l'entité Utilisateur
        public static Utilisateur ToUtilisateur(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Utilisateur()
            {
                Utilisateur_Id = (Guid)record[nameof(Utilisateur.Utilisateur_Id)],
                Email = (string)record[nameof(Utilisateur.Email)],
                Password = "********",
                Pseudo = (string)record[nameof(Utilisateur.Pseudo)],
                CreatedAt = (DateTime)record[nameof(Utilisateur.CreatedAt)],
                DisabledAt = (record[nameof(Utilisateur.DisabledAt)] is DBNull) ? null : (DateTime?)record[nameof(Utilisateur.DisabledAt)]
            };
        }
        // Mapper pour l'entité Tag
        public static Tag ToTag(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Tag()
            {
                Tag_Id = (Guid)record[nameof(Tag.Tag_Id)],
                Nom = (string)record[nameof(Tag.Nom)]
            };
        }
        // Mapper pour l'entité Emprunt
        public static Emprunt ToEmprunt(this IDataRecord record)
        {
            if(record is null) throw new ArgumentNullException(nameof (record));
            return new Emprunt()
            {
                Emprunt_Id = (Guid)record[nameof(Emprunt.Emprunt_Id)],
                Jeu_Utilisateur_Id = (Guid)record[nameof(Emprunt.Jeu_Utilisateur_Id)],
                Emprunteur_Id = (Guid)record[nameof(Emprunt.Emprunteur_Id)],
                DateEmprunt = (DateTime)record[nameof(Emprunt.DateEmprunt)],
                DateRetour = (record[nameof(Emprunt.DateRetour)] is DBNull) ? null : (DateTime?)record[nameof(Emprunt.DateRetour)],
                EvaluationPreteur = (record[nameof(Emprunt.EvaluationPreteur)] is DBNull) ? null : (decimal?)record[nameof(Emprunt.EvaluationPreteur)],
                EvaluationEmprunteur = (record[nameof(Emprunt.EvaluationEmprunteur)] is DBNull) ? null : (decimal?)record[nameof(Emprunt.EvaluationEmprunteur)]
            };
        }
        // Mapper pour l'entité Jeux_Utilisateur
        public static Jeux_Utilisateur ToJeuxUtilisateur(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Jeux_Utilisateur()
            {
                Jeux_Utilisateur_Id = (Guid)record[nameof(Jeux_Utilisateur.Jeux_Utilisateur_Id)],
                Utilisateur_Id = (Guid)record[nameof(Jeux_Utilisateur.Utilisateur_Id)],
                Jeu_Id = (Guid)record[nameof(Jeux_Utilisateur.Jeu_Id)],
                DateAcquisition = (record[nameof(Jeux_Utilisateur.DateAcquisition)] is DBNull) ? null : (DateTime?)record[nameof(Jeux_Utilisateur.DateAcquisition)],
                Etat = (string)record[nameof(Jeux_Utilisateur.Etat)] // Etat est obligatoire (non nullable)
            };
        }
        // Mapper pour l'entité JeuxTag
        public static JeuxTag ToJeuxTag(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new JeuxTag()
            {
                Jeu_Tag_Id = (Guid)record[nameof(JeuxTag.Jeu_Tag_Id)],
                Jeu_Id = (Guid)record[nameof(JeuxTag.Jeu_Id)],
                Tag_Id = (Guid)record[nameof(JeuxTag.Tag_Id)]
            };
        }
    }
}