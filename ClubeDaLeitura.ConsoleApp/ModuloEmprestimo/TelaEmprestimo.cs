using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioRevista repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    public string? ObterOpcaoMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Empréstimos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Registrar empréstimo");
        Console.WriteLine("2 - Registrar devolução");
        Console.WriteLine("3 - Visualizar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        return Console.ReadLine()?.ToUpper();
    }

    public void RegistrarEmprestimo()
    {
        Console.WriteLine("Selecione o amigo:");
        foreach (Amigo a in repositorioAmigo.SelecionarTodos())
        {
            if (a != null)
                Console.WriteLine($"{a.Id} - {a.Nome}");
        }

        int idAmigo = Convert.ToInt32(Console.ReadLine());
        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

        // regra: só um empréstimo ativo por amigo
        foreach (Emprestimo e in repositorioEmprestimo.SelecionarTodos())
        {
            if (e == null) continue;
            if (e.Amigo.Id == amigoSelecionado.Id && e.Status == StatusEmprestimo.Aberto)
            {
                Console.WriteLine("Esse amigo já possui empréstimo ativo!");
                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine("Selecione a revista:");
        foreach (Revista r in repositorioRevista.SelecionarTodos())
        {
            if (r != null)
                Console.WriteLine($"{r.Id} - {r.Titulo} (Caixa {r.Caixa.Etiqueta})");
        }

        int idRevista = Convert.ToInt32(Console.ReadLine());
        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

        if (revistaSelecionada == null)
        {
            Console.WriteLine("Revista inválida!");
            return;
        }

        Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada, revistaSelecionada.Caixa);
        repositorioEmprestimo.Cadastrar(novoEmprestimo);

        Console.WriteLine("Empréstimo registrado com sucesso!");
        Console.ReadLine();
    }

    public void RegistrarDevolucao()
    {
        Console.WriteLine("Selecione o empréstimo para devolução:");
        foreach (Emprestimo e in repositorioEmprestimo.SelecionarTodos())
        {
            if (e != null && e.Status == StatusEmprestimo.Aberto)
                Console.WriteLine($"{e.Id} - {e.Amigo.Nome} / {e.Revista.Titulo}");
        }

        int idEmprestimo = Convert.ToInt32(Console.ReadLine());
        Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

        if (emprestimoSelecionado == null)
        {
            Console.WriteLine("Empréstimo inválido!");
            return;
        }

        emprestimoSelecionado.Concluir();
        Console.WriteLine("Devolução registrada com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarTodos()
    {
        Console.WriteLine(
            "{0,-7} | {1,-20} | {2,-20} | {3,-15} | {4,-15}",
            "Id", "Amigo", "Revista", "Status", "Data Devolução"
        );

        foreach (Emprestimo e in repositorioEmprestimo.SelecionarTodos())
        {
            if (e == null) continue;
            e.VerificarAtraso();

            if (e.Status == StatusEmprestimo.Atrasado)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(
                "{0,-7} | {1,-20} | {2,-20} | {3,-15} | {4,-15}",
                e.Id, e.Amigo.Nome, e.Revista.Titulo, e.Status, e.DataDevolucao.ToShortDateString()
            );

            Console.ResetColor();
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
}
