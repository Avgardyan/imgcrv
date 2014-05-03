using NHibernate;

namespace imgcrv.Data.DataContracts
{
    public interface ISessionFactoryProvider
    {
        ISessionFactory SessionFactory { get; }

        ISession Open();
    }
}
