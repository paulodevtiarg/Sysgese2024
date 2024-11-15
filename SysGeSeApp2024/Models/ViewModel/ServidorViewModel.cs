using SysGeSeApp2024.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class ServidorListViewModel : BaseListViewModel
    {
        public ServidorListViewModel(List<ServidorViewModel>? servidores, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Servidores = servidores;
            TotalItens = totalItens;
            Status = status;

        }


        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }

        public List<ServidorViewModel>? Servidores { get; set; }
    }
    public class ServidorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo MATRICULA é obrigatório.")]
        public string Matricula { get; set; }


        [Required(ErrorMessage = "O campo LOGIN é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo SENHA é obrigatório.")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "O campo CONFIRMAR SENHA é obrigatório.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
        public string? ConfirmarSenha { get; set; }
                
        public string? Telefone { get; set; }

        public string? Celular { get; set; }
              
        public string? Sexo { get; set; }
               
        public string? Logradouro { get; set; }

             
        public string? Cep { get; set; }
               
        public string? Bairro { get; set; }
               
        public string? Numero { get; set; }

        [Required(ErrorMessage = "O campo CIDADE é obrigatório.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "O campo EMAIL é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo E-MAIL é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo UNIDADE é obrigatório.")]
        public int IdUnidade { get; set; }

        public virtual Unidade? Unidade { get; set; }

        [Required(ErrorMessage = "O campo PERFIL é obrigatório.")]
        public int IdPerfil { get; set; }

        public virtual Perfil? Perfil { get; set; }

        [Required(ErrorMessage = "O campo fUNCAO é obrigatório.")]
        public int IdFuncao { get; set; }

        public virtual Funcao? Funcao { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }
    }
}
