using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoulletteVinnieEx
{
    class Program
    {
        static decimal userPot { get; set; }
        static void Main()
        {

            try
            {
                Console.WriteLine("!!!Welcome To Rusty Roulette!!!");
                Console.WriteLine("---Enter Your Total Pot Amount--- ");
                userPot = Convert.ToDecimal(Console.ReadLine());
                //user sets the amount they have 'coming to the table' o they cant go over their amount in their 'pot'
                Console.WriteLine($"---Your pot amount is {userPot}---");
                Bet A = new Bet(userPot);
                A.NumberOfBets();
            }
            catch(ArgumentNullException)
            {
                Main();
            }
            catch(FormatException)
            {
                Main();
            }
        }
    }

}
