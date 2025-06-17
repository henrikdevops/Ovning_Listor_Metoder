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

            int tärning = slumpObjekt.Next(1, 7); // Slumpar fram ett tal mellan 1 och 6
            return tärning; // Returnerar det rullade värdet
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
                        Console.Write("\n\tHur många tärningar vill du rulla: "); // Här frågar vi användaren hur många tärningar de vill rulla
                        bool inmatning = int.TryParse(Console.ReadLine(), out int antal); // Här försöker vi läsa in ett heltal från användaren och spara det i variabeln antal

                        // Om inmatningen lyckades, så kör vi koden i if-satsen
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
                            Console.WriteLine("\n\tRullade tärningar: "); // Skriver vi ut alla rullade tärningar
                            foreach (int tärning in tärningar) // Loopar vi igenom listan tärningar och skriver ut varje rullad tärning
                            {
                                Console.WriteLine("\t" + tärning); //
                                int medelvärde = tärning / tärningar; // Här sparar vi varje rullad tärning i medelvärdet
                                
                            }
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum); // Här ska medelvärdet skrivas ut
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
