using Hub.Projetos.JogoDaVelha.Entities;
using Login.Entities;

namespace Hub.Projetos.JogoDaVelha.View
{
    public static class Menu
    {
        public static void ShowMenu(Usuario jogador1, Usuario jogador2)
        {
            int opcao = 0;
            while (opcao != 3)
            {
                Console.Clear();
                Console.WriteLine("Escolha qual opção você deseja:");
                Console.WriteLine("1 - INICIAR O JOGO");
                Console.WriteLine("2 - VER O RANKING DE VITÓRIAS");
                Console.WriteLine("3 - ENCERRAR");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        InteracaoUsuario.InicioJogo(jogador1, jogador2);
                        break;
                    case 2:
                        InteracaoUsuario.Ranking();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
