using System.Collections.Generic;
using System.Linq;
using System.Net;
using CsvWebApiSwagger.Models;
using Microsoft.AspNetCore.Mvc;

namespace CsvWebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private static List<Job> Jobs = new List<Job>
        {

        };

        /// <summary>
        /// docs for get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Job>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return Ok(Jobs);
        }

        /// <summary>
        /// get id
        /// </summary>
        /// <param name="id">any id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Job>), (int)HttpStatusCode.OK)]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var job = Jobs.FirstOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound($"Job with Id not found: {id}");
            }
            return Ok(job);
        }

        /// <summary>
        /// post a string
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]Job value)
        {
            Jobs.Add(value);
        }

        /// <summary>
        /// put a string
        /// </summary>
        /// <param name="id">id of a string</param>
        /// <param name="value">value of the string</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Job value)
        {
            var job = Jobs.First(j => j.Id == id);
            job.Description = value.Description;
            job.Level = value.Level;
            job.Title = value.Title;
            job.Requirements = value.Requirements;
        }

        /// <summary>
        /// delete something
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var job = Jobs.First(j => j.Id == id);
            Jobs.Remove(job);
        }
    }
}
