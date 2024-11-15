using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        Task<List<Estado>> ObterTodos();
    }
}
