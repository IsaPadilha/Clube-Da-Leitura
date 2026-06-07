using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo
{
    private readonly RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Amigos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar amigo");
        Console.WriteLine("2 - Editar amigo");
        Console.WriteLine("3 - Excluir amigo");
        Console.WriteLine("4 - Visualizar amigos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        return Console.ReadLine()?.ToUpper();
    }

    public void Cadastrar()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Responsável: ");
        string responsavel = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        if (nome.Length < 3 || responsavel.Length < 3 || telefone.Length < 10 || telefone.Length > 11)
        {
            Console.WriteLine("Dados inválidos!");
            Console.ReadLine();
            return;
        }

        if (repositorioAmigo.ExisteDuplicado(nome, telefone))
        {
            Console.WriteLine("Já existe amigo com esse nome e telefone!");
            Console.ReadLine();
            return;
        }

        Amigo novoAmigo = new Amigo(nome, responsavel, telefone);
        repositorioAmigo.Cadastrar(novoAmigo);

        Console.WriteLine("Amigo cadastrado com sucesso!");
        Console.ReadLine();
    }

    public void Editar()
    {
        VisualizarTodos(false);
        Console.Write("Digite o ID do amigo: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Novo nome: ");
        string nome = Console.ReadLine();
        Console.Write("Novo responsável: ");
        string responsavel = Console.ReadLine();
        Console.Write("Novo telefone: ");
        string telefone = Console.ReadLine();

        Amigo atualizado = new Amigo(nome, responsavel, telefone);
        repositorioAmigo.Editar(id, atualizado);

        Console.WriteLine("Amigo editado com sucesso!");
        Console.ReadLine();
    }

    public void Excluir(RepositorioEmprestimo repositorioEmprestimo)
    {
        VisualizarTodos(false);
        Console.Write("Digite o ID do amigo: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (repositorioAmigo.PodeExcluir(id, repositorioEmprestimo))
        {
            Console.WriteLine("Não é possível excluir: possui empréstimos vinculados!");
            Console.ReadLine();
            return;
        }

        repositorioAmigo.Excluir(id);
        Console.WriteLine("Amigo excluído com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarTodos(bool cabecalho)
    {
        if (cabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Amigos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0,-7} | {1,-20} | {2,-20} | {3,-15}",
            "Id", "Nome", "Responsável", "Telefone"
        );

        foreach (Amigo a in repositorioAmigo.SelecionarTodos())
        {
            if (a == null) continue;
            Console.WriteLine(
                "{0,-7} | {1,-20} | {2,-20} | {3,-15}",
                a.Id, a.Nome, a.Responsavel, a.Telefone
            );
        }

        if (cabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
}
