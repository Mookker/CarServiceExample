using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CarService.AppCore.Constants;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Services
{
    public class RepairOrdersService : IRepairOrdersService
    {
        private readonly HttpClient _client;

        public RepairOrdersService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.RepairOrdersClient);
        }

        public async Task<RepairOrder> CreateAsync(CreateRepairOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync("api/v1/repairOrders", request);
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<RepairOrder>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _client.DeleteAsync($"api/v1/repairOrders/{id}");
            result.EnsureSuccessStatusCode();
        }

        public async Task<RepairOrder> GetByCarId(Guid carId)
        {
            var result = await _client.GetAsync($"api/v1/repairOrders/?carId={carId}");
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<RepairOrder>();
        }

        public async Task<RepairOrder> GetById(Guid id)
        {
            var result = await _client.GetAsync($"api/v1/repairOrders/{id}");
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<RepairOrder>();
        }

        public async Task UpdateAsync(UpdateRepairOrderRequest request)
        {
            var result = await _client.PutAsJsonAsync("api/v1/repairOrders", request);
            result.EnsureSuccessStatusCode();
        }
    }
}
