using AutoMapper;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context.Main;
using Minibox.Presentation.Core.Data.Context.Main.Schema.Dbo.Table;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;
using Minibox.Presentation.Share.Model;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.Core.Service.Infrastructure.Implementation
{
    public class BrandService(
        IMapper mapper, 
        IOptions<AppSettings> appSettings, 
        IUnitOfWork<MainDbContext> mainUnitOfWork) 
        : BaseService(mapper, appSettings, mainUnitOfWork), IBrandService
    {
        public async Task Create(BrandVM brand)
        {
            var entity = _mapper.Map<Brand>(brand);
            _mainUnitOfWork.GetRepo<Brand>().Insert(entity);
            await _mainUnitOfWork.SaveChangesAsync();
        }
    }
}
