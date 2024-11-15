using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface ITabelaRepository : IRepository<Tabela>
    {
        Task<(List<Tabela>? Tabelas, int QtdTotalItens)> ObterTabelas(string descricao, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);

    }
}
