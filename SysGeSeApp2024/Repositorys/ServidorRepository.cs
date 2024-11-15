using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class ServidorRepository : Repository<Servidor>, IServidorRepository
    {
        public ServidorRepository(SysGeseDbContext context) : base(context) { }

        public  async Task<(List<Servidor>? Servidores, int QtdTotalItens)> ObterServidores(string nome, string matricula, string cidade, string unidade, string perfil, string funcao, sbyte status, string ordenarPor, string tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            IQueryable<Servidor> query = _db.Servidores.AsNoTracking();


            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(matricula))
            {
                query = query.Where(p => p.Matricula.Contains(matricula));
            }

            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(p => p.Cidade.Contains(cidade));
            }
            if (!string.IsNullOrEmpty(unidade))
            {
                query = query.Where(p => p.Unidade.Nome.Contains(unidade));
            }
            if (!string.IsNullOrEmpty(perfil))
            {
                query = query.Where(p => p.Perfil.Descricao.Contains(unidade));
            }

            if (!string.IsNullOrEmpty(funcao))
            {
                query = query.Where(p => p.Perfil.Descricao.Contains(unidade));
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
