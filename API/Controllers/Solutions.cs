using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Solutions : ControllerBase
    {
        private readonly ISolutionsRecuperator solutions;

        public Solutions(ISolutionsRecuperator solutions)
        {
            this.solutions = solutions;
        }
        // GET: api/<Solutions>
        [HttpGet]
        public List<Solution> Get()
        {
            return solutions.Recuperate();


        }

        // GET api/<Solutions>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Solutions>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
