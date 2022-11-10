using ProjectV2.Common.Dtos.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface ICityService
    {
        public Task<CityDto> GetByIdAsync(int id);
        public Task<IList<CityDto>> GetAllAsync();
        public Task<IList<CityDto>> GetAllOfCountryAsync(string countryName);
        public Task<CityDto> CreateCityAsync(CityUpdateDto cityUpdateDto);
        public Task UpdateCityAsync(int id, CityUpdateDto cityUpdateDto);
        public Task DeleteCityAsync(int id);
    }
}
