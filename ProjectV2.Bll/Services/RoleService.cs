using AutoMapper;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Roles;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;
        private readonly IMapper _mapper;

        public RoleService(IRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<IList<RoleDto>> GetAllAsync()
        {
            var roles = _repository.GetAllAsync();
            IList<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var r in await roles)
            {
                roleDtos.Add(_mapper.Map<RoleDto>(r));
            }
            return roleDtos;
        }

        public async Task<RoleDto> CreateRoleAsync(RoleUpdateDto roleUpdateDto)
        {
            var role = _mapper.Map<Role>(roleUpdateDto);
            if (_repository.ExistInDbByProperties(role, nameof(role.Name)))
            {
                throw new ExistInDbException();
            }
            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(roleUpdateDto, role);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
