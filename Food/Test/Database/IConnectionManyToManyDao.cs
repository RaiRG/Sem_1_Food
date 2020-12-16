using System.Collections.Generic;

namespace Test
{
    public interface IConnectionManyToMany
    {
        public Dictionary<int, List<int>> ConnectWithFirstKey { get; }
        public Dictionary<int, List<int>> ConnectWithSecondKey { get; }
        public List<int> GetIdOfFirstBySecond(int secondId);
        public List<int> GetIdOfSecondByFirst(int firstId);

        public void Insert(int firstId, int secondId);
        
    }
}