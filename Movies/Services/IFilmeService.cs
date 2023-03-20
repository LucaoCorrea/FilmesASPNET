using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Services
{
    public interface IFilmeService
    {
        List<Filme> GetFilmes();
        List<Tipo> GetTipos();
        Filme GetFilme(int Numero);
        MoviesDto GetMoviesDto();
        DetailsDto GetDetailedFilme(int Numero);
        Tipo GetTipo(string Nome);
    }
}