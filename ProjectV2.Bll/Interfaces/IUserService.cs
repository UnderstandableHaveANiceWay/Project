using ProjectV2.Common.Dtos.Users;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetByIdAsync(int id);
        public Task<IList<UserDto>> GetAllAsync();
        public bool UserExistByUsername(string username);
        public bool UserExistByEmail(string email);
        public Task<UserDto> CreateUserAsync(UserUpdateDto userUpdateDto);
        public Task UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        public Task DeleteUserAsync(int id);
    }
}
