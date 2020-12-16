using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace Test
{
    public class Dish_ProductDao
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        private static List<FirstSecondItem> connectDishProduct;

        public List<FirstSecondItem> ConnectDishProduct => connectDishProduct;

        private static bool isFirstLaunch = true;

        public Dish_ProductDao()
        {
            if (isFirstLaunch)
            {
                connectDishProduct = new List<FirstSecondItem>();
                isFirstLaunch = false;
                using (NpgsqlConnection connect = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connect.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM dish_product;", connect);
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
                                        case "product_id":
                                            current.SecondId = (int) tableName;
                                            break;
                                    }
                                }
                            }

                            connectDishProduct.Add(current);
                        }
                    }
                }
            }
        }

        public List<int> GetDishesIdByProductId(int prosuctId)
        {
            return ConnectDishProduct.Where(x => x.SecondId == prosuctId).Select(x => x.FirstId).ToList();
        }

        public List<int> GetProductIdByDishesId(int dishId)
        {
            return ConnectDishProduct.Where(x => x.FirstId == dishId).Select(x => x.SecondId).ToList();
        }

        public void Insert(int firstId, int secondId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO dish_product (dish_id, product_id ) VALUES ( " +
                    firstId + ", " + secondId + ")", connection);
                command.ExecuteNonQuery();
            }
            ConnectDishProduct.Add(new FirstSecondItem() {FirstId = firstId, SecondId = secondId});
        }
    }
}