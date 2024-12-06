using SysGeSeApp2024.Models;
namespace SysGeSeApp2024.Interfaces
{
    public interface IAcessoRepository : IRepository<Acesso>
    {
        Task<(List<Acesso>? Acessos, int QtdTotalItens)> ObterAcessos(int? tabelaId,int? perfilId, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina);
        Task<bool> VerificaAcesso(int? idPerfil, int? idTabela);

       
    }
}
