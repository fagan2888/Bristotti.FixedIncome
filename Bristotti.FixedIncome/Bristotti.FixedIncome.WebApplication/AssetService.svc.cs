using System;
using Bristotti.FixedIncome.Model;
using Bristotti.FixedIncome.Model.Repositories;
using Bristotti.FixedIncome.Model.Services;

namespace Bristotti.FixedIncome.WebApplication
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRespository;

        public AssetService(IAssetRepository assetRespository)
        {
            _assetRespository = assetRespository ?? throw new ArgumentNullException(nameof(assetRespository));
        }

        public Asset Get(Guid id)
        {
            return _assetRespository.Get(id);
        }

        public Asset GetByTicker(string ticker)
        {
            return _assetRespository.GetByTicker(ticker);
        }

        public bool IsValid(Asset asset)
        {
            return true;
        }
    }
}