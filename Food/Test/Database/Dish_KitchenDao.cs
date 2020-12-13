using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace Test.Connections
{
    //TODO: блюдо и страна какое отношение??
    public class Dish_KitchenDao
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        private static List<FirstSecondItem> connectDishKitchen;

        public List<FirstSecondItem> ConnectDishKitchen => connectDishKitchen;

        private static bool isFirstLaunch = true;

        public Dish_KitchenDao()
        {
            if (isFirstLaunch)
            {
                connectDishKitchen = new List<FirstSecondItem>();
                isFirstLaunch = false;
                using (NpgsqlConnection connect = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connect.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM dish_kitchen;", connect);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new FirstSecondItem();
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    switch (allreader.GetName(i).ToString())
                                    {
                                        case "dish_id":
                                            current.FirstId = (int) tableName;
                                            break;
                                        case "kitchen_id":
                                            current.SecondId = (int) tableName;
                                            break;
                                    }
                                }
                            }

                            connectDishKitchen.Add(current);
                        }
                    }
                }
            }
        }

        public List<int> GetDishesIdByProductId(int prosuctId)
        {
            return ConnectDishKitchen.Where(x => x.SecondId == prosuctId).Select(x => x.FirstId).ToList();
        }

        public List<int> GetProductIdByDishesId(int dishId)
        {
            return ConnectDishKitchen.Where(x => x.FirstId == dishId).Select(x => x.SecondId).ToList();
        }

        public void Insert(int firstId, int secondId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO dish_kitchen (dish_id, kitchen_id ) VALUES ( " +
                    firstId + ", " + secondId + ")", connection);
                command.ExecuteNonQuery();
            }
            ConnectDishKitchen.Add(new FirstSecondItem() {FirstId = firstId, SecondId = secondId});
        }
    }
}