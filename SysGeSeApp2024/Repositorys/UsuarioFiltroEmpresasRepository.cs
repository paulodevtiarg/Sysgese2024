using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class UsuarioFiltroEmpresasRepository : Repository<UsuarioFiltroEmpresas>, IUsuarioFiltroEmpresasRepository
    {
        public UsuarioFiltroEmpresasRepository(SysGeseDbContext context) : base(context) { }

        public async Task<List<UsuarioFiltroEmpresas>> ObterTodosUsuarioFiltroEmpresas()
        {
            return await _db.UsuariosFiltrosEmpresas.Include(e => e.User).Include(e=>e.Empresa).Include(e=>e.Filtro).AsNoTracking().ToListAsync();
        }
    }
}
