using SiteMercado.Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Product.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(long id);
        Task<int> SaveChanges();
    }
}
