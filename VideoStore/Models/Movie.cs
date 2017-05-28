using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Movie's Name")]
        public string Name { get; set; }

        [Display(Name = "Relase date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        #region Navigation Properties
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        #endregion
    }
}