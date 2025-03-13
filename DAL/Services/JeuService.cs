using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class JeuService : BaseService, IJeuRepository<Jeu>
    {
        public JeuService(IConfiguration config) : base(config, "Main-DB") { }

        public IEnumerable<Jeu> GetFromUser(Guid utilisateur_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_Jeu_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(utilisateur_id), utilisateur_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToJeu();
                        }
                    }
                }
            }
        }
        public void Delete(Guid jeu_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Delete_Jeu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(jeu_id), jeu_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Jeu> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_All_Jeu";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToJeu();
                        }
                    }
                }
            }
        }

        public Jeu Get(Guid jeu_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_Jeu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(jeu_id), jeu_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToJeu();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(jeu_id));
                        }
                    }
                }
            }
        }

        public Guid Insert(Jeu jeu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Create_Jeu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Jeu.Nom), jeu.Nom);
                    command.Parameters.AddWithValue(nameof(Jeu.Description), jeu.Description);
                    command.Parameters.AddWithValue(nameof(Jeu.MinAge), jeu.MinAge);
                    command.Parameters.AddWithValue(nameof(Jeu.MaxAge), jeu.MaxAge);
                    command.Parameters.AddWithValue(nameof(Jeu.MinPlayers), jeu.MinPlayers);
                    command.Parameters.AddWithValue(nameof(Jeu.MaxPlayers), jeu.MaxPlayers);
                    command.Parameters.AddWithValue(nameof(Jeu.DurationMinutes), (object?)jeu.DurationMinutes ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Jeu.CreationDate), jeu.CreationDate);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid jeu_id, Jeu jeu)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Update_Jeu";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(jeu_id), jeu_id);
                    command.Parameters.AddWithValue(nameof(Jeu.Nom), jeu.Nom);
                    command.Parameters.AddWithValue(nameof(Jeu.Description), jeu.Description);
                    command.Parameters.AddWithValue(nameof(Jeu.MinAge), jeu.MinAge);
                    command.Parameters.AddWithValue(nameof(Jeu.MaxAge), jeu.MaxAge);
                    command.Parameters.AddWithValue(nameof(Jeu.MinPlayers), jeu.MinPlayers);
                    command.Parameters.AddWithValue(nameof(Jeu.MaxPlayers), jeu.MaxPlayers);
                    command.Parameters.AddWithValue(nameof(Jeu.DurationMinutes), (object?)jeu.DurationMinutes ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Jeu.CreationDate), jeu.CreationDate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Méthode pour rechercher un jeu par nom ou par tag
        public IEnumerable<Jeu> Search(string searchQuery)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // On va créer une requête qui recherche par le nom et les tags.
                    command.CommandText = @"
                        SELECT j.*
                        FROM Jeu j
                        LEFT JOIN JeuxTag jt ON j.Jeu_Id = jt.Jeu_Id
                        LEFT JOIN Tag t ON jt.Tag_Id = t.Tag_Id
                        WHERE j.Nom LIKE @searchQuery OR t.Nom LIKE @searchQuery";
                    command.CommandType = CommandType.Text;

                    // Ajout du paramètre de recherche pour éviter les injections SQL
                    command.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToJeu(); // Conversion de la ligne en objet Jeu
                        }
                    }
                }
            }
        }
    }
}
