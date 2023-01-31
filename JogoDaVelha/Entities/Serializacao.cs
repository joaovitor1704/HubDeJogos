using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JogoDaVelha.Entities
{
    public static class Serializacao
    {
        public static List<Usuario> Jogadores = new List<Usuario>();
        public static string fileName = @"C:\Users\joaov\OneDrive\Documentos\Imã\JogoDaVelha\JogoDaVelha\Arquivos\RankingJogadores.json";

        public static void AdicionaJogadoresOrdenados()
        {
            Jogadores.Add(InteracaoUsuario.jogador1);
            Jogadores.Add(InteracaoUsuario.jogador2);
            Jogadores = Jogadores.OrderByDescending(x => x.Vitorias).ToList();
        }
        public static void Serializar()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString;

            if (new FileInfo(fileName).Length != 0)
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                }
                Jogadores = JsonSerializer.Deserialize<List<Usuario>>(jsonString);
                AdicionaJogadoresOrdenados();
                jsonString = JsonSerializer.Serialize(Jogadores, options);
                File.WriteAllText(fileName, jsonString);
                Console.WriteLine(File.ReadAllText(fileName));
            }
            else
            {
                AdicionaJogadoresOrdenados();

                jsonString = JsonSerializer.Serialize(Jogadores, options);
                File.WriteAllText(fileName, jsonString);
                Console.WriteLine(File.ReadAllText(fileName));
            }
        }
    }
}
