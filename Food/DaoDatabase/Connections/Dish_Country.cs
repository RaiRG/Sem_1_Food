using System.Collections.Generic;

namespace DaoDatabase.Connections
{
    //TODO: блюдо и страна какое отношение??
    public class Dish_Country : IConnactionOneToOne
    {
        public Dictionary<int, int> Connecton { get; set; }

        public int GetIdOfFirstBySecond(int secondId)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdOfSecondByFirst(int firstId)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int firstId, int secondId)
        {
            throw new System.NotImplementedException();
        }
    }
}