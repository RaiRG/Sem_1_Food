﻿namespace DaoDatabase
{
    public class Client : Entity<Client>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Rating { get; set; }

        public int NumberOfDishes { get; set; }
        
        //TODO: password!
    }
}