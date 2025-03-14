using System;

namespace BLL.Entities
{
    public class Utilisateur
    {
        public Guid Utilisateur_Id { get; private set; } // Identifiant unique de l'utilisateur
        public string Email { get; private set; }       // Adresse e-mail de l'utilisateur
        public string Password { get; private set; }    // Mot de passe sécurisé (haché)
        public string Pseudo { get; private set; }      // Pseudonyme de l'utilisateur
        public DateTime CreatedAt { get; private set; } // Date de création du compte
        public DateTime? DisabledAt { get; private set; } // Date de désactivation du compte (null si actif)
        public List<Jeu> Jeux { get; internal set; }

        // Constructeur principal
        public Utilisateur(Guid utilisateur_Id, string email, string password, string pseudo, DateTime createdAt, DateTime? disabledAt = null)
        {
            Utilisateur_Id = utilisateur_Id;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Pseudo = pseudo ?? throw new ArgumentNullException(nameof(pseudo));
            CreatedAt = createdAt;
            DisabledAt = disabledAt;
        }

       
    }
}
