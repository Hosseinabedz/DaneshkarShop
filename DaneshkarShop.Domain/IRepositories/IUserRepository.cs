using DaneshkarShop.Domain.Entities.Role;
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
        Task<List<int>> GetListOfRolesIdByUserId(int userId);
        void UpdateUser(User user);
        Task<List<UserSelectedRole>> GetListOfUserSelectedRolesByUserId(int userId);
        void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles);
        Task<int> GetCountOfActiveUsers();
    }
}
