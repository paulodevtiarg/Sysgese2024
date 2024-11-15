using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        Task<(List<Unidade>? Unidades, int QtdTotalItens)> ObterUnidades(string cidade, string estado, string nome, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);
    }
}
