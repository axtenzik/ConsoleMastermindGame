using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            //6 colours, 4 holes, 12 turns

            int turn;
            int colours;
            bool successful;

            do
            {
                Console.Clear();
                Console.WriteLine("How many turns do you want? Minimum is 4, Maximum is 100");
                successful = Int32.TryParse(Console.ReadLine(), out turn);
                if (turn < 1 || turn > 100)
                {
                    successful = false;
                }
            } while (!successful);

            do
            {
                Console.Clear();
                Console.WriteLine("Please choose between 6 and 17 colours");
                successful = Int32.TryParse(Console.ReadLine(), out colours);
                if (colours < 6 || colours > 17)
                {
                    successful = false;
                }
            } while (!successful);

            Random rnd = new Random();
            int[] rand = new int[4]; //the four random number the player has to guess
            rand[0] = rnd.Next(1, colours + 1);
            rand[1] = rnd.Next(1, colours + 1);
            rand[2] = rnd.Next(1, colours + 1);
            rand[3] = rnd.Next(1, colours + 1);
            int[] ans = new int[4]; // the four numbers that the player guesses
            string[] input = new string[4];
            string[] pastGuesses = new string[turn]; //array to store all the past guesses
            int[] correct = new int[turn];
            int[] incorrect = new int[turn];
            bool[] pos = new bool[4];
            bool[] colour = new bool[4];
            int right = 0;
            int wrong = 0;
            string[] place = new string[] { "first", "second", "third", "forth" };
            string[] allColours = new string[] { "Red", "Green", "Blue", "Yellow", "Purple", "White", "Black", "Orange", "Pink", "Grey", "Brown", "Indigo", "Violet", "Cyan", "Magenta", "Turquoise", "Lime" };

            for (int i = 0; i < turn; i++) //loop for each turn
            {
                Console.Clear();
                //Console.WriteLine("These are the random numbers {0}, {1}, {2}, {3}",rand[0], rand[1], rand[2], rand[3]);
                //Console.WriteLine("The colours that you can choose from are: Red, Green, Blue, Yellow, Purple and White"); //Need to change this for different colour amounts
                Console.Write("The colours that you can choose from are: ");
                for (int list = 0; list < colours - 1; list++)
                {
                    Console.Write("{0}", allColours[list]);
                    if (list < colours - 2)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.Write(" and {0}", allColours[list + 1]);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("You are currently on turn {0} of {1}", i + 1, turn);
                if (i != 0)
                {
                    Console.WriteLine("You got {0} that are the right colour in the right place", right);
                    Console.WriteLine("You got {0} that are the right colour, but they are in the wrong place", wrong);
                    Console.WriteLine("Your previous guesses are: ");
                }
                
                int j = 0;
                while (j < i)
                {
                    Console.WriteLine("{0} {1} {2}", pastGuesses[j], correct[j], incorrect[j]);
                    j++;
                }
                /*do
                {
                    Console.WriteLine("{0} {1} {2}", pastGuesses[j], correct[j], incorrect[j]);
                    j++;
                } while (j < i);*/

                Console.WriteLine();

                int k = 0;

                while (k < 4)
                {
                    Console.Write("Please enter your {0} colour: ", place[k]);
                    input[k] = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    switch (input[k])
                    {
                        case "RED":
                            ans[k] = 1;
                            k++;
                            break;
                        case "GREEN":
                            ans[k] = 2;
                            k++;
                            break;
                        case "BLUE":
                            ans[k] = 3;
                            k++;
                            break;
                        case "YELLOW":
                            ans[k] = 4;
                            k++;
                            break;
                        case "PURPLE":
                            ans[k] = 5;
                            k++;
                            break;
                        case "WHITE":
                            ans[k] = 6;
                            k++;
                            break;
                        case "BLACK":
                            if (colours >= 7)
                            {
                                ans[k] = 7;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "ORANGE":
                            if (colours >= 8)
                            {
                                ans[k] = 8;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "PINK":
                            if (colours >= 9)
                            {
                                ans[k] = 9;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "GREY":
                            if (colours >= 10)
                            {
                                ans[k] = 10;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "BROWN":
                            if (colours >= 11)
                            {
                                ans[k] = 11;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "INDIGO":
                            if (colours >= 12)
                            {
                                ans[k] = 12;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "VIOLET":
                            if (colours >= 13)
                            {
                                ans[k] = 13;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "CYAN":
                            if (colours >= 14)
                            {
                                ans[k] = 14;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "MAGENTA":
                            if (colours >= 15)
                            {
                                ans[k] = 15;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "TURQUOISE":
                            if (colours >= 16)
                            {
                                ans[k] = 16;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        case "LIME":
                            if (colours >= 17)
                            {
                                ans[k] = 17;
                                k++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            }
                            break;
                        default:
                            Console.WriteLine("Incorrect input! Please answer with a valid colour.");
                            break;

                    }

                }

                pastGuesses[i] = input[0] + ", " + input[1] + ", " + input[2] + ", " + input[3];

                right = 0;
                wrong = 0;

                if (ans[0] == rand[0] && ans[1] == rand[1] && ans[2] == rand[2] && ans[3] == rand[3])
                {
                    Console.WriteLine("You win");
                    break;
                }
                else
                {
                    pos[0] = false;
                    pos[1] = false;
                    pos[2] = false;
                    pos[3] = false;
                    colour[0] = false;
                    colour[1] = false;
                    colour[2] = false;
                    colour[3] = false;
                    for (int l = 0; l < 4; l++)
                    {
                        if (ans[l] == rand[l]) //if answer in position L is the same as the random number in position l
                        {
                            right = right + 1; // add 1 to right answer, right place
                            pos[l] = true;
                            colour[l] = true;
                        }
                        /*else if (ans[l] == rand[0] && pos[0] == false)
                        {
                            wrong = wrong + 1; // add 1 to right answer, wrong place
                            pos[0] = true;
                        }
                        else if (ans[l] == rand[1] && pos[1] == false)
                        {
                            wrong = wrong + 1;
                            pos[1] = true;
                        }
                        else if (ans[l] == rand[2] && pos[2] == false)
                        {
                            wrong = wrong + 1;
                            pos[2] = true;
                        }
                        else if (ans[l] == rand[3] && pos[3] == false)
                        {
                            wrong = wrong + 1;
                            pos[3] = true;
                        }*/

                    }
                    for (int l = 0; l < 4; l++)
                    {
                        if (ans[l] == rand[0] && pos[0] == false && colour[l] == false)
                        {
                            wrong = wrong + 1; // add 1 to right answer, wrong place
                            pos[0] = true;
                        }
                        else if (ans[l] == rand[1] && pos[1] == false && colour[l] == false)
                        {
                            wrong = wrong + 1;
                            pos[1] = true;
                        }
                        else if (ans[l] == rand[2] && pos[2] == false && colour[l] == false)
                        {
                            wrong = wrong + 1;
                            pos[2] = true;
                        }
                        else if (ans[l] == rand[3] && pos[3] == false && colour[l] == false)
                        {
                            wrong = wrong + 1;
                            pos[3] = true;
                        }
                    }
                    correct[i] = right;
                    incorrect[i] = wrong;
                    
                }


                /*Console.Write("PLease enter your second colour: ");
                input2 = Console.ReadLine().ToUpper();
                Console.WriteLine();

                Console.Write("Please enter your third colour: ");
                input3 = Console.ReadLine().ToUpper();
                Console.WriteLine();

                Console.Write("Please enter your fourth colour: ");
                input4 = Console.ReadLine().ToUpper();
                Console.WriteLine();
                */


                //use ToUpper itll convert characters to upper case
            }


            Console.WriteLine("This was the sequence of colours: {0}, {1}, {2}, {3}",allColours[rand[0] - 1], allColours[rand[1] - 1], allColours[rand[2] - 1], allColours[rand[3] - 1]);
            Console.ReadKey();
        }
    }
}
