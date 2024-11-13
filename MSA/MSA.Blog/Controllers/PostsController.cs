using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MSA.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
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
