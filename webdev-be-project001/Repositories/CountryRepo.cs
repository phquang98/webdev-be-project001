using AutoMapper;
using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class CountryRepo : ICountryRepo
    {
        private readonly DataCtx _ctx;

        public CountryRepo(DataCtx ctxHere)
        {
            _ctx = ctxHere;
        }

        public bool CountryExists(int ctryIdParam)
        {
            return _ctx.CountryTable.Any(ctry => ctry.IdColumn == ctryIdParam);
        }

        public ICollection<Country> GetCountryClt()
        {
            return _ctx.CountryTable.ToList();
        }

        public Country GetCountry(int ctryIdParam)
        {
            return _ctx.CountryTable.FirstOrDefault(ctry => ctry.IdColumn == ctryIdParam);
        }

        public Country GetCountryByOwner(int ownerIdParam)
        {
            return _ctx.OwnerTable
                .Where(own => own.IdColumn == ownerIdParam)
                .Select(ctry => ctry.CountryColumn)
                .FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int ctryIdParam)
        {
            return _ctx.OwnerTable.Where(own => own.CountryColumn.IdColumn == ctryIdParam).ToList();
        }

        public bool CreateCountry(Country ctryParam)
        {
            _ctx.Add(ctryParam);
            return Save();
        }

        public bool Save()
        {
            var saved = _ctx.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country ctryParam)
        {
            _ctx.Update(ctryParam);
            return Save();
        }
    }
}
