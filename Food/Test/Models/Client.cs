﻿﻿namespace Test
{
    public class Client : Entity<Client>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Login { get; set; }
        public int NumberOfDishes { get; set; }
        public int Rating { get; set; }
        public string Img { get; set; }

    }
}