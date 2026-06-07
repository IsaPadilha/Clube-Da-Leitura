using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class RepositorioAmigo : RepositorioBase
{
    public bool ExisteDuplicado(string nome, string telefone)
    {
        foreach (Amigo a in SelecionarTodos())
        {
            if (a == null) continue;
            if (a.Nome == nome && a.Telefone == telefone)
                return true;
        }
        return false;
    }

    public bool PodeExcluir(int idSelecionado, RepositorioEmprestimo repositorioEmprestimo)
    {
        foreach (Emprestimo e in repositorioEmprestimo.SelecionarTodos())
        {
            if (e == null) continue;
            if (e.Amigo.Id == idSelecionado && e.Status == StatusEmprestimo.Aberto)
                return false;
        }
        return true;
    }
}