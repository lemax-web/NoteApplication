using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteWebApi.Model;
using RecipeWebApi.Data;

namespace NoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlServerDbContext _dbContext;

        public UserController(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> getUsers()
        {
            return Ok(await _dbContext.User.ToListAsync());
        }
        [HttpGet("{id}")]
        public ActionResult<User> getUser(int id)
        {
            var user = _dbContext.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();

            }
            _dbContext.User.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login(String email, String password)
        {
            var user = _dbContext.User.Where(user => user.Email == email).First();
            if (user == null)
            {
                return NotFound();
            }
            if (user.Password == password)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
