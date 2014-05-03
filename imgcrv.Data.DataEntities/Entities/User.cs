using System;
using System.Collections.Generic;

namespace imgcrv.Data.DataEntities.Entities
{
    public class User : EntityBase<User>
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public virtual IList<Image> Images { get; set; }
        public virtual IList<LogEvent> Log { get; set; }
    }
}