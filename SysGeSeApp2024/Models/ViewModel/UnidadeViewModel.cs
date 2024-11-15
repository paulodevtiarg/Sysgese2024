using SysGeSeApp2024.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SysGeSeApp2024.Models.ViewModel
{

    public class UnidadeListViewModel: BaseListViewModel
    {
        public UnidadeListViewModel(List<UnidadeViewModel>? unidades, List<EstadoViewModel>? estados,  sbyte status, int totalItens, int paginaAtual, int qtdItensPagina):base(totalItens, paginaAtual, qtdItensPagina)
        {
            Unidades = unidades;
            TotalItens = totalItens;
            Status = status;
            Estados = estados;
        }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }


        public List<UnidadeViewModel>? Unidades { get; set; }
        public List<EstadoViewModel>? Estados { get; set; }

    }

    public class UnidadeViewModel
    {
        public int Id { get; set; }
                

        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        [MinLength(4, ErrorMessage = "O NOME deve ter 4 ou mais caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo LOGRADOURO é obrigatório.")]
        public string Logradouro { get; set; }

               
        public string? Cep { get; set; }


        [Required(ErrorMessage = "O campo BAIRRO é obrigatório.")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "O campo CIDADE é obrigatório.")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "O campo ESTADO é obrigatório.")]
        public string Estado { get; set; }

       
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        [StringLength(100, MinimumLength = 4, ErrorMessage ="O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string? Email { get; set; }

       
        public string? Cnpj { get; set; }

       
        public string? Ie { get; set; }

      
        public string? Telefone { get; set; }

      
        public string? Celular { get; set; }

      
        public string? Observacoes { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

        public List<EstadoViewModel>? Estados { get; set; }


    }
}
