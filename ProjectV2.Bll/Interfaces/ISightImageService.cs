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
        public Task<RoomImageDto> GetByIdAsync(int id);
        public Task<IList<RoomImageDto>> GetAllOfSightAsync(int sightId);
        public Task<RoomImageDto> CreateSightImageAsync(RoomImageUpdateDto sightImageUpdateDto);
        public Task UpdateSightImageAsync(RoomImageUpdateDto sightImageUpdateDto);
        public Task DeleteSightImageAsync(int sightId, string sightImageName);
    }
}
