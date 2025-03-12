using System;


namespace BLL.Entities
{
    public class JeuxUtilisateur
    {
        public Guid Jeux_Utilisateur_Id { get; set; }
        public Guid Utilisateur_Id { get; set; }
        public Guid Jeu_Id { get; set; }
        public DateTime? DateAcquisition { get; set; }
        public string Etat { get; set; }

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
