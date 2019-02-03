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
        [ProducesResponseType(typeof(Job), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Job), (int)HttpStatusCode.Conflict)]
        public IActionResult Post([FromBody]Job request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var job = Jobs.FirstOrDefault(j => j.Id == request.Id);

            if (job != null)
            {
                return Conflict($"Job with Id {request.Id} exists");
            }

            Jobs.Add(request);

            return Ok(request);
        }

        /// <summary>
        /// put a string
        /// </summary>
        /// <param name="id">id of a string</param>
        /// <param name="value">value of the string</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Job), (int)HttpStatusCode.OK)]
        public IActionResult Put(int id, [FromBody]Job value)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var job = Jobs.First(j => j.Id == id);
            job.Description = value.Description;
            job.Level = value.Level;
            job.Title = value.Title;
            job.Requirements = value.Requirements;

            return Ok(value);
        }

        /// <summary>
        /// delete something
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var job = Jobs.First(j => j.Id == id);

            if (job == null)
            {
                return Conflict($"Job with Id {id} does not exist");
            }

            Jobs.Remove(job);
            return Ok();
        }

        private static List<Job> Jobs = new List<Job>
        {
            new Job
            {
                Id = 1,
                Title = "Senior Software Engineer ASP.NET Core",
                Description = "knows how to do a stack overflow search",
                Level = "Level 3",
                Requirements = "5 years experience using some of the following: ASP.NET Core, ASP.NET, C#, HTML, Javascript, Typescript, SignalR, Azure"
            },
            new Job
            {
                Id = 2,
                Title = "Professional Software Engineer ASP.NET Core",
                Description = "knows how to do a stack overflow search",
                Level = "Level 2",
                Requirements = "3 years experience using some of the following: ASP.NET Core, ASP.NET, C#, HTML, Javascript, Typescript, SignalR, Azure"
            },
            new Job
            {
                Id = 3,
                Title = "Junior Software Engineer ASP.NET Core",
                Description = "knows how to do a stack overflow search",
                Level = "Level 1",
                Requirements = "knows some of the following: ASP.NET Core, ASP.NET, C#, HTML, Javascript, Typescript, SignalR, Azure, worked in a team"
            }
        };

    }
}
