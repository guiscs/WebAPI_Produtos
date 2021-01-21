using AutoMapper;
using Microsoft.AspNetCore.Http;
using SiteMercado.Product.Business.Interfaces;
using SiteMercado.Product.Business.Models;
using SiteMercado.Product.Business.Validations;
using SiteMercado.Product.Data.Interfaces;
using SiteMercado.Product.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SiteMercado.Product.Business.Business
{
    public class ProdutoBusiness : BaseBusiness, IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoBusiness(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        #region CRUD

        public async Task Adicionar(ProdutoViewModel produto)
        {
            Produto produtoModel = Map(produto);
            if (!ExecutarValidacao(new ProdutoValidation(), produtoModel)) return;

            if (!ValidateNameExists(produtoModel.NM_PRODUTO, produtoModel.Id))
            {
                Notificar("Este nome já pertence a outro produto!");
                return;
            }

            await _produtoRepository.Adicionar(produtoModel);
        }

        public async Task Atualizar(ProdutoViewModel produto)
        {
            var produtoAtualizacao = await _produtoRepository.ObterPorID(produto.Id);
            produtoAtualizacao.NM_PRODUTO = produto.Nome;
            produtoAtualizacao.VL_PRODUTO = produto.Valor;

            if(produto.ImagemUpload?.Length>0)
            {
                produtoAtualizacao.NM_IMAGEM = produto.ImagemUpload.FileName;
                produtoAtualizacao.DS_TIPO_ARQUIVO = produto.ImagemUpload.ContentType;
                produtoAtualizacao.VB_IMAGEM_ARQUIVO = GetBinaryFile(produto.ImagemUpload);
            }

            if (!ExecutarValidacao(new ProdutoValidation(), produtoAtualizacao)) return;

            if (!ValidateNameExists(produto.Nome, produto.Id))
            {
                Notificar("Este nome já pertence a outro produto!");
                return;
            }

            await _produtoRepository.Atualizar(produtoAtualizacao);
        }

        public async Task<List<ProdutoViewModel>> ListarTodos()
        {
            return Map(await _produtoRepository.ObterTodos());
        }

        public async Task<ProdutoViewModel> BuscarProdutoPorID(long id)
        {
            return Map(await _produtoRepository.ObterPorID(id));
        }

        public async Task<ProdutoViewModel> BuscarProdutoPorIDNoTracking(long id)
        {
            return Map(await _produtoRepository.ObterPorIDNotracking(id));
        }

        public async Task Excluir(long id)
        {
            await _produtoRepository.Remover(id);
        }

        public async Task<(byte[] file, string fileName, string contentType)> GetImageByIdProd(long idProduto)
        {
            var produto = await _produtoRepository.ObterPorID(idProduto);
            return (produto.VB_IMAGEM_ARQUIVO, produto.NM_IMAGEM, produto.DS_TIPO_ARQUIVO );
        }

        #endregion

        #region Validate

        private bool ValidateNameExists(string nome, long Id)
        {
            return _produtoRepository.ObterPorNomeOutroID(nome, Id).Result == null;
        }

        #endregion

        #region Map

        private Produto Map(ProdutoViewModel produto)
        {
            var produtoMap = new Produto()
            {
                Id = produto.Id,
                NM_PRODUTO = produto.Nome,
                VL_PRODUTO = produto.Valor,

                // Imagem
                DS_TIPO_ARQUIVO = produto.ImagemUpload.ContentType,
                NM_IMAGEM = produto.ImagemUpload.FileName,
                VB_IMAGEM_ARQUIVO = GetBinaryFile(produto.ImagemUpload)
            };


            return produtoMap;
        }

        private List<ProdutoViewModel> Map(List<Produto> produtos)
        {
            var produtoList = new List<ProdutoViewModel>();

            produtos.ForEach(produto => produtoList.Add(Map(produto)));

            return produtoList;
        }

        private ProdutoViewModel Map(Produto produto)
        {
            var produtoMap = new ProdutoViewModel()
            {
                Id = produto.Id,
                Nome = produto.NM_PRODUTO,
                Valor = produto.VL_PRODUTO,
                ImagemUpload = null
            };

            return produtoMap;
        }

        private byte[] GetBinaryFile(IFormFile imagemUpload)
        {
            byte[] fileBytes = null;
            if (imagemUpload.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imagemUpload.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
            }

            return fileBytes;
        }

        #endregion

        #region GC
        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        #endregion
    }
}
