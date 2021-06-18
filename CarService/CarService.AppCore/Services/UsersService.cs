using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using CarService.AppCore.Constants;
using CarService.AppCore.Models;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _client;

        public UsersService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.UsersClient);
        }
        public Task<CarOwner> GetUserById(string userId)
        {
            return _client.GetFromJsonAsync<CarOwner>($"api/v1/users/{userId}");
        }

        public async Task<CarOwner> CreateUser(CreateCarOwnerRequest request)
        {
            var result = await _client.PostAsJsonAsync("api/v1/users", request);
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<CarOwner>();
        }

        public async Task<CarOwner> GetUserByCarId(string carId)
        {
            var result = await _client.GetAsync($"api/v1/users?carId={carId}");
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<CarOwner>();
        }

        public async Task<CarOwner> UpdateUser(UpdateCarOwnerRequest request)
        {
            var result = await _client.PutAsJsonAsync("api/v1/users", request);
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<CarOwner>();
        }

        public async Task<CarOwner> DeleteUser(string userId)
        {
            var result = await _client.DeleteAsync($"api/v1/users/{userId}");
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<CarOwner>();
        }
    }
}
