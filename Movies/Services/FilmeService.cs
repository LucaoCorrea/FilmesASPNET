using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Models;
using JsonSerializer;

namespace Movies.Services;

public class FilmeService : IFilmeService
{
    private readonly IHttpContextAccessor _session;
    private readonly string filmeFile = @"Data\filmes.json";
    private readonly string tiposFile = @"Data\tipos.json";
    public FilmeService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    public List<Filme> GetFilmes()
    {
        PopularSessao();
        var filmes = JsonSerializer.Deserialize<List<Filme>>
        (_session.HttpContext.Session.GetString("Filmes"));
        return filmes;
    }
    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>
        (_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }
    public Filme GetFilme(int Numero)
    {
        var filmes = GetFilmes();
        return filmes.Where(p => p.Numero == Numero).FirstOrDefault();
    }
    public MoviesDto GetMoviesDto()
    {
        var movie = new MoviesDto()
        {
            Filmes = GetFilmes(),
            Tipos = GetTipos()
        };
        return movie;
    }
    public DetailsDto GetDetailedFilme(int Numero)
    {
        var filmes = GetFilmes();
        var movie = new DetailsDto()
        {
            Current = filmes.Where(p => p.Numero == Numero)
        .FirstOrDefault(),
            Prior = filmes.OrderByDescending(p => p.Numero)
        .FirstOrDefault(p => p.Numero < Numero),
            Next = filmes.OrderBy(p => p.Numero)
        .FirstOrDefault(p => p.Numero > Numero),
        };
        return movie;
    }
    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }
    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session
            .SetString("Filmes", LerArquivo(filmeFile));
            _session.HttpContext.Session
            .SetString("Tipos", LerArquivo(tiposFile));
        }
    }
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }

}