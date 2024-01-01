using DaneshkarShop.Domain.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IRoleService
    {
        Task<List<Role>> GetUserRolesByUserId(int userId);
        Task<bool> IsUserAdmin(int userId);
        Task<List<Role>> GetListOfRoles();
        Task AddUserSelectedRole(UserSelectedRole userSelectedRole);
    }
}
