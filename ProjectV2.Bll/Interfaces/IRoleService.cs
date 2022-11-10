using ProjectV2.Common.Dtos.Roles;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface IRoleService
    {
        public Task<RoleDto> GetByIdAsync(int id);
        public Task<IList<RoleDto>> GetAllAsync();
        public Task<RoleDto> CreateRoleAsync(RoleUpdateDto roleUpdateDto);
        public Task UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto);
        public Task DeleteRoleAsync(int id);
    }
}
