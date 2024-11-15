using Org.BouncyCastle.Bcpg.OpenPgp;
using SysGeSeApp2024.Models;
namespace SysGeSeApp2024.Interfaces
{
    public interface IServidorRepository : IRepository<Servidor>
    {
        Task<(List<Servidor>? Servidores, int QtdTotalItens)> ObterServidores(string nome, string matricula, string cidade, string unidade, string perfil, string funcao,  sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);

    }
}
