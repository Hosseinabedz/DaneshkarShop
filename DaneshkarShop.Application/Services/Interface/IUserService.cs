using DaneshkarShop.Application.DTOs.AdminSide.User;
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
        Task AddUserToTheDataBase(User user);
        Task<bool> IsExistsUserByMobile(string mobile);
        User FillUserEntity(UserRegisterDTO userDTO);
        Task<bool> RegisterUser(UserRegisterDTO userDTO);
        Task<User> GetUserByMobile(string mobile);
        Task<bool> LoginUser(UserLoginDTO userDTO);
        Task<List<ListOfUsersDTO>> GetAllUsresAsync();
        Task<User?> GetUserById(int id);
        Task<EditUserAdminSideDTO?> FillEditUserAdminSideDTO(int id);
        Task<bool> EditUserAdminSide(EditUserAdminSideDTO model, List<int> SelectedRoles);

    }
}
