using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        // detta är en statisk metod med en int som ett returvärde
        // metoden tar en parameter i form av ett random objekt av
        // randomklassen
        static int RullaTärning(Random slumpObjekt)
        {
            // här ska du skapa kod som slumpar fram ett tal
            // mellan 1 och 6, så att metoden "rullar" en 6 sidig
            // tärning när vi kallar på den
            // metoden ska sedan returnera det rullade värdet


            // Slumpar fram ett tal mellan 1 och 6
            int tärning = slumpObjekt.Next(1, 7);
            Console.WriteLine("\nDu rullade en tärning och fick: " + tärning);

            // Returnerar det rullade värdet
            return tärning;
        }



        static void Main()
        {
            Random slump = new Random(); // Skapar en instans av klassen Random för vårt slumptal
            List<int> tärningar = new List<int>(); // listan för att spara våra rullade tärningar

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true;
            while (kör)
            {
                Console.WriteLine("\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Avsluta");
                Console.Write("\tVälj: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);

                switch (val)
                {
                    case 1:
                        Console.Write("\n\tHur många tärningar vill du rulla: ");
                        bool inmatning = int.TryParse(Console.ReadLine(), out int antal);

                        if (inmatning)
                        {
                            for (int i = 0; i < antal; i++)
                            {
                                // här kallar vi på metoden RullaTärning
                                // och sparar det returnerade värdet i 
                                // listan tärningar
                                tärningar.Add(RullaTärning(slump));
                            }
                        }
                        break;
                    case 2:
                        int sum = 0; // Skapar en int som ska innehålla medelvärdet av alla tärningsrullningar.
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            Console.WriteLine("\n\tRullade tärningar: ");
                            foreach (int tärning in tärningar)

                            {
                                Console.WriteLine("\t" + tärning );
                                sum += tärning;
                                // Här lägger vi till varje rullad tärning till
                                double medelvärdet = (double)sum / tärningar.Count; 
                            }
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum ); // Här ska medelvärdet skrivas ut   

                        }

                        break;
                    case 3:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;
                    default:
                        Console.WriteLine("\n\tVälj 1-3 från menyn.");
                        break;
                }
            }
        }
    }
}
