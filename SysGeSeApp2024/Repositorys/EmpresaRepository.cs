using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class EmpresaRepository : Repository<EmpresaModel>, IEmpresaRepository
    {
        public EmpresaRepository(SysGeseDbContext context) : base(context) { }
        public async Task<List<EmpresaModel>> ObterTodosEmpresas()
        {
            return await _db.Empresas.AsNoTracking().ToListAsync();
        }
    }
}
