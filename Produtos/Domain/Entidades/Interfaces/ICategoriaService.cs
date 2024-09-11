﻿using Domain.Entidades.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades.Interfaces
{
    public interface ICategoriaService
    {
        Task<ResponseModel<List<Categoria>>> BuscarCategoria();
        Task<ResponseModel<Categoria>> BuscarPorId(int categoriaId);
        Task<ResponseModel<List<Categoria>>> CriarCategoria(Categoria categoriaCriarDto);
        Task<ResponseModel<List<Categoria>>> EditarCategoria(Categoria categoriaEditarDto);
        Task<ResponseModel<List<Categoria>>> Remover(int categoriaId);
    }
}