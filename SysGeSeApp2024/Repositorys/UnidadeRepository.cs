using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(SysGeseDbContext context) : base(context) { }
        public async  Task<(List<Unidade>? Unidades, int QtdTotalItens)> ObterUnidades(string cidade, string estado, string nome, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            IQueryable<Unidade> query = _db.Unidades.AsNoTracking();

            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(p => p.Cidade.Contains(cidade));
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(p => p.Estado == estado);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.Nome.Contains(nome));
            }

            if (status != 2)
            {
                query = query.Where(f => f.Status.Equals(status));
            }

            int qtdTotalItens = await query.CountAsync();
            var lista2 = await query.ToListAsync();

            var lista = await query.
               OrderBy(p => p.Id).
               Skip(paginaAtual * qtdItensPagina).
               Take(qtdItensPagina).ToListAsync();

            return (lista, qtdTotalItens);
        }
    }
}
