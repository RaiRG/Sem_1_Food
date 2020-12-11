using System.Collections.Generic;
using Npgsql;

namespace Test.Database.Connections
{
    public class Dish_ClientDao : IConnactionOneToOne
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
        private static bool isFirstLaunch = true;

        public Dish_ClientDao()
        {
            if (isFirstLaunch)
            {
                connection = new Dictionary<int, int>();
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

                            connection.Add(dish, clientt);
                        }
                    }
                }
            }
        }

        private static Dictionary<int, int> connection;

        public Dictionary<int, int> Connecton => connection;

        public int GetIdOfFirstBySecond(int secondId)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdOfSecondByFirst(int firstId)
        {
            return Connecton[firstId];
        }

        public void Insert(int firstId, int secondId)
        {
            throw new System.NotImplementedException();
        }
    }
}
// using System.Collections.Generic;
// using System.Text;
// using Npgsql;
//
// namespace Test.Connections
// {
//     public class Client_Dish : IConnectionManyToMany
//     {
//         //TODO: изменить строку подключения 
//         private string connectionString =
//             @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";
//         // private string connectionString =
//         //     @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";
//
//         public Dictionary<int, List<int>> ConnectWithFirstKey { get; set; }
//
//         public Dictionary<int, List<int>> ConnectWithSecondKey { get; set; }
//
//         public List<int> GetIdOfFirstBySecond(int secondId)
//         {
//             return ConnectWithSecondKey[secondId];
//         }
//
//         public List<int> GetIdOfSecondByFirst(int firstId)
//         {
//             return ConnectWithSecondKey[firstId];
//         }
//
//         public void Insert(int firstId, int secondId)
//         {
//             using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
//             {
//                 connection.Open();
//                 var command = new NpgsqlCommand(
//                     "INSERT INTO client_dish (client_id, dish_id) VALUES ( " +
//                     firstId + ", " + secondId + " "
//                     + ")");
//                 command.ExecuteNonQuery();
//             }
//         }
//     }
// }