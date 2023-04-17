using System.Linq;
using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DataCtx _ctx;

        public CategoryRepo(DataCtx ctxHere)
        {
            _ctx = ctxHere;
        }

        public bool CategoryExists(int cateIdParam)
        {
            return _ctx.CategoryTable.Any(cate => cate.IdColumn == cateIdParam);
        }

        public bool CreateCategory(Category cateParam)
        {
            // Change Tracker
            _ctx.Add(cateParam);
            return Save();
        }

        public bool DeleteCategory(Category cateIdParam)
        {
            _ctx.Remove(cateIdParam);
            return Save();
        }

        public Category GetCategory(int cateIdParam)
        {
            return _ctx.CategoryTable.FirstOrDefault(cate => cate.IdColumn == cateIdParam);
        }

        public ICollection<Category> GetCategoryClt()
        {
            return _ctx.CategoryTable.ToList();
        }

        public ICollection<Pokemon> GetPokemonCltByCategory(int cateIdParam)
        {
            var queryRes = _ctx.PokemonCategoryTable
                .Where(pokeCate => pokeCate.CategoryId == cateIdParam)
                .Select(cate => cate.Pokemon)
                .ToList();
            return queryRes;
        }

        public bool Save()
        {
            var saved = _ctx.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category cateParam)
        {
            _ctx.Update(cateParam);
            return Save();
        }
    }
}
