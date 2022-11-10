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
        public Task<SightDto> GetByIdAsync(int id);
        public Task<ICollection<SightDto>> GetAllOfCityAsync(string cityName);
        public Task<ICollection<SightDto>> GetAllAsync();
        public Task<SightDto> CreateSightAsync(SightUpdateDto sightUpdateDto);
        public Task UpdateSightAsync(int id, SightUpdateDto sightUpdateDto);
        public Task DeleteSightAsync(int id);
    }
}
