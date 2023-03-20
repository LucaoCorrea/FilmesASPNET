using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class DetailsDto
    {
        public Filme Prior { get; set; }
        public Filme Current { get; set; }
        public Filme Next { get; set; }
    }
}