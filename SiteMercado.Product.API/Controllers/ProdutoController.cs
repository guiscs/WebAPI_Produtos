using AutoMapper;
using SiteMercado.Product.Business.Interfaces;
using SiteMercado.Product.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SiteMercado.Product.Data.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace SiteMercado.Product.API.Controllers
{
    [Route("api/product")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador,
            IMapper mapper,
            IProdutoBusiness produtoBusiness) : base(notificador)
        {
            _produtoBusiness = produtoBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return await _produtoBusiness.ListarTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(long id)
        {
            var produto = await _produtoBusiness.BuscarProdutoPorID(id);

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar([FromForm] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoBusiness.Adicionar(produtoViewModel);

            return CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(long id, [FromForm] ProdutoViewModel produto)
        {
            var produtoAtualizacao = await _produtoBusiness.BuscarProdutoPorID(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (produtoAtualizacao == null) return NotFound();

            await _produtoBusiness.Atualizar(produto);

            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var produtoViewModel = await _produtoBusiness.BuscarProdutoPorIDNoTracking(id);
            if (produtoViewModel == null) return NotFound();
            await _produtoBusiness.Excluir(id);
            return CustomResponse();
        }

        [HttpGet("Imagem/{idProduto}")]
        public async Task<IActionResult> GetImageByIdProd(long idProduto)
        {
            var produto = await _produtoBusiness.GetImageByIdProd(idProduto);

            if (produto.file == null) return NotFound();

            return CustomResponse($"data:{produto.contentType};base64," + Convert.ToBase64String(produto.file));
        }
    }
}
