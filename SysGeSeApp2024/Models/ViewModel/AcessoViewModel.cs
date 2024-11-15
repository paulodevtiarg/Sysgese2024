namespace SysGeSeApp2024.Models.ViewModel
{
    public class AcessoListViewModel : BaseListViewModel
    {
        public AcessoListViewModel(List<AcessoViewModel>? acessos, List<TabelaViewModel>? tabelas, List<PerfilViewModel>? perfis, sbyte status, int totalItens, int paginaAtual, int qtdItensPagina) : base(totalItens, paginaAtual, qtdItensPagina)
        {
            Acessos = acessos;
            TotalItens = totalItens;
            Status = status;
            Perfis = perfis;
            Tabelas = tabelas;
            
        }
        public int TotalItens { get; set; }
        public sbyte? Status { get; set; }
        public int IdTabela { get; set; }

        public string? TabelaDesc { get; set; }
        public string? PerfilDesc { get; set; }
        public int IdPerfil { get; set; }
        public List<AcessoViewModel>? Acessos { get; set; }

        public List<TabelaViewModel>? Tabelas { get; set; }

        public List<PerfilViewModel>? Perfis { get; set; }
    }



    public class AcessoViewModel
    {
        public int Id { get; set; }

        public int IdTabela { get; set; }
        public virtual Tabela? Tabela { get; set; }
        public sbyte? TabelaVisualizar { get; set; }
        public sbyte? TabelaInserir { get; set; }
        public sbyte? TabelaAlterar { get; set; }

        public sbyte? TabelaExcluir { get; set; }

        public string? TabelaObservacao { get; set; }
        public int IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }


        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }

        public List<TabelaViewModel>? Tabelas { get; set; }

        public List<PerfilViewModel>? Perfis { get; set; }
    }
}

