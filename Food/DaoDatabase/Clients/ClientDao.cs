﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace DaoDatabase
{
    public class ClientDao : IDao<Client>
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        //TODO: класс Entity, в котором переопределю Equals
        public List<Client> AllEntities { get; set; }
        public Dictionary<int, Client> DictionaryOfEntities { get; set; }
        

        public List<Client> GetAll()
        {
            return AllEntities;
        }

        public Client GetOne(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(int id, Client newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "'" + ", ");
            valueis.Append("'" + newEntity.Surname + "'" + ", ");
           valueis.Append(newEntity.Rating + ", ");
            valueis.Append(newEntity.NumberOfDishes + " ");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                        "INSERT INTO clients (id, name, surname, rating, numberOfDishes) VALUES ( " +
                        valueis.ToString() + ")");
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Client client)
        {
            AllEntities = AllEntities
                .Where(x => (x != client)).ToList();
            DictionaryOfEntities.Remove(client.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM clients WHERE id = " + client.Id);
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
                        "DELETE FROM clients WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }
    }
}