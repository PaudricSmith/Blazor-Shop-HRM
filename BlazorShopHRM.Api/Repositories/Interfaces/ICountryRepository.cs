using BlazorShopHRM.Shared.Domain;


namespace BlazorShopHRM.Api.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
