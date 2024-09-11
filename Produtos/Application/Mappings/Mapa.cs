using Application.Dto;
using AutoMapper;
using Domain.Entidades.Models;
using Domain.Models;
using WebApi.Dto;

namespace Application.Mappings
{ 
    public class Mapa : Profile
    {
        public Mapa()
        {

            //Produto
            CreateMap<Produtos, ProdutoDto>();
            CreateMap<Produtos, ProdutoCriarDto>();
            CreateMap<Produtos, ProdutoEditarDto>();





            //ResponseModel Produto
            CreateMap<ResponseModel<List<Produtos>>, ResponseModel<List<ProdutoDto>>>();
            CreateMap<ResponseModel<List<Produtos>>, ResponseModel<List<ProdutoCriarDto>>>();
            CreateMap<ResponseModel<List<Produtos>>, ResponseModel<List<ProdutoEditarDto>>>();
            CreateMap<ResponseModel<Produtos>,ResponseModel<ProdutoDto>>();



            //Categoria
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Categoria, CategoriaCriarDto>();
            CreateMap<Categoria, CategoriaEditarDto>();





            //ResponseModel Categoria
            CreateMap<ResponseModel<List<Categoria>>, ResponseModel<List<CategoriaDto>>>();
            CreateMap<ResponseModel<List<Categoria>>, ResponseModel<List<CategoriaCriarDto>>>();
            CreateMap<ResponseModel<List<Categoria>>, ResponseModel<List<CategoriaEditarDto>>>();
            CreateMap<ResponseModel<Categoria>, ResponseModel<CategoriaDto>>();
        }

      
    }
}
