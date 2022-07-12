using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class PG2Sorting
    {
      public static List<string> LoadFile(string filePath)
        {
            char delimiter = ',';
            string titles = File.ReadAllText(filePath);
            string[] data = titles.Split(delimiter);

            List<string> comicTitle = new(data);
            List<string> unsorted = comicTitle.ToList();

            return unsorted;
        }

       public static List<string> BubbleSort(List<string> unsortedList)
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
        public static List<string> MergeSort(List<string> sorted)
        {
            List<string> left = new();
            List<string> right = new();
            if (sorted.Count <= 1)
            {
                for (int i = 0; i < sorted.Count; i++)
                {
                    if (i < (sorted.Count) / 2)
                    {
                        left.Add(sorted[i]);
                    }
                    if (i < (sorted.Count) / 2)
                    {
                        right.Add(sorted[i]);
                    }
                }
                left = MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);


            }
            return sorted;
        }
       public static List<string> Merge(List<string> left, List<string> right)
        {
            var result = new List<string>();
            int j = 0;
            int k = 0;
            while (left != null && right != null)
            {
                if (left[j].CompareTo(right[j]) <= 0)
                {
                    result.Add(left.First());
                    result.Add(left[j]);
                    left.RemoveAt(j);
                }
                else
                {
                    result.Add(right[k]);
                    right.RemoveAt(k);
                }
            }
            while (left != null)
            {
                result.Add(result[j]);
                left.RemoveAt(j);
            }
            while (right != null)
            {
                result.Add(result[k]);
                right.RemoveAt(k);
            }
            return result;
        }

        public static int BinarySearch(List<string> sorted, string itemToFind, int min, int max)
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
        public static int BinarySearch1(List<string> sorted, string itemToFind)
        {
            return BinarySearch(sorted, itemToFind, 0, sorted.Count - 1);
        }
    }

}

