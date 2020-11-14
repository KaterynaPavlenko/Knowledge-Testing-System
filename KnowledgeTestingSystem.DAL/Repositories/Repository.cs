﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _entities;
        protected readonly TestingSystemDbContext _testingSystemDbContext;

        public Repository(TestingSystemDbContext context)
        {
            _testingSystemDbContext = context;
            _entities = _testingSystemDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(string includeProperties = "")
        {
             IQueryable<TEntity> query = _entities;
             foreach (var includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
             {
                 query = query.Include(includeProperty);
             }
             return query.ToList();
             
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            _entities.Add(entity);
        }

        public void Update(TEntity updatedEntity)
        {
            _testingSystemDbContext.Entry(updatedEntity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var found = _entities.FirstOrDefault(entity => entity.Id == id);
            if (found != null)
                _entities.Remove(found);
        }
    }
}