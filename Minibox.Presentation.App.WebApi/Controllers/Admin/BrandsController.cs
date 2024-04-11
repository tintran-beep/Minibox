using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minibox.Presentation.Core.Service.Infrastructure.Interface;
using Minibox.Presentation.Share.Model.ViewModel;

namespace Minibox.Presentation.App.WebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/brand")]
    public class BrandsController(
        IBrandService brandService) : ControllerBase
    {
        private readonly IBrandService _brandService = brandService;

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(BrandVM brand)
        {
            try
            {
                await _brandService.Create(brand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
