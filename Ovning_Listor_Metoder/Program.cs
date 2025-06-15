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
        
            // Slumpar fram ett tal mellan 1 och 6
            int tärning = slumpObjekt.Next(1, 7);
            Console.WriteLine("\nDu rullade en tärning och fick: " + tärning);

            // Returnerar det rullade värdet
            return tärning;
        }
            

        static void Main()
        {
            // Skapar en instans av klassen Random för att generera slumptal
            Random slump = new Random();

            // Skapar en lista av int för att spara tärningsrullningar
            List<int> tärningar = new List<int>(); 

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true;
            while (kör)
            {
                // Skriver ut menyn för användaren
                Console.WriteLine("\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Avsluta");
                Console.Write("\tVälj: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);

                switch (val)
                {
                    case 1:
                        // Här frågar vi användaren hur många tärningar de vill rulla
                        Console.Write("\n\tHur många tärningar vill du rulla: ");

                        // Vi försöker läsa in ett heltal från användaren
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
                            //Här skapar vi en lista som innehåller tärningssiffrorna 1-6
                            // Denna lista används för att spara tärningsrullningar 


                            //Kan jag verkligen döpa min List<int>" till vad som helst????  Och varför? När kommer den till användning?
                            List<int> myTärningslista= new List<int> { 1, 2, 3, 4, 5, 6 };


                            // Här skriver vi ut alla rullade tärningar
                            Console.WriteLine("\n\tRullade tärningar: ");

                            // Vi loopar igenom listan tärningar och skriver ut varje rullad tärning
                            foreach (int tärning in tärningar)

                            {
                                Console.WriteLine("\t" + tärning );
                                sum += tärning;
                                // Här lägger vi till varje rullad tärning till
                                // summan för att sedan räkna ut medelvärdet
                                // medelvärdet
                                // beräknas genom att dela summan med antalet rullade tärningar
                                // Om du vill ha medelvärdet som ett double kan du göra så här:
                            }

                            // Beräkna medelvärdet av alla rullade tärningar. Double är en datatyp som kan hantera decimaler eftersom talet kan bli decimalt.
                            double medelvärde = (double)sum / tärningar.Count;

                            // Skriv ut medelvärdet
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + medelvärde );

                        }
                        // Vänta i 1 sekund innan vi går tillbaka till menyn
                        break;

                    // Avsluta programmet
                    case 3:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;

                    // Om användaren väljer ett ogiltigt alternativ
                    default:
                        Console.WriteLine("\n\tVälj 1-3 från menyn.");
                        break;
                }
            }
        }
    }
}
