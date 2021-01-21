using SiteMercado.Product.Data.Context;
using SiteMercado.Product.Data.Interfaces;
using SiteMercado.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Product.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ProductContext _ctxDB;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ProductContext db)
        {
            _ctxDB = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _ctxDB.SaveChangesAsync();
        }

        public virtual async Task Remover(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public void Dispose()
        {
            _ctxDB?.Dispose();
        }
    }
}
