using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.Services
{
    public class JeuxUtilisateurService : BaseService, IJeuxUtilisateurRepository<Jeux_Utilisateur>
    {
        public JeuxUtilisateurService(IConfiguration config) : base(config, "Main-DB") { }

        // Méthode pour récupérer les jeux associés à un utilisateur
        public IEnumerable<Jeux_Utilisateur> GetFromUtilisateur(Guid utilisateurId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // Appel de la procédure stockée pour récupérer les jeux associés à un utilisateur
                    command.CommandText = "SP_Get_Jeux_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Utilisateur_Id", utilisateurId);
                    connection.Open();

                    // Exécution de la commande SQL et traitement du résultat
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcours des résultats et mapping des données en objets Jeux_Utilisateur
                        while (reader.Read())
                        {
                            // Mapping des résultats en objets de type Jeux_Utilisateur
                            yield return new Jeux_Utilisateur
                            {
                                Jeux_Utilisateur_Id = reader.GetGuid(reader.GetOrdinal("Jeux_Utilisateur_Id")),
                                Utilisateur_Id = utilisateurId,
                                Jeu_Id = reader.GetGuid(reader.GetOrdinal("Jeu_Id")),
                                Etat = reader.GetString(reader.GetOrdinal("Etat")),
                                DateAcquisition = reader.IsDBNull(reader.GetOrdinal("DateAcquisition"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime(reader.GetOrdinal("DateAcquisition"))
                            };
                        }
                    }
                }
            }
        }
    }
}
