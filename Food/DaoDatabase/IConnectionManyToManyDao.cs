using System.Collections.Generic;

namespace DaoDatabase
{
    public interface IConnectionManyToMany
    {
        public Dictionary<int, List<int>> ConnectWithFirstKey { get; set; }
        public Dictionary<int, List<int>> ConnectWithSecondKey { get; set; }
        public List<int> GetIdOfFirstBySecond(int secondId);
        public List<int> GetIdOfSecondByFirst(int firstId);

        public void Insert(int firstId, int secondId);
        
    }
}