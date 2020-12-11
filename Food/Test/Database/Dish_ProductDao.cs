using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace Test
{
    public class Dish_ProductDao
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        private static List<DishProductItem> connectDishProductweight;

        public List<DishProductItem> ConnectDishProductweight => connectDishProductweight;

        private static bool isFirstLaunch = true;

        public Dish_ProductDao()
        {
            if (isFirstLaunch)
            {
                connectDishProductweight = new List<DishProductItem>();
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
                            var current = new DishProductItem();
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                switch (allreader.GetName(i).ToString())
                                {
                                    case "dish_id":
                                        current.DishId = (int) tableName;
                                        break;
                                    case "product_id":
                                        current.ProductId = (int) tableName;
                                        break;
                                    case "weight":
                                        current.Weight = (int) tableName;
                                        break;
                                }
                            }

                            connectDishProductweight.Add(current);
                        }
                    }
                }
            }
        }

        public List<int> GetDishesIdByProductId(int prosuctId)
        {
            return ConnectDishProductweight.Where(x => x.ProductId == prosuctId).Select(x => x.DishId).ToList();
        }

        public List<int> GetProductIdByDishesId(int dishId)
        {
            return ConnectDishProductweight.Where(x => x.DishId == dishId).Select(x => x.ProductId).ToList();
        }

        public int GetWeight(int dishId, int productId)
        {
            return ConnectDishProductweight.Where(x => x.DishId == dishId && x.ProductId == productId)
                .Select(x => x.Weight).ToArray()[0];
        }

        public void Insert(int firstId, int secondId, int weight)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO dish_product (dish_id, product_id, weight ) VALUES ( " +
                    firstId + ", " + secondId + ", " + weight
                    + ")");
                command.ExecuteNonQuery();
            }
        }
    }
}