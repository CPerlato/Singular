using Singular.Models;

namespace Singular.Repositorio
{
    public interface IAlunoRepositorio
    {
        List<AlunoModel> BuscarTodos();
        AlunoModel Adicionar (AlunoModel aluno);
    }
}
