using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IFilltroRepository
    {

        Task<List<FiltroModel>> ObterTodosFiltros();

    }
}
