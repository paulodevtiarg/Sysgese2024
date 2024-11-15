using SysGeSeApp2024.Models;
namespace SysGeSeApp2024.Interfaces
{
    public interface IAcessoRepository : IRepository<Acesso>
    {

        Task<(List<Acesso>? Acessos, int QtdTotalItens)> ObterAcessos(string tabdescricao, string perfil, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);
    }
}
