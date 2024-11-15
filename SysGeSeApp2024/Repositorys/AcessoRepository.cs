using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class AcessoRepository : Repository<Acesso>, IAcessoRepository 
    {
        public AcessoRepository(SysGeseDbContext context):base(context) { }

        public async Task<(List<Acesso>? Acessos, int QtdTotalItens)> ObterAcessos(string tabdescricao,string perfil, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            IQueryable<Acesso> query = _db.Acessos.AsNoTracking();


            if (!string.IsNullOrEmpty(tabdescricao))
            {
                query = query.Where(p => p.Tabela.Id.Equals(int.Parse(tabdescricao)));
            }

            if (!string.IsNullOrEmpty(perfil))
            {
                query = query.Where(p => p.Perfil.Descricao.Contains(perfil));
            }

            if (status != 2)
            {
                query = query.Where(f => f.Status.Equals(status));
            }

            int qtdTotalItens = await query.CountAsync();

            var lista = await query.
               Include(p=> p.Tabela).
               Include(p=>p.Perfil).
               OrderBy(p => p.Id).
               Skip(paginaAtual * qtdItensPagina).
               Take(qtdItensPagina).ToListAsync();

            return (lista, qtdTotalItens);
        }
    }
}
