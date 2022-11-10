using ProjectV2.Common.Dtos.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface ICountryService
    {
        public Task<CountryDto> GetByIdAsync(int id);
        public Task<IList<CountryDto>> GetAllAsync();
        public Task<CountryDto> CreateCountryAsync(CountryUpdateDto countryUpdateDto);
        public Task UpdateCountryAsync(int id, CountryUpdateDto countryUpdateDto);
        public Task DeleteCountryAsync(int id);
    }
}
