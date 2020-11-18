using System.Collections.Generic;

namespace DaoDatabase
{
    public interface IConnactionOneToOne
    {
        public Dictionary<int,int> Connecton{ get; set; }
       
        public int GetIdOfFirstBySecond(int secondId);
        public int GetIdOfSecondByFirst(int firstId);

        public void Insert(int firstId, int secondId);
    }
}