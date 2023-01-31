namespace Login.Entities;

public class Usuario
{
    public string Nome { get; set; }
    public string Senha { get; set; }

    public Usuario() {}

    public Usuario(string nome, string senha)
    {
        Nome = nome;
        Senha = senha;
    }

    public override string ToString()
    {
        return $"Nome: {this.Nome}, Senha: {this.Senha}";
    }
}
