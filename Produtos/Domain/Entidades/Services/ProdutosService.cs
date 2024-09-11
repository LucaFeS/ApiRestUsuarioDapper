using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;

public class ProdutosService : IProdutosService
{
    private readonly IProdutosRepository _produtosRepository;

    public ProdutosService(IProdutosRepository produtoRepository)
    {
        _produtosRepository = produtoRepository;
    }

    public Task<ResponseModel<Produtos>> BuscarPorId(int produtosId)
    {
        return _produtosRepository.BuscarPorId(produtosId);
    }

    public Task<ResponseModel<List<Produtos>>> BuscarProduto()
    {
        return _produtosRepository.BuscarProduto();
    }

    public Task<ResponseModel<List<Produtos>>> CriarProduto(Produtos produtosCriarDto)
    {
        return _produtosRepository.CriarProduto(produtosCriarDto);
    }

    public Task<ResponseModel<List<Produtos>>> EditarProduto(Produtos produtosEditarDto)
    {
        return _produtosRepository.EditarProduto(produtosEditarDto);
    }

    public Task<ResponseModel<List<Produtos>>> Remover(int produtosId)
    {
        return _produtosRepository.Remover(produtosId);
    }

    // Construtor que injeta a interface IUsuarioService



}
