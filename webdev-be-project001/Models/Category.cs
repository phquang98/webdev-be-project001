﻿using System.ComponentModel.DataAnnotations;

namespace webdev_be_project001.Models
{
    public class Category
    {
        [Key]
        public int IdColumn { get; set; }
        public string NameColumn { get; set; }
        public ICollection<JoinPokemonCategory> PokemonCategoryClt { get; set; }
    }
}
