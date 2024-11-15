using Microsoft.EntityFrameworkCore;
using SysGeSeApp2024.Data;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Repositorys
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new ()
    {
        protected readonly SysGeseDbContext _db;
        protected readonly DbSet<TEntity> _debSet;

        protected Repository(SysGeseDbContext db)
        {
            _db = db;
            _debSet = db.Set<TEntity>();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            _debSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _debSet.ToListAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _debSet.Update(entity);
            await SaveChanges();
        }

     
            public void Dispose()
            {
                _db?.Dispose();
            }
        

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _debSet.FindAsync(id);
        }

        //public virtual async Task Remover(int id)
        //{
        //    _debSet.Remove(new TEntity { Id = id });
        //    await SaveChanges();
        //}

        public virtual async Task Remover(TEntity entity)
        {
            _debSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
