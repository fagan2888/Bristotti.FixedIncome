using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Bristotti.FixedIndome.UI.Model;

namespace Bristotti.FixedIndome.UI.Services
{
    [ServiceContract]
    public interface IAssetService
    {
        [OperationContract]
        Asset Get(Guid id);

        [OperationContract]
        Asset GetByTicker(string ticker);

        [OperationContract]
        bool IsValid(Asset asset);
    }
}
