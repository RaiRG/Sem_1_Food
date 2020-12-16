using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Test.Database
{
    public class ForumDao : IDao<ForumItem, int>
    {
        public static List<ForumItem> allEntities;
        public Dictionary<int, ForumItem> dictionaryOfEntities;

        public List<ForumItem> AllEntities => allEntities;

        public Dictionary<int, ForumItem> DictionaryOfEntities => dictionaryOfEntities;

        public int Id => allEntities.Count;
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        private static bool isFirstLaunch = true;

        public ForumDao()
        {
             if (isFirstLaunch)
            {
                isFirstLaunch = false;
                allEntities = new List<ForumItem>();
                dictionaryOfEntities = new Dictionary<int, ForumItem>();
                using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM forum;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new ForumItem();
                            
                            for (var i = 0; i < allreader.FieldCount; i++)
                            {
                                var tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    current.Id = Id;
                                    switch (allreader.GetName(i))
                                    {
                                        case "client_id":
                                            current.ClientId = (int) tableName;
                                            break;
                                        case "message":
                                            current.Message = (string) tableName;
                                            break;
                                        case "send_date_time":
                                            current.SendDate = (DateTime) tableName;
                                            break;
                                    }
                                }
                            }
                            allEntities.Add(current);
                            dictionaryOfEntities.Add(current.Id, current);
                        }
                    }
                }
            }
        }
        public ForumItem GetOneById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(ForumItem newEntity)
        {
            newEntity.Id = Id;
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append(newEntity.ClientId + ", ");
            valueis.Append("'" + newEntity.Message + "'" + ", ");
            valueis.Append("'" + newEntity.SendDate +"'");
           
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO forum (id, client_id, message, send_date_time) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }
            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(newEntity.Id, newEntity);
        }

        public void Delete(ForumItem entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}