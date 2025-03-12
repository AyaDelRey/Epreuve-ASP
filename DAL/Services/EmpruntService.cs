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
    public class EmpruntService : BaseService, IEmpruntRepository<Emprunt>
    {
        public EmpruntService(IConfiguration config) : base(config, "Main-DB") { }


        public IEnumerable<Emprunt> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_All_Emprunt";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToEmprunt();
                        }
                    }
                }
            }
        }

        public Emprunt Get(Guid emprunt_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_GetById_Emprunt";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(emprunt_id), emprunt_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToEmprunt();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(emprunt_id));
                        }
                    }
                }
            }
        }

        public Guid Insert(Emprunt emprunt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Create_Emprunt";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Emprunt.Jeu_Utilisateur_Id), emprunt.Jeu_Utilisateur_Id);
                    command.Parameters.AddWithValue(nameof(Emprunt.Emprunteur_Id), emprunt.Emprunteur_Id);
                    command.Parameters.AddWithValue(nameof(Emprunt.DateEmprunt), emprunt.DateEmprunt);
                    command.Parameters.AddWithValue(nameof(Emprunt.DateRetour), (object?)emprunt.DateRetour ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Emprunt.EvaluationPreteur), (object?)emprunt.EvaluationPreteur ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Emprunt.EvaluationEmprunteur), (object?)emprunt.EvaluationEmprunteur ?? DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid emprunt_id, Emprunt emprunt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cloturer_Emprunt";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(emprunt_id), emprunt_id);
                    command.Parameters.AddWithValue(nameof(Emprunt.Jeu_Utilisateur_Id), emprunt.Jeu_Utilisateur_Id);
                    command.Parameters.AddWithValue(nameof(Emprunt.Emprunteur_Id), emprunt.Emprunteur_Id);
                    command.Parameters.AddWithValue(nameof(Emprunt.DateEmprunt), emprunt.DateEmprunt);
                    command.Parameters.AddWithValue(nameof(Emprunt.DateRetour), (object?)emprunt.DateRetour ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Emprunt.EvaluationPreteur), (object?)emprunt.EvaluationPreteur ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Emprunt.EvaluationEmprunteur), (object?)emprunt.EvaluationEmprunteur ?? DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
