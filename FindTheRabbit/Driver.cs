using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheRabbit
{
    class Driver
    {
        public static void Main(string[] args)
        {
            int count = 1;
            int userTries = 1;
            Random random = new Random();
            int rabbitHole = random.Next(1, 49);
            string[] holes = new string[49];
            RabbitGame game = new RabbitGame();
            string userDecision = "";

            do
            {
                for(int i = 0; i < holes.Length; i++)
                {
                    if(count == 1)
                    {
                        Console.Write("|");
                    }
                    count++;

                    Console.Write(String.Format("{0, 4}", (i + 1)));
                    Console.Write("  |");
                    if (count == 8)
                    {
                        Console.WriteLine();
                        count = 1;
                    }
                }
                game.findRabbit(holes, rabbitHole, userTries);
                Console.WriteLine("Would you like to play again (Y/N)?");
                if(userDecision.ToUpper() == "Y")
                {
                    rabbitHole = random.Next(1, 49);
                    for(int i = 0; i < holes.Length; i++)
                    {
                        holes[i] = "";
                    }
                }
                userDecision = Console.ReadLine();
            } while (userDecision.ToUpper() == "Y");
        }
    }

}
