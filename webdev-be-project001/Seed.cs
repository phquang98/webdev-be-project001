using webdev_be_project001.Data;
using webdev_be_project001.Models;

namespace webdev_be_project001
{
    public class Seed
    {
        private readonly DataCtx dataContext;

        public Seed(DataCtx context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwnerTable.Any())
            {
                var pokemonOwners = new List<JoinPokemonOwner>()
                {
                    new JoinPokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            NameColumn = "Pikachu",
                            DOBColumn = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { NameColumn = "Electric" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    TitleColumn = "Pikachu",
                                    TextColumn = "Pickahu is the best pokemon, because it is electric",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Teddy",
                                        LastNameColumn = "Smith"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Pikachu",
                                    TextColumn = "Pickachu is the best a killing rocks",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Taylor",
                                        LastNameColumn = "Jones"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Pikachu",
                                    TextColumn = "Pickchu, pickachu, pikachu",
                                    RatingColumn = 1,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Jessica",
                                        LastNameColumn = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            NameColumn = "Jack London",
                            GymColumn = "Brocks Gym",
                            CountryColumn = new Country() { NameColumn = "Kanto" }
                        }
                    },
                    new JoinPokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            NameColumn = "Squirtle",
                            DOBColumn = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { NameColumn = "Water" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    TitleColumn = "Squirtle",
                                    TextColumn = "squirtle is the best pokemon, because it is electric",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Teddy",
                                        LastNameColumn = "Smith"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Squirtle",
                                    TextColumn = "Squirtle is the best a killing rocks",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Taylor",
                                        LastNameColumn = "Jones"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Squirtle",
                                    TextColumn = "squirtle, squirtle, squirtle",
                                    RatingColumn = 1,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Jessica",
                                        LastNameColumn = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            NameColumn = "Harry Potter",
                            GymColumn = "Mistys Gym",
                            CountryColumn = new Country() { NameColumn = "Saffron City" }
                        }
                    },
                    new JoinPokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            NameColumn = "Venasuar",
                            DOBColumn = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { NameColumn = "Leaf" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    TitleColumn = "Veasaur",
                                    TextColumn = "Venasuar is the best pokemon, because it is electric",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Teddy",
                                        LastNameColumn = "Smith"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Veasaur",
                                    TextColumn = "Venasuar is the best a killing rocks",
                                    RatingColumn = 5,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Taylor",
                                        LastNameColumn = "Jones"
                                    }
                                },
                                new Review
                                {
                                    TitleColumn = "Veasaur",
                                    TextColumn = "Venasuar, Venasuar, Venasuar",
                                    RatingColumn  = 1,
                                    ReviewerColumn = new Reviewer()
                                    {
                                        FirstNameColumn = "Jessica",
                                        LastNameColumn = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            NameColumn = "Ash Ketchum",
                            GymColumn = "Ashs Gym",
                            CountryColumn = new Country() { NameColumn = "Millet Town" }
                        }
                    }
                };
                dataContext.PokemonOwnerTable.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
