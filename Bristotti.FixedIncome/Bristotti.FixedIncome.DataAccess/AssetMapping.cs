using Bristotti.FixedIncome.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bristotti.FixedIncome.DataAccess
{
    public class AssetMapping : ClassMapping<Asset>
    {
        public AssetMapping()
        {
            Id(p => p.Id, m => m.Generator(Generators.Guid));
            Property(p => p.IssueDate);
            Property(p => p.MaturityDate);
            Property(p => p.Notional);
            Property(p => p.Ticker);
            Property(p => p.CurrencyId);
        }
    }
}
