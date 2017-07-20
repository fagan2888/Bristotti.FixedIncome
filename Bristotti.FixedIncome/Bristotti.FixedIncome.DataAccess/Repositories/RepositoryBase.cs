using System;
using NHibernate;

namespace Bristotti.FixedIncome.DataAccess.Repositories
{
    public abstract class RepositoryBase : IDisposable
    {
        private readonly ISessionFactory _sessionFactory;
        private ISession _session;

        protected RepositoryBase(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
        }

        protected ISession Session => _session ?? (_session = _sessionFactory.OpenSession());

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !Disposed)
            {
                _session?.Dispose();
                Disposed = true;
            }
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}