using Singular.Models;

namespace Singular.Repositorio
{
    public interface IAlunoRepositorio
    {
        AlunoModel BuscarPorId(int id);
        List<AlunoModel> BuscarTodos();
        AlunoModel Adicionar(AlunoModel aluno);
        AlunoModel Atualizar(AlunoModel aluno);
    }
}
