using Singular.Models;

namespace Singular.Repositorio
{
    public interface IProfessorRepositorio
    {
        ProfessorModel BuscarPorId(int id);
        List<ProfessorModel> BuscarTodos();
        ProfessorModel Adicionar(ProfessorModel professor);
        ProfessorModel Atualizar(ProfessorModel professor);
    }
}
