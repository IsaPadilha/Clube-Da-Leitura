using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public string Nome { get; private set; }
    public string Responsavel { get; private set; }
    public string Telefone { get; private set; }

    public Amigo(string nome, string responsavel, string telefone)
    {
        Id = GeradorIds.ObterIdAmigo();
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;
        Nome = amigoAtualizado.Nome;
        Responsavel = amigoAtualizado.Responsavel;
        Telefone = amigoAtualizado.Telefone;
    }
}
