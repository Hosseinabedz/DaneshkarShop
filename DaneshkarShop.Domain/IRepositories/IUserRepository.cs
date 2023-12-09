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
    }
}
