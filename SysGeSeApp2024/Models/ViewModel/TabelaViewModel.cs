using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class TabelaListViewModel : BaseListViewModel
    {
        public TabelaListViewModel(List<TabelaViewModel>? tabelas, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Tabelas = tabelas;
            TotalItens = totalItens;
            Status = status;

        }
        public string? TabelaDesc { get; set; }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }
        public List<TabelaViewModel>? Tabelas { get; set; }


    }
    public class TabelaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo DESCRIÇÃO é obrigatório.")]
        public string TabelaDesc { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }
    }
}
