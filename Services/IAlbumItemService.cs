using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAlbum.Models;
namespace AspNetCoreAlbum.Services
{
    public interface IAlbumItemService
    {
        Task<AlbumItem[]> GetIncompleteAlbumsAsync();
        Task<bool> AddItemAsync(AlbumItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}