using ProjectV2.Common.Dtos.Sights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface ISightService
    {
        public Task<RoomDto> GetByIdAsync(int id);
        public Task<ICollection<RoomDto>> GetAllOfCityAsync(string cityName);
        public Task<ICollection<RoomDto>> GetAllAsync();
        public Task<RoomDto> CreateSightAsync(RoomUpdateDto sightUpdateDto);
        public Task UpdateSightAsync(int id, RoomUpdateDto sightUpdateDto);
        public Task DeleteSightAsync(int id);
    }
}
