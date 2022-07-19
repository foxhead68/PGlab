using System;
using BlackjackClassLibrary;
using OpenXmlPowerTools;
using PG2Input;
using SolrNet.Utils;
using Stripe;
using Card = BlackjackClassLibrary.Card;

namespace Lab3
{
    //
    //------------To run your lab code-------------
    // make sure Lab3 is the "Startup Project" (the name, Lab3, should be bold in Solution Explorer)
    // Right click the Lab3 project and select "Set as startup project"
    //
    //
    //------------To run your lecture code-------------
    // right-click the LectureCode project and select "Set as startup project"
    //      NOTE: the lecture code is NOT required for turning in the lab.
    //      Each lab solution has a LectureCode project in it.That is provided for you to use
    //      if you want to follow along with the lecture videos.
    //      Also, it's a way to make that code easier to find when you're working on the lab.
    //      The lecture code is not required. It is highly recommended that you do the lecture challenges
    //      but that code won't be graded or reviewed.
    //


    //
    //------------Lab 3 Notes-------------
    //      Add your classes to the BlackjackClassLibrary project.
    //      Add the menu code to the Main method.
    //


    //
    //------------Lab 4 Notes-------------
    //      This project and file will be reused for lab 4. 
    //      When you start working on lab 4...
    //          Add your BlackjackGame class to the FullSailCasino project.
    //          update the menu code for Play Blackjack menu option
    //

    class Program
    {
        

        static void Main(string[] args)
        {
            
        Console.WriteLine();

            int menuChoice = 0;
            string[] mainMenu = new string[] { "1.Sample card", "2.Shuffle and Show Deck", "3.Sample Blackjack Hands", "4.Play Blackjack", "5.Exit" };
            while (menuChoice != mainMenu.Length)
            {
                ReadChoice("Please select an option: ", mainMenu, out menuChoice);
                Console.WriteLine();

                
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("\nYou Selected: Sample card ");
                        break;
                    case 2:
                        Console.WriteLine("\nYou Selected: Shuffle and Show Deck");                     
                        break;
                    case 3:                        
                        Console.WriteLine("\nYou Selected: Sample Blackjack Hands");
                        
                        break; 
                Console.WriteLine();
                        break;
                    case 4:
                        
                        Console.WriteLine("\nYou Selected: Play BlackJack");
                        break;
                    case 5:
                        Console.WriteLine("\nYou Selected: Exit");                       
                        break;
                }
                static int ReadInteger(string prompt, int min, int max)
                {
                    bool valid = false;
                    int num = 0;
                    while (!valid)
                    {
                        Console.Write(prompt);
                        string input = Console.ReadLine();
                        if (!int.TryParse(input, out int number))
                        {
                            Console.WriteLine("That is not a number. Please try again");
                            Console.WriteLine();
                        }
                        else if (number >= min && number <= max)
                        {
                            return number;
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    return num;
                }
                static void ReadString(string prompt, ref string value)
                {
                    bool valid = false;
                    while (!valid)
                    {
                        Console.Write(prompt);
                        value = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("Please enter a valid number");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                static void ReadChoice(string prompt, string[] options, out int selection)
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine(options[i]);
                    }
                    selection = ReadInteger(prompt, 1, options.Length);
                }
            }
        }
    }
}

