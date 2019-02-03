using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsvWebApiSwagger.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Requirements { get; set; }
    }
}
