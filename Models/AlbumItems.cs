using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreAlbum.Models
{
    public class AlbumItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}