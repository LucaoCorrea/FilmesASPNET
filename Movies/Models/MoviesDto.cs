using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MoviesDto
    {
        public List<Tipo> Tipos { get; set; }
        public List<Filme> Filmes { get; set; }
    }
}