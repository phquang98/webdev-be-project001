﻿using webdev_be_project001.Data;
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
                            Name = "Pikachu",
                            DOB = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { Name = "Electric" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pickahu is the best pokemon, because it is electric",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Teddy",
                                        LastName = "Smith"
                                    }
                                },
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pickachu is the best a killing rocks",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Taylor",
                                        LastName = "Jones"
                                    }
                                },
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pickchu, pickachu, pikachu",
                                    Rating = 1,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Jessica",
                                        LastName = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack London",
                            Gym = "Brocks Gym",
                            Country = new Country() { Name = "Kanto" }
                        }
                    },
                    new JoinPokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Squirtle",
                            DOB = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { Name = "Water" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Squirtle",
                                    Text = "squirtle is the best pokemon, because it is electric",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Teddy",
                                        LastName = "Smith"
                                    }
                                },
                                new Review
                                {
                                    Title = "Squirtle",
                                    Text = "Squirtle is the best a killing rocks",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Taylor",
                                        LastName = "Jones"
                                    }
                                },
                                new Review
                                {
                                    Title = "Squirtle",
                                    Text = "squirtle, squirtle, squirtle",
                                    Rating = 1,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Jessica",
                                        LastName = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry Potter",
                            Gym = "Mistys Gym",
                            Country = new Country() { Name = "Saffron City" }
                        }
                    },
                    new JoinPokemonOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Venasuar",
                            DOB = new DateTime(1903, 1, 1),
                            PokemonCategoryClt = new List<JoinPokemonCategory>()
                            {
                                new JoinPokemonCategory
                                {
                                    Category = new Category() { Name = "Leaf" }
                                }
                            },
                            ReviewClt = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Veasaur",
                                    Text = "Venasuar is the best pokemon, because it is electric",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Teddy",
                                        LastName = "Smith"
                                    }
                                },
                                new Review
                                {
                                    Title = "Veasaur",
                                    Text = "Venasuar is the best a killing rocks",
                                    Rating = 5,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Taylor",
                                        LastName = "Jones"
                                    }
                                },
                                new Review
                                {
                                    Title = "Veasaur",
                                    Text = "Venasuar, Venasuar, Venasuar",
                                    Rating = 1,
                                    Reviewer = new Reviewer()
                                    {
                                        FirstName = "Jessica",
                                        LastName = "McGregor"
                                    }
                                },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash Ketchum",
                            Gym = "Ashs Gym",
                            Country = new Country() { Name = "Millet Town" }
                        }
                    }
                };
                dataContext.PokemonOwnerTable.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
