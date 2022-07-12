using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab2
{
    //
    //------------To run your lab code-------------
    // make sure Lab2 is the "Startup Project" (the name, Lab2, should be bold in Solution Explorer)
    // Right click the Lab2 project and select "Set as startup project"
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
    //      Add your Sorting and Searching methods to the PG2Sorting.cs file.
    //      Add any other methods in this file.
    //      Add the menu code to the Main method.
    //

    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "inputFile.csv";
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
            Console.Clear();



            void Serialize(List<string> unsorted)
            {
                List<string> sortedCopy = unsorted.ToList();
                BubbleSort(sortedCopy);
                filePath = Path.ChangeExtension(filePath, ".json");
                using StreamWriter sw = new(filePath);
                using JsonTextWriter jsonWriter = new(sw);
                jsonWriter.Formatting = Formatting.Indented;

                JsonSerializer serializer = new();
                serializer.Serialize(jsonWriter, sortedCopy);
            }
            
                string filePath1 = "inputFile.csv";

            int menuChoice = 0;
            string[] mainMenu = new string[] { "1.Bubble Sort", "2.Merge Sort", "3.Binary Search", "4.Save", "5.Exit" };
            while (menuChoice != mainMenu.Length)
            {
                ReadChoice("Please select an option: ", mainMenu, out menuChoice);
                Console.WriteLine();

                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("\nBubble Sort");
                        Console.Write("------------------------------------------------------------");
                        Console.Write("------------------------------------------------------------");
                        List<string> loading = LoadFile1(filePath1);
                        List<string> toSort = BubbleSort(loading);
                        for (int i = 0; i < toSort.Count; i++)
                        {
                            Console.Write(loading[i]);
                            Console.CursorLeft = 70;
                            Console.WriteLine(toSort[i]);
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nMerge Sort");
                        Console.Write("------------------------------------------------------------");
                        Console.Write("------------------------------------------------------------");
                        Console.WriteLine();
                        List<string> notSorted = LoadFile1(filePath1);
                        List<string> willSort = BubbleSort(notSorted);
                        for (int i = 0; i < willSort.Count; i++)
                        {
                            Console.Write(notSorted[i]);
                            Console.CursorLeft = 70;
                            Console.WriteLine(willSort[i]);
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nBinary Search");
                        Console.Write("------------------------------------------------------------");
                        Console.Write("------------------------------------------------------------");
                        Console.WriteLine();
                        List<string> original = LoadFile1(filePath1);
                        List<string> sorted = BubbleSort(original);
                        string search = string.Empty;

                        for (int i = 0; i < sorted.Count; i++)
                        {
                            var foundIndex = BinarySearch1(sorted, search);
                            Console.Write(sorted[i]);
                            int Index = sorted.IndexOf(sorted[i]);
                            Console.CursorLeft = 50;

                            Console.Write($"Index: {i}");
                            Console.CursorLeft = 90;
                            Console.WriteLine($"Found Index: {Index}");
                        }
                        break;


                    case 4:
                        Console.WriteLine("\n4.Save");
                        Console.Write("------------------------------------------------------------");
                        Console.Write("------------------------------------------------------------");
                        Console.WriteLine();
                        string file = "";
                        ReadString("\n Enter the name of the File to Save: ", ref file);
                        List<string> unSorted = LoadFile1(filePath1);
                        BubbleSort(unSorted);
                        for (int i = 0; i < unSorted.Count; i++)
                        {
                            Console.Write(unSorted[i]);
                            Console.CursorLeft = 70;
                            Console.WriteLine(unSorted[i]);
                        }
                        Serialize(BubbleSort(unSorted));
                        break;
            
                    case 5:
                        Console.WriteLine("5.Exit\n");
                        return;

                }

            }
            Console.WriteLine();
                Console.Write("\n Press any key to continue ");
                String keepgoing = Console.ReadLine();
                Console.WriteLine();
            }
            static List<string> LoadFile1(string filePath)
            {
                char delimiter = ',';
                string titles = File.ReadAllText(filePath);
                string[] data = titles.Split(delimiter);

                List<string> comicTitle = new(data);
                List<string> unsorted = comicTitle.ToList();

                return unsorted;
            }

            static List<string> BubbleSort(List<string> unsortedList)
            {
                bool swapped = false;
                while (!swapped)
                {
                    swapped = true;
                    for (int i = 0; i < unsortedList.Count - 1; i++)
                    {

                        if (unsortedList[i].CompareTo(unsortedList[i + 1]) > 0)
                        {
                            string temp = unsortedList[i];
                            unsortedList[i] = unsortedList[i + 1];
                            unsortedList[i + 1] = temp;
                            swapped = false;
                        }
                    }
                }
                return unsortedList;
            }
            static int BinarySearch(List<string> sorted, string itemToFind, int min, int max)
            {
                List<string> sortedList = sorted.ToList();
                int high = sortedList.Count - 1;
                int foundIndex = -1;
                if (max < min)
                {
                    int mid = (high + min) / 2;
                    if (sortedList[mid].CompareTo(itemToFind) > 0)
                    {
                        return BinarySearch(sortedList, itemToFind, min, mid - 1);
                    }
                    else if (sortedList[mid].CompareTo(itemToFind) > 0)
                    {
                        return BinarySearch(sortedList, itemToFind, min, mid + 1);
                    }
                    else
                    {
                        return mid;
                    }
                }
                return foundIndex;
            }
            static int BinarySearch1(List<string> sorted, string itemToFind)
            {
                return BinarySearch(sorted, itemToFind, 0, sorted.Count - 1);
            }
        }
    }


            
        
    

















































