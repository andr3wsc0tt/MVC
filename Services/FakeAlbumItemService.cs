/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAlbum.Models;
namespace AspNetCoreAlbum.Services
{
    public class FakeAlbumItemService : IAlbumItemService
    {
        public Task<AlbumItem[]> GetIncompleteAlbumsAsync()
        {
            var item1 = new AlbumItem
            {
                Title = "Chocolate Starfish",
                ReleaseDate = new DateTime(2001, 1, 1, 12, 0, 0)
            };
            var item2 = new AlbumItem
            {
                Title = "Ice Ice Baby",
                ReleaseDate = new DateTime(1985, 1, 1, 12, 0, 0)
            };
            return Task.FromResult(new[] { item1, item2 });
        }
    }
}
*/