using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class TabelaRepository : Repository<Tabela>, ITabelaRepository
    {
        public TabelaRepository(SysGeseDbContext context): base(context) { }

        public async Task<(List<Tabela>? Tabelas, int QtdTotalItens)> ObterTabelas(string descricao, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            
            IQueryable<Tabela> query = _db.Tabelas.AsNoTracking();

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.TabelaDesc.Contains(descricao));
            }

            if (status != 2)
            {
                query = query.Where(f => f.Status.Equals(status));
            }

            int qtdTotalItens = await query.CountAsync();

            var lista = await query.
               OrderBy(p => p.Id).
               Skip(paginaAtual * qtdItensPagina).
               Take(qtdItensPagina).ToListAsync();

            return (lista, qtdTotalItens);
        }
    }
}
