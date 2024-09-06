﻿
using Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Interfaces.Interfaces
{
    public interface IUsuarioService
    {


        Task<ResponseModel<List<Usuario>>> BuscarUsuario();
        Task<ResponseModel<Usuario>> BuscarPorId(int usuarioId);
        Task<ResponseModel<List<Usuario>>> CriarUsuario(Usuario usuarioCriarDto);
        Task<ResponseModel<List<Usuario>>> EditarUsuario(Usuario usuarioEditarDto);
        Task<ResponseModel<List<Usuario>>> Remover(int usuarioId);


    }
}