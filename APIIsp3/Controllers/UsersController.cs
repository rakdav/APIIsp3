using APIIsp3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIIsp3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        ModelDB db;

        public UsersController(ModelDB db)
        {
            this.db = db;
        }
        //Get api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }
        //Get api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user=await db.Users.
                FirstOrDefaultAsync(x=>x.id==id);
            if(user==null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        //POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if(user==null)
            {
                return BadRequest();
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(User);
        }
        //PUT api/users
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if(!db.Users.Any(x=>x.id==user.id))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(User);
        }
        //DELETE api/users/4
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user=db.Users.FirstOrDefault(x=>x.id==id);
            if(user==null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
