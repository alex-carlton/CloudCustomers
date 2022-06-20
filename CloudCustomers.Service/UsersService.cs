using CloudCustomers.Services.Models;
using System;
using System.Net.Http.Json;

namespace CloudCustomers.Services
{
    public interface IUsersService
    {
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List of User Data</returns>
        public Task<List<User>> GetAllUsers();
    }

    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await _httpClient
                .GetAsync("https://example.com/users");

            if (usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();
            }

            var users = await usersResponse.Content.ReadFromJsonAsync<List<User>>();

            if (users == null)
                throw new NullReferenceException(nameof(users));

            return users.ToList();
        }
    }
}