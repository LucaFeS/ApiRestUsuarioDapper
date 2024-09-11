using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;
using WebApi.Dto;

public class ProdutoApplication : IProdutoApplication
{
    private readonly IMapper _mapper;
    private readonly IProdutosService _produtoService;

    public ProdutoApplication(IMapper mapper, IProdutosService produtoService)
    {
        _mapper = mapper;
        _produtoService = produtoService;
    }

    public async Task<ResponseModel<Produtos>> BuscarPorId(int produtosId)
    {
        var retorno = await _produtoService.BuscarPorId(produtosId);
        return _mapper.Map<ResponseModel<Produtos>>(retorno);
    }

    public async Task<ResponseModel<List<Produtos>>> BuscarProduto()
    {
        var retorno = await _produtoService.BuscarProduto();
        return _mapper.Map<ResponseModel<List<Produtos>>>(retorno); ;
    }

    public async Task<ResponseModel<List<Produtos>>> CriarProduto(Produtos produtosCriarDto)
    {
        var retorno = await _produtoService.CriarProduto(produtosCriarDto);
        return _mapper.Map<ResponseModel<List<Produtos>>>(retorno);
    }

    public async Task<ResponseModel<List<Produtos>>> EditarProduto(Produtos produtosEditarDto)
    {
        var retorno = await _produtoService.EditarProduto(produtosEditarDto);
        return _mapper.Map<ResponseModel<List<Produtos>>>(retorno);
    }

    public async Task<ResponseModel<List<Produtos>>> Remover(int produtosId)
    {
        var retorno = await _produtoService.Remover(produtosId);
        return _mapper.Map<ResponseModel<List<Produtos>>>(retorno);
    }
}

    