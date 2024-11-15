using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
 
    public interface IPerfilRepository : IRepository<Perfil>
    {

        Task<(List<Perfil>? Perfis, int QtdTotalItens)> ObterPerfis(string descricao, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);


    }
}
