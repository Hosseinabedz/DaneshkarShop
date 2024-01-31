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
using DaneshkarShop.Application.DTOs.AdminSide.User;
using DaneshkarShop.Domain.Entities.Role;
using DaneshkarShop.Application.DTOs.AdminSide.LandingPage;

namespace DaneshkarShop.Application.Services.Implementation
{
    #region Ctor

    #endregion
    public class UserService : IUserService
    {
        #region Ctor
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public IUserRepository _userRepository { get; }
        public IRoleRepository _roleRepository { get; }
        #endregion
        public async Task AddUserToTheDataBase(User user)
        {
            await _userRepository.AddUser(user);
        }
        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            User user = new User()
            {
                UserName = userDTO.Username,
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                Mobile = userDTO.Mobile.Trim(),
                CreateDate = DateTime.Now
            };
            return user;
        }
        public async Task<bool> IsExistsUserByMobile(string mobile)
        {
            return await _userRepository.IsExistsUserByMobile(mobile.Trim());
        }
        public async Task<bool> RegisterUser(UserRegisterDTO userDTO)
        {
            bool IsExsitUser = await IsExistsUserByMobile(userDTO.Mobile);
            if (IsExsitUser)
            {
                return false;
            }
            var user = FillUserEntity(userDTO);
            await AddUserToTheDataBase(user);
            return true;
        }
        public async Task<User> GetUserByMobile(string mobile)
        {
            return await _userRepository.GetUserByMobile(mobile.Trim());
        }
        public async Task<bool> LoginUser(UserLoginDTO userDTO) 
        {
            var user = await GetUserByMobile(userDTO.Mobile);
            if (user == null)
            {
                return false;
            }
            return true;
        }
        public async Task<List<ListOfUsersDTO>> GetAllUsresAsync()
        {
            var users = await _userRepository.GetAllUsresAsync();
            List<ListOfUsersDTO> returnModel = new();
            foreach (var user in users)
            {
                ListOfUsersDTO usersDTO = new()
                {
                    UserId = user.UserId,
                    CreateDate = user.CreateDate,
                    Mobile = user.Mobile,
                    UserName = user.UserName,
                    Avatar = user.Avatar,
                };
                returnModel.Add(usersDTO);
            }
            return returnModel;
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }
        public async Task<EditUserAdminSideDTO?> FillEditUserAdminSideDTO(int id)
        {
            // Get user by Id
            var user = await _userRepository.GetUserById(id);
            // map to the DTO
            if (user == null) return null;
            EditUserAdminSideDTO returnModel = new()
            {
                UserId = user.UserId,
                Mobile = user.Mobile,
                UserName = user.UserName,
                OriginalAvatar = user.Avatar,
            };
            // get user roles
            returnModel.CurrentUserRolesId = await _userRepository.GetListOfRolesIdByUserId(user.UserId);
            return returnModel;
        }
        public async Task<bool> EditUserAdminSide(EditUserAdminSideDTO model, List<int>? SelectedRoles)
        {

            // Get user by Id
            var userOrigin = await _userRepository.GetUserById(model.UserId);
            if (userOrigin == null) return false;
            // Update user
            userOrigin.UserName = model.UserName;
            userOrigin.Mobile = model.Mobile;
            if (model.Avatar != null)
            {
                //Save New Image
                userOrigin.Avatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.Avatar.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", userOrigin.Avatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.Avatar.CopyTo(stream);
                }
            }
            // Update roles
            List<UserSelectedRole> userSelectedRoles = await _userRepository.GetListOfUserSelectedRolesByUserId(model.UserId);
            if (userSelectedRoles != null && userSelectedRoles.Any())
            {
                _userRepository.DeleteRangeOfUserSelectedRoles(userSelectedRoles);
            }
            if (SelectedRoles != null && SelectedRoles.Any())
            {
                foreach (var roleId in SelectedRoles)
                {

                    UserSelectedRole userSelectedRole = new()
                    {
                        RoleId = roleId,
                        UserId = model.UserId,
                    };

                    await _roleRepository.AddUserSelectedRole(userSelectedRole);
                }
            }

            _userRepository.UpdateUser(userOrigin);
            await _userRepository.SaveChanges();
            return true;
        }
        public async Task<bool> DeleteUser(int id, CancellationToken cancellation)
        {
            var deleteUser = await _userRepository.GetUserById(id);
            if (deleteUser == null) return false;
            deleteUser.IsDelete = true;

            _userRepository.UpdateUser(deleteUser);
            await _userRepository.SaveChanges();
            return true;
        }
        public async Task<LandingPageModelDTO> FillLandingPageModelDTO()
        {
            var result = new LandingPageModelDTO()
            {
                CountOfActiveUsers = await _userRepository.GetCountOfActiveUsers()
            };
            return result;
        }
    }
}
