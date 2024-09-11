using Domain.Entidades.Interfaces;
using Domain.Entidades.Models;
using Domain.Models;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public Task<ResponseModel<List<Categoria>>> BuscarCategoria()
    {
        return _categoriaRepository.BuscarCategoria();
    }

    public Task<ResponseModel<Categoria>> BuscarPorId(int categoriaId)
    {
        return _categoriaRepository.BuscarPorId(categoriaId);
    }

    public Task<ResponseModel<List<Categoria>>> CriarCategoria(Categoria categoriaCriarDto)
    {
        return _categoriaRepository.CriarCategoria(categoriaCriarDto);
    }

    public Task<ResponseModel<List<Categoria>>> EditarCategoria(Categoria categoriaEditarDto)
    {
        return _categoriaRepository.EditarCategoria(categoriaEditarDto);
    }

    public Task<ResponseModel<List<Categoria>>> Remover(int categoriaId)
    {
        return _categoriaRepository.Remover(categoriaId);
    }

    // Construtor que injeta a interface IUsuarioService



}
