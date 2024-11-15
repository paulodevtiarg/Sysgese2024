using Microsoft.AspNetCore.Mvc.Rendering;
using SysGeSeApp2024.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class FuncaoListViewModel : BaseListViewModel
    {
        public FuncaoListViewModel(List<FuncaoViewModel>? funcoes, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Funcoes = funcoes;
            TotalItens = totalItens;
            Status = status;
           
        }
        public string Descricao { get; set; }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }
        public List<FuncaoViewModel>? Funcoes { get; set; }
              
        
       
    }
    public class FuncaoViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        public string Descricao { get; set; }

        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

     



    }
}
