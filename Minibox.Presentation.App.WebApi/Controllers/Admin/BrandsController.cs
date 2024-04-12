using Microsoft.AspNetCore.Mvc;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;
using Minibox.Presentation.Share.Model.Authenticate;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.App.WebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController(
        IBrandService brandService) : ControllerBase
    {
        private readonly IBrandService _brandService = brandService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(RequestVM<BrandVM> request)
        {
            var response = await _brandService.CreateAsync(request);
            return Ok(response);
        }
    }
}
