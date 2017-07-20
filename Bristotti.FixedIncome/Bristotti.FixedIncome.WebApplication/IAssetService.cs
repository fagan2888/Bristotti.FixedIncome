using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bristotti.FixedIncome.WebApplication
{
    [ServiceContract]
    public interface IAssetService
    {
        [OperationContract]
        string Get(Guid id);

        [OperationContract]
        string GetByTicker(string ticker);
    }
}
