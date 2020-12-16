﻿using System;
 using System.Collections.Generic;

namespace Test
{
    public class Dish : Entity<Dish>
    {
        //TODO: Поудмать, как хранить Img
        public string Name { get; set; }
        public DateTime CreatingDate { get; set; }
        public TimeSpan CookTime { get; set; }
        public int Portions { get; set; }
        public string CookingMethod { get; set; } //Описание
        public string Img { get; set; }
    }
}