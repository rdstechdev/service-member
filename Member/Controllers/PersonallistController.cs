using Member.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonallistController : ControllerBase
    {
        private MemberContext db = new MemberContext();
        // GET: api/<PersonallistController>
        [HttpGet]
        public IEnumerable<Personallist> Get()
        {
            return db.Personallists.ToList();

        }

        // GET api/<PersonallistController>/5
        [HttpGet("{id}")]
        public Personallist Get(int id)
        {
            return db.Personallists.Find(id);
        }

        // POST api/<PersonallistController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonallistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonallistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
