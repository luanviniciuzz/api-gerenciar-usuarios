using ApiCadastro.Data;
using ApiCadastro.Dto.Usuario;
using ApiCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastro.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if ( usuario == null)
                {
                    response.Mensagem = "Usuário não localizado!";
                    return response;
                }

                response.Dados = usuario;
                response.Mensagem = "Usuário localizado!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                if(usuarios.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário cadastrado!";
                    return response;
                }

                response.Dados = usuarios;
                response.Mensagem = "Usuarios listados!";

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

            return response;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (!VerificaSeExisteEmailUsuarioRepetido(usuarioCriacaoDto))
                {
                    response.Mensagem = "Email/Usuario já cadastrado.";
                    return response;
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    return response;
                }

                _context.Remove(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = $"Usuário {usuario.Nome} removido com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        private bool VerificaSeExisteEmailUsuarioRepetido(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(item => item.Email == usuarioCriacaoDto.Email || item.Usuario == usuarioCriacaoDto.Usuario);

            if(usuario != null)
            {
                return false;
            }

            return true;
        }
    }
}
