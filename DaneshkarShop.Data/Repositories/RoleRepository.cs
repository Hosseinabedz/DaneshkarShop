using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        #region Ctor
        public RoleRepository(DaneshkarDbContext dbContext)
        {
            _context = dbContext;
        }

        public DaneshkarDbContext _context { get; }
        #endregion
        
        public async Task<List<Role>> GetUserRolesByUserId(int userId)
        {
            var roles = await _context.UserSelectedRoles
                            .Where(x => x.UserId == userId)
                            .Select(x => x.Role)
                            .ToListAsync();
            return roles;
        }
    }
}
