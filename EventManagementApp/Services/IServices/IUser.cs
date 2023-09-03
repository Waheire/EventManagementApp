using EventManagementApp.Entities;
using EventManagementApp.Request;
using EventManagementApp.Response;

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
        //get registred users for an event
        Task<IEnumerable<GetRegisteredUsers>> GetRegisteredUsersToAnEventAsync();
        //Get a registred user for an event
        Task<GetRegisteredUsers> GetRegistredUserToAnEventAsync(Guid id);
    }
}
