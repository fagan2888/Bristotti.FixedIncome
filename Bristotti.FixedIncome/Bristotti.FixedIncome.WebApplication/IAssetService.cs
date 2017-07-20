using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Bristotti.FixedIncome.WebApplication.Model;

namespace Bristotti.FixedIncome.WebApplication
{
    [ServiceContract]
    public interface IAssetService
    {
        [OperationContract]
        AssetDTO Get(Guid id);

        [OperationContract]
        AssetDTO GetByTicker(string ticker);
    }
}
