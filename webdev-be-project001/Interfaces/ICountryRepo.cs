using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface ICountryRepo
    {
        ICollection<Country> GetCountryClt();
        Country GetCountry(int ctryIdParam);
        Country GetCountryByOwner(int ownerIdParam);
        ICollection<Owner> GetOwnersFromACountry(int ctryIdParam);
        bool CountryExists(int ctryIdParam);
        bool CreateCountry(Country ctryParam);
        bool UpdateCountry(Country ctryParam);
        bool Save();
    }
}
