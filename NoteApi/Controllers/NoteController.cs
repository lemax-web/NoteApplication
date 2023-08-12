using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApi.Model;
using RecipeWebApi.Data;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly SqlServerDbContext _dbContext;

        public NoteController(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> getUsers()
        {
            return Ok(await _dbContext.Note.ToListAsync());
        }
        [HttpGet("{id}")]
        public ActionResult<Note> getUser(int id)
        {
            var note = _dbContext.Note.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }
        [HttpPost]
        public async Task<ActionResult> Create(Note note)
        {
            _dbContext.Note.Add(note);
            await _dbContext.SaveChangesAsync();
            return Ok(note);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();

            }
            _dbContext.Note.Entry(note).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(note);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await _dbContext.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            _dbContext.Note.Remove(note);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
