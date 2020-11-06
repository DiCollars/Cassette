using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cassette.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Cassette.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _db;
        public HomeController(UserContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index(string Id)
        {
            //Change the way
            DirectoryInfo path = new DirectoryInfo(@"A:\Stack\Projects\petProjects\Mvc\Cassette\Cassette\wwwroot\music");
            FileInfo[] Files = path.GetFiles("*.mp3");
            List<string> FullNamesOfSongs = new List<string>();

            foreach (var song in Files)
            {
                FullNamesOfSongs.Add(song.Name);
            }

            if (Id == default)
            {
                Id = FullNamesOfSongs.FirstOrDefault();
            }

            ViewBag.SongName = Id;

            return View(FullNamesOfSongs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
