namespace JogoDaVelha.Entities;

public class Usuario
{
    public string Nome { get; set; }
    public int Vitorias { get; set; }
    public Usuario() { }

    public Usuario(string nome)
    {
        Nome = nome;
        Vitorias = 0;
    }

    public override string ToString()
    {
        if (this.Vitorias > 1 || this.Vitorias == 0)
        {
            return $"{this.Nome}: {this.Vitorias} vitórias";
        }
        return $"{this.Nome}: {this.Vitorias} vitória";
    }
}
