using System;

namespace CasinoGame
{
    public class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Name have to has more than 2 letters");
                }
                else
                {
                    name = value;
                }
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static float bankAccount = 30;


        internal void Account()
        {
            Console.SetCursorPosition(30, 2);
            Console.WriteLine($"Your cash: {Math.Round(bankAccount, 2)}$");
            Console.SetCursorPosition(0, 0);
        }
        internal void Bankrupt()
        {
            if (bankAccount <= 0)
            {
                Console.WriteLine("No money. You lose");
                throw new Exception("No money");
            }
        }

    }
}
