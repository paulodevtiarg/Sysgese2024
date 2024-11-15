using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface ISociosV2Repository : IRepository<SociosV2Model>
    {
        Task<List<SociosV2Model>> ObterTodosSociosV2();
    }
}
