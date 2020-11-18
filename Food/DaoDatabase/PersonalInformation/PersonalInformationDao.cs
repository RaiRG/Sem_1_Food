using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DaoDatabase
{
    public class PersonalInformationDao : IDao<PersonalInformation>
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";
        public List<PersonalInformation> AllEntities { get; set; }

        public Dictionary<int, PersonalInformation> DictionaryOfEntities { get; set; }

        public List<PersonalInformation> GetAll()
        {
            return AllEntities;
        }

        public PersonalInformation GetOne(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(int id, PersonalInformation newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Mail + "'" + ", ");
            valueis.Append("'" + newEntity.StringValue + "'" + ", ");
            valueis.Append("'" + newEntity.HashCode + "'");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO personalEnformations (id, mail, stringValue, hashCode) VALUES ( " +
                    valueis.ToString() + ")");
                command.ExecuteNonQuery();
            }
        }

        public void Delete(PersonalInformation entity)
        {
            AllEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            DictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM personalEnformations WHERE id = " + entity.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            AllEntities = AllEntities
                .Where(x => (x.Id != id)).ToList();
            DictionaryOfEntities.Remove(id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM personalEnformations WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }
    }
}