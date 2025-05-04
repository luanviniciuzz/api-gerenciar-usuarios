using System.ComponentModel.DataAnnotations;

namespace ApiCadastro.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "Digite o Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        [Required(ErrorMessage = "Digite o Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Confirmação da Senha"), Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
