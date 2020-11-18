﻿namespace DaoDatabase
{
    public class Country : Entity<Country>
    {
        public string Name { get; set; }
        public int NumberOfDishes { get; set; }
    }
}