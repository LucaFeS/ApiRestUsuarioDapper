using AutoMapper;
using Dapper;
using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CategoriaRepository(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        private static async Task<IEnumerable<Categoria>> ListarCategoria(SqlConnection connection)

        {
            return await connection.QueryAsync<Categoria>("select * from Categoria");
        }

        public async Task<ResponseModel<List<Categoria>>> BuscarCategoria()
        {
            ResponseModel<List<Categoria>> response = new ResponseModel<List<Categoria>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var CategoriaBancos = await connection.QueryAsync<Categoria>("select * from Categoria");

                if (CategoriaBancos.Count() <= 0)
                {
                    response.Mensagem = "Nenhum categoria localizado!";
                    response.Status = false;

                    return response;
                }

                var CategoriaMapeados = _mapper.Map<List<Categoria>>(CategoriaBancos);

                response.Dados = CategoriaMapeados;
                response.Mensagem = "Categoria Localizados com suceso!";

            }
            return response;
        }

        public async Task<ResponseModel<Categoria>> BuscarPorId(int CategoriaId)
        {
            ResponseModel<Categoria> response = new ResponseModel<Categoria>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var categoriaBanco = await connection.QueryFirstOrDefaultAsync<Categoria>("select * from Categoria where id = @Id", new { Id = CategoriaId });

                if (categoriaBanco == null)
                {
                    response.Mensagem = "Nenhuma Categoria localizado!";
                    response.Status = false;
                    return response;
                }
                var categoriaMapeado = _mapper.Map<Categoria>(categoriaBanco);

                response.Dados = categoriaMapeado;
                response.Mensagem = "Categoria localizado com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<Categoria>>> CriarCategoria(Categoria categoriaCriarDto)
        {
            ResponseModel<List<Categoria>> response = new ResponseModel<List<Categoria>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var categoriaBanco = await connection.ExecuteAsync("insert into Categoria (Id, Nome)" +
                    "values(@Id,@Nome)", categoriaCriarDto);

                if (categoriaBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar um registro!";
                    response.Status = false;
                    return response;
                }

                var categoria = await ListarCategoria(connection);

                var categoriaMapeados = _mapper.Map<List<Categoria>>(categoria);

                response.Dados = categoriaMapeados;
                response.Mensagem = "Categoria listados com sucesso!";
            }
            return response;
        }

        public async Task<ResponseModel<List<Categoria>>> EditarCategoria(Categoria categoriaEditarDto)
        {
            ResponseModel<List<Categoria>> response = new ResponseModel<List<Categoria>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var categoriaBanco = await connection.ExecuteAsync(
            "UPDATE Categoria   " +
            "SET Nome = @Nome   " +

            "WHERE Id = @Id",
            categoriaEditarDto
);


                if (categoriaBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                    response.Status = false;
                    return response;
                }

                var categoria = await ListarCategoria(connection);

                var categoriaMapeados = _mapper.Map<List<Categoria>>(categoria);

                response.Dados = categoriaMapeados;
                response.Mensagem = "Categoria listados com sucesso!";
            }
            return response;
        }

        



        


      


        async Task<ResponseModel<List<Categoria>>> ICategoriaRepository.Remover(int CategoriaId)
        {
            ResponseModel<List<Categoria>> response = new ResponseModel<List<Categoria>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var categoriaBanco = await connection.ExecuteAsync("delete from Categoria where Id = @Id", new { @Id = CategoriaId });
                if (categoriaBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a remoção!";
                    response.Status = false;
                    return response;
                }

                var categoria = await ListarCategoria(connection);

                var categoriaMapeados = _mapper.Map<List<Categoria>>(categoria);

                response.Dados = categoriaMapeados;
                response.Mensagem = "Categoria listados com sucesso!";
            }
            return response;
        }
    }
}
        





 
    

       

   
