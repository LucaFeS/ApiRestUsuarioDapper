using Application.Dto;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;
        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioApplication.BuscarUsuario();

            if (usuarios.Status == false)
            {
                return NotFound(usuarios);
            }

            return Ok(usuarios);
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarPorId(int usuarioId)
        {
            var usuarios = await _usuarioApplication.BuscarPorId(usuarioId);

            if (usuarios.Status == false)
            {
                return NotFound(usuarios);
            }

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuatio(Usuario usuarioCriarDto)
        {
            var usuarios = await _usuarioApplication.CriarUsuario(usuarioCriarDto);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }
        [HttpPut]
        public async Task<IActionResult> EditarUsuario(Usuario usuarioEditarDto)
        {
            var usuarios = await _usuarioApplication.EditarUsuario(usuarioEditarDto);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }
        [HttpDelete]
                public async Task<IActionResult> Remover(int usuariosId)
        {
            var usuarios = await _usuarioApplication.Remover(usuariosId);

            if (usuarios.Status == false)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }
    }
}
