using AutoMapper;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context.Main;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;
using Minibox.Presentation.Share.Model;
using Minibox.Presentation.Share.Model.Authenticate;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Core.Service.Infrastructure.Implementation
{
    public class BrandService(
        IMapper mapper, 
        IOptions<AppSettings> appSettings, 
        IUnitOfWork<MainDbContext> mainUnitOfWork) 
        : BaseService(mapper, appSettings, mainUnitOfWork), IBrandService
    {
        public async Task<ResponseVM> CreateAsync(RequestVM<BrandVM> request)
        {
            var response = new ResponseVM();
            try
            {
                //upload image

                //validate
                if (request.Data == null 
                    || string.IsNullOrWhiteSpace(request.Data.Name)
                    || string.IsNullOrWhiteSpace(request.Data.Origin)
                    || string.IsNullOrWhiteSpace(request.Data.Description))
                {
                    throw new Exception($"Value can't be null.");
                }

                var existed = await _mainUnitOfWork.GetRepo<Brand>().ExistAsync(x => x.Name.Equals(request.Data.Name, StringComparison.OrdinalIgnoreCase));
                if (existed)
                    throw new Exception($"Brand {request.Data.Name} already existed.");

                var brand = new Brand()
                {
                    Name = request.Data.Name,
                    Origin = request.Data.Origin,
                    Description = request.Data.Description,
                };

                _mainUnitOfWork.GetRepo<Brand>().Insert(brand);

                await _mainUnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Data = ex;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
