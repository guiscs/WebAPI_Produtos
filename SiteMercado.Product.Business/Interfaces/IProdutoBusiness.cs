using SiteMercado.Product.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Product.Business.Interfaces
{
    public interface IProdutoBusiness : IDisposable
    {
        Task Adicionar(ProdutoViewModel produto);
        Task Atualizar(ProdutoViewModel produto);
        Task<List<ProdutoViewModel>> ListarTodos();
        Task<ProdutoViewModel> BuscarProdutoPorID(long id);
        Task<ProdutoViewModel> BuscarProdutoPorIDNoTracking(long id);
        Task Excluir(long id);
        Task<(byte[] file, string fileName, string contentType)> GetImageByIdProd(long idProduto);
    }
}
