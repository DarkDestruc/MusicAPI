using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;
using System.Reflection;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> _songs = new List<Song>
        {
        new Song
        {
            Id = 1,
            Title = "Yeah",
            Language = "English",
        },
        new Song
        {
            Id = 2,
            Title = "Still Waiting",
            Language="English",
        },
        new Song
        {
            Id=3,
            Title = "Entre Nosotros",
            Language = "Spanish",
        },
        };

        [HttpGet]
        public IEnumerable<Song> GetAllSongs()
        {
            return _songs;
        }

    }
}
