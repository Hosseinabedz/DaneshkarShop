using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class RoleService : IRoleService
    {
        #region Ctor
        public RoleService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IRoleRepository _roleRepository { get; }
        public IUserRepository _userRepository { get; }
        #endregion
        public async Task<List<Role>> GetUserRolesByUserId(int userId)
        {
            return await _roleRepository.GetUserRolesByUserId(userId);
        }
        public async Task<bool> IsUserAdmin(int userId)
        {
            // check user is super admin?
            var user = await _userRepository.GetUserById(userId);
            if (user.SuperAdmin == true) return true;
            
            // check user is admin?
            var listOfRoles = await GetUserRolesByUserId(userId);
            foreach (var role in listOfRoles)
            {
                if (role.RoleUniqueName == "Admin") return true;
            }
            return false;
        }
    }
}