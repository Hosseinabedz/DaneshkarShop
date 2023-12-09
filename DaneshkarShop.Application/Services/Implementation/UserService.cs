using DaneshkarShop.Application.DTOs.SiteSide.Account;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.IRepositories;
using DaneshkarShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegisterDTO = DaneshkarShop.Application.DTOs.SiteSide.Account.UserRegisterDTO;
using DaneshkarShop.Application.Utilities;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Ctor
        public UserService(IUserRepository repository)
        {
            _repo = repository;
        }

        public IUserRepository _repo { get; }
        #endregion

        public async void AddUserToTheDataBase(User user)
        {
            _repo.AddUser(user);
        }

        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            User user = new User()
            {
                UserName = userDTO.Username,
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                Mobile = userDTO.Mobile.Trim(),
                CreateDate = DateTime.Now,
            };
            return user;
        }

        public async Task<bool> IsExistsUserByMobile(string mobile)
        {
            return await _repo.IsExistsUserByMobile(mobile.Trim());
        }
        public async Task<bool> RegisterUser(UserRegisterDTO userDTO)
        {
            bool IsExsitUser = await IsExistsUserByMobile(userDTO.Mobile);
            if (IsExsitUser)
            {
                return false;
            }
            var user = FillUserEntity(userDTO);
            AddUserToTheDataBase(user);
            return true;
        }
        

    }

}
