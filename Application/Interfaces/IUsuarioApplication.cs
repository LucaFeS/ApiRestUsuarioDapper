using Application.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Dto;

namespace Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<ResponseModel<List<UsuarioDto>>> BuscarUsuario();
        Task<ResponseModel<UsuarioDto>> BuscarPorId(int usuarioId);
        Task<ResponseModel<List<UsuarioCriarDto>>> CriarUsuario(Usuario usuarioCriarDto);
        Task<ResponseModel<List<UsuarioEditarDto>>> EditarUsuario(Usuario usuarioEditarDto);
        Task<ResponseModel<List<UsuarioDto>>> Remover(int usuarioId);

    }
}
