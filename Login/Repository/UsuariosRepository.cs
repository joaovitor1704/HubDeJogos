using Login.Entities;
using System.Text.Json;

namespace Login.Repository;

public class UsuariosRepository
{
    public List<Usuario> Usuarios = new List<Usuario>();
    public string fileName = @"C:\\Users\\joaov\\OneDrive\\Documentos\\Imã\\HubDeJogos\\Login\\Repository\\UsuariosCadastrados.json";


    public void LerCadastros()
    {
        string jsonString;
        if (File.Exists(fileName))
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                jsonString = sr.ReadToEnd();
            }
            Usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonString);
        }
    }

    public bool verificaNomeUsuario(Usuario usuario)
    {
        LerCadastros();
        if (Usuarios.Any(x => x.Nome == usuario.Nome))
        {
            return false;
        }
        return true;
    }
    public bool VerificaCadastro(Usuario usuario)
    {
        LerCadastros();
        if (Usuarios.Any() && Usuarios.Exists(x => x.Nome == usuario.Nome))
        {
            Usuario user = Usuarios.Find(x => x.Nome == usuario.Nome);
            if (user.Senha == usuario.Senha)
            {
                return true;
            }
            Console.WriteLine("Senha incorreta");
            return false;

        }
        Console.WriteLine("Usuário não encontrado");
        return false;
    }

    public void AdicionarCadastro(Usuario usuario)
    {
        LerCadastros();
        Usuarios.Add(usuario);
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Usuarios, options);
        File.WriteAllText(fileName, jsonString);
    }

}
