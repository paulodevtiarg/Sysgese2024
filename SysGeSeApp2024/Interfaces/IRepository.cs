using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(int id);

        Task<List<TEntity>> ObterTodos();
        Task Adicionar(TEntity entity);

        Task Atualizar(TEntity entity);

        Task Remover(TEntity entity);
        Task<int> SaveChanges();
    }
}
