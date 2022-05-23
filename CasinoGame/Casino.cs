using System;
using System.IO;
using System.Linq;

namespace CasinoGame
{
    public class Casino : Menu
    {

        void Save()
        {
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(lines.Length - 1).ToArray());
            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine(bankAccount);
        }
        private static float MakingPrice()
        {

            while (true)
            {
                Console.Write("Price of bet ('a' to all in):  ");
                try
                {
                    string input = Console.ReadLine();
                    float priceOfBet;
                    if (input == "a")
                    {
                        priceOfBet = bankAccount;
                        return priceOfBet;
                    }
                    else
                    {
                        priceOfBet = float.Parse(input);

                        if (priceOfBet > bankAccount)
                        {
                            Console.WriteLine("You don't have enough money");
                        }
                        else if (priceOfBet == 0)
                        {
                            Console.WriteLine("Bet have to be for more than 0$");
                        }
                        else
                        {
                            return priceOfBet;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        void Card(string comunicate)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(comunicate + " \n");
            Console.ResetColor();
        }

        float P1Course(string firstCard)
        {
            float playerOneCourse = 1f;
            switch (firstCard)
            {
                case "3":
                    playerOneCourse = 11.50f;
                    return playerOneCourse;
                case "4":
                    playerOneCourse = 6.11f;
                    return playerOneCourse;
                case "5":
                    playerOneCourse = 3.94f;
                    return playerOneCourse;
                case "6":
                    playerOneCourse = 3.15f;
                    return playerOneCourse;
                case "7":
                    playerOneCourse = 2.41f;
                    return playerOneCourse;
                case "8":
                    playerOneCourse = 2.11f;
                    return playerOneCourse;
                case "9":
                    playerOneCourse = 1.80f;
                    return playerOneCourse;
                case "10":
                    playerOneCourse = 1.62f;
                    return playerOneCourse;
                case "J":
                    playerOneCourse = 1.36f;
                    return playerOneCourse;
                case "D":
                    playerOneCourse = 1.25f;
                    return playerOneCourse;
                case "K":
                    playerOneCourse = 1.07f;
                    return playerOneCourse;
                case "A":
                    playerOneCourse = 1.03f;
                    return playerOneCourse;
                default:
                    return playerOneCourse;

            }

        }
        float P2Course(string firstCard)
        {
            float playerTwoCourse = 1f;
            switch (firstCard)
            {
                case "2":
                    playerTwoCourse = 1.03f;
                    return playerTwoCourse;
                case "3":
                    playerTwoCourse = 1.07f;
                    return playerTwoCourse;
                case "4":
                    playerTwoCourse = 1.19f;
                    return playerTwoCourse;
                case "5":
                    playerTwoCourse = 1.32f;
                    return playerTwoCourse;
                case "6":
                    playerTwoCourse = 1.48f;
                    return playerTwoCourse;
                case "7":
                    playerTwoCourse = 1.64f;
                    return playerTwoCourse;
                case "8":
                    playerTwoCourse = 1.94f;
                    return playerTwoCourse;
                case "9":
                    playerTwoCourse = 2.27f;
                    return playerTwoCourse;
                case "10":
                    playerTwoCourse = 2.78f;
                    return playerTwoCourse;
                case "J":
                    playerTwoCourse = 3.78f;
                    return playerTwoCourse;
                case "D":
                    playerTwoCourse = 6.20f;
                    return playerTwoCourse;
                case "K":
                    playerTwoCourse = 12.03f;
                    return playerTwoCourse;
                default:
                    return playerTwoCourse;
            }

        }

        internal void WarGame()
        {
            char end;
            do
            {
                string[] firstChoiceArr = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };
                string[] secondChoiceArr = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };

                while (true)
                {
                    Bankrupt();
                    Account();
                    #region randoms
                    Random random = new Random();
                    Random anotherRandom = new Random();
                    int numb1 = random.Next(0, firstChoiceArr.Length);
                    int numb2 = anotherRandom.Next(0, secondChoiceArr.Length);
                    #endregion randoms
                    string[] winOrLoseOrDrawChoice = new string[] { "[1]First Player Win", "[2]Second Player Win", "[3]Draw" };

                    string first = firstChoiceArr[numb1];
                    string second = secondChoiceArr[numb2];

                    Console.Write("First Player Card: "); Card(first);

                    Console.WriteLine("Take a bet");

                    Console.Write($"{winOrLoseOrDrawChoice[0]}"); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine($" {P1Course(first)}"); Console.ResetColor();
                    Console.Write($"{winOrLoseOrDrawChoice[1]}"); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine($" {P2Course(first)}"); Console.ResetColor();
                    Console.Write($"{winOrLoseOrDrawChoice[2]}"); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine(" 14.00"); Console.ResetColor();

                    bool isCorrectBet = false;
                    while (!isCorrectBet)
                    {

                        string myChoice = Console.ReadLine();

                        float priceOfBet = MakingPrice();
                        bankAccount -= priceOfBet;

                        float course;
                        switch (myChoice)
                        {
                            case "1":
                                course = P1Course(first);
                                if (numb1 > numb2)
                                {
                                    Console.Write("Second Player Card: "); Card(second);
                                    GreenComunicate("You win " + (Math.Round(priceOfBet * course, 2)));

                                    bankAccount += (priceOfBet * course);
                                }
                                else if (numb1 < numb2)
                                {
                                    Console.Write("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                else if (numb1 == numb2)
                                {
                                    Console.Write("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                isCorrectBet = true;
                                break;
                            case "2":
                                course = P2Course(first);
                                if (numb1 < numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    GreenComunicate("You win " + (Math.Round(priceOfBet * course, 2)));

                                    bankAccount += (priceOfBet * course);
                                }
                                else if (numb1 > numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                else if (numb1 == numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                isCorrectBet = true;
                                break;
                            case "3":
                                if (numb1 > numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                else if (numb1 < numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    RedComunicate("You lose");
                                }
                                else if (numb1 == numb2)
                                {
                                    Console.WriteLine("Second Player Card: "); Card(second);
                                    GreenComunicate("You win " + (Math.Round(priceOfBet * 14f, 2))); bankAccount += (priceOfBet * 14f);
                                }
                                isCorrectBet = true;
                                break;
                            default:
                                RedComunicate("Incorrect input, correct it: ");
                                isCorrectBet = false;
                                break;
                        }
                        Save();
                        Bankrupt();
                    }


                    Console.WriteLine("\nOne more try? [y]/[n]");
                    while (true)
                    {
                        try
                        {
                            end = Console.ReadLine()[0];
                            break;
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Incorect input");
                        }
                    }
                    if (end == 'n')
                    {
                        break;
                    }
                    Console.Clear();
                }
                Bankrupt();
            } while (end != 'n');
            Console.Clear();
            MainMenu();

        }
        internal void HeadsOrTails()
        {
            char end;
            do
            {
                Bankrupt();
                Account();
                string[] winLoseArr = new string[] { "Head", "Tails" };
                string[] winOrLoseChoice = new string[] { "[1]Head", "[2]Tails" };
                Random random = new Random();
                int hT = random.Next(0, winLoseArr.Length);

                bool isCorrectBet = false;

                Console.WriteLine("Take a bet");
                foreach (var item in winOrLoseChoice)
                {
                    Console.WriteLine(item);
                }
                while (!isCorrectBet)
                {
                    string myChoice = Console.ReadLine();
                    float priceOfBet = MakingPrice();
                    switch (myChoice)
                    {
                        case "1":
                            if (hT == 0)
                            {
                                Console.WriteLine("Crupier draw a: "); Card(winLoseArr[hT]);
                                GreenComunicate("You win"); bankAccount += priceOfBet;
                            }
                            else
                            {
                                Console.WriteLine("Crupier draw a: "); Card(winLoseArr[hT]);
                                RedComunicate("You lose"); bankAccount -= priceOfBet;
                            }
                            isCorrectBet = true;
                            break;
                        case "2":
                            if (hT == 0)
                            {
                                Console.WriteLine("Crupier draw a: "); Card(winLoseArr[hT]);
                                RedComunicate("You lose"); bankAccount -= priceOfBet;

                            }
                            else
                            {
                                Console.WriteLine("Crupier draw a: "); Card(winLoseArr[hT]);
                                GreenComunicate("You win"); bankAccount += priceOfBet;
                            }
                            isCorrectBet = true;
                            break;
                        default:
                            RedComunicate("Incorrect input, correct it: ");
                            isCorrectBet = false;
                            break;

                    }
                    Save();

                    Bankrupt();

                }
                Console.WriteLine("One more ty? [y]/[n]");
                while (true)
                {
                    try
                    {
                        end = Console.ReadLine()[0];
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorect input");
                    }
                }

                Console.Clear();
            } while (end != 'n');

            MainMenu();

        }
        internal void ThreeInRowMachine()
        {
            char end;
            string[] symbolsArr = new string[] { "@", "#", "$", "%", "&", "*" };
            do
            {
                Bankrupt();
                while (true)
                {
                    Account();
                    #region randoms
                    Random random = new Random();
                    Random random1 = new Random();
                    Random random2 = new Random();
                    int sb = random.Next(0, symbolsArr.Length);
                    int sb1 = random1.Next(0, symbolsArr.Length);
                    int sb2 = random2.Next(0, symbolsArr.Length);
                    #endregion

                    float price = MakingPrice();
                    Console.Write($"{symbolsArr[sb]} {symbolsArr[sb1]} {symbolsArr[sb2]}\n");
                    if (sb == sb1 && sb == sb2)
                    {
                        Console.WriteLine("YOU WIN!!!!!!!!");
                        bankAccount += (price * 1000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lose");
                        bankAccount -= price;
                        break;
                    }

                }
                Save();
                Bankrupt();

                Console.WriteLine("One more ty? [y]/[n]");
                while (true)
                {
                    try
                    {
                        end = Console.ReadLine()[0];
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorect input");
                    }
                }

                Console.Clear();

            } while (end != 'n');

            MainMenu();

        }
        internal void Roulette()
        {
            char end;
            do
            {
                Bankrupt();
                string[] winLoseArr = new string[36];
                for (int i = 0; i < winLoseArr.Length; i++)
                {
                    if (i == 0)
                    {
                        winLoseArr[i] = "green";
                    }
                    else if (i % 2 == 0)
                    {
                        winLoseArr[i] = "black";
                    }
                    else
                    {
                        winLoseArr[i] = "red";
                    }

                }
                string[] winOrLoseChoice = new string[] { "[1]Black", "[2]Red", "[3]Green" };


                Account();
                Random random = new Random();
                int rbg = random.Next(0, winLoseArr.Length);

                bool isCorrectBet = false;

                Console.WriteLine("Take a bet");
                foreach (var item in winOrLoseChoice)
                {
                    Console.WriteLine(item);
                }
                while (!isCorrectBet)
                {

                    string myChoice = Console.ReadLine();
                    float priceOfBet = MakingPrice();
                    switch (myChoice)
                    {
                        case "1":
                            if (rbg != 0 && rbg % 2 == 0)
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                GreenComunicate("You win"); bankAccount += priceOfBet;
                            }
                            else
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                RedComunicate("You lose"); bankAccount -= priceOfBet;
                            }
                            isCorrectBet = true;
                            break;
                        case "2":
                            if (rbg != 0 && rbg % 2 != 0)
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                GreenComunicate("You win"); bankAccount += priceOfBet;

                            }
                            else
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                RedComunicate("You lose"); bankAccount -= priceOfBet;
                            }
                            isCorrectBet = true;
                            break;
                        case "3":
                            if (rbg == 0)
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                GreenComunicate("You win"); bankAccount += (35 * priceOfBet);

                            }
                            else
                            {
                                Console.WriteLine("Result: "); Card(winLoseArr[rbg]);
                                RedComunicate("You lose"); bankAccount -= priceOfBet;
                            }
                            isCorrectBet = true;
                            break;
                        default:
                            RedComunicate("Incorrect input, correct it: ");
                            isCorrectBet = false;
                            break;

                    }

                }
                Save();
                Bankrupt();

                Console.WriteLine("One more ty? [y]/[n]");
                while (true)
                {
                    try
                    {
                        end = Console.ReadLine()[0];
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorect input");
                    }
                }

                Console.Clear();

            } while (end != 'n');

            MainMenu();
        }
    }
}
