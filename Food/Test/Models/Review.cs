using System;

namespace Test
{
    public class Review : Entity<Review>
    {
        public int DishId { get; set; }
        public int ClientID { get; set; }
        public DateTime SendTime { get; set; }

        public string Description { get; set; }
    }
}