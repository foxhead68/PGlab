using System;
using BlackjackClassLibrary;
using OpenXmlPowerTools;
using PG2Input;
using SolrNet.Utils;
using Stripe;
using Card = BlackjackClassLibrary.Card;
using BlackjackClassLibrary;
using FullSailCasino;

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

            string[] menuOptions = { "1. Play Blackjack", "2. Shuffle and Show Deck", "3. Exit" };
            int userChoice = 0;

            bool willExit = false;

            while (!willExit)
            {
                Deck baseDeck = new Deck();
                Hand playerHand = new Hand();
                Hand dealerHand = new Hand();

                
                baseDeck.Shuffle();
               
               
                
                ReadChoice("Choice: ", menuOptions, out userChoice);

                
                if (userChoice == 1)
                {
                    bool playerCondition = true;
                    bool firstTurn = true;
                    bool dealerInitilize = true;
                    bool dealerPlay = false;

                    Console.Clear();
                   
                    for (int ndx = 0; ndx < 2; ndx++)
                    {
                        playerHand.AddCard(baseDeck.Draw());
                        dealerHand.AddCard(baseDeck.Draw());
                    }

                    
                    string[] emptyArray = new string[] { string.Empty };
                    while (playerCondition)
                    {
                        Console.Clear();
                        BlackJackGame.DrawGame(playerHand, dealerHand, dealerInitilize, dealerPlay);
                        if ((dealerHand.Score == 21 || playerHand.Score == 21) && firstTurn)
                        {
                            dealerPlay = true;
                            dealerInitilize = false;
                            Console.Clear();
                            BlackJackGame.DrawGame(playerHand, dealerHand, dealerInitilize, dealerPlay);
                            if (playerHand.Score == 21 && dealerHand.Score == 21)
                            {
                                BlackJackGame.stalemate("The dealer and player have 21.");
                            }
                            else if (dealerHand.Score == 21)
                            {
                                BlackJackGame.playerLost("Dealer has 21");
                            }
                            else if (playerHand.Score == 21)
                            {
                                BlackJackGame.playerWon("Player has 21");
                            }
                            dealerInitilize = true;
                            BlackJackGame.endScene(ref baseDeck, ref playerHand, ref dealerHand, ref playerCondition, ref firstTurn, emptyArray);
                        }
                        else if (playerHand.Score < 21)
                        {
                            ReadChoice("Choice: ", emptyArray, out int gameplayChoice);
                           
                            if (gameplayChoice == 1)
                            {
                                playerHand.AddCard(baseDeck.Draw());
                                firstTurn = false;
                            }
                            
                            else if (gameplayChoice == 2)
                            {
                                dealerPlay = true;

                                BlackJackGame.dealerTurn(playerHand, dealerHand, baseDeck);
                                firstTurn = false;
                                BlackJackGame.endScene(ref baseDeck, ref playerHand, ref dealerHand, ref playerCondition, ref firstTurn, emptyArray);
                            }
                            else
                            {
                                Console.WriteLine("Input 1 or 2.");
                            }
                        }
                        else if (playerHand.Score == 21 && !firstTurn)
                        {
                            Console.WriteLine("21 Attained, standing.");
                            dealerPlay = true;

                            BlackJackGame.dealerTurn(playerHand, dealerHand, baseDeck);
                            BlackJackGame.endScene(ref baseDeck, ref playerHand, ref dealerHand, ref playerCondition, ref firstTurn, emptyArray);
                        }
                        else
                        {
                            BlackJackGame.playerLost("Player has busted!");
                            BlackJackGame.endScene(ref baseDeck, ref playerHand, ref dealerHand, ref playerCondition, ref firstTurn, emptyArray);
                        }
                    }
                }
              
                else if (userChoice == 2)
                {
                    Console.WriteLine("Shuffled, showing deck.");
                    baseDeck.Shuffle();

                    baseDeck.Display();

                    Console.ReadKey();
                }
               
                else if (userChoice == 3)
                {
                    willExit = true;
                }
                else
                {
                    Console.Write("You input an invalid solution, try again.");
                }
                Console.Clear();
            }
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
    


