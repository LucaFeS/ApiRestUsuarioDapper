using Domain.Entidades.Models;
using Domain.Models;

namespace Domain.Entidades.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<ResponseModel<List<Categoria>>> BuscarCategoria();
        Task<ResponseModel<Categoria>> BuscarPorId(int categoriaId);
        Task<ResponseModel<List<Categoria>>> CriarCategoria(Categoria categoriaCriarDto);
        Task<ResponseModel<List<Categoria>>> EditarCategoria(Categoria categoriaEditarDto);
        Task<ResponseModel<List<Categoria>>> Remover(int categoriaId);
    }
}
