using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UtilisateurService : BaseService, IUtilisateurRepository<Utilisateur>
    {
        public UtilisateurService(IConfiguration config) : base(config, "Main-DB") { }

        public void Delete(Guid utilisateur_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Delete_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(utilisateur_id), utilisateur_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Utilisateur> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_All_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToUtilisateur();
                        }
                    }
                }
            }
        }

        public Utilisateur Get(Guid utilisateur_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(utilisateur_id), utilisateur_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUtilisateur();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(utilisateur_id));
                        }
                    }
                }
            }
        }

        public Guid Insert(Utilisateur utilisateur)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Create_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Utilisateur.Email), utilisateur.Email);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Password), utilisateur.Password);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), utilisateur.Pseudo);
                    command.Parameters.AddWithValue(nameof(Utilisateur.CreatedAt), utilisateur.CreatedAt);
                    command.Parameters.AddWithValue(nameof(Utilisateur.DisabledAt), (object?)utilisateur.DisabledAt ?? DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid utilisateur_id, Utilisateur utilisateur)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Update_Utilisateur";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(utilisateur_id), utilisateur_id);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Email), utilisateur.Email);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Password), utilisateur.Password);
                    command.Parameters.AddWithValue(nameof(Utilisateur.Pseudo), utilisateur.Pseudo);
                    command.Parameters.AddWithValue(nameof(Utilisateur.CreatedAt), utilisateur.CreatedAt);
                    command.Parameters.AddWithValue(nameof(Utilisateur.DisabledAt), (object?)utilisateur.DisabledAt ?? DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Utilisateur GetByEmailAndPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_Utilisateur_By_Email_And_Password";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    // Hacher le mot de passe en byte[] et l'envoyer correctement
                    byte[] hashedPassword = ComputeSha512Hash(password);
                    command.Parameters.Add("@Password", SqlDbType.VarBinary, 64).Value = hashedPassword;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToUtilisateur();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // Méthode pour hacher le mot de passe en C#
        public static byte[] ComputeSha512Hash(string password)
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(password);
                return shaM.ComputeHash(textData); // Retourne directement un byte[]
            }
        }
    }
}