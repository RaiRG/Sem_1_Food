using System;
using System.Collections.Generic;
using Npgsql;

namespace Test.Database.Connections
{
    public class Dish_ClientDao
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        private static bool isFirstLaunch = true;

        private static List<FirstSecondItem> connectDishClient;

        public List<FirstSecondItem> ConnectDishClient => connectDishClient;
        public Dish_ClientDao()
        {
            if (isFirstLaunch)
            {
                connectDishClient = new List<FirstSecondItem>();
                isFirstLaunch = false;
                using (NpgsqlConnection connect = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connect.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM dish_client;", connect);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var dish = -1;
                            var clientt = -1;
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    switch (allreader.GetName(i).ToString())
                                    {
                                        case "dish_id":
                                            dish = (int) tableName;
                                            break;
                                        case "client_id":
                                            clientt = (int) tableName;
                                            break;
                                    }
                                }
                            }
                            connectDishClient.Add(new FirstSecondItem(dish, clientt));
                        }
                    }
                }
            }
        }

        public void Insert(int firstId, int secondId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
             {
                 connection.Open();
                 var command = new NpgsqlCommand(
                     "INSERT INTO dish_client (dish_id, client_id) VALUES ( " +
                     firstId + ", " + secondId + " "
                     + ")", connection);
                 command.ExecuteNonQuery();
             }
            connectDishClient.Add(new FirstSecondItem(firstId, secondId));
            
        }
    }
}