using SiteMercado.Product.Data.Context;
using SiteMercado.Product.Data.Interfaces;
using SiteMercado.Product.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SiteMercado.Product.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProductContext context) : base(context) { }

        public async Task<Produto> ObterPorNomeOutroID(string Nome, long id)
        {
            return await _ctxDB.Produtos.SingleOrDefaultAsync(p => p.NM_PRODUTO == Nome && p.Id != id);
        }

        public async Task<Produto> ObterPorID(long id)
        {
            return await _ctxDB.Produtos.FindAsync(id);
        }

        public async Task<Produto> ObterPorIDNotracking(long id)
        {
            return await _ctxDB.Produtos.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}