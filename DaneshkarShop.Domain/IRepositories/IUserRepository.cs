using DaneshkarShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<bool> IsExistsUserByMobile(string mobile);
        Task SaveChanges();
        Task<User> GetUserByMobile(string mobile);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetAllUsresAsync();
    }
}
