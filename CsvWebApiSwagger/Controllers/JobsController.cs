using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Job> Get()
        {
            return Jobs;
        }

        /// <summary>
        /// get id
        /// </summary>
        /// <param name="id">any id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Job Get(int id)
        {
            return Jobs.First(j => j.Id == id);
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
