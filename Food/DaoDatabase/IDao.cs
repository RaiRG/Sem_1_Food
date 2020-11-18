﻿using System.Collections.Generic;

namespace DaoDatabase
{
    public interface IDao<TEntity>
    {
        public List<TEntity> AllEntities { get; set; }
        public Dictionary<int, TEntity> DictionaryOfEntities { get; set; }
        public List<TEntity> GetAll();

        public TEntity GetOne(int id);

        public void Insert(int id, TEntity newEntity);

        public void Delete(TEntity entity);

        public void Delete(int id);
    }
}