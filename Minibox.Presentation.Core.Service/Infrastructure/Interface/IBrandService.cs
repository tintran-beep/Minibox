using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Core.Service.Infrastructure.Interface
{
    public interface IBrandService
    {
        Task CreateNewBrand(BrandVM brand);
    }
}
