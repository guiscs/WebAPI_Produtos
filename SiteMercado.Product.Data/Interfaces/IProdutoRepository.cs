using SiteMercado.Product.Data.Models;
using System.Threading.Tasks;

namespace SiteMercado.Product.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorID(long id);
        Task<Produto> ObterPorNomeOutroID(string Nome, long id);
        Task<Produto> ObterPorIDNotracking(long id);
    }
}
