using imgcrv.Data.DataEntities.Entities;

namespace imgcrv.Data.DataEntities.Mappings
{
    public class LogEventMap : EntityMapBase<LogEvent>
    {
        public LogEventMap()
        {
            Map(m => m.EventType).Not.Nullable();
            Map(m => m.EventTime).Not.Nullable();
            Map(m => m.EventDescription).Not.Nullable();
            Map(m => m.IP).Not.Nullable();

            References(m => m.User);
        }
    }
}
