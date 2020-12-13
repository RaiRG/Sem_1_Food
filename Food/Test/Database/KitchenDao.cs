using System.Collections.Generic;

namespace Test.Database
{
    public class KitchenDao :IDao<Kitchen, int>
    {
        public List<Kitchen> AllEntities { get; }

        public Dictionary<int, Kitchen> DictionaryOfEntities { get; }

        public Kitchen GetOneById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Kitchen newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Kitchen entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}