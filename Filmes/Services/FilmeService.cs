using Filmes.Models;
using System.Text.Json;
namespace Filmes.Services;
public class FilmeService : IFilmeService
{
    private readonly IHttpContextAccessor _session;

    public FilmeService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public Filme GetFilme(int Numero)
    {
        var filmes = GetFilmes();
        return filmes.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public List<Filme> GetFilmes()
    {
        PopularSessao();

        var filmes = JsonSerializer.Deserialize<List<Filme>>(
            _session.HttpContext.Session.GetString("Filmes"));
        return filmes;
    }

    public List<Tipo> GetTipos()
    {
        PopularSessao();

        var tipos = JsonSerializer.Deserialize<List<Tipo>>(
            _session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(
            _session.HttpContext.Session.GetString("Filmes")))
        {        
            var dados = LerArquivo(@"Data\filmes.json");
            _session.HttpContext.Session.SetString("Filmes", dados);
            dados = LerArquivo(@"Data\tipos.json");
            _session.HttpContext.Session.SetString("Tipos", dados);
        }
    }


    private string LerArquivo(string nomeArquivo)
    {
        using (StreamReader leitor = new StreamReader(nomeArquivo))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }

}
