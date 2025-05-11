using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionsMerge_4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines1 = { "1", "2", "1" };
            string[] lines2 = { "3", "2", "4" };

            string[] mergedArray = GetMergedArray(lines1, lines2);

            foreach (string item in mergedArray)
            {
                Console.WriteLine(item);
            }
        }

        private static string[] GetMergedArray(string[] lines1, string[] lines2)
        {
            var mergedCollection = new List<string>();

            foreach (string line in lines1)
                mergedCollection.Add(line);

            foreach (string line in lines2)
                mergedCollection.Add(line);

            for (int i = 0; i < mergedCollection.Count; i++)
            {
                int countOfItem = CountOf(mergedCollection[i], mergedCollection);

                if (countOfItem > 1)
                {
                    for (int j = 0; j < countOfItem - 1; j++)
                        mergedCollection.Remove(mergedCollection[i]);
                }
            }

            return mergedCollection.ToArray();
        }

        private static int CountOf(string item, List<string> items)
        {
            int count = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                    count++;
            }

            return count;
        }
    }
}
