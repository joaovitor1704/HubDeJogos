namespace Hub.Projetos.JogoDaVelha.Entities;

public class Jogador
{
    public string Nome { get; set; }
    public int Vitorias { get; set; }
    public Jogador() { }

    public Jogador(string nome)
    {
        Nome = nome;
        Vitorias = 0;
    }

    public override string ToString()
    {
        if (Vitorias > 1 || Vitorias == 0)
        {
            return $"{Nome}: {Vitorias} vitórias";
        }
        return $"{Nome}: {Vitorias} vitória";
    }
}
