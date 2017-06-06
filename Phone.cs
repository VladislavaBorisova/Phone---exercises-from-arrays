using System;
using System.Linq;

namespace temp
{
    class Program
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] peopleNames = Console.ReadLine().Split(' ');
            string[] command = Console.ReadLine().Split(' ');

            while (command[0] != "done")
            {
                string currentPhoneNumber = FirstLine(phoneNumbers, peopleNames, command);
                PrintSecondLine(command, currentPhoneNumber);

                command = Console.ReadLine().Split(' ');
            }
        }

        static string FirstLine(string[] phoneNumbers, string[] peopleNames, string[] command)
        {
            string actionToDo = command[0] == "call" ? "calling " : "sending sms to ";

            string currentPhoneNumber = string.Empty;
            string personToConnect = string.Empty;

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i] == command[1])
                {
                    personToConnect = peopleNames[i];
                    currentPhoneNumber = phoneNumbers[i];
                }
                else if (peopleNames[i] == command[1])
                {
                    personToConnect = phoneNumbers[i];
                    currentPhoneNumber = phoneNumbers[i];
                }
            }
            Console.WriteLine(actionToDo + personToConnect + "...");
            return currentPhoneNumber;
        }

        static void PrintSecondLine(string[] command, string currentPhoneNumber)
        {
            int sumOfDigitOfPhoneNumbers = 0;
            string number = string.Empty;

            for (int i = 0; i < currentPhoneNumber.Length; i++)
            {
                if (char.IsDigit(currentPhoneNumber[i]))
                {
                    number += currentPhoneNumber[i];
                }
            }

            long convertPhoneNumber = long.Parse(number);

            foreach (int symbol in convertPhoneNumber.ToString())
            {
                int current = (int)(symbol - '0');
                sumOfDigitOfPhoneNumbers += current;
            }

            if (sumOfDigitOfPhoneNumbers % 2 == 1)
            {
                if (command[0] == "call")
                {
                    Console.WriteLine("no answer");
                }
                else if (command[0] == "message")
                {
                    Console.WriteLine("busy");
                }
            }
            else if (sumOfDigitOfPhoneNumbers % 2 == 0)
            {
                if (command[0] == "message")
                {
                    Console.WriteLine("meet me there");
                }
                else
                {
                    if (command[0] == "call")
                    {
                        int minutes = sumOfDigitOfPhoneNumbers / 60;
                        int seconds = sumOfDigitOfPhoneNumbers % 60;
                        Console.WriteLine($"call ended. duration: {minutes:d2}:{seconds:d2}");
                    }
                }
            }
        }
    }
}
