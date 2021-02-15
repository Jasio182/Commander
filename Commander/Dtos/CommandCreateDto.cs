using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        // Id will be created by database, so it shouldn't be supplied
        // public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }
    }
}
