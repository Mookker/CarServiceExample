using CarService.AppCore.Constants;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarService.AppCore.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _client;

        public UsersService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.UsersClient);
        }
        public async Task<CarOwner> GetUserById(string userId)
        {
            return await _client.GetFromJsonAsync<CarOwner>($"api/v1/users/{userId}");
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

        public async Task UpdateUser(UpdateCarOwnerRequest request)
        {
            var result = await _client.PutAsJsonAsync("api/v1/users", request);
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(string userId)
        {
            var result = await _client.DeleteAsync($"api/v1/users/{userId}");
            result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<CarOwner>> GetUsers()
        {
            return await _client.GetFromJsonAsync<IEnumerable<CarOwner>>($"api/v1/users");
        }
    }
}
