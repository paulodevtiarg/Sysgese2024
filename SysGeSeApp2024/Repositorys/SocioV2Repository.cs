using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public class SocioV2Repository : Repository<SociosV2Model>, ISociosV2Repository
    {
        public SocioV2Repository(SysGeseDbContext context) : base(context) { }
        public async Task<List<SociosV2Model>> ObterTodosSociosV2()
        {
            return await _db.Socios2.AsNoTracking().ToListAsync();
        }
    }
}
