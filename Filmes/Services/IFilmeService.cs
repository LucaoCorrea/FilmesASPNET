using Filmes.Models;
namespace Filmes.Services;

public interface IFilmeService
{
    Filme GetFilme(int Numero);
    List<Filme> GetFilmes();
    List<Tipo> GetTipos();
}
