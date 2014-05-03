using imgcrv.Data.DataEntities.Entities;

namespace imgcrv.Data.DataEntities.Mappings
{
    public class UserMap : EntityMapBase<User>
    {
        public UserMap()
        {
            Map(m => m.Username).Length(20).Not.Nullable();
            Map(m => m.Password).Length(20).Not.Nullable();
            Map(m => m.Email).Length(100).Not.Nullable();
            Map(m => m.LastLogin).Not.Nullable();
            Map(m => m.CreatedAt).Not.Nullable();

            HasMany(m => m.Images);
        }
    }
}
