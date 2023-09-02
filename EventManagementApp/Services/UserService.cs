﻿using EventManagementApp.Data;
using EventManagementApp.Entities;
using EventManagementApp.Request;
using EventManagementApp.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Services
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Created successfully";
        }

        public async Task<string> BookEvent(BookEvent bookEvent)
        {
            var user = await _context.Users.Where(x => x.Id == bookEvent.UserId).FirstOrDefaultAsync();
            var eventItem = await _context.Events.Where(x => x.EventId == bookEvent.EventId).FirstOrDefaultAsync();
            if (user != null && eventItem != null)
            {
                //book event
                user.Events.Add(eventItem);
                await _context.SaveChangesAsync();
                return "Event booked Successfully";
            }
            throw new Exception("Invalid Id's");
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User Deleted successfully";
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User Updated successfully";
        }
    }
}
