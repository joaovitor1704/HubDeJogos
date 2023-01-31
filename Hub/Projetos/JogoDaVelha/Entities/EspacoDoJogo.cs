namespace Hub.Projetos.JogoDaVelha.Entities;

public class EspacoDoJogo
{
    public string[,] Jogo = new string[,] { {"  " , " |" , "  " , " |", "  " },
        {"---", "|", "---", "|", "---" },
        {"  " , " |" , "  " , " |", "  " },
        {"---", "|", "---", "|", "---" },
        {"  " , " |" , "  " , " |", "  " } };

    public void ReiniciaJogo()
    {
        Jogo = new string[,] { {"  " , " |" , "  " , " |", "  " },
        {"---", "|", "---", "|", "---" },
        {"  " , " |" , "  " , " |", "  " },
        {"---", "|", "---", "|", "---" },
        {"  " , " |" , "  " , " |", "  " } };

        

    }
    public int ConverteLinhasColunas(int posicao)
    {
        if (posicao == 1)
        {
            return 0;
        }
        else if (posicao == 2)
        {
            return 2;
        }
        else if(posicao == 3)
        {
            return 4;
        }
        else
        {
            return -1;
        }
    }

    public bool VerificaJogo(int linha, int coluna)
    {
        linha = ConverteLinhasColunas(linha);
        coluna = ConverteLinhasColunas(coluna);
        if (linha == -1 || coluna == -1)
        {
            Console.WriteLine("Espaço inexistente, tente novamente em outro lugar");
            return false;
        }
        else
        {
            if (Jogo[linha, coluna] == "  ")
            {
                return true;
            }
            else if (Jogo[linha, coluna] != "  ")
            {
                Console.WriteLine("Espaço já foi preechido, tente novamente em outro lugar");
                return false;
            }
            else
            {
                return false;
            }
        }
    }
    public void PreencheJogo(int linha, int coluna, string valor)
    {
        if (VerificaJogo(linha, coluna))
        {
            linha = ConverteLinhasColunas(linha);
            coluna = ConverteLinhasColunas(coluna);
            Jogo[linha, coluna] = " " + valor;
        }
    }

    public bool VerificaEmpate()
    {
        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (Jogo[i,j] == "  ")
                {
                    return true;
                }
            }
        }
        return false;
        
    }

    public bool VerificaVencedor()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Jogo[i, 0] == Jogo[i, 2] && Jogo[i, 0] == Jogo[i, 4] && Jogo[i, 0] != "  " && Jogo[i, 0] != "---")
            {
                return true;
            }

            else if (Jogo[0, i] == Jogo[2, i] && Jogo[0, i] == Jogo[4, i] && Jogo[0, i] != "  " && Jogo[0, i] != " |")
            {
                return true;
            }
        }
        if (Jogo[0, 0] == Jogo[2, 2] && Jogo[0, 0] == Jogo[4, 4] && Jogo[4, 4] != "  ")
        {
            return true;
        }
        else if (Jogo[4, 0] == Jogo[2, 2] && Jogo[4, 0] == Jogo[0, 4] && Jogo[0, 4] != "  ")
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void ImprimeJogo()
    {
        Console.Clear();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{Jogo[i, j]} ");
                if (j == 4)
                {
                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine();
    }
}
