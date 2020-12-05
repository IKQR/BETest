using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qualitative.DAL.Abstract.IRepository.Base
{
    public interface IBaseRepository<in TKey, TEntity>
    {
        //CREATE
        public Task<TEntity> Create(TEntity ent);

        //READ
        public Task<List<TEntity>> GetAll();
        public Task<TEntity> GetById(TKey id);

        //UPDATE
        public Task Update(TEntity ent);

        //DELETE
        public Task Delete(TEntity ent);
    }
}
