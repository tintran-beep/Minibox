using Minibox.Presentation.Share.Model.Authenticate;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Core.Service.Infrastructure.Interface
{
    public interface ICategoryService
    {
        Task<ResponseVM> CreateAsync(RequestVM<CategoryVM> request);
    }
}
