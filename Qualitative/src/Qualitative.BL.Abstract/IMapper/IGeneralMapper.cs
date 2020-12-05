namespace Qualitative.BL.Abstract.IMapper
{
    public interface IGeneralMapper<TEntity, TModel>
    {
        public TModel Map(TEntity entity);
        public TEntity MapBack(TModel model);
        public TEntity MapUpdate(TModel model, TEntity entity);
    }
}
