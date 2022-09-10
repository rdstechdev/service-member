using Microsoft.AspNetCore.Mvc;
using Member.Context;
using Member.Helper;
using Member.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberlistController : ControllerBase
    {
        private MemberContext db = new MemberContext();
        private readonly MemberService _iService =  new MemberService();

        // Dependency Injection in Constructor Class
        public MemberlistController()
        {

        }
        [HttpPost("search")]
        public SearchList<Memberlist> Get(List<Filter> param)
        {
            return _iService.Search(param);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Memberlist> Get()
        {
            return db.Memberlists.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Memberlist Get(int id)
        {
            return db.Memberlists.Find(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
