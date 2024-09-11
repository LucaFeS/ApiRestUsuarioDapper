using Domain.Entidades.Models;
using Domain.Models;

namespace Domain.Entidades.Interfaces
{
    public interface IProdutosService
    {
        Task<ResponseModel<List<Produtos>>> BuscarProduto();
        Task<ResponseModel<Produtos>> BuscarPorId(int produtosId);
        Task<ResponseModel<List<Produtos>>> CriarProduto(Produtos produtosCriarDto);
        Task<ResponseModel<List<Produtos>>> EditarProduto(Produtos produtosEditarDto);
        Task<ResponseModel<List<Produtos>>> Remover(int produtosId);
    }
}
