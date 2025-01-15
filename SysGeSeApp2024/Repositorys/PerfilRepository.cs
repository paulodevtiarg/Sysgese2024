using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(SysGeseDbContext context) : base(context) { }


        public async Task<(List<Perfil>? Perfis, int QtdTotalItens)> ObterPerfis(string descricao, sbyte status, string? ordenarPor, string? tipoOrdenacao, int paginaAtual, int qtdItensPagina)
        {
            IQueryable<Perfil> query = _db.Perfis.AsNoTracking();


            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.Descricao.Contains(descricao));
            }

            if (status != 2)
            {
                query = query.Where(f => f.Status.Equals(status));
            }
            // Aplicar ordenação dinâmica
            if (!string.IsNullOrWhiteSpace(ordenarPor))
            {
                ordenarPor = ordenarPor.ToLower();
                tipoOrdenacao = tipoOrdenacao?.ToLower() == "desc" ? "desc" : "asc"; // Padrão: ascendente

                query = ordenarPor switch
                {
                    "perfil" => tipoOrdenacao == "asc"
                        ? query.OrderBy(p => p.Descricao)
                        : query.OrderByDescending(p => p.Descricao),
                    _ => query // Sem ordenação se o campo for inválido
                };
            }
            else
            {

                // Ordenação padrão por Tabela.TabelaDesc (ascendente)
                query = query.OrderBy(p => p.Id);

            }
            int qtdTotalItens = await query.Select(x => x.Id).CountAsync();

            var lista = await query.
               Skip(paginaAtual * qtdItensPagina).
               Take(qtdItensPagina).ToListAsync();

            return (lista, qtdTotalItens);
        }
        public async Task<bool> VerificarUsoPerfil(int? idPerfil)
        {
            if (_db.Servidores.Where(x => x.IdPerfil == idPerfil).Count() > 0)
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
