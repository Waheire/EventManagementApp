using EventManagementApp.Entities;
using EventManagementApp.Request;

namespace EventManagementApp.Services.IServices
{
    public interface IUser
    {
        //shape of user - crud operations
        //Add user 
        Task<string> AddUserAsync(User user);
        //update user 
        Task<string> UpdateUserAsync(User user);
        //Delete a user
        Task<string> DeleteUserAsync(User user);
        //Get all users
        Task<IEnumerable<User>> GetAllUsersAsync();
        //Get one user
        Task<User> GetUserByIdAsync(Guid id);
        //Book for an event
       Task<string> BookEvent(BookEvent bookEvent);
    }
}
