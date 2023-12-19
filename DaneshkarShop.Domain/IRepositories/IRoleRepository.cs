using DaneshkarShop.Domain.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Domain.IRepositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetUserRolesByUserId(int userId);
    }
}
