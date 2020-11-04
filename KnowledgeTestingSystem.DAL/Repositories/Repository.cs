using System;
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
        protected readonly TestingSystemDbContext _testingSystemDbContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(TestingSystemDbContext context)
        {
            _testingSystemDbContext = context;
            _entities = _testingSystemDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.AsNoTracking().ToList();
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
            _entities.AddOrUpdate(updatedEntity);
        }

        public void Delete(int id)
        {
            var found = _entities.FirstOrDefault(entity => entity.Id == id);
            if (found != null)
                _entities.Remove(found);
        }
    }
}