using Hub.Projetos.JogoDaVelha.Entities;
using Hub.Projetos.JogoDaVelha.View;
using Login.Entities;

namespace Hub.Projetos.Login.View;

public static class Jogos
{
    public static void EscolhaJogo(Usuario jogador1, Usuario jogador2)
    {
        
        int opcao = 0;
        while(opcao != 3)
        {
            Console.WriteLine("Escolha qual jogo vocês querem jogar:");
            Console.WriteLine("1 - JOGO DA VELHA");
            Console.WriteLine("2 - BATALHA NAVAL");
            Console.WriteLine("3 - ENCERRAR");
            opcao = int.Parse(Console.ReadLine());
            switch(opcao)
            {
                case 1:
                    Menu.ShowMenu(jogador1, jogador2);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        
    }
}
