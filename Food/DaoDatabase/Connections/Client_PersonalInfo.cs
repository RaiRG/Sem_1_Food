using System;
using System.Collections.Generic;
using Npgsql;

namespace DaoDatabase.Connections
{
    public class Client_PersonalInfo : IConnactionOneToOne
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public Dictionary<int, int> Connecton { get; set; }

        public int GetIdOfFirstBySecond(int secondId)
        {
            foreach (var pair in Connecton)
            {
                if (pair.Value == secondId)
                    return pair.Key;
            }

           throw new Exception("Нет такого индекса");
        }

        public int GetIdOfSecondByFirst(int firstId)
        {
            return Connecton[firstId];
        }

        public void Insert(int firstId, int secondId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO client_personalInfo (client_id, personalInfo_id) VALUES ( " +
                    firstId + ", " + secondId + " "
                    + ")");
                command.ExecuteNonQuery();
            }
        }
    }
}