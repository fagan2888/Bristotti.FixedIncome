using System;
using System.ServiceModel;
using Bristotti.FixedIncome.Model;

namespace Bristotti.FixedIncome.Contracts
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