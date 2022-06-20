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
                return new List<User>()
                { 
                    new User()
                    {
                        Id = 0,
                        Name = "Jack",
                        Email = "jack@text.com",
                        Address = new Address()
                        {
                            Street = "123 Main Street",
                            City = "Greenville",
                            ZipCode = "55555"
                        }
                    },
                    new User()
                    {
                        Id = 1,
                        Name = "Jill",
                        Email = "jill@text.com",
                        Address = new Address()
                        {
                            Street = "123 Main Street",
                            City = "Greenville",
                            ZipCode = "55555"
                        }
                    },
                };
            }

            var users = await usersResponse.Content.ReadFromJsonAsync<List<User>>();

            if (users == null)
                throw new NullReferenceException(nameof(users));

            return users.ToList();
        }
    }
}