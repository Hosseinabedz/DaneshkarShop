using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entities.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor
        public UserRepository(DaneshkarDbContext dbContext)
        {
            _context = dbContext;
        }

        private readonly DaneshkarDbContext _context;


        #endregion

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChanges();
        }
        public async Task<bool> IsExistsUserByMobile(string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetUserByMobile(string mobile)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile && u.IsDelete == false);
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.UserId == id);
        }
        public async Task<List<User>> GetAllUsresAsync()
        {
            var listOfUsers = await _context.Users
                                            .Where(u => !u.IsDelete)
                                            .ToListAsync();
            return listOfUsers;

        }
        public async Task<List<int>> GetListOfRolesIdByUserId(int userId)
        {
            return await _context.UserSelectedRoles
                                 .Where(e => e.UserId == userId)
                                 .Select(e => e.RoleId)
                                 .ToListAsync();
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }

}
