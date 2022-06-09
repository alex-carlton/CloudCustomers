using CloudCustomers.Services.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Id = 1,
                    Name = "Test User 1",
                    Email = "test.user.1@example.com",
                    Address = new Address()
                    {
                        Street = "123 Main St",
                        City = "Somewhere",
                        ZipCode = "123456"
                    }
                },
                new User
                {
                    Id = 2,
                    Name = "Test User 2",
                    Email = "test.user.2@example.com",
                    Address = new Address()
                    {
                        Street = "900 Main St",
                        City = "Somewhere",
                        ZipCode = "654321"
                    }
                },
                new User
                {
                    Id = 2,
                    Name = "Test User 3",
                    Email = "test.user.3@example.com",
                    Address = new Address()
                    {
                        Street = "321 Main St",
                        City = "Somewhere",
                        ZipCode = "615243"
                    }
                }
            };
    }
}