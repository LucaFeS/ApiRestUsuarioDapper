using Application.Dto;
using Domain.Entidades.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Dto;

namespace Application.Interfaces
{
    public interface IProdutoApplication
    {
        

        Task<ResponseModel<List<Produtos>>> BuscarProduto();
        Task<ResponseModel<Produtos>> BuscarPorId(int produtosId);
        Task<ResponseModel<List<Produtos>>> CriarProduto(Produtos produtosCriarDto);
        Task<ResponseModel<List<Produtos>>> EditarProduto(Produtos produtosEditarDto);
        Task<ResponseModel<List<Produtos>>> Remover(int produtosId);

    }
}
