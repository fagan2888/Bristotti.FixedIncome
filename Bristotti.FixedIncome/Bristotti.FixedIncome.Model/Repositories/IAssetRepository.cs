using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bristotti.FixedIncome.Model.Repositories
{
    public interface IAssetRepository
    {
        Asset Get(Guid id);
        Asset GetByTicker(string ticker);
    }
}
