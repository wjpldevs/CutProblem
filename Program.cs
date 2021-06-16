using System;
using System.IO;

namespace Problema5
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Instancia de clase
            Heuristics heuristic = new Heuristics(5); 
            
            var reader = new StreamReader(File.OpenRead(@".\BD.csv"));
            
            Console.WriteLine("Ingrese la base: ");
            heuristic.Bl = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la altura: ");
            heuristic.Hl = int.Parse(Console.ReadLine());

            while(!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var values = row.Split(",");
                heuristic.Bi[heuristic.i] = int.Parse(values[0]);
                heuristic.Hi[heuristic.i] = int.Parse(values[1]);
                heuristic.Vi[heuristic.i] = int.Parse(values[2]);
                heuristic.Di[heuristic.i] = int.Parse(values[3]);
                heuristic.i++;
            }

            for (int j = 0; j < heuristic.i; j++) 
            {
                Console.WriteLine("> SEGMENTOS DE CORTES: ({0},{1})", heuristic.Bi[j], heuristic.Hi[j]);

                int H1 = heuristic.Hl - heuristic.Hi[j];

                Console.WriteLine("H1 ({0},{1})", heuristic.Bl, H1);
                heuristic.Evaluar(heuristic.Bl, H1);

                int H2 = heuristic.Bl - heuristic.Bi[j];
                
                Console.WriteLine("H2 ({0},{1})", H2, heuristic.Hi[j]);
                heuristic.Evaluar(H2, heuristic.Hi[j]);

                int V3 = heuristic.Hl - heuristic.Hi[j];

                Console.WriteLine("V1 ({0},{1})", heuristic.Bi[j], V3);
                heuristic.Evaluar(heuristic.Bi[j], V3);

                int V4 = heuristic.Bl - heuristic.Bi[j];

                Console.WriteLine("V2 ({0},{1})", V4, heuristic.Hl);
                heuristic.Evaluar (V4, heuristic.Hl);
            }
            Console.ReadKey();
        }
    }
}
