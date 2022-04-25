using BibliotecaBackend.Domain.Entities;
using BibliotecaBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Infra.Data.WriteModel.Repositories
{
    public class WriteBaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity: Entity
    {
        protected DbSet<TEntity> DbSet;
        protected BibliotecaContext Context;

        public WriteBaseRepository(BibliotecaContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>(); 
        }

        public async Task Remove(TEntity aggregateRoot)
        {
            DbSet.Remove(aggregateRoot);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Update(TEntity aggregateRoot)
        {
            DbSet.Update(aggregateRoot);
            await Context.SaveChangesAsync();
        }

        public async Task AddAsync(TEntity aggregateRoot)
        {
            await DbSet.AddAsync(aggregateRoot);
            await Context.SaveChangesAsync();
        }
    }
}
