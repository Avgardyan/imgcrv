using imgcrv.Data.DataContracts;

using NHibernate;

namespace imgcrv.Data.Data
{
    public class Repository : GenericRepositoryBase<int>, IRepository
    {
        public Repository(ISessionFactoryProvider sessionFactoryProvider)
            : base(sessionFactoryProvider)
        {
        }

        public Repository(ISession session)
            : base(session)
        {
        }
    } 
}
