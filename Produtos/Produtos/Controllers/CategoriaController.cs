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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplication _categoriaapplication;
        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaapplication = categoriaApplication;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCategoria()
        {
            var categoria = await _categoriaapplication.BuscarCategoria();

            if (categoria.Status == false)
            {
                return NotFound(categoria);
            }

            return Ok(categoria);
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> BuscarPorId(int caregoriaId)
        {
            var categoria = await _categoriaapplication.BuscarPorId(caregoriaId);

            if (categoria.Status == false)
            {
                return NotFound(categoria);
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(Categoria categoriaCriarDto)
        {
            var categoria = await _categoriaapplication.CriarCategoria(categoriaCriarDto);

            if (categoria.Status == false)
            {
                return BadRequest(categoria);
            }

            return Ok(categoria);
        }
        [HttpPut]
        public async Task<IActionResult> EditarCategoria(Categoria cateogiraEditarDto)
        {
            var categoria = await _categoriaapplication.EditarCategoria(cateogiraEditarDto);

            if (categoria.Status == false)
            {
                return BadRequest(categoria);
            }

            return Ok(categoria);
        }
        [HttpDelete]
                public async Task<IActionResult> Remover(int categoriaId)
        {
            var categoria = await _categoriaapplication.Remover(categoriaId);

            if (categoria.Status == false)
            {
                return BadRequest(categoria);
            }

            return Ok(categoria);
        }
    }
}
