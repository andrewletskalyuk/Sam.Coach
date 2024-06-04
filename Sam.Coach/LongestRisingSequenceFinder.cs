using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.Coach
{
    public class LongestRisingSequenceFinder : ILongestRisingSequenceFinder
    {
        public Task<IEnumerable<int>> Find(IEnumerable<int> numbers, IEnumerable<int> second_numbers) => Task.Run(() =>
        {
            IEnumerable<int> result = null;

            // TODO: Given input of 2 array of integers, return the array which has maxium number
            // of elements in the longest raising sequence of that array
            // when numbers = [4, 6, -3, 3, 7, 9] then longest raising sequence is [-3, 3, 7, 9]
            // when numbers = [9, 6, 4, 5, 2, 0] then longest raising sequence is [4, 5]
            // input =  [4, 6, -3, 3, 7, 9] and [9, 6, 4, 5, 2, 0], then output is [4, 6, -3, 3, 7, 9]

            /// In real-world conditions, use a validator to check whether the inputs are correct
            if (numbers == null || second_numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "Input collections cannot be null.");
            }
            else if (numbers.Count() == 1 || second_numbers.Count() == 1)
            {
                throw new ArgumentException(nameof(numbers), "Both input collections must contain more than one element.");
            }

            int longestSequenceFirst = FindLongestIncreasingSubsequence(numbers);
            int longestSequenceSecond = FindLongestIncreasingSubsequence(second_numbers);

            if (FindLongestIncreasingSubsequence(numbers) == FindLongestIncreasingSubsequence(second_numbers))
            {
                return null; //in case both array has the same number of elements
            }

            return longestSequenceFirst > longestSequenceSecond ? numbers : second_numbers;
        });

        private int FindLongestIncreasingSubsequence(IEnumerable<int> numbers)
        {
            int length = 0;
            int lengthMax = 0;

            int[] numArray = numbers.ToArray();

            for (int i = 0; i < numArray.Length - 1; ++i)
            {
                if (numArray[i + 1] > numArray[i])
                {
                    length++;
                }
                else
                {
                    length = 0;
                }

                lengthMax = Math.Max(length, lengthMax);
            }
            return lengthMax + 1; 
        }
    }
}
