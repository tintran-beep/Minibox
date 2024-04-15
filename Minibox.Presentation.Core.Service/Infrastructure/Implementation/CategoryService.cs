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
    public class CategoryService(
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IUnitOfWork<MainDbContext> mainUnitOfWork)
        : BaseService(mapper, appSettings, mainUnitOfWork), ICategoryService
    {
        public async Task<ResponseVM> CreateAsync(RequestVM<CategoryVM> request)
        {
            var response = new ResponseVM();
            try
            {
                //upload image

                //validate
                if (request.Data == null
                    || string.IsNullOrWhiteSpace(request.Data.Name)
                    || string.IsNullOrWhiteSpace(request.Data.Description))
                {
                    throw new Exception($"Value can't be null.");
                }

                var existed = await _mainUnitOfWork.GetRepo<Category>().AnyAsync(x => x.Name.Equals(request.Data.Name, StringComparison.OrdinalIgnoreCase));
                if (existed)
                    throw new Exception($"Category {request.Data.Name} already existed.");

                var category = new Category()
                {
                    Name = request.Data.Name,
                    Description = request.Data.Description,
                    ParentId = request.Data.ParentId,
                };

                _mainUnitOfWork.GetRepo<Category>().Insert(category);

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
