using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoulletteVinnieEx
{
    class Bet
    {

        public decimal userPot { get; set; }

        public List<Tuple<int,string, decimal>> tupleList = new List<Tuple<int, string, decimal>>();
        public int locationOfBet { get; set; }
        public decimal valueOfBet { get; set; }
        public string secondLocationOfBet { get; set; }
        public Random rand = new Random();
        public int ballroll { get; set; }

        RouletteBoard Board = new RouletteBoard();
        public Bet(decimal A)
        {
            userPot = A;
            
        }
        public void NumberOfBets()
        {
            // this method operates as the entry point to the class.
            //this method is where the user will ultimately return until they no longer want to play
            while (userPot > 0)
            {
                //allows the user ton input the amount of bets they would liek to place and stores this into a variable
                int numberOfBets = 0;
                Console.WriteLine("---Its Time To Play Roulette!----");
                Console.WriteLine("----type (-1) if you would like to exit---");
                Console.WriteLine("----How many bets would you like to place?---");
                //the variable the number of bets will be placed in
                numberOfBets = int.Parse(Console.ReadLine());
                if (numberOfBets > 0)
                {//looping the number of bets chosen to be placed to allow the specifics of the bet
                    while (numberOfBets > 0)
                    {
                        UserInterface();
                        numberOfBets--;

                    }
                    Console.WriteLine("----are you ready to play your chances?----");
                    Console.WriteLine("----press enter  if you are ready to roll!----");
                    Console.ReadLine();
                    //randomly select number or "roll ball", and save value into a field to be used in each method
                    ballroll = rand.Next(0, 38);
                    //calls method to evaluate each bet given the ball value
                    EvaluateThatTuple();
                }
                else if (numberOfBets <0)
                {
                    break;
                }
                else
                //recalls the method to allow more bets to be placed
                NumberOfBets();
            }
            Console.WriteLine("Sorry But you are out of money!");
            Console.ReadLine();
            return;
        }
        public void UserInterface()
        {
            //menu that allows users to select where bet will be placed.
            Console.WriteLine("----Choose where to place your bet!---");
            Console.WriteLine($"your pot amount is {userPot}");
            Console.WriteLine("1.On One Single Number.");
            Console.WriteLine("2.Evens/Odds.");
            Console.WriteLine("3.Reds/Blacks.");
            Console.WriteLine("4.Lows/Highs.");
            Console.WriteLine("5.Dozens(row thirds).");
            Console.WriteLine("6.Columns.");
            Console.WriteLine("7.Streets(rows).");
            Console.WriteLine("8.6 Numbers.");
            Console.WriteLine("9.Splits.");
            Console.WriteLine("10.Corners.");
            //field storing the value of the locationbet for use in the tuple
            locationOfBet = int.Parse(Console.ReadLine());
            Console.WriteLine("----Enter the amount you wish to bet----");
            //field stroing monetary vaue of bet to be placed in tuple
            valueOfBet = Convert.ToDecimal(Console.ReadLine());
            if (valueOfBet > userPot)
            {
                Console.WriteLine("you cannot bet more money than you have!");
                UserInterface();
            }
            else 
            {

                switch (locationOfBet)
                {
                    //switch which evaluates which of the ten initial bet options the user has chosen and saves it into a field which will be used in the tuple
                    //each case contains a menas of a bet which will allow the user to pic which submenu or "specific bet" they want to use
                    case 1:
                        Console.WriteLine("--Choose your Individual Value 1-36, if betting 0 type 37 and if betting 00 type 38--");
                        secondLocationOfBet = (int.Parse(Console.ReadLine()) - 1).ToString();
                        break;
                    case 2:
                        Console.WriteLine("--Choose wether you want to place your bet on odd or Even--");
                        Console.WriteLine("---type (even) or (odd) and press enter---");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("---Choose wether you want to place your bet on Reds or Blacks---");
                        Console.WriteLine("---Options are (red) or (black), type where you want to place your bet and press enter---");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("---Choose wether you want to place your bet on lows or highs---");
                        Console.WriteLine("---Options are (low) or (high), type where you want to place your bet and press enter---");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("---Choose which dozen you want to place your bet on---");
                        Console.WriteLine("---Options are (dozen 1)=(1-12),(doxen 2)=(13-24),(dozen 3)=(25-36)");
                        Console.WriteLine(" type the words in () corresponding to your choice column and press enter---");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("---Choose which dozen you want to place your bet on---");
                        Console.WriteLine("---Options are (column 1),(column 2),(column 3) type the words in () corresponding to your choice column and press enter---");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("enter a single number in the street you wish to Choose and press enter");
                        Console.WriteLine("Streets are (1,2,3)(4,5,6)(7,8,9)(10,11,12)(13,14,15)(16,17,18)(19,20,21)");
                        Console.WriteLine("streets are (22,23,24)(25,26,27)(28,29,30(31,32,33)(34,35,36)");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("enter a single number withinin the sixes you wish to Choose and press enter");
                        Console.WriteLine("sixes are (1,2,3,4,5,6)(4,5,6,7,8,9)(7,8,9,10,11,12)(10,11,12,13,14,15)(13,14,15,16,17,18)");
                        Console.WriteLine("sixes are (16,17,18,19,20,21)(19,20,21,22,23,24)(22,23,24,25,26,27)");
                        Console.WriteLine("(25,26,27,28,29,30)(28,29,30,31,32,33)(31,32,33,34,35,36)");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("enter both numbers of the split you wish to choose seperated by a comma and press enter");
                        Console.WriteLine("example - 1,2 ");
                        secondLocationOfBet = Console.ReadLine();
                        break;
                    case 10:
                        //this menu is  different due to the user having to nter so many numbers
                        //in order to prevent input error the user simply chooses a number corresponding to a string which then corresponds to a switch case that will auto fill their choice
                        Console.WriteLine("enter the number coresponding to the corner you wish to bet on and press enter");
                        Console.WriteLine("1.(1,2,4,5) 2.(2,3,5,6) 3.(4,5,7,8) 4.(5,6,8,9)");
                        Console.WriteLine("5.(7,8,10,11) 6.(8,9,11,12) 7.(10,11,13,14) 8.(11,12,14,15)");
                        Console.WriteLine("9.(13,14,16,17) 10.(14,15,17,18) 11.(16,17,19,20) 12.(17,18,20,21)");
                        Console.WriteLine("13.(19,20,22,23) 14.(20,21,23,24) 15.(22,23,25,26) 16.(23,24,26,27)");
                        Console.WriteLine("17.(25,26,28,29) 18.(26,27,29,30) 19.(31,32,34,35) 20.(32,33,35,36)");
                        int userSelection = int.Parse(Console.ReadLine());
                        switch(userSelection)
                        {
                            case 1:
                                secondLocationOfBet = "1,2,4,5";
                                break;
                            case 2:
                                secondLocationOfBet = "2,3,5,6";
                                break;
                            case 3:
                                secondLocationOfBet = "4,5,7,8";
                                break;
                            case 4:
                                secondLocationOfBet = "5,6,8,9";
                                break;
                            case 5:
                                secondLocationOfBet = "7,8,10,11";
                                break;
                            case 6:
                                secondLocationOfBet = "8,9,11,12";
                                break;
                            case 7:
                                secondLocationOfBet = "10,11,13,14";
                                break;
                            case 8:
                                secondLocationOfBet = "11,12,14,15";
                                break;
                            case 9:
                                secondLocationOfBet = "13,14,16,17";
                                break;
                            case 10:
                                secondLocationOfBet = "14,15,17,18";
                                break;
                            case 11:
                                secondLocationOfBet = "16,17,19,20";
                                break;
                            case 12:
                                secondLocationOfBet = "17,18,20,21";
                                break;
                            case 13:
                                secondLocationOfBet = "19,20,22,23";
                                break;
                            case 14:
                                secondLocationOfBet = "20,21,23,24";
                                break;
                            case 15:
                                secondLocationOfBet = "22,23,25,26";
                                break;
                            case 16:
                                secondLocationOfBet = "23,24,26,27";
                                break;
                            case 17:
                                secondLocationOfBet = "25,26,28,29";
                                break;
                            case 18:
                                secondLocationOfBet = "26,27,29,30";
                                break;
                            case 19:
                                secondLocationOfBet = "31,32,34,35";
                                break;
                            case 20:
                                secondLocationOfBet = "32,33,35,36";
                                break;
                            default:
                                UserInterface();
                                break;
                        }
                        break;
                    default:
                        UserInterface();
                        break;
                }
                //creates a tuple to be used as an "address" for the monetary value
                tupleList.Add(Tuple.Create(locationOfBet, secondLocationOfBet, valueOfBet));
            }
        }
        public void EvaluateThatTuple()
        {
            //method that evaluates the tuple and decides whhich menu, sub menu will get the monrtary value

            for (int i = 0; i < tupleList.Count; i++)
            {//counts through the items in the list of tuples or "list of bets" to place each bet and print if won or lost

                switch (tupleList[i].Item1)
                {//evaluates the initial tuple value which is the main menu assignment

                    case 1:
                        SingleValueBet(i);
                        break;
                    case 2:
                        EvenOddBet(i);
                        break;
                    case 3:
                        RedsBlacksBet(i);
                        break;
                    case 4:
                        LowsHighsBet(i);
                        break;
                    case 5:
                        DozensBet(i);
                        break;
                    case 6:
                        ColumnsBet(i);
                        break;
                    case 7:
                        StreetsBet(i);
                        break;
                    case 8:
                        SixNumbersBet(i);
                        break;
                    case 9:
                        SplitsBet(i);
                        break;
                    case 10:
                        CornersBet(i);
                        break;
                    default:
                        UserInterface();
                        break;
                }
                Console.WriteLine($"---your pot amount is now $ {userPot}  ----");
                
            }

            NumberOfBets();
        }
        //the following methods are called from the initial item in the tuple and will take the second item of the tuple to show which item the user chose
        public void SingleValueBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing
            int placeHolderForBet = int.Parse(tupleList[i].Item2);
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            if(ballroll == placeHolderForBet)
            {
                //action if player wins bet
                dealerPayout = moneyOnTable * 35;
                moneyOnTable = moneyOnTable + dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet +1} payed out and you earned {dealerPayout}");
            }
            else
            {
                //action if player loses bet
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet +1} did not payout and you lost {moneyOnTable}");
            }
        }
        public void EvenOddBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing 
            string placeHolderForBet = tupleList[i].Item2;
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            string isEvenOrOdd = null;
            //deciding if the ball rolled on an even or odd number
            if(ballroll % 2==0)
            {
                isEvenOrOdd = "even";
            }
            else
            {
                isEvenOrOdd = "odd";
            }
            
            if(placeHolderForBet == isEvenOrOdd)
            {
                //if user bet wins
                dealerPayout = moneyOnTable * 2;
                moneyOnTable =  dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet} payed out and you earned {dealerPayout}");
            }
            else
            {
                //if user bet loses
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet} did not payout and you lost {moneyOnTable}");
            }
            
        }
        public void RedsBlacksBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing 
            string placeHolderForBet = tupleList[i].Item2;
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            List<int> Reds = new List<int>();
            List<int> Blacks = new List<int>();
            string winningColor = null;
            //creates lists of numbers on board which are red or black
            foreach (Cell c in Board.GridCells)
            {
                if (c.Color == CellColor.Red)
                {
                    Reds.Add(c.Value);
                }
            }
            foreach (Cell c in Board.GridCells)
            {
                if (c.Color == CellColor.Black)
                {
                    Blacks.Add(c.Value);
                }
            }
            //sorts through red numbers to see if the value matches the winning number
            //if the number matches a red number the winningcolor variable is set to red else it is set to black
            foreach(int value in Reds)
            {
                if(value == ballroll)
                {
                    winningColor = "red";
                    
                }
                else
                {
                    winningColor = "black";
                    
                }
            }
            //if statement evaluates if the user chose to bet on red or black and compares it to the winning color to see if they won
            if(winningColor == placeHolderForBet)
            {
                dealerPayout = moneyOnTable * 2;
                moneyOnTable =  dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet} payed out and you earned {dealerPayout}");
            }
            else
            {
                //if user bet loses
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet} did not payout and you lost {moneyOnTable}");              
            }
        }

        public void LowsHighsBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing 
            string placeHolderForBet = tupleList[i].Item2;
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            string lowOrHigh = null;
            //if statement set winnning low or high variable to low or high depending on what number the ball roll is
            //if the ballrolls lower thn 18 it is a low else it must be a high
            if(ballroll < 18)
            {
                lowOrHigh = "low";
            }
            else
            {
                lowOrHigh = "high";
            }
            //compares the value the user entered to see if they hose low or high against the winning low or high variable
            if(placeHolderForBet == lowOrHigh)
            {
                dealerPayout = moneyOnTable * 2;
                moneyOnTable = dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet} payed out and you earned {dealerPayout}");
            }
            else
            {
                //if user bet loses
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet} did not payout and you lost {moneyOnTable}");
            }
        }
        public void DozensBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing 
            string placeHolderForBet = tupleList[i].Item2;
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            string whichDozen = null;
            //if statement evaluates where in the dozens the ball rolls
            //if the ball falls below 13 then whichdozen variabe is set to identity 1


            if(ballroll < 13)
            {
                whichDozen = "dozen 1";
            }
            //if the ball does not fall under 13 but does fall below 25 than it is asigned to the second dozen identity 2
            else if (ballroll < 25)
            {
                whichDozen = "dozen 2";
            }
            //if the ball doesnt fall below 25 it is set to the third and final dozen
            else
            {
                whichDozen = "dozen 3";
            }
            if(placeHolderForBet == whichDozen)
            {
                //if user bet matches which doezen won
                dealerPayout = moneyOnTable * 2;
                moneyOnTable = moneyOnTable + dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet} payed out and you earned {dealerPayout}");
            }
            else
            {
                //if user bet loses
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet} did not payout and you lost {moneyOnTable}");
            }
        }
        public void ColumnsBet(int i)
        {
            //variables for math to decide winning and losing amounts and if winning or losing 
            string placeHolderForBet = tupleList[i].Item2;
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            List<int> column_1 = new List<int>();
            List<int> column_2 = new List<int>();
            string winningColumnIs = null;
            //the for loops counts down through each row in the 2d array and adds the items to three seperate columns
            for (int x = 0; x < 1; x++)
            {
                for (int y = 0; y < Board.GridCells.GetLength(1); y++)
                {
                    column_1.Add(Board.GridCells[x, y].Value);
                }
            }
            for (int x = 1; x < 2; x++)
            {
                for (int y = 0; y < Board.GridCells.GetLength(1); y++)
                {
                    column_2.Add(Board.GridCells[x, y].Value);
                }
            }
            //these forrreach statements evaluate the values in each row starting with the first one, column 1
            //if the value doesnt fall into column on then the statement falls through and the next forreach reads the next clumn until a winner is found
            //whichever column is the winner is set in the variable winningcolumnis 
            foreach(int value in column_1)
            {
                if (ballroll == value)
                {
                    winningColumnIs = "column 1";
                }
                else
                    return;
            }
            foreach (int value in column_2)
            {
                if (ballroll == value)
                {
                    winningColumnIs = "column 2";
                }
                else
                {
                    winningColumnIs = "column 3";
                }
            }
            //if statement matches userinput to winning column to tell if they are the winnner
            if(placeHolderForBet == winningColumnIs)
            {
                dealerPayout = moneyOnTable * 2;
                moneyOnTable = moneyOnTable + dealerPayout;
                userPot = userPot + moneyOnTable;
                Console.WriteLine("Congrats you have won!");
                Console.WriteLine($" your bet on {placeHolderForBet} payed out and you earned {dealerPayout}");
            }
            else
            {
                //if user bet loses
                userPot = userPot - moneyOnTable;
                Console.WriteLine("sorry you didnt win");
                Console.WriteLine($"your bet on {placeHolderForBet} did not payout and you lost {moneyOnTable}");
            }
        }
        public void StreetsBet(int i)
        {
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            bool isStreetWinner = false;

            int[] tempStreet = new int[3];
            int streetId = 0;
            int userStreetId = 0;
            int numberOfUserChoice = int.Parse(tupleList[i].Item2);
            int J = 0;
            //the while continues the itmes within in it creating streets and evaluating if the strret is the winner
            //the for loop will create a 'street' by iterating through three numbers and incrementing variable j, each time the for loop is gone through the array strret will be overwritten
            //this is because you dont need to save all of the streets created, only the winning one. 
            //the foreach loop will then iterate through each item in the street created and comapare each value to the winning number or ball roll
            //if the street contains the ballroll than it is the winner and the bool statement isboolwinner is set to true exiting the while loop
            
            while (isStreetWinner == false)
            {
                streetId++;
                for (int j=0; j<3;j++)
                {
                    J++;
                    tempStreet[j] = J;
                    Console.WriteLine(tempStreet[j]);
                    
                }
                Console.WriteLine("break");
                
                foreach (int value in tempStreet)
                {
                    if (value == numberOfUserChoice)
                    {
                        userStreetId = streetId;
                    }
                }
                foreach (int value in tempStreet)
                {
                    if(value==ballroll)
                    {
                        isStreetWinner = true;
                    }
                }
            }
            //once the winning street is found the while loop is exited and the arr street is carried down to the rest of the actions
            foreach(int value in tempStreet)
            {
                //the items in the winning street are compared to the users number and if their number is contained in the winning street than that means they chose the winning street.
                if(value==numberOfUserChoice)
                {
                    dealerPayout = moneyOnTable * 11;
                    moneyOnTable = moneyOnTable + dealerPayout;
                    userPot = userPot + moneyOnTable;
                    Console.WriteLine("Congrats you have won!");
                    Console.WriteLine($" your bet on number {numberOfUserChoice} street{userStreetId} payed out and you earned {dealerPayout}");
                    return;
                }
                else
                {
                    break;
                }
            }
            userPot = userPot - moneyOnTable;
            Console.WriteLine("sorry you didnt win");
            Console.WriteLine($"your bet on {numberOfUserChoice} street{userStreetId} did not payout and you lost {moneyOnTable}");
        }
        public void SixNumbersBet(int i)
        {
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            int numberOfUserChoice = int.Parse(tupleList[i].Item2);
            int J = 1;
            int[] Sixes = new int[6];
            bool isSixesWinner = false;
            //this metho works the ame as the streets bet, the while loop continues creating new sixes and evaluating if the winning value is within it
            //this while loop differ because variable J will count to 6 and then subtract three afterwards from J.
            // this heppens because the sixes are counted from the beginning of each row on the roulette board
            while(isSixesWinner == false)
            {
                for(int j = 0; j < 6; j++)
                {
                    Sixes[j] = J;
                    J++;
                    
                }
                foreach(int value in Sixes)
                {
                    if(value==ballroll)
                    {
                        isSixesWinner = true;

                    }
                }
                J = J - 3;
            }
            foreach (int value in Sixes)
            {
                if (value == numberOfUserChoice)
                {
                    dealerPayout = moneyOnTable * 5;
                    moneyOnTable = moneyOnTable + dealerPayout;
                    userPot = userPot + moneyOnTable;
                    Console.WriteLine("Congrats you have won!");
                    Console.WriteLine($" your bet on number {numberOfUserChoice}  payed out and you earned {dealerPayout}");
                }

            }
            userPot = userPot - moneyOnTable;
            Console.WriteLine("sorry you didnt win");
            Console.WriteLine($"your bet on {numberOfUserChoice} did not payout and you lost {moneyOnTable}");
        }
        public void SplitsBet(int i)
        {
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            string userSplitString = tupleList[i].Item2;
            string[] splits = userSplitString.Split(',');
            //the splits method will intake the two numbers the user inputs in a string and split them so they can be evaluated seperataely
            
            foreach(string value in splits)
            {
                //the ballroll value is converted to a string and compared to the values in the split 
                if(ballroll.ToString() == value)
                {
                    dealerPayout = moneyOnTable * 17;
                    moneyOnTable = moneyOnTable + dealerPayout;
                    userPot = userPot + moneyOnTable;
                    Console.WriteLine("Congrats you have won!");
                    Console.WriteLine($" your bet on split {userSplitString} payed out and you earned {dealerPayout}");
                    return;
                }

            }
            userPot = userPot - moneyOnTable;
            Console.WriteLine("sorry you didnt win");
            Console.WriteLine($"your bet on {userSplitString}  did not payout and you lost {moneyOnTable}");
        }
        public void CornersBet(int i)
        {
            decimal moneyOnTable = tupleList[i].Item3;
            decimal dealerPayout = 0;
            string userCornerString = tupleList[i].Item2;
            string[] cornerList =userCornerString.Split(',');
            //the corners method operates the same as the splits method. 
            //the user input string is split into separate values and placed in  the array cornerlist 
            // the corner list array is then evaluated to see if contains the winning value
                    foreach (string value in cornerList)
                    {
                           Console.WriteLine($"number is {value}");
                           Console.WriteLine("next");
                    }
                foreach(string value in cornerList)
                {
                    if(ballroll.ToString()==value)
                    {
                        dealerPayout = moneyOnTable * 8;
                        moneyOnTable = moneyOnTable + dealerPayout;
                        userPot = userPot + moneyOnTable;
                        Console.WriteLine("Congrats you have won!");
                        Console.WriteLine($" your bet on number {userCornerString}  payed out and you earned {dealerPayout}");
                        return;
                    }
                }
            userPot = userPot - moneyOnTable;
            Console.WriteLine("sorry you didnt win");
            Console.WriteLine($"your bet on {userCornerString}  did not payout and you lost {moneyOnTable}");
        }
    }
}
