using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreAlbum.Services;
using AspNetCoreAlbum.Models;

namespace AspNetCoreAlbum.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumItemService _albumItemService;
        public AlbumController(IAlbumItemService albumItemService)
        {
            _albumItemService = albumItemService;
        }
        public async Task<IActionResult> Index()
        {
            // Get to-do items from database
            // Put items into a model
            // Pass the view to a model and render

            var items = await _albumItemService.GetIncompleteAlbumsAsync();

            var model = new AlbumViewModel()
            {
                Items = items 
            };

            return View(model);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(AlbumItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _albumItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
        if (id == Guid.Empty)
        {
            return RedirectToAction("Index");
        }
        
        var successful = await _albumItemService.MarkDoneAsync(id);
        Console.WriteLine(successful);
        if (!successful)
        {
            return BadRequest("Could not mark item as done.");
        }
        return RedirectToAction("Index");
        }
    }
}
