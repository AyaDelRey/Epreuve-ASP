using System;

namespace BLL.Entities
{
    public class JeuxUtilisateur
    {
        public Guid Jeux_Utilisateur_Id { get; }
        public Guid Utilisateur_Id { get; }
        public Guid Jeu_Id { get; }
        public DateTime? DateAcquisition { get; }
        public string Etat { get; }

        public JeuxUtilisateur(Guid jeuxUtilisateurId, Guid utilisateurId, Guid jeuId, DateTime? dateAcquisition, string etat)
        {
            Jeux_Utilisateur_Id = jeuxUtilisateurId;
            Utilisateur_Id = utilisateurId;
            Jeu_Id = jeuId;
            DateAcquisition = dateAcquisition;
            Etat = etat ?? throw new ArgumentNullException(nameof(etat));
        }
    }
}
