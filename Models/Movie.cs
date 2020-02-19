using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string SubTitle { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Year { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}
