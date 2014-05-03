using System;

namespace imgcrv.Data.DataEntities.Entities
{
    public class LogEvent : EntityBase<LogEvent>
    {
        public virtual string EventType { get; set; }
        public virtual DateTime EventTime { get; set; }
        public virtual string EventDescription { get; set; }
        public virtual string IP { get; set; }
        public virtual User User { get; set; }
    }
}