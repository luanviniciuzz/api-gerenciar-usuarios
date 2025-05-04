using ApiCadastro.Models;

namespace ApiCadastro.Services.Usuario
{
    public interface IUsuarioInterface
    {
        //retorno nome parametros
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id);

    }
}
