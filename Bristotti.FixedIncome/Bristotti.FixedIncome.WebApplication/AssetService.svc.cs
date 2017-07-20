using Bristotti.FixedIncome.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Bristotti.FixedIncome.WebApplication.Model;

namespace Bristotti.FixedIncome.WebApplication
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRespository;

        public AssetService(IAssetRepository assetRespository)
        {
            _assetRespository = assetRespository ?? throw new ArgumentNullException(nameof(assetRespository));
        }

        public AssetDTO Get(Guid id)
        {
            return Transformer.Transform(_assetRespository.Get(id));
        }

        public AssetDTO GetByTicker(string ticker)
        {
            return Transformer.Transform(_assetRespository.GetByTicker(ticker));
        }
    }
}
