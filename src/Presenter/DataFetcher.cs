using Database.Entities;
using System.Text.Json;

namespace Presenter
{
    internal class DataFetcher
    {
        private readonly HttpClient _httpClient;

        public DataFetcher()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://meter-iot-as-func.azurewebsites.net") };
        }

        public string DeviceId { get; set; }

        public async Task<MeterReading> FetchData()
        {
            var result = await _httpClient.GetAsync($"/api/devices/{DeviceId}");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MeterReading>(json) ?? new MeterReading();
            }
            else
            {
                return new MeterReading();
            }
        }
    }
}
