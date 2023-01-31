namespace JogoDaVelha.Entities
{
    public class InteracaoUsuario
    {
        static public EspacoDoJogo Jogo = new EspacoDoJogo();
        static public Usuario jogador1 = new Usuario();
        static public Usuario jogador2 = new Usuario();
        public static void EntradaJogo()
        {
            Console.WriteLine("SEJA BEM VINDO");
            Console.Write("JOGADOR 1 -> DIGITE O SEU NOME: ");
            string nome1 = Console.ReadLine();
            jogador1.Nome = nome1;
            Console.Write("JOGADOR 2 -> DIGITE O SEU NOME: ");
            string nome2 = Console.ReadLine();
            jogador2.Nome = nome2;
            Console.WriteLine($"Olá {jogador1.Nome}, você jogará com O");
            Console.WriteLine($"Olá {jogador2.Nome}, você jogará com X");
            Thread.Sleep(2000);
        }

        public static void InicioJogo()
        {
            Console.Clear();
            Console.WriteLine("VAMOS COMEÇAR");
            while (!Jogo.VerificaVencedor())
            {
                Jogo.ImprimeJogo();
                Jogar(jogador1, "O");
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
                if (Jogo.VerificaVencedor())
                {
                    Jogo.ImprimeJogo();
                    Thread.Sleep(1500);
                    Console.WriteLine("O Jogo acabou");
                    Console.WriteLine($"PARABÉNS {jogador2.Nome}!!!!! VOCÊ VENCEU.");
                    jogador2.Vitorias += 1;
                    break;
                }

            }
            ReiniciaJogo();
            Jogo.ImprimeJogo();
        }

        public static void Jogar(Usuario jogador, string valor)
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

        public static void ReiniciaJogo()
        {
            Console.Write("Vocês desejam jogar novamente? (S/N): ");
            char resposta = char.Parse(Console.ReadLine());
            if (resposta == 's' || resposta == 'S')
            {
                Jogo.ReiniciaJogo();
                InicioJogo();
            }
        }

        public static void Ranking()
        {
            jogador1.ToString();
            jogador2.ToString();
        }

    }
}
