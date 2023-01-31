using Hub.Projetos.Login.Repository;
using Hub.Projetos.Login.View;

namespace Login.Entities;

public class LoginConta
{
    UsuariosRepository repository = new();
    
    public void RealizaCadastro()
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
                Console.WriteLine("Cadastro realizado com sucesso, agora faça o login na conta");
                repository.AdicionarCadastro(usuario);
                Thread.Sleep(2000);
                Console.Clear();
                contaCriada = true;
                return;
            }
            Console.WriteLine("Já existe um usuário com esse nome. Tente novamente");
        }
    }

    public Usuario RealizaLogin(int numUsuario)
    {

        int count = 0;
        while (count < 3)
        {
            Console.WriteLine($"Realize seu login usuario {numUsuario}");
            Console.Write("Digite o seu usuario: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a sua senha: ");
            string senha = Console.ReadLine();
            Usuario usuario = new Usuario(nome, senha);
            if (repository.VerificaCadastro(usuario))
            {
                Console.WriteLine("Login realizado com sucesso");
                Thread.Sleep(2000);
                Console.Clear();
                return usuario;
            }
            count++;
        }
        Console.WriteLine("Tente novamente mais tarde.");
        Environment.Exit(0);    
        return new Usuario();
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
                    var jogador1 = RealizaLogin(1);
                    var jogador2 = RealizaLogin(2);
                    Jogos.EscolhaJogo(jogador1, jogador2);
                    break;
                case 2:
                    RealizaCadastro();
                    Console.WriteLine("a");
                    break;
            }
        }
    }
}
