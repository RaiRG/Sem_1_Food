using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DaoDatabase
{
    public class CountryDao : IDao<Country>
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public List<Country> AllEntities { get; set; }

        public Dictionary<int, Country> DictionaryOfEntities { get; set; }

        public List<Country> GetAll()
        {
            return AllEntities;
        }

        public Country GetOne(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(int id, Country newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "'");
            valueis.Append(newEntity.NumberOfDishes + " ");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO countries (id, name, numberOfDishes) VALUES ( " +
                    valueis.ToString() + ")");
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Country entity)
        {
            AllEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            DictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM countries WHERE id = " + entity.Id);
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
                    "DELETE FROM countries WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }
    }
}