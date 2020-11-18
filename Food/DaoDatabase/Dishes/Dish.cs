﻿using System.Collections.Generic;

namespace DaoDatabase
{
    public class Dish : Entity<Dish>
    {
        public int Time;
        public int Portions;
        public string CookingMethod; //Описание
    }
}