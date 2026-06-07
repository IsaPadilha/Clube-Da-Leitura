using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public enum StatusEmprestimo { Aberto, Concluido, Atrasado }

public class Emprestimo : EntidadeBase
{
    public Amigo Amigo { get; private set; }
    public Revista Revista { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public StatusEmprestimo Status { get; private set; }

    public Emprestimo(Amigo amigo, Revista revista, Caixa caixa)
    {
        Id = GeradorIds.ObterIdEmprestimo();
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = DateTime.Now;
        DataDevolucao = DataEmprestimo.AddDays(caixa.DiasDeEmprestimo);
        Status = StatusEmprestimo.Aberto;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Emprestimo e = (Emprestimo)entidadeAtualizada;
        Amigo = e.Amigo;
        Revista = e.Revista;
        DataEmprestimo = e.DataEmprestimo;
        DataDevolucao = e.DataDevolucao;
        Status = e.Status;
    }

    public void Concluir()
    {
        Status = StatusEmprestimo.Concluido;
    }

    public void VerificarAtraso()
    {
        if (Status == StatusEmprestimo.Aberto && DateTime.Now > DataDevolucao)
            Status = StatusEmprestimo.Atrasado;
    }
}
