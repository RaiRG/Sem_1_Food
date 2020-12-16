using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test
{
    public class PersonalInfoDao : IDao<PersonalInfo, int>
    {
        //TODO: изменить строку подключения 
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        // private string connectionString =
        //     @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";
        private static Dictionary<int, PersonalInfo> dictionaryOfEntities = new Dictionary<int, PersonalInfo>();
        private static List<PersonalInfo> allEntities = new List<PersonalInfo>();
        private static bool isFirstLaunch = true;

          public PersonalInfoDao()
        {
            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM personalinfo;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            PersonalInfo current = new PersonalInfo();
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                switch (allreader.GetName(i).ToString())
                                {
                                    case "mail":
                                        current.Mail = (string) tableName;
                                        break;
                                    case "hashpassword":
                                        current.HashPassword = (string) tableName;
                                        break;
                                    case "id":
                                        current.Id = (int) tableName;
                                        break;
                                }
                            }
                            allEntities.Add(current);
                            dictionaryOfEntities.Add(current.Id, current);
                        }
                    }
                }
            }
        }
        public List<PersonalInfo> AllEntities => allEntities;

        public Dictionary<int, PersonalInfo> DictionaryOfEntities => dictionaryOfEntities;

        public List<PersonalInfo> GetAll()
        {
            return AllEntities;
        }

        public PersonalInfo GetOneById(int id)
        {
            return dictionaryOfEntities[id];
        }
        

        public void Insert(PersonalInfo newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Mail + "'" + ", ");
            valueis.Append("'" + newEntity.HashPassword + "'");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO personalInfo (id, mail, hashPassword) VALUES ( " +
                    valueis.ToString() + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(newEntity.Id, newEntity);
        }

        public void Delete(PersonalInfo entity)
        {
            allEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            dictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM personalInfo WHERE id = " + entity.Id, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            allEntities = AllEntities
                .Where(x => (x.Id != id)).ToList();
            dictionaryOfEntities.Remove(id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM personalInfo WHERE id = " + id, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, string email)
        {
            allEntities = allEntities
                .Select(x =>
                {
                    if (x.Id == id)
                    {
                        x.Mail = email ?? x.Mail;
                        
                    }

                    return x;
                })
                .ToList();
            var old = GetOneById(id);
            dictionaryOfEntities[id] = new PersonalInfo()
            {
               Id = id,
               Mail = email ?? old.Mail,
               HashPassword = old.HashPassword
                
            };
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                if (email != null)
                {
                    var command = new NpgsqlCommand(
                        "UPDATE personalinfo SET mail = " + "'" + email + "'" + "  WHERE id = " + id, connection);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}