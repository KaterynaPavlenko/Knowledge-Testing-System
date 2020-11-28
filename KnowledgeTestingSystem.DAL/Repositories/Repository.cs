using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using KnowledgeTestingSystem.DAL.Context;
using KnowledgeTestingSystem.DAL.Entity;
using KnowledgeTestingSystem.DAL.Repositories.Interfaces;

namespace KnowledgeTestingSystem.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _entities;
        private readonly TestingSystemDbContext _testingSystemDbContext;

        public Repository(TestingSystemDbContext context)
        {
            _testingSystemDbContext = context;
            _entities = _testingSystemDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(string includeProperties = "")
        {
            IQueryable<TEntity> query = _entities;
            query = query.Where(e => e.IsDeleted == false);
            foreach (var includeProperty in includeProperties.Split
                (new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);
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
            var doesEntityExist = _testingSystemDbContext.Set<TEntity>().Any(x => x.Id == updatedEntity.Id);
            _testingSystemDbContext.Set<TEntity>().Attach(updatedEntity);
            _testingSystemDbContext.Entry(updatedEntity).State =
                doesEntityExist ? EntityState.Modified : EntityState.Added;
        }

        public void Delete(int id)
        {
            var found = _entities.FirstOrDefault(entity => entity.Id == id);
            if (found != null)
            {
                found.DeletedDate = DateTime.Now;
                found.IsDeleted = true;
            }
        }
    }
}