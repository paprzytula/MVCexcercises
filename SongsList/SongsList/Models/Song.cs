using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SongsList.Helpers;

namespace SongsList.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required(ErrorMessage ="Please enter the songs name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter a year")]
        [RangeUntilCurrentYear(1700, ErrorMessage = "Year must be between 1700 and current year")]
        public int? Year { get; set; }
        [Required(ErrorMessage ="Please enter the rating")]
        [Range(1,5, ErrorMessage = "Rating must be set between 1 and 5")]
        public int? Rating { get; set; }
        [Required(ErrorMessage ="Please enter genre")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string Slug => Name.Replace(' ', '-').ToLower() + '-' + Year.ToString();
    }
}
