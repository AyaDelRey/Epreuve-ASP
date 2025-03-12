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
    public class TagService : BaseService, ITagRepository<Tag>
    {
        public TagService(IConfiguration config) : base(config, "Main-DB") { }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Get_All_Tag";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToTag();
                        }
                    }
                }
            }
        }

        public Tag Get(Guid tag_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_GetById_Tag";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(tag_id), tag_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToTag();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(tag_id));
                        }
                    }
                }
            }
        }

        public IEnumerable<Tag> GetFromUser(Guid utilisateur_id)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(Tag tag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Create_Tag";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Tag.Nom), tag.Nom);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid id, Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
