using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test
{
    public class ClientDao : IDao<Client, int>
    {
        //TODO: изменить строку подключения 
        private static readonly string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";


        private static bool isFirstLaunch = true;

        private static readonly Dictionary<int, Client> dictionaryOfEntities = new Dictionary<int, Client>();
        private static List<Client> allEntities = new List<Client>();

        public static int ID => allEntities.Count();

        public List<Client> AllEntities => allEntities;

        public Dictionary<int, Client> DictionaryOfEntities => dictionaryOfEntities;

        public ClientDao()
        {
            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM clients;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new Client();
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
                                        case "surname":
                                            current.Surname = (string) tableName;
                                            break;
                                        case "id":
                                            current.Id = (int) tableName;
                                            break;
                                        case "numberofdishes":
                                            current.NumberOfDishes = (int) tableName;
                                            break;
                                        case "login":
                                            current.Login = tableName.ToString();
                                            break;
                                        case "rating":
                                            current.Rating = (int) tableName;
                                            break;
                                        case "img":
                                            current.Img = (string) tableName;
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

        public Client GetOneById(int id)
        {
            return dictionaryOfEntities[id];
        }

        public void Insert(Client newEntity)
        {
            newEntity.Id = ID;
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "'" + ", ");
            valueis.Append("'" + newEntity.Surname + "'" + ", ");
            valueis.Append("'" + newEntity.Login + "'" + ", ");
            valueis.Append(newEntity.Rating + ", ");
            valueis.Append(newEntity.NumberOfDishes + " ");
            if (newEntity.Img == null)
            {
                newEntity.Img = "img/default.png";
            }
            valueis.Append(", '" + newEntity.Img + "'");
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO clients (id, name, surname, login, rating, numberOfDishes, img) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(ID, newEntity);
        }

        public void Delete(Client client)
        {
            allEntities = AllEntities
                .Where(x => (x != client)).ToList();
            dictionaryOfEntities.Remove(client.Id);
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM clients WHERE id = " + client.Id, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            allEntities = AllEntities
                .Where(x => (x.Id != id)).ToList();
            dictionaryOfEntities.Remove(id);
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM clients WHERE id = " + id, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, string name, string surname, string login)
        {
            allEntities = allEntities
                .Select(x =>
                {
                    if (x.Id == id)
                    {
                        x.Name = name ?? x.Name;
                        x.Surname = surname ?? x.Surname;
                        x.Login = login;
                    }

                    return x;
                })
                .ToList();
            var old = GetOneById(id);
            dictionaryOfEntities[id] = new Client()
            {
                Name = name?? old.Name,
                Surname = surname?? old.Surname,
                Login = login?? old.Login,
                Id = id,
                Img = old.Img,
                Rating = old.Rating,
                NumberOfDishes = old.NumberOfDishes
                
            };
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                if (name != null)
                {
                    var command = new NpgsqlCommand(
                        "UPDATE clients SET name = " + "'" + name +  "'" +"  WHERE id = " + id, connection);
                    command.ExecuteNonQuery();
                }
                if (surname != null)
                {
                    var command = new NpgsqlCommand(
                        "UPDATE clients SET surname = " + "'" + surname + "'" + "  WHERE id = " + id, connection);
                    command.ExecuteNonQuery();
                }
                if (login != null)
                {
                    var command = new NpgsqlCommand(
                        "UPDATE clients SET login = " + "'" + login + "'" + "  WHERE id = " + id, connection);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}