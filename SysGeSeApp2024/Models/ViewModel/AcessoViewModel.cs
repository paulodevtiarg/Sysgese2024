using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class AcessoListViewModel : BaseListViewModel
    {
        public AcessoListViewModel(List<AcessoViewModel>? acessos, List<TabelaViewModel>? tabelas, List<PerfilViewModel>? perfis, int? tabId, int? perfilId, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Acessos = acessos;
            TotalItens = totalItens;
            Status = status;
            Perfis = perfis;
            Tabelas = tabelas;
            IdTabela = tabId;
            IdPerfil = perfilId;
            
        }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }
        public int? IdTabela { get; set; }
        public virtual Tabela? Tabela { get; set; }

      
        public int? IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }
        public List<AcessoViewModel>? Acessos { get; set; }

        public List<TabelaViewModel>? Tabelas { get; set; }

        public List<PerfilViewModel>? Perfis { get; set; }
    }



    public class AcessoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário escolher uma TABELA")]
        public int? IdTabela { get; set; }
        public virtual Tabela? Tabela { get; set; }
        public bool TabelaVisualizar { get; set; } = false;
        public bool TabelaInserir { get; set; } = false;
        public bool TabelaAlterar { get; set; } = false;

        public bool TabelaExcluir { get; set; } = false;

        public string? TabelaObservacao { get; set; }
        [Required(ErrorMessage = "É necessário escolher um PERFIL")]
        public int? IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }


        public sbyte? Status { get; set; }

        public string StatusString { get;set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

      

        public List<TabelaViewModel>? Tabelas { get; set; }

        public List<PerfilViewModel>? Perfis { get; set; }
    }
}

