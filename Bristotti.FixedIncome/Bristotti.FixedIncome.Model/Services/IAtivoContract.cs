using System;
using System.ServiceModel;

namespace Bristotti.FixedIncome.Model.Services
{
    [ServiceContract]
    public interface IAssetService
    {
        [OperationContract]
        Asset Get(Guid id);

        [OperationContract]
        Asset GetByTicker(string ticker);
    }
}