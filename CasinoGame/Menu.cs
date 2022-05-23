using System;
using System.IO;

namespace CasinoGame
{
    public class Menu : Player
    {
        internal string path = "../../../pass.txt";
        public Player p1 = new Player();
        internal void Switch()
        {
            Console.WriteLine("[1] Sign-In");
            Console.WriteLine("[2] Create Acc");

            bool correct = false;
            while (!correct)
            {
                string result = Console.ReadLine();
                bool succes = Int32.TryParse(result, out int numb);

                if (!succes)
                {
                    Console.WriteLine("Wrong input");
                }

                switch (numb)
                {
                    case 1:
                        if (File.Exists(path))
                        {
                            LogIn();
                            correct = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Any account alredy doesn't exist");
                            break;
                        }

                    case 2:
                        CreateAcc();
                        correct = true;
                        break;
                    default:
                        Console.WriteLine("Choose between 1 and 2");
                        break;
                }
            }

        }
        void LogIn()
        {
            string secondLine;
            string firstLine;
            //string money;
            using (StreamReader sr = new StreamReader(path))
            {
                firstLine = sr.ReadLine();
                secondLine = sr.ReadLine();
                bankAccount = float.Parse(sr.ReadLine());
                sr.Close();
            }
            while (true)
            {
                Console.Write("Enter your name: ");
                p1.Name = Console.ReadLine();

                Console.Write("Enter your password: ");
                p1.Password = Console.ReadLine();

                if (p1.Name != firstLine || p1.Password != secondLine)
                {
                    RedComunicate("Name or password are wrong\n");
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            MainMenu();
        }
        void CreateAcc()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {

                while (p1.Name == null)
                {
                    Console.Write("Enter your name: ");
                    p1.Name = Console.ReadLine();

                }
                sw.WriteLine(p1.Name);
                Console.Write("Enter your password: ");
                p1.Password = Console.ReadLine();

                sw.WriteLine(p1.Password);
                sw.WriteLine(bankAccount.ToString(), true);
                sw.Close();
            }

            Console.Clear();
            MainMenu();

        }
        internal void MainMenu()
        {
            Account();

            Console.WriteLine("Choose the game: ");
            Console.WriteLine("[1] War game/ Battle game");
            Console.WriteLine("[2] Heads or Tails");
            Console.WriteLine("[3] Three in row");
            Console.WriteLine("[4] Roulette");
            int result;



            var games = new Casino();
            bool correct = false;
            while (!correct)
            {
                while (true)
                {
                    try
                    {
                        result = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect input!");
                    }
                }
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        games.WarGame();
                        correct = true;
                        break;
                    case 2:
                        Console.Clear();
                        games.HeadsOrTails();
                        correct = true;
                        break;
                    case 3:
                        Console.Clear();
                        games.ThreeInRowMachine();
                        correct = true;
                        break;
                    case 4:
                        Console.Clear();
                        games.Roulette();
                        correct = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

        }
        public void RedComunicate(string comunicate)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(comunicate);
            Console.ResetColor();
        }
        public void GreenComunicate(string comunicate)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(comunicate);
            Console.ResetColor();
        }
    }
}
