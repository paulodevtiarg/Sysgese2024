using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class FiltroRepository : Repository<FiltroModel>, IFilltroRepository
    {
        public FiltroRepository(SysGeseDbContext context) : base(context) { }
        public async Task<List<FiltroModel>> ObterTodosFiltros()
        {
            return await _db.Filtros.Include(e=>e.UsuarioFiltros).AsNoTracking().ToListAsync();
        }

      
       
    }
}
