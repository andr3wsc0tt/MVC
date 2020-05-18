using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAlbum.Data;
using AspNetCoreAlbum.Models;
using Microsoft.EntityFrameworkCore;
namespace AspNetCoreAlbum.Services
{
    public class AlbumItemService : IAlbumItemService
    {
        private readonly ApplicationDbContext _context;
        public AlbumItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AlbumItem[]> GetIncompleteAlbumsAsync()
        {
            return await _context.Items
            .Where(x => x.ReleaseDate.Year < 2000)
            .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(AlbumItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.ReleaseDate = new DateTime();
            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
            if (item == null) return false;

            item.ReleaseDate = new DateTime(1995, 1, 1, 12, 0, 0);
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1; // One entity should have been updated
        }

    }
}