using ApiAzureAi.Model.Requests;
using ApiAzureAi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAzureAi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ISearchService restService) : ControllerBase
    {

        [HttpPost(nameof(GetFilteredData))]
        public async Task<IActionResult> GetFilteredData([FromBody] SearchRequest search)
        {
            try
            {
                var response = await restService.GetSearch(search);

                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(
                    statusCode: StatusCodes.Status500InternalServerError,
                    new
                    {
                        detail = ex.Message
                    });
            }
        }
    }
}
