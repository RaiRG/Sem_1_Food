using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test.Database
{
    public class ReviewDao : IDao<Review, (int, int)>
    {
        private static readonly string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        private static List<Review> allEntities;

        private static Dictionary<(int, int), Review> dictionaryOfEntities;

        public List<Review> AllEntities => allEntities;

        public Dictionary<(int, int), Review> DictionaryOfEntities => dictionaryOfEntities;

        private static bool isFirstLaunch = true;


        public ReviewDao()
        {
            if (isFirstLaunch)
            {
                allEntities = new List<Review>();
                dictionaryOfEntities = new Dictionary<(int, int), Review>();
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
                                switch (allreader.GetName(i).ToString())
                                {
                                    case "dish_id":
                                        current.DishId = (int) tableName;
                                        break;
                                    case "client_id":
                                        current.ClientID = (int) tableName;
                                        break;
                                    case "send_time":
                                        current.SendTime = (TimeSpan) tableName;
                                        break;
                                    case "description":
                                        current.Description = (string) tableName;
                                        break;
                                }
                            }

                            allEntities.Add(current);
                            dictionaryOfEntities.Add((current.DishId, current.ClientID), current);
                        }
                    }
                }
            }
        }

        public Review GetOneById((int, int) id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(Review newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.DishId + ", ");
            valueis.Append(newEntity.ClientID + ", ");
            valueis.Append("'" + newEntity.SendTime + "'" + ", ");
            valueis.Append("'" + newEntity.Description + "'");
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO reviews (dish_id, client_id, send_time, description) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add((newEntity.DishId, newEntity.ClientID), newEntity);
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

        public void Delete((int, int) id)
        {
            throw new NotImplementedException();
            // allEntities = AllEntities
            //     .Where(x => (x.DishId != id.Item1 && x.ClientID != id.Item2)).ToList();
            // dictionaryOfEntities.Remove(id);
            // using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            // {
            //     connection.Open();
            //     var command = new NpgsqlCommand(
            //         "DELETE FROM clients WHERE id = " + id, connection);
            //     command.ExecuteNonQuery();
            // }
        }
    }
}