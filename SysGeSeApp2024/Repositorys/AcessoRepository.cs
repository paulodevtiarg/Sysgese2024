using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class AcessoRepository : Repository<Acesso>, IAcessoRepository 
    {
        public AcessoRepository(SysGeseDbContext context):base(context) { }

        public async Task<(List<Acesso>? Acessos, int QtdTotalItens)> ObterAcessos(int? tabelaId,int? perfilId, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            IQueryable<Acesso> query = _db.Acessos.AsNoTracking();


            if (tabelaId.HasValue && tabelaId.Value > 0)
            {
                query = query.Where(p => p.Tabela.Id == tabelaId);
            }

            if (perfilId.HasValue && perfilId.Value > 0)
            {
                query = query.Where(p => p.Perfil.Id == perfilId);
            }

            if (status != 2)
            {
                query = query.Where(f => f.Status.Equals(status));
            }

            int qtdTotalItens = await query.CountAsync();

            var lista = await query.
               Include(p=> p.Tabela).
               Include(p=>p.Perfil).
               OrderBy(p => p.Perfil).
               Skip(paginaAtual * qtdItensPagina).
               Take(qtdItensPagina).ToListAsync();

            return (lista, qtdTotalItens);
        }

        public async Task<List<Acesso>?> ObterTabelasPorPerfil(int idPerfil)
        {
            IQueryable<Acesso> query = _db.Acessos.AsNoTracking();

            var lista = await query.Include(p => p.Tabela).Include(p => p.Perfil).Where(x=>x.IdPerfil == idPerfil).ToListAsync();
            return lista;
        }

        public async Task<bool> VerificaAcesso(int? idPerfil, int? idTabela)
        {
            if(_db.Acessos.Where(x=>x.IdPerfil == idPerfil && x.IdTabela == idTabela).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
