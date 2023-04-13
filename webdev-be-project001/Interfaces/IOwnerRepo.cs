using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IOwnerRepo
    {
        ICollection<Owner> GetOwnerClt();
        Owner GetOwner(int ownerIdParam);
        ICollection<Owner> GetOwnerOfAPokemon(int pokeIdParam);
        ICollection<Pokemon> GetPokemonByOwner(int ownerIdParam);
        bool OwnerExists(int ownerIdParam);
    }
}
