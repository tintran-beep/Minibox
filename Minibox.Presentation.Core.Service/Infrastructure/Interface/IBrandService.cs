using Minibox.Presentation.Share.Model.Authenticate;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Core.Service.Infrastructure.Interface
{
    public interface IBrandService
    {
        Task<ResponseVM> CreateAsync(RequestVM<BrandVM> request);
        Task<ResponseVM> UpdateAsync(RequestVM<BrandVM> request);
        Task<ResponseVM> DeleteAsync(RequestVM<BrandVM> request);
        Task<ResponseVM> GetBrandAsync(RequestVM<BrandVM> request);
        Task<ResponseVM> GetBrandsAsync(RequestVM<BrandFilterVM> request);
    }
}
