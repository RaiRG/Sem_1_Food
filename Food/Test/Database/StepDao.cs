using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Test.Database
{
    public class StepDao : IDao<Step, (int, int)>
    {
        //TODO: изменить строку подключения 
        private static readonly string connectionString =
            @"Server=127.0.0.1;Port=5432;Database=Test;User Id=postgres;Password=postgres;";

        private static bool isFirstLaunch = true;
        private static Dictionary<(int, int), Step> dictionaryOfEntities;
        private static List<Step> allEntities;

        public List<Step> AllEntities => allEntities;

        public Dictionary<(int, int), Step> DictionaryOfEntities => dictionaryOfEntities;

        public StepDao()
        {
            if (isFirstLaunch)
            {
                isFirstLaunch = false;
                dictionaryOfEntities = new Dictionary<(int, int), Step>();
                allEntities = new List<Step>();
                using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
                {
                    connection.Open();
                    var selectAll = new NpgsqlCommand(
                        "SELECT * FROM steps;", connection);
                    var allreader = selectAll.ExecuteReader();
                    if (allreader.HasRows) // если есть данные
                    {
                        while (allreader.Read())
                        {
                            var current = new Step();
                            for (var i = 0; i < allreader.FieldCount; i++)
                            {
                                var tableName = allreader.GetValue(i);
                                switch (allreader.GetName(i))
                                {
                                    case "description":
                                        current.Description = (string) tableName;
                                        break;
                                    case "img":
                                        current.Img = (string) tableName;
                                        break;
                                    case "dishid":
                                        current.DishID = (int) tableName;
                                        break;
                                    case "numberofstep":
                                        current.NumberOfStep = (int) tableName;
                                        break;
                                }
                            }
                            allEntities.Add(current);
                            dictionaryOfEntities.Add((current.DishID, current.NumberOfStep), current);
                        }
                    }
                }
            }
        }

        public Step GetOneById((int, int) dishId_stepNumber)
        {
            return dictionaryOfEntities[dishId_stepNumber];
        }

        public void Insert(Step newEntity)
        {
            var valueis = new StringBuilder();
            valueis.Append(newEntity.DishID + ", ");
            valueis.Append(newEntity.NumberOfStep + ", ");
            valueis.Append("'" + newEntity.Description + "'" + ", ");
            if (newEntity.Img == null)
            {
                newEntity.Img = "img/default.png";
            }
            valueis.Append( "'"+newEntity.Img + "'");
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO steps (dishid, numberofstep, description, img) VALUES ( " +
                    valueis + ")", connection);
                command.ExecuteNonQuery();
            }

            allEntities.Add(newEntity);
            dictionaryOfEntities.Add((newEntity.DishID, newEntity.NumberOfStep), newEntity);
        }

        public void Delete(Step client)
        {
            allEntities = AllEntities
                .Where(x => (x != client)).ToList();
            dictionaryOfEntities.Remove((client.DishID, client.NumberOfStep));
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM clients WHERE ( dishid = " + client.DishID + "AND numberofstep = " +  client.NumberOfStep + ")", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete((int, int) dishId_stepNumber)
        {
            allEntities = AllEntities
                .Where(x => (x.DishID != dishId_stepNumber.Item1 && x.NumberOfStep != dishId_stepNumber.Item2)).ToList();
            dictionaryOfEntities.Remove(dishId_stepNumber);
            using (var connection = new NpgsqlConnection(connectionString)) // подключаемся к бд
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "DELETE FROM clients WHERE ( dishid = " + dishId_stepNumber.Item1 + "AND numberofstep = " +  dishId_stepNumber.Item2 + ")", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}