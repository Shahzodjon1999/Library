﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damen.Models
{
    public class Author
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public int BookId { get; set; }

    }
}
