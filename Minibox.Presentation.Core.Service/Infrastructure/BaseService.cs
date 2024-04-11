using AutoMapper;
using Microsoft.Extensions.Options;
using Minibox.Presentation.Core.Data.Context.Main;
using Minibox.Presentation.Core.Data.Infrastructure.Interface;
using Minibox.Presentation.Share.Model;

namespace Minibox.Presentation.Core.Service.Infrastructure
{
    public class BaseService(
        IMapper mapper,
        IOptions<AppSettings> appSettings,
        IUnitOfWork<MainDbContext> mainUnitOfWork)
    {
        protected readonly IMapper _mapper = mapper;
        protected readonly AppSettings _appSettings = appSettings.Value;
        protected readonly IUnitOfWork<MainDbContext> _mainUnitOfWork = mainUnitOfWork;
    }
}
