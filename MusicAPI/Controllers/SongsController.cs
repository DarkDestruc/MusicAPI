using Microsoft.AspNetCore.Mvc;
using MusicAPI.Data;
using MusicAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public SongsController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return dbContext.Songs;
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return dbContext.Songs.Find(id);
        }

        // POST api/<SongsController>
        [HttpPost]
        public ActionResult Post([FromBody] Song newSong)
        {
            dbContext.Songs.Add(newSong);
            dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var SongToDelete = dbContext.Songs.Find(id);
            if(SongToDelete != null)
            {
                dbContext.Remove(SongToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}
