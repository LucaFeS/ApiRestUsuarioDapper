using Domain.Models;
using Domain.Interfaces.Interfaces;


public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    // Construtor que injeta a interface IUsuarioService
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<ResponseModel<Usuario>> BuscarPorId(int usuarioId)
    {
        return _usuarioRepository.BuscarPorId(usuarioId);
    }

    // Método que utiliza a instância injetada para chamar BuscarUsuario
    public Task<ResponseModel<List<Usuario>>> BuscarUsuario()
    {
        return _usuarioRepository.BuscarUsuario();

    }

    public Task<ResponseModel<List<Usuario>>> CriarUsuario(Usuario usuarioCriarDto)
    {
        return _usuarioRepository.CriarUsuario(usuarioCriarDto);
    }

    public Task<ResponseModel<List<Usuario>>> EditarUsuario(Usuario usuarioEditarDto)
    {
        return _usuarioRepository.EditarUsuario(usuarioEditarDto);
    }

    public Task<ResponseModel<List<Usuario>>> Remover(int usuarioId)
    {
        return _usuarioRepository.Remover(usuarioId);
    }
}
