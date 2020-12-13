using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test.Database
{
    public class ReviewDao : IDao<Review, int>
    {
        private int Id => dictionaryOfEntities.Count;
        private static readonly string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        private static List<Review> allEntities;

        private static Dictionary<int, Review> dictionaryOfEntities;

        public List<Review> AllEntities => allEntities;

        public Dictionary<int, Review> DictionaryOfEntities => dictionaryOfEntities;

        private static bool isFirstLaunch = true;


        public ReviewDao()
        {
            if (isFirstLaunch)
            {
                allEntities = new List<Review>();
                dictionaryOfEntities = new Dictionary<int, Review>();
                isFirstLaunch = false;
                using (NpgsqlConnection connect = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connect.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM reviews;", connect);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new Review();
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    switch (allreader.GetName(i).ToString())
                                    {
                                        case "id":
                                            current.Id = (int) tableName;
                                            break;
                                        case "dish_id":
                                            current.DishId = (int) tableName;
                                            break;
                                        case "client_id":
                                            current.ClientID = (int) tableName;
                                            break;
                                        case "send_time":
                                            current.SendTime = (DateTime) tableName;
                                            break;
                                        case "description":
                                            current.Description = (string) tableName;
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

        public Review GetOneById(int id)
        {
            return DictionaryOfEntities[id];
        }
        public void Insert(Review newEntity)
        {
            var valueis = new StringBuilder();
            newEntity.Id = Id;
            valueis.Append(newEntity.Id + ", ");
            valueis.Append(newEntity.DishId + ", ");
            valueis.Append(newEntity.ClientID + ", ");
            valueis.Append("'" + newEntity.SendTime + "'" + ", ");
            //valueis.Append("'" + newEntity.DateTime + "'" + ", ");
            valueis.Append("'" + newEntity.Description + "'");
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO reviews (id, dish_id, client_id, send_time, description) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(newEntity.Id, newEntity);
        }

        public void Delete(Review client)
        {
            
            throw new NotImplementedException();
            // allEntities = AllEntities
            //     .Where(x => (x.DishId != client.DishId && x.ClientID != client.ClientID)).ToList();
            // dictionaryOfEntities.Remove((client.DishId, client.ClientID));
            // using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            // {
            //     connection.Open();
            //     var command = new NpgsqlCommand(
            //         "DELETE FROM clients WHERE ( dish_id = " + client.DishId + "AND client_id = " + client.ClientID + ")", connection);
            //     command.ExecuteNonQuery();
            // }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}