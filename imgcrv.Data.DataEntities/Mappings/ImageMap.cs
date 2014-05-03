using imgcrv.Data.DataEntities.Entities;

namespace imgcrv.Data.DataEntities.Mappings
{
    public class ImageMap : EntityMapBase<Image>
    {
        public ImageMap()
        {
            Map(m => m.Path).Not.Nullable();
            Map(m => m.UploadedAt).Not.Nullable();
            
            References(m => m.User).Not.Nullable();
        }
    }
}
