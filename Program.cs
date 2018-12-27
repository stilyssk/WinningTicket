using System;
using System.Linq;
using System.Collections.Generic;
namespace WinningTicket
{
    class MainClass
    {
        public struct TypeFromCheck 
        {
            public bool FlagCheck;
            public char MachSymbol;
            public int MachLeght;
        }
        public static bool Check20Simbols(string tempString)
        {
            bool result=false;
            if (tempString.Length==20)
            {
                result = true;
            }
            return result;
        }
        public static TypeFromCheck CheckWinning (string tempString)
        {
            TypeFromCheck result = new TypeFromCheck();
            result.FlagCheck = false;
            result.MachLeght = 0;
            char[] validChar = new char[]
                {
                    '@', '#', '$'
                };
            foreach (var item in validChar)
            {
                int count = 1;
                int repeatNumber = 0;
                bool flagLeft = false;
                int countLeft = 0;
                bool flagRight = false;
                int countRight = 0;
                foreach (var itemFromString in tempString) 
                {
                    
                    if (item == itemFromString)
                    {
                        repeatNumber++;
                    }
                    else
                    {
                        if (repeatNumber < 6)
                        {
                            repeatNumber = 0;
                        }
                    }
                    if (count <= 10)
                    {
                        if (repeatNumber >= 6)
                        {
                            flagLeft = true;
                            countLeft = repeatNumber;
                        }
                        if (count == 10)
                        {
                            repeatNumber = 0;
                        }
                    }
                    else
                    {
                        if (repeatNumber >= 6)
                        {
                            flagRight = true;
                            countRight = repeatNumber;
                        }
                    }
                    if (flagLeft&&flagRight)
                    {
                        if (countLeft==countRight)
                        {
                            result.FlagCheck = true;
                            result.MachLeght = repeatNumber;
                            result.MachSymbol = item;
                        }
                    }
                    count++;
                }


            }

            return result;
        }
        public static TypeFromCheck CheckJackpot(string tempString)
        {
            TypeFromCheck result = new TypeFromCheck();
            result.FlagCheck = false;
           result.MachLeght = 0;
            char[] validChar = new char[]
            {
                '@', '#', '$'
            };
            foreach (var item in validChar)
            {
                int count = 0;
                foreach (var itemFromString in tempString) 
                {
                    if (item == itemFromString)
                    {                    
                        count++;
                        if (count == 20)
                        {
                            result.FlagCheck = true;
                        }
                    }
                }
            }
            if (result.FlagCheck)
            {
                result.MachSymbol = tempString[0];
                result.MachLeght = tempString.Length/2;
            }
            return result;
        }

        public static void Main(string[] args)
        {
            List<string> inputListOfString = Console.ReadLine()
                .Split(new string[] {", "," ",","},StringSplitOptions.RemoveEmptyEntries)
                .ToList() ;
            foreach (var item in inputListOfString)
            {
                if (Check20Simbols(item))
                {
                    TypeFromCheck result = new TypeFromCheck();
                    result = CheckJackpot(item);
                    if (result.FlagCheck)
                    {
                        
                        Console.WriteLine("ticket \"{0}\" - {1}{2} Jackpot!",item,result.MachLeght,result.MachSymbol);
                    }
                    else 
                    {
                        result = CheckWinning(item);
                        if (result.FlagCheck)
                        {
                            Console.WriteLine("ticket \"{0}\" - {1}{2}", item, result.MachLeght, result.MachSymbol);
                        }
                        else
                        {
                            Console.WriteLine("ticket \"{0}\" - no match",item);

                        }
                    }

                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
