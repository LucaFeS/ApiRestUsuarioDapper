using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Interfaces;
using Domain.Models;
using WebApi.Dto;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IMapper _mapper;
    private readonly IUsuarioService _usuarioService;

    public UsuarioApplication(IMapper mapper, IUsuarioService usuarioService)
    {
        _mapper = mapper;
        _usuarioService = usuarioService;
    }

    public async Task<ResponseModel<List<UsuarioCriarDto>>> CriarUsuario(Usuario usuarioCriarDto)
    {
        var retorno = await _usuarioService.CriarUsuario(usuarioCriarDto);
        return _mapper.Map<ResponseModel<List<UsuarioCriarDto>>>(retorno);
    }

    public async Task<ResponseModel<List<UsuarioDto>>> Remover(int usuarioId)
    {
        var retorno = await _usuarioService.Remover(usuarioId);
        return _mapper.Map<ResponseModel<List<UsuarioDto>>>(retorno);
    }

    async Task<ResponseModel<UsuarioDto>> IUsuarioApplication.BuscarPorId(int usuarioId)
    {
        var retorno = await _usuarioService.BuscarPorId(usuarioId);
        return _mapper.Map<ResponseModel<UsuarioDto>>(retorno);
    }

    async Task<ResponseModel<List<UsuarioDto>>> IUsuarioApplication.BuscarUsuario()
    {
        var retorno = await _usuarioService.BuscarUsuario();
        return _mapper.Map<ResponseModel<List<UsuarioDto>>>(retorno);
    }

    async Task<ResponseModel<List<UsuarioEditarDto>>> IUsuarioApplication.EditarUsuario(Usuario usuarioEditarDto)
    {
        var retorno = await _usuarioService.EditarUsuario(usuarioEditarDto);
        return _mapper.Map<ResponseModel<List<UsuarioEditarDto>>>(retorno);
    }
}
