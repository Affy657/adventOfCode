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

        // POST api/<Solutions>
        [HttpPost]
        public int Post( int year, int day, bool bonus = false)
        {
            return 0;
        }

    }
}
