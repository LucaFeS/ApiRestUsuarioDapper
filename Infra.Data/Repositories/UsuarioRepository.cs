using Application.Interfaces;
using AutoMapper;
using Dapper;
using Domain.Models;
using Domain.Interfaces.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebApi.Dto;
using Application.Dto;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioRepository(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<Usuario>> BuscarPorId(int usuarioId)
        {
            ResponseModel<Usuario> response = new ResponseModel<Usuario>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("select * from Usuarios where id = @Id", new { Id = usuarioId });

                if (usuarioBanco == null)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Status = false;
                    return response;
                }
                var usuarioMapeado = _mapper.Map<Usuario>(usuarioBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuário localizado com sucesso!";
            }
            return response;
        }


        async Task<ResponseModel<List<Usuario>>> IUsuarioRepository.BuscarUsuario()
        {
            ResponseModel<List<Usuario>> response = new ResponseModel<List<Usuario>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");

                if (usuariosBanco.Count() <= 0)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Status = false;

                    return response;
                }

                var usuarioMapeado = _mapper.Map<List<Usuario>>(usuariosBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuários Localizados com suceso!";

            }
            return response;
        }

        private static async Task<IEnumerable<Usuario>> ListarUsuarios(SqlConnection connection)

        {
            return await connection.QueryAsync<Usuario>("select * from Usuarios");
        }

        public async Task<ResponseModel<List<Usuario>>> CriarUsuario(Usuario usuarioCriarDto)
        {
            ResponseModel<List<Usuario>> response = new ResponseModel<List<Usuario>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync("insert into Usuarios (NomeCompleto, Email, Cargo, Salario, CPF, Senha, Situacao)" +
                    "values(@NomeCompleto, @Email, @Cargo, @Salario, @CPF, @Senha, @Situacao)", usuarioCriarDto);

                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar um registro!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<Usuario>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuários listados com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<Usuario>>> EditarUsuario(Usuario usuarioEditarDto)
        {
            ResponseModel<List<Usuario>> response = new ResponseModel<List<Usuario>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync(
            "UPDATE Usuarios " +
            "SET NomeCompleto = @NomeCompleto, " +
            "    Email = @Email, " +
            "    Cargo = @Cargo, " +
            "    Salario = @Salario, " +
            "    Situacao = @Situacao, " +
            "    CPF = @CPF " +
            "WHERE Id = @Id",
            usuarioEditarDto
);


                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<Usuario>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuários listados com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<Usuario>>> Remover(int usuarioId)
        {
            ResponseModel<List<Usuario>> response = new ResponseModel<List<Usuario>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.ExecuteAsync("delete from Usuarios where Id = @Id", new {@Id = usuarioId });
                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a remoção!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<Usuario>>(usuarios);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuários listados com sucesso!";
            }
            return response;
        }
                
        
    }
}





 
    

       

   
