using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface ICategoryRepo
    {
        ICollection<Category> GetCategoryClt();
        Category GetCategory(int cateIdParam);
        ICollection<Pokemon> GetPokemonCltByCategory(int cateIdParam);
        bool CategoryExists(int cateIdParam);
    }
}
