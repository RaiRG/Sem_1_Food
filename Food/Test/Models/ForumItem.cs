using System;

namespace Test
{
    public class ForumItem : Entity<ForumItem>
    {
        public int ClientId { get; set; }
        public DateTime SendDate { get; set; }
       public TimeSpan SendTime { get; set; }
        public string Message { get; set; }
    }
}