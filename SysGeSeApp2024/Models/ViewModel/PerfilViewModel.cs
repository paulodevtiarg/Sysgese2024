using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{
 
    public class PerfilListViewModel : BaseListViewModel
    {
        public PerfilListViewModel(List<PerfilViewModel>? perfis, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Perfis = perfis;
            TotalItens = totalItens;
            Status = status;

        }
        public string? Descricao { get;set; }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }
        public List<PerfilViewModel>? Perfis { get; set; }


    }
    public class PerfilViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo DESCRIÇÃO é obrigatório.")]
        public string Descricao { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }





    }
}
