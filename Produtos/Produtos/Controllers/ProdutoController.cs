using Application.Dto;
using Application.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        public ProdutoController(IProdutoApplication usuarioApplication)
        {
            _produtoApplication = usuarioApplication;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarProduto()
        {
            var produtos = await _produtoApplication.BuscarProduto();

            if (produtos.Status == false)
            {
                return NotFound(produtos);
            }

            return Ok(produtos);
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> BuscarPorId(int produtosId)
        {
            var produtos = await _produtoApplication.BuscarPorId(produtosId);

            if (produtos.Status == false)
            {
                return NotFound(produtos);
            }

            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto(Produtos produtosCriarDto)
        {
            var produtos = await _produtoApplication.CriarProduto(produtosCriarDto);

            if (produtos.Status == false)
            {
                return BadRequest(produtos);
            }

            return Ok(produtos);
        }
        [HttpPut]
        public async Task<IActionResult> EditarProduto(Produtos produtosEditarDto)
        {
            var produtos = await _produtoApplication.EditarProduto(produtosEditarDto);

            if (produtos.Status == false)
            {
                return BadRequest(produtos);
            }

            return Ok(produtos);
        }
        [HttpDelete]
                public async Task<IActionResult> Remover(int produtosId)
        {
            var produtos = await _produtoApplication.Remover(produtosId);

            if (produtos.Status == false)
            {
                return BadRequest(produtos);
            }

            return Ok(produtos);
        }
    }
}
