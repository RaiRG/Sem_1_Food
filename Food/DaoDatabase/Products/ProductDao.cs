using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DaoDatabase
{
    public class ProductDao : IDao<Product>
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public List<Product> AllEntities { get; set; }

        public Dictionary<int, Product> DictionaryOfEntities { get; set; }

        public List<Product> GetAll()
        {
            return AllEntities;
        }

        public Product GetOne(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(int id, Product newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "'");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO products (id, name) VALUES ( " +
                    valueis.ToString() + ")");
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Product entity)
        {
            AllEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            DictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM products WHERE id = " + entity.Id);
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
                    "DELETE FROM products WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }
    }
}