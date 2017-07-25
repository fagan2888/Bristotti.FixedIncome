using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bristotti.FixedIncome.Model;
using Bristotti.FixedIncome.Model.Repositories;
using NHibernate;

namespace Bristotti.FixedIncome.DataAccess.Repositories
{
    public class AssetRepository : RepositoryBase, IAssetRepository
    {
        public AssetRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public Asset Get(Guid id)
        {
            return Session.Get<Asset>(id);
        }

        public Asset GetByTicker(string ticker)
        {
            return Session.QueryOver<Asset>().Where(a => a.Ticker == ticker).List().FirstOrDefault();
        }
    }
}
