using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Utilidades;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class Revista : EntidadeBase
{
    public string Titulo { get; private set; }
    public int NumeroEdicao { get; private set; }
    public int AnoPublicacao { get; private set; }
    public Caixa Caixa { get; private set; }

    public Revista(string titulo, int numeroEdicao, int anoPublicacao, Caixa caixa)
    {
        Id = GeradorIds.ObterIdRevista();

        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = caixa;
    }

    // substituição de método
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Revista revistaAtualizada = (Revista)entidadeAtualizada;

        Titulo = revistaAtualizada.Titulo;
        NumeroEdicao = revistaAtualizada.NumeroEdicao;
        AnoPublicacao = revistaAtualizada.AnoPublicacao;
        Caixa = revistaAtualizada.Caixa;
    }
}
