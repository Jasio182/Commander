﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dtos
{
    public class CommandReadDto
    {

        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        // For illustration Platform is removed.
        // public string Platform { get; set; }
    }
}
