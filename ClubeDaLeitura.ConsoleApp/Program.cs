using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();

Caixa caixaTeste = new Caixa("Ação", "Vermelho", 5);
Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);

repositorioCaixa.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);

TelaCaixa telaCaixa = new TelaCaixa("Caixa", repositorioCaixa, repositorioRevista);
TelaRevista telaRevista = new TelaRevista("Revista", repositorioRevista, repositorioCaixa);
TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    string? opcaoMenuPrincipal = telaPrincipal.ObterMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1") // caixas
        {
            string? opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaCaixa.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaCaixa.Editar();

            else if (opcaoMenuInterno == "3")
                telaCaixa.Excluir();

            else if (opcaoMenuInterno == "4")
                telaCaixa.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "2") // revistas
        {
            string? opcaoMenuInterno = telaRevista.ObterOpcaoMenu();

            if (opcaoMenuInterno == "S")
                break;

            if (opcaoMenuInterno == "1")
                telaRevista.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaRevista.Editar();

            else if (opcaoMenuInterno == "3")
                telaRevista.Excluir();

            else if (opcaoMenuInterno == "4")
                telaRevista.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "3") // amigos
        {
            string? opcaoMenuInterno = telaAmigo.ObterOpcaoMenu();
            if (opcaoMenuInterno == "S") break;

            if (opcaoMenuInterno == "1") telaAmigo.Cadastrar();
            else if (opcaoMenuInterno == "2") telaAmigo.Editar();
            else if (opcaoMenuInterno == "3") telaAmigo.Excluir(repositorioEmprestimo);
            else if (opcaoMenuInterno == "4") telaAmigo.VisualizarTodos(true);
        }

        else if (opcaoMenuPrincipal == "4") // emprestimos
        {
            string? opcaoMenuInterno = telaEmprestimo.ObterOpcaoMenu();
            if (opcaoMenuInterno == "S") break;

            if (opcaoMenuInterno == "1") telaEmprestimo.RegistrarEmprestimo();
            else if (opcaoMenuInterno == "2") telaEmprestimo.RegistrarDevolucao();
            else if (opcaoMenuInterno == "3") telaEmprestimo.VisualizarTodos();
        }
    }
}