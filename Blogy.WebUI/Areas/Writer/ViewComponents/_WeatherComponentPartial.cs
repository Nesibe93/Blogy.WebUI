using Blogy.WebUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogy.WebUI.Areas.Writer.ViewComponents
{
    public class _WeatherComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/forecast.json?q=istanbul&days=7&lang=TR"),
                Headers =
    {
        { "X-RapidAPI-Key", "37a7d71a37msh26fee5c4314fa6dp1d1043jsn0c26a3096c90" },
        { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(values);
            }
        }
    }
}
