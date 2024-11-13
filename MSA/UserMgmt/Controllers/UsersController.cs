using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "User 1", "User 2" };
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"User {id}";
        }

        // POST api/<PostsController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return value + " " + id;
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
