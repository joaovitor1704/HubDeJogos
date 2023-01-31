using Hub.Projetos.JogoDaVelha.Repository;
using Login.Entities;

namespace Hub.Projetos.JogoDaVelha.Entities
{
    public class InteracaoUsuario
    {
        static public EspacoDoJogo Jogo = new EspacoDoJogo();
        static public Jogador jogador1 = new Jogador();
        static public Jogador jogador2 = new Jogador();
        static RankingJogoDaVelhaRepository ranking = new RankingJogoDaVelhaRepository();

        public static void InicioJogo(Usuario usuario1, Usuario usuario2)
        {
            jogador1.Nome = usuario1.Nome;
            jogador2.Nome = usuario2.Nome;
            Console.Clear();
            Console.WriteLine("VAMOS COMEÇAR");
            while (!Jogo.VerificaVencedor())
            {
                Jogo.ImprimeJogo();
                Jogar(jogador1, "O");
                if (!Jogo.VerificaEmpate())
                {
                    Console.WriteLine("EMPATE");
                    break;
                }
                if (Jogo.VerificaVencedor())
                {
                    Jogo.ImprimeJogo();
                    Console.WriteLine("O Jogo acabou");
                    Console.WriteLine($"PARABÉNS {jogador1.Nome}!!!!! VOCÊ VENCEU.");
                    jogador1.Vitorias += 1;
                    break;
                }
                Jogo.ImprimeJogo();
                Jogar(jogador2, "X");
                if (!Jogo.VerificaEmpate())
                {
                    Console.WriteLine("EMPATE");
                    break;
                }
                if (Jogo.VerificaVencedor())
                {
                    Jogo.VerificaEmpate();
                    Jogo.ImprimeJogo();
                    Thread.Sleep(1500);
                    Console.WriteLine("O Jogo acabou");
                    Console.WriteLine($"PARABÉNS {jogador2.Nome}!!!!! VOCÊ VENCEU.");
                    jogador2.Vitorias += 1;
                    break;
                }
            }
            ReiniciaJogo(usuario1, usuario2);
            ranking.AdicionarJogador(jogador1);
            ranking.AdicionarJogador(jogador2);
            Environment.Exit(0);
        }

        public static void Jogar(Jogador jogador, string valor)
        {
            Console.WriteLine($"É a sua vez {jogador.Nome}:");
            Console.Write("Digite a linha que deseja preencher: ");
            int linha = int.Parse(Console.ReadLine());
            Console.Write("Digite a coluna que deseja preencher: ");
            int coluna = int.Parse(Console.ReadLine());
            while (!Jogo.VerificaJogo(linha, coluna))
            {
                Console.Write("Digite a linha que deseja preencher: ");
                linha = int.Parse(Console.ReadLine());
                Console.Write("Digite a coluna que deseja preencher: ");
                coluna = int.Parse(Console.ReadLine());
            }
            Jogo.PreencheJogo(linha, coluna, valor);
        }

        public static void ReiniciaJogo(Usuario usuario1, Usuario usuario2)
        {
            Console.Write("Vocês desejam jogar novamente? (S/N): ");
            char resposta = char.Parse(Console.ReadLine());
            if (resposta == 's' || resposta == 'S')
            {
                Jogo.ReiniciaJogo();
                InicioJogo(usuario1, usuario2);
            }
        }

        public static void Ranking()
        {
            Console.Clear();
            ranking.LerRanking();
            if (ranking.Jogadores.Any())
            {
                foreach (var item in ranking.Jogadores)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Thread.Sleep(4000);
            }

        }

    }
}
