using AutoMapper;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using ProjectV2.Common.Exceptions;
using ProjectV2.Common.Dtos.Users;
using Microsoft.EntityFrameworkCore;

namespace ProjectV2.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IList<UserDto>> GetAllAsync()
        {
            var users = _repository.GetAllAsync();
            var userDtos = new List<UserDto>();
            foreach (var u in await users)
            {
                userDtos.Add(_mapper.Map<UserDto>(u));
            }
            return userDtos;
        }

        public bool UserExistByUsername(string username)
        {
            return _repository
                    .GetIQueryableAll()
                    .Where( u => u.Username == username )
                    .Count() > 0;
        }

        public bool UserExistByEmail(string email)
        {
            return _repository
                    .GetIQueryableAll()
                    .Where(u => u.Email == email)
                    .Count() > 0;
        }

        public async Task<UserDto> CreateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.RoleId = 2;
            if ( _repository.ExistInDbByEntityWithProperties(user, nameof(user.Username)))
            {
                throw new ExistInDbException();
            } 
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(userUpdateDto, user);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
