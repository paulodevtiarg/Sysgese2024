using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IEmpresaRepository :  IRepository<EmpresaModel>
    {

        Task<List<EmpresaModel>> ObterTodosEmpresas();
    }
}
