using CloudCustomers.Services.Models;

namespace CloudCustomers.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }

    public class UsersService : IUsersService
    {
        public UsersService()
        {

        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}