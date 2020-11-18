using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DaoDatabase.Connections
{
    public class Client_Dish : IConnectionManyToMany
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public Dictionary<int, List<int>> ConnectWithFirstKey { get; set; }

        public Dictionary<int, List<int>> ConnectWithSecondKey { get; set; }

        public List<int> GetIdOfFirstBySecond(int secondId)
        {
            return ConnectWithSecondKey[secondId];
        }

        public List<int> GetIdOfSecondByFirst(int firstId)
        {
            return ConnectWithSecondKey[firstId];
        }

        public void Insert(int firstId, int secondId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO client_dish (client_id, dish_id) VALUES ( " +
                    firstId + ", " + secondId + " "
                    + ")");
                command.ExecuteNonQuery();
            }
        }
    }
}