﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShoppingCartMvcUI.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required] //свойство должно быть обязательно установлено
        [MaxLength(40)]
        public string? BookName { get; set; }


        [Required] //свойство должно быть обязательно установлено
        [MaxLength(40)]
        public string? AuthorName { get; set; }

        [Required]
        public double Price { get; set; }
        
        public string? Image { get; set; }
       
        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }

        public List<CartDetail> CartDetail { get; set; }

        public Stock Stock { get; set; }

        [NotMapped]
        public string GenreName { get; set; }

        public int Quantity { get; set; }
    }
}
