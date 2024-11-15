using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IUsuarioFiltroEmpresasRepository : IRepository<UsuarioFiltroEmpresas>
    {
        Task<List<UsuarioFiltroEmpresas>> ObterTodosUsuarioFiltroEmpresas();
    }
}
