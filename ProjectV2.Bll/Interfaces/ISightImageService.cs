using ProjectV2.Common.Dtos.SightImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface ISightImageService
    {
        public Task<SightImageDto> GetByIdAsync(int id);
        public Task<IList<SightImageDto>> GetAllOfSightAsync(int sightId);
        public Task<SightImageDto> CreateSightImageAsync(SightImageUpdateDto sightImageUpdateDto);
        public Task UpdateSightImageAsync(SightImageUpdateDto sightImageUpdateDto);
        public Task DeleteSightImageAsync(int sightId, string sightImageName);
    }
}
