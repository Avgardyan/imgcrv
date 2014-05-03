using System;

namespace imgcrv.Data.DataEntities.Entities
{
    public class Image : EntityBase<Image>
    {
        public virtual string Path { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime UploadedAt { get; set; }
    }
}
