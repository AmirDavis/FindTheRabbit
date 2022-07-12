using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheRabbit
{
    internal class RabbitGame
    {
        public void findRabbit(string[] array, int rabbitHole, int userTries)
        {
            int userChoice;
            int count = 1;
            array[rabbitHole - 1] = "R";
            
            Console.Write("Choose a rabbit hole: ");
            userChoice = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("rabbit: " + rabbitHole); used as error handling to easily find the rabbit

            /*Checks to see if the user's choice is within the bounds of the array[0-49]. Also checks
             * to see if the user has selected that number already
             */
            while((userChoice < 1) || (userChoice > 49) || (array[userChoice - 1] == " X"))
            {
                if(userChoice < 1 || userChoice > 49)
                {
                    Console.Write("Please enter a number between 1-49: ");
                }
                else
                {
                    Console.Write("You've already looked at this hole. Choose another hole: ");
                }
                userChoice = Int32.Parse(Console.ReadLine());
            }

            if (userChoice != rabbitHole) //if the user's choice is not the rabbit hole, marks the hole chosen w/ an X
            {
                array[userChoice - 1] = "X";
            }
            else //If the user chooses the right hole, marks it w/ an R
            {
                array[userChoice - 1] = "R";
            }

            //If the user chooses the right hole, tells the user they have found the rabbit and prints out the array
            if(userChoice == rabbitHole)
            {
                Console.WriteLine("You found the rabbit!");
                Console.WriteLine("It only took you " + userTries + " tries!");
                for (int i = 0; i < array.Length; i++)
                {
                    if (count == 1)
                    {
                        Console.Write("|");
                    }
                    count++;

                    if (array[i] == "R" && userChoice == rabbitHole)
                    {
                        Console.Write(String.Format("{0,7}", "R  |"));
                    }
                    else if (array[i] == "X")
                    {
                        Console.Write(String.Format("{0, 7}", "X  |"));
                    }
                    else
                    {
                        Console.Write(String.Format("{0,4}", (i + 1)));
                        Console.Write("  |");
                    }

                    if (count == 8)
                    {
                        Console.WriteLine();
                        count = 1;
                    }
                }
            }
            else
            {
                for(int i = 0; i < array.Length; i++)
                {
                    if(count == 1)
                    {
                        Console.Write("|");
                    }
                    count++;

                    if ((array[i] == "R") && (userChoice == rabbitHole))
                    {
                        Console.Write(String.Format("{0, 7}", "R  |"));
                    }
                    if(array[i] == "X")
                    {
                        Console.Write(String.Format("{0, 7}", "X  |"));
                    }
                    else
                    {
                        Console.Write(String.Format("{0, 4}", (i+1)));
                        Console.Write("  |");
                    }

                    if(count == 8)
                    {
                        Console.WriteLine();
                        count = 1;
                    }
                }
                userTries++;
                findRabbit(array, rabbitHole, userTries);
            }
        }
    }
}
