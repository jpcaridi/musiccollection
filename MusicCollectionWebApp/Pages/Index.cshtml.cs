using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly string TEST_LIBRARY_NAME = "TEST_LIBRARY";
        private static IMusicCollection _mMusicCollection;
        private static IAlbumLibrary _mAlbumLibrary;
        public string LibraryName => _mAlbumLibrary?.LibraryName;
        public void OnGet()
        {
            _mMusicCollection = Driver.CreateXmlMusicCollection();
            _mAlbumLibrary = MusicCollectionController.Controller.ReadLibrary(_mMusicCollection.Persistance, TEST_LIBRARY_NAME);
        }

        public IReadOnlyList<IAlbum> Albums()
        {
            return _mAlbumLibrary.Albums;
        }
    }
}

