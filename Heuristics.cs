using System;

namespace Problema5
{
    class Heuristics
    {

        // Campos de clase (arreglos)
        public int[] Bi, Hi, Vi, Di;
        // Campos de clase (variables enteras)
        public int Bl, Hl, i;

        public Heuristics(int longitud = 5)
        {
            Bi = new int[longitud];
            Hi = new int[longitud];
            Vi = new int[longitud];
            Di = new int[longitud];

            Bl = Hl = i = 0;
        }

        public void Evaluar(int B, int H) 
        {
            int[] tempAr = new int[i];
            int AreaTemporal = B * H;
            int CostoMaximo = 0;
            int CantidadMinima = 0;

            for (int j = 0; j < i; j++) 
            {
                if (B >= Bi[j] && H >= Hi[j]) 
                {
                    if (Di[j] > ((B / Bi[j]) * (H / Hi[j])))
                    { 
                        tempAr[j] = (B / Bi[j]) * (H / Hi[j]);
                    }
                    else
                    { 
                        tempAr[j] = Di[j];
                    }
                } 
            }
            for (int j = 0; j < i; j++) 
            {
                if (B >= Bi[j] && H >= Hi[j]) 
                {
                    Console.WriteLine("El mínimo de ("+ Bi[j] + "," + Hi[j] + ") es "+ tempAr[j] + "Z = "+ (tempAr[j] * Vi[j]));
                    if ((AreaTemporal / (Bi[j] * Hi[j])) > Di[j])
                    { 
                        CantidadMinima = Di[j];
                    }
                    else 
                    { 
                        CantidadMinima = (AreaTemporal / (Bi[j] * Hi[j]));  
                    }
                    if (AreaTemporal> 0)
                    { 
                        CortesSucesivos(Bi[j], Hi[j], tempAr[j], Vi[j], CostoMaximo, AreaTemporal, CantidadMinima);
                        if (tempAr[j] >CantidadMinima) 
                        {
                            AreaTemporal = AreaTemporal - (Bi[j] * Hi[j] * CantidadMinima);
                            CostoMaximo = CostoMaximo + (CantidadMinima * Vi[j]); 
                        }
                        else 
                        {
                            AreaTemporal = AreaTemporal - (Bi[j] * Hi[j] * tempAr[j]);
                            CostoMaximo = CostoMaximo + (tempAr[j] * Vi[j]);
                        }
                    } 
                }
            }
            Console.WriteLine("Función Objetivo tomando primero (" + B + ", " + H + "): " + CostoMaximo);
            Console.WriteLine("Valor de i: {0}", i);
        }

        public void CortesSucesivos(int B, int H, int C1, int CostAr, int CosteMaximo, int AreaMax, int C2) 
        {
            int TempZ = (AreaMax);
            if (TempZ>= 0)
            { 
                int minC = 0;
                if (C1 > C2)
                { 
                    minC = C2; 
                }
                else 
                { 
                    minC = C1; 
                }
                TempZ = (AreaMax - (minC * B * H));
                Console.WriteLine("X1 <= min {" + C1 + ", [" + AreaMax + " / " + (B * H) + "]} = " + minC);
                Console.WriteLine("Z = " + (CosteMaximo) + " + (" + minC + ")(" + CostAr + ") = " + (CosteMaximo + (minC * CostAr)));
                Console.WriteLine("Área = " + AreaMax + " - (" + minC + ")(" + (B * H) + ") = " + TempZ);
                Console.WriteLine();
            } 
        } 

    }
}
