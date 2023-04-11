using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IPokemonRepo
    {
        ICollection<Pokemon> GetPokemonClt();
    }
}
