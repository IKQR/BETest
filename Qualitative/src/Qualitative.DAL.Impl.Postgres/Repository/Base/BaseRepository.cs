using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qualitative.DAL.Abstract.IRepository.Base;

namespace Qualitative.DAL.Impl.Postgres.Repository.Base
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity>
    where TEntity : class
    {
        protected readonly QualitativeDbContext Context;
        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();


        public BaseRepository(QualitativeDbContext context)
        {
            Context = context;
        }


        public async Task<TEntity> Create(TEntity ent)
        {
            TEntity result = (await DbSet.AddAsync(ent)).Entity;

            await SaveAsync();

            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Update(TEntity ent)
        {
            DbSet.Update(ent);
            await SaveAsync();
        }

        public async Task Delete(TEntity ent)
        {
            DbSet.Remove(ent);
            await SaveAsync();
        }


        protected async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
