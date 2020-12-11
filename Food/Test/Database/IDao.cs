﻿using System.Collections.Generic;

namespace Test
{
    public interface IDao<TEntity, TId>
    {
        public List<TEntity> AllEntities { get; }
        public Dictionary<TId, TEntity> DictionaryOfEntities { get;  }

        public TEntity GetOneById(TId id);

        public void Insert(TEntity newEntity);

        public void Delete(TEntity entity);

        public void Delete(TId id);

    }
}