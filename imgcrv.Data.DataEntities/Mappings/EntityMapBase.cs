using FluentNHibernate.Mapping;

namespace imgcrv.Data.DataEntities.Mappings
{
    public abstract class EntityMapBase<TEntity> : ClassMap<TEntity>
        where TEntity : class, IEntity<int>
    {
        public EntityMapBase()
        {
            Id(x => x.Id);
        }
    }
}
