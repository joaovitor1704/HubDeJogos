using Hub.Projetos.JogoDaVelha.Entities;
using Login.Entities;
using System.Text.Json;

namespace Hub.Projetos.JogoDaVelha.Repository
{
    public class RankingJogoDaVelhaRepository
    {
        public List<Jogador> Jogadores = new List<Jogador>();
        public string fileName = @"C:\Users\joaov\OneDrive\Documentos\Imã\HubDeJogos\Hub\Projetos\JogoDaVelha\Repository\RankingJogadores.json";

        public void LerRanking()
        {
            string jsonString;
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                }
                Jogadores = JsonSerializer.Deserialize<List<Jogador>>(jsonString);
            }
        }

        public bool VerificaNomeJogadores(Jogador jogador)
        {
            LerRanking();
            if (Jogadores.Any(x => x.Nome == jogador.Nome))
            {
                return false;
            }
            return true;
        }

        public void AdicionarJogador(Jogador jogador)
        {
            if (VerificaNomeJogadores(jogador))
            {
                Jogadores.Add(jogador);
                Jogadores = Jogadores.OrderByDescending(x => x.Vitorias).ToList();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Jogadores, options);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                Jogadores.Find(x => x.Nome == jogador.Nome).Vitorias += jogador.Vitorias;
                Jogadores = Jogadores.OrderByDescending(x => x.Vitorias).ToList();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Jogadores, options);
                File.WriteAllText(fileName, jsonString);
            }
        }

        
    }
}
