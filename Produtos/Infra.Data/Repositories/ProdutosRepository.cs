using AutoMapper;
using Dapper;
using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProdutosRepository(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        private static async Task<IEnumerable<Produtos>> ListarProdutos(SqlConnection connection)

        {
            return await connection.QueryAsync<Produtos>("select * from Produtos");
        }
        public async Task<ResponseModel<Produtos>> BuscarPorId(int produtosId)
        {
            ResponseModel<Produtos> response = new ResponseModel<Produtos>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var produtosBanco = await connection.QueryFirstOrDefaultAsync<Produtos>("select * from Produtos where id = @Id", new { Id = produtosId });

                if (produtosBanco == null)
                {
                    response.Mensagem = "Nenhum Produto localizado!";
                    response.Status = false;
                    return response;
                }
                var produtosMapeado = _mapper.Map<Produtos>(produtosBanco);

                response.Dados = produtosMapeado;
                response.Mensagem = "Produto localizado com sucesso!";
            }
            return response;
        }

        async Task<ResponseModel<List<Produtos>>> IProdutosRepository.BuscarProduto()
        {
            ResponseModel<List<Produtos>> response = new ResponseModel<List<Produtos>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var produtosBancos = await connection.QueryAsync<Produtos>("select * from Produtos");

                if (produtosBancos.Count() <= 0)
                {
                    response.Mensagem = "Nenhum Produto localizado!";
                    response.Status = false;

                    return response;
                }

                var produtosMapeados = _mapper.Map<List<Produtos>>(produtosBancos);

                response.Dados = produtosMapeados;
                response.Mensagem = "Produto Localizados com suceso!";

            }
            return response;
        }



        async Task<ResponseModel<List<Produtos>>> IProdutosRepository.CriarProduto(Produtos produtosCriarDto)
        {
            ResponseModel<List<Produtos>> response = new ResponseModel<List<Produtos>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var produtosBanco = await connection.ExecuteAsync("insert into Produtos (Id, Nome, Qtd, Preco, Lote)" +
                    "values(@Id, @Nome, @Qtd, @Preco, @Lote)", produtosCriarDto);

                if (produtosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar um registro!";
                    response.Status = false;
                    return response;
                }

                var produto = await ListarProdutos(connection);

                var produtosMapeado = _mapper.Map<List<Produtos>>(produto);

                response.Dados = produtosMapeado;
                response.Mensagem = "Produtos listados com sucesso!";
            }
            return response;
        }


       async Task<ResponseModel<List<Produtos>>> IProdutosRepository.EditarProduto(Produtos produtosEditarDto)
        {
            ResponseModel<List<Produtos>> response = new ResponseModel<List<Produtos>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var produtosBanco = await connection.ExecuteAsync(
            "UPDATE Produtos " +
            "SET Nome = @Nome, " +
            "    Qtd = @Qtd, " +
            "    Preco = @Preco, " +
            "    Lote = @Lote  " +

            "WHERE Id = @Id",
            produtosEditarDto
);


                if (produtosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a edição!";
                    response.Status = false;
                    return response;
                }

                var produtos = await ListarProdutos(connection);

                var produtosMapeados = _mapper.Map<List<Produtos>>(produtos);

                response.Dados = produtosMapeados;
                response.Mensagem = "Produtos listados com sucesso!";
            }
            return response;
        }


        async Task<ResponseModel<List<Produtos>>> IProdutosRepository.Remover(int produtosId)
        {
            ResponseModel<List<Produtos>> response = new ResponseModel<List<Produtos>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var produtosBanco = await connection.ExecuteAsync("delete from Produtos where Id = @Id", new { @Id = produtosId });
                if (produtosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a remoção!";
                    response.Status = false;
                    return response;
                }

                var produtos = await ListarProdutos(connection);

                var produtosMapeados = _mapper.Map<List<Produtos>>(produtos);

                response.Dados = produtosMapeados;
                response.Mensagem = "Produtos listados com sucesso!";
            }
            return response;
        }
    }
}
        





 
    

       

   
