using Login.Repository;

namespace Login.Entities;

public class LoginConta
{
    UsuariosRepository repository = new();
    public Usuario RealizaCadastro()
    {
        Usuario usuario = new Usuario();

        bool contaCriada = false;
        string nome, senha;
        while (!contaCriada)
        {
            Console.Write("Digite o nome do usuario: ");
            nome = Console.ReadLine();
            Console.Write("Digite a sua senha: ");
            senha = Console.ReadLine();
            usuario = new Usuario(nome, senha);
            if (repository.verificaNomeUsuario(usuario))
            {
                repository.AdicionarCadastro(usuario);
                contaCriada = true;
                return usuario;
            }
            Console.WriteLine("Já existe um usuário com esse nome. Tente novamente");
        }
        return usuario;
    }

    public void RealizaLogin()
    {
        int count = 0;
        while (count < 3)
        {
            Console.Write("Digite o nome do seu usuario: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a sua senha: ");
            string senha = Console.ReadLine();
            Usuario usuario = new Usuario(nome, senha);
            if (repository.VerificaCadastro(usuario))
            {
                Console.WriteLine("Login realizado com sucesso");
                return;
            }
            count++;
        }
    }

    public void MenuLogin()
    {
        Console.WriteLine("BEM VINDO!");
        Console.WriteLine("DIGITE A OPÇAO QUE VOCÊ DESEJA:");
        Console.WriteLine("1 - PARA REALIZAR LOGIN");
        Console.WriteLine("2 - PARA REALIZAR CADASTRO");
        Console.WriteLine("3 - PARA ENCERRAR O PROGRAMA");
    }

    public void LogarNaConta()
    {
        int opcao = 0;
        while (opcao != 3)
        {
            MenuLogin();
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    RealizaLogin();
                    break;
                case 2:
                    RealizaCadastro();
                    break;
            }
        }
    }
}
