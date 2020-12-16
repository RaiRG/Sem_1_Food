using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test
{
    public class DishDao : IDao<Dish, int>
    {
        //TODO: Внести country
        private string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        static Dictionary<int, Dish> dictionaryOfEntities = new Dictionary<int, Dish>();
        static List<Dish> allEntities = new List<Dish>();

        private static bool isFirstLaunch = true;

        public DishDao()
        {
            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM dishes;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            Dish current = new Dish();
                            for (int i = 0; i < allreader.FieldCount; i++)
                            {
                                object tableName = allreader.GetValue(i);
                                if (tableName != DBNull.Value)
                                {
                                    switch (allreader.GetName(i).ToString())
                                    {
                                        case "name":
                                            current.Name = (string) tableName;
                                            break;
                                        case "img":
                                            current.Img = (string) tableName;
                                            break;
                                        case "id":
                                            current.Id = (int) tableName;
                                            break;
                                        case "portions":
                                            current.Portions = (int) tableName;
                                            break;
                                        case "cooktime":
                                            current.CookTime = (TimeSpan) tableName;
                                            break;
                                        case "cookingmethod":
                                            current.CookingMethod = (string) tableName;
                                            break;
                                        case "creatingdate":
                                            current.CreatingDate = (DateTime) tableName;
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
        
        public static int ID => allEntities.Count();
        public List<Dish> AllEntities => allEntities;

        public Dictionary<int, Dish> DictionaryOfEntities => dictionaryOfEntities;

        public List<Dish> GetAll()
        {
            return AllEntities;
        }

        public Dish GetOneById(int id)
        {
            return dictionaryOfEntities[id];
        }

        public void Insert(Dish newEntity)
        {
            newEntity.Id = ID;
            var valueis = new StringBuilder();
            valueis.Append(newEntity.Id + ", ");
            valueis.Append("'" + newEntity.Name + "',");
            valueis.Append("'" + newEntity.CreatingDate.Year + "-" + newEntity.CreatingDate.Month + "-"+ newEntity.CreatingDate.Day + "',");
            valueis.Append("'" + newEntity.CookTime.Hours + ":" + newEntity.CookTime.Minutes + "',"); 
            valueis.Append(newEntity.Portions + ", ");
            valueis.Append("'" + newEntity.CookingMethod + "'");
            if (newEntity.Img == null || newEntity.Img == "")
            {
                newEntity.Img = "img/default.png";
            }
            valueis.Append(", '" + newEntity.Img + "'");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO dishes (id, name, creatingdate, cooktime, portions, cookingMethod, img) VALUES ( " +
                    valueis.ToString() + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add(newEntity.Id, newEntity);
        }

        public void Delete(Dish entity)
        {
            allEntities = AllEntities
                .Where(x => (x != entity)).ToList();
            dictionaryOfEntities.Remove(entity.Id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM dishes WHERE id = " + entity.Id, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            allEntities = AllEntities
                .Where(x => (x.Id != id)).ToList();
            dictionaryOfEntities.Remove(id);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM dishes WHERE id = " + id, connection);
                command.ExecuteNonQuery();
            }
        }
        
    }
}