using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;
using WebApi.Dto;

public class CategoriaApplication : ICategoriaApplication
{
    private readonly IMapper _mapper;
    private readonly ICategoriaService _categoriaService;

    public CategoriaApplication(IMapper mapper, ICategoriaService categoriaService)
    {
        _mapper = mapper;
        _categoriaService = categoriaService;
    }

    public async Task<ResponseModel<List<Categoria>>> BuscarCategoria()
    {
        var retorno = await _categoriaService.BuscarCategoria();
        return _mapper.Map<ResponseModel<List<Categoria>>>(retorno);
    }

  

 

    public async Task<ResponseModel<List<Categoria>>> CriarCategoria(Categoria categoriaCriarDto)
    {
        var retorno = await _categoriaService.CriarCategoria(categoriaCriarDto);
        return _mapper.Map<ResponseModel<List<Categoria>>>(retorno);
    }


    public async Task<ResponseModel<List<Categoria>>> EditarCategoria(Categoria categoriaEditarDto)
    {
        var retorno = await _categoriaService.EditarCategoria(categoriaEditarDto);
        return _mapper.Map<ResponseModel<List<Categoria>>>(retorno);
    }

 

   

    async Task<ResponseModel<Categoria>> ICategoriaApplication.BuscarPorId(int categoriaId)
    {
        var retorno = await _categoriaService.BuscarPorId(categoriaId);
        return _mapper.Map<ResponseModel<Categoria>>(retorno);
    }

    async Task<ResponseModel<List<Categoria>>> ICategoriaApplication.Remover(int categoriaId)
    {
        var retorno = await _categoriaService.Remover(categoriaId);
        return _mapper.Map<ResponseModel<List<Categoria>>>(retorno);
    }
}

    