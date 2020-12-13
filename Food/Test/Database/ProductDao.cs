using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test
{
    public class ProductDao : IDao<Product, int>
    {
        // private string connectionString =
        //     @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public static int ID => allEntities.Count();
        
        private static bool isFirstLaunch = true;
        //TODO: изменить строку подключения 
        private readonly string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        private static readonly Dictionary<int, Product> dictionaryOfEntities = new Dictionary<int, Product>();
        private static List<Product> allEntities = new List<Product>();
        public List<Product> AllEntities => allEntities;

        public Dictionary<int, Product> DictionaryOfEntities => dictionaryOfEntities;

        public ProductDao()
        {
            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM products;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new Product();
                            for (var i = 0; i < allreader.FieldCount; i++)
                            {
                                var tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    switch (allreader.GetName(i))
                                    {
                                        case "name":
                                            current.Name = (string) tableName;
                                            break;
                                        case "id":
                                            current.Id = (int) tableName;
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

        public List<Product> GetAll()
        {
            return AllEntities;
        }

        public Product GetOneById(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(Product newEntity)
        {
            newEntity.Id = ID;
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "'");
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO products (id, name) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }
            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(newEntity.Id, newEntity);
        }

        public void Delete(Product entity)
        {
            allEntities = allEntities
                .Where(x => (x != entity)).ToList();
            dictionaryOfEntities.Remove(entity.Id);
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM products WHERE id = " + entity.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            allEntities = allEntities
                .Where(x => (x.Id != id)).ToList();
            dictionaryOfEntities.Remove(id);
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM products WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }

        public int GetNumberOfLinesForFirstLaunch()
        {
            throw new System.NotImplementedException();
        }
    }
}