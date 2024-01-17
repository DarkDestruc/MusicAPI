using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("{id}")]
        public Song GetSongById(int id)
        {
            return _songs.Find (song => song.Id == id);
             
        }

        [HttpPost]
        public IActionResult SaveSong([FromBody] Song newSong)
        { 
        _songs.Add(newSong);
            return Ok();
        }

        [HttpPut("{id}/{newTitle}")]
        public ActionResult UpdateSongTitle(int id, string newTitle)
        {
            var song = _songs.Find(song => song.Id == id);
            song .Title= newTitle;

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSong(int id,[FromBody] Song updateSong)
        {
            var song = _songs.Find(song => song.Id == id);
            song.Title = updateSong.Title;
            song.Language= updateSong.Language;

            return Ok();
        }
    }
}
