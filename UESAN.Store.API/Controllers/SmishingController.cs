using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UESAN.Store.CORE.DTOs;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmishingController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SmishingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(SmishingDTO smishingDTO)
        {

            var url = "https://smishinguesan.luischang.repl.co/api/v1/smishing";

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                title = smishingDTO.title,
                description = smishingDTO.description
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseJSON = await response.Content.ReadAsStringAsync();

                return Ok(responseJSON);
            }

            else
                return BadRequest("Error al enviar JSON");

        }
    }
}
