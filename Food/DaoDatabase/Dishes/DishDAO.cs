﻿using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using Npgsql;

 namespace DaoDatabase
{
    public class DishDAO : IDao<Dish>
    {
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Food;User Id=postgres;Password=postgres;";

        public List<Dish> AllEntities { get; set; }

        public Dictionary<int, Dish> DictionaryOfEntities { get; set; }

        public List<Dish> GetAll()
        {
            return AllEntities;
        }

        public Dish GetOne(int id)
        {
            return DictionaryOfEntities[id];
        }

        public void Insert(int id, Dish newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append(newEntity.Time + ", ");
            valueis.Append(newEntity.Portions + ", ");
            valueis.Append("'" + newEntity.CookingMethod + "'");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO dishes (id, time, positions, cookingMethod) VALUES ( " +
                    valueis.ToString() + ")");
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Dish entity)
        {
            AllEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            DictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM dishes WHERE id = " + entity.Id);
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
                    "DELETE FROM dishes WHERE id = " + id);
                command.ExecuteNonQuery();
            }
        }
    }
}