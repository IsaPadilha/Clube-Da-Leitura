using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);

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

        }

        else if (opcaoMenuPrincipal == "3") // amigos
        {

        }

        else if (opcaoMenuPrincipal == "4") // emprestimos
        {

        }
    }
}