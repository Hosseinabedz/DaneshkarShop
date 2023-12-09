using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.Services.Interface
{
    public interface IUserService
    {
        void AddUserToTheDataBase(User user);
        Task<bool> IsExistsUserByMobile(string mobile);
        User FillUserEntity(UserRegisterDTO userDTO);
        Task<bool> RegisterUser(UserRegisterDTO userDTO);
    }
}
