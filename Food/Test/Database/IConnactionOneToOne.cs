using System.Collections.Generic;

namespace Test
{
    public interface IConnactionOneToOne
    {
        public Dictionary<int,int> Connecton{ get; }
       
        public int GetIdOfFirstBySecond(int secondId);
        public int GetIdOfSecondByFirst(int firstId);

        public void Insert(int firstId, int secondId);
    }
}