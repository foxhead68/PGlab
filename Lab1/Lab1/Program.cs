using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using PG2Input;

namespace Lab1
{
    //
    //------------To run your lab code-------------
    // make sure Lab1 is the "Startup Project" (the name, Lab1, should be bold in Solution Explorer)
    // Right click the Lab1 project and select "Set as startup project"
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
    //------------Lab Notes-------------
    //      Add your Read methods to the Input.cs file in the PG2Input project.
    //      Add any other methods in this file.
    //      Add the menu code to the Main method.
    //

    class Program
    {
        static void Main(string[] args)
        {
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
            static string GetSpeech()
            {
                string text = "I say to you today, my friends, so even though we face the difficulties of today and tomorrow, I still have a dream. It is a dream deeply rooted in the American dream. " +
            "I have a dream that one day this nation will rise up and live out the true meaning of its creed: We hold these truths to be self-evident: that all men are created equal. " +
            "I have a dream that one day on the red hills of Georgia the sons of former slaves and the sons of former slave owners will be able to sit down together at the table of brotherhood. " +
            "I have a dream that one day even the state of Mississippi, a state sweltering with the heat of injustice, sweltering with the heat of oppression, will be transformed into an oasis of freedom and justice. " +
            "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character. " +
            "I have a dream today. I have a dream that one day, down in Alabama, with its vicious racists, with its governor having his lips dripping with the words of interposition and nullification; one day right there in Alabama, little black boys and black girls will be able to join hands with little white boys and white girls as sisters and brothers. " +
            "I have a dream today. I have a dream that one day every valley shall be exalted, every hill and mountain shall be made low, the rough places will be made plain, and the crooked places will be made straight, and the glory of the Lord shall be revealed, and all flesh shall see it together. " +
            "This is our hope. This is the faith that I go back to the South with. With this faith we will be able to hew out of the mountain of despair a stone of hope. With this faith we will be able to transform the jangling discords of our nation into a beautiful symphony of brotherhood. " +
            "With this faith we will be able to work together, to pray together, to struggle together, to go to jail together, to stand up for freedom together, knowing that we will be free one day. " +
            "This will be the day when all of God's children will be able to sing with a new meaning, My country, 'tis of thee, sweet land of liberty, of thee I sing. Land where my fathers died, land of the pilgrim's pride, from every mountainside, let freedom ring. " +
            "And if America is to be a great nation this must become true. So let freedom ring from the prodigious hilltops of New Hampshire. Let freedom ring from the mighty mountains of New York. Let freedom ring from the heightening Alleghenies of Pennsylvania! " +
            "Let freedom ring from the snowcapped Rockies of Colorado! Let freedom ring from the curvaceous slopes of California! But not only that; let freedom ring from Stone Mountain of Georgia! " +
            "Let freedom ring from Lookout Mountain of Tennessee! Let freedom ring from every hill and molehill of Mississippi. From every mountainside, let freedom ring. " +
            "And when this happens, when we allow freedom to ring, when we let it ring from every village and every hamlet, from every state and every city, we will be able to speed up that day when all of God's children, black men and white men, Jews and Gentiles, Protestants and Catholics, will be able to join hands and sing in the words of the old Negro spiritual, Free at last! free at last! thank God Almighty, we are free at last!";
                return text;
            }
            string Text = GetSpeech();
            int number = ReadInteger("Enter a number from 0 to 10: ", 0, 10);
            Console.WriteLine();
            string make = string.Empty;
            ReadString("What is the Make of your car? : ", ref make);
            Console.WriteLine();
            int myChoice = 0;
            string[] tochoose = new string[] { " 1. Consultation", " 2. Appointment", " 3. Walk-In" };
            while (true)
            {
                ReadChoice("Please select an option: ", tochoose, out myChoice);
                switch (myChoice)
                {
                    case 1:
                        Console.WriteLine("You Selected: Consultation\n");
                        break;
                    case 2:
                        Console.WriteLine("You Selected: Appointment\n");
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("\nYou did not make a valid selection\n");
                        break;
                }
                Console.Write("\n Press any key to continue ");
                String keepgoing = Console.ReadLine();
                Console.WriteLine();
                string[] words = Text.Split(new char[] { '.', ' ', ',', '!', '?', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                
                List<string> wordList = new List<string>(words);
                Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
                for (int i = 0; i < words.Length; i++)
                {
                    if (dictionary.ContainsKey(words[i]))
                    {
                        dictionary[words[i]]++;
                    }
                    else
                    {
                        dictionary.Add(words[i], 1);
                    }
                }
                Console.WriteLine();

                int menuChoice = 0;
                string[] mainMenu = new string[] { "1.The Speech", "2.List of Words", "3.Show Histogram", "4.Search for Word", "5.Remove Word", "6.Exit" };
                while (menuChoice != mainMenu.Length)
                {
                    ReadChoice("Please select an option: ", mainMenu, out menuChoice);
                    Console.WriteLine();

                    switch (menuChoice)
                    {
                        case 1:
                            Console.WriteLine("\nYou Selected: The Speech ");
                            Console.ReadLine();
                            Console.Clear();
                            //Show Speech
                            Console.WriteLine(Text);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("\nYou Selected: List of Words");
                            Console.ReadLine();
                            Console.Clear();
                            //Show List of Words
                            for (int i = 0; i < wordList.Count; i++)
                            {
                                Console.WriteLine(wordList[i]);
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            //PART C-2 - Show Histogram: print the word, the count, and the bar
                            Console.WriteLine("\nYou Selected: Show Histogram");
                            Console.WriteLine();
                            foreach (KeyValuePair<string, int> show in dictionary)
                            {
                                string key = show.Key; //get the word in the dictionary
                                Console.Write($"{show.Key}:"); //get the word
                                Console.CursorLeft = 15; //start bar at cursor at x = 15
                                Console.BackgroundColor = ConsoleColor.Magenta; //change background color
                                int value = show.Value; //get the value
                                for (int v = 0; v < show.Value; v++) //make the bars
                                {
                                    Console.Write(" ");
                                }
                                Console.ResetColor(); //reset background color back to black
                                Console.WriteLine($"{show.Value}:"); //get/show the numbers in the dictionary
                            }
                            break;
                        case 4:
                            //PART C-3 - Search for Word
                            Console.WriteLine("\nYou Selected: Search for Word");
                            string find = "";
                            ReadString("\nWhat word do you want to find? ", ref find);
                            //checked if word "find" is in the dictionary
                            if (dictionary.ContainsKey(find))
                            {
                                Console.CursorLeft = 9;
                                Console.Write(find);//Print the word to be found
                                Console.CursorLeft = 15; //start bar at cursor at x = 15
                                Console.BackgroundColor = ConsoleColor.Magenta; //change background color
                                for (int i = 0; i < dictionary[find]; i++)
                                {
                                    Console.Write(" "); //print the bar
                                }
                                Console.ResetColor(); // reset background color back to black
                                Console.WriteLine(dictionary[find]);//Print the word
                                Console.WriteLine();
                                //PART C- 4 - Sentences for Word
                                string[] sentences = Text.Split(new char[] { '.', '!', '?', ',' });
                                for (int i = 0; i < sentences.Length; i++) // for loop through sentences
                                {
                                    //if the word is in the dictionary
                                    char[] delimiters = new char[] { '.', ' ', ',', '!', '?', };
                                    string[] wordsArray = sentences[i].Split(delimiters,
                                   StringSplitOptions.RemoveEmptyEntries); //Split
                                    for (int w = 0; w < wordsArray.Length; w++)
                                    {
                                        // if (wordsArray[i].ToLower() == find.ToLower())
                                        if (wordsArray[w].ToLower().CompareTo(find.ToLower()) == 0)
                                        {
                                            Console.WriteLine(sentences[i]);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{find} is not Found");

                            }
                            break;
                        case 5:
                            //PART C-5 - Remove Word
                            Console.WriteLine("\nYou Selected: Remove Word");
                            string word = "";
                            ReadString("\nEnter the Word to Remove: ", ref word);
                            bool removed = dictionary.Remove(word);
                            if (removed)
                            {
                                Console.WriteLine($"{word} has been removed");
                            }
                            else
                            {
                                Console.WriteLine($"{word} is not Found");

                            }
                            break;
                        default: continue;
                        case 6:
                            return;
                    }
                    Console.WriteLine();
                }


            }
        }
    }
}

















