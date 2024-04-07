/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                if(nums.Length == 0) // Checking for an empty array
                    return 0;

                int uniqueElements = 1; // Create atleast one unique element

                for(int i=1; i<nums.Length; i++)
                {
                    if (nums[i] != nums[i-1]) // Ensure whether the current element is different from the previous one
                    {
                        nums[uniqueElements] = nums[i]; //Place the unique element at the next available position 
                        uniqueElements++;
                    }
                }

                return uniqueElements;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                int nonZeroIndex = 0; //Index to track the position where the non-zero elements has to be places

                for(int i=0; i<nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        // Swap the non-zero element with the element at nonZeroIndex
                        int temp = nums[nonZeroIndex];
                        nums[nonZeroIndex] = nums[i];
                        nums[i] = temp;

                        nonZeroIndex++; // Move the nonZeroIndex to the next place
                    }
                }
                return nums; // Return the modified array
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                IList<IList<int>> triplets = new List<IList<int>>();

                // Count occurrences of each number
                Dictionary<int, int> numCount = new Dictionary<int, int>();
                foreach (int num in nums)
                {
                    if (!numCount.ContainsKey(num))
                        numCount[num] = 1; // Start the counting if you see the occurence of a number for the first time
                    else
                        numCount[num]++; // Increment the count if the number is already counted
                }

                // Hashset to track processed triplets
                HashSet<string> processed = new HashSet<string>();

                for (int i = 0; i < nums.Length; i++) // Loop through the array
                {
                    numCount[nums[i]]--;  // Reduce the count of the current number

                    for (int j = i + 1; j < nums.Length; j++)  // Find pairs for the current number
                    {
                        int complement = -(nums[i] + nums[j]);  //Find the complement needed

                        //Check if the complement exists
                        if (numCount.ContainsKey(complement) && (complement > nums[j] || (complement == nums[j] && numCount[complement] > 0)))
                        {
                            string key = nums[i] + "," + nums[j] + "," + complement;  //Create a key for the triplet
                            if (!processed.Contains(key)) //Avoid processing duplicates 
                            {
                                triplets.Add(new List<int> { nums[i], nums[j], complement }); //Add the triplets to the result
                                processed.Add(key); // Record the obtained triplet
                            }
                        }
                    }
                }

                return triplets; // Return the list of triplets
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                int maxConsecutive = 0; // Keeps track of the longest sequence of consecutive ones
                int currentConsecutive = 0; // Counts the length of the current sequence of consecutive ones

                for(int i=0; i<nums.Length; i++) // Loop through each element
                {
                    if (nums[i] == 1)
                    {
                        currentConsecutive++; // Increment the consecutive count

                        maxConsecutive = Math.Max(maxConsecutive, currentConsecutive); // Update the maxConsecutive if the current count is greater
                    }

                    // If the current number is 0, the sequence of consecutive 1's ends
                    else
                    {
                        currentConsecutive = 0; //Reset the count of consecutive 1's 
                    }
                }

                return maxConsecutive; // Return the length of the longest sequence of consecutive 1's 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binaryNumber)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                int decimalNumber = 0;
                int baseValue = 1; // Represents the base value for the current bit position

                while (binaryNumber > 0)
                {
                    int lastDigit = binaryNumber % 10; // Extract the last digit of the binary number
                    binaryNumber /= 10; // Remove the last digit from the binary number

                    decimalNumber += lastDigit * baseValue; // Multiply the last digit by the base value and add it to the decimal number
                    baseValue *= 2; // Move to the next bit position by multiplying the base value by 2
                }

                return decimalNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                if (nums.Length < 2) return 0;

                int maxDifference = 0;
                int minNum = int.MaxValue;
                int maxNum = int.MinValue;

                // Find the minimum and maximum elements in the array
                foreach (int num in nums)
                {
                    minNum = Math.Min(minNum, num);
                    maxNum = Math.Max(maxNum, num);
                }

                // Calculate the size of each bucket
                int bucketSize = Math.Max(1, (maxNum - minNum) / (nums.Length - 1));

                // Calculate the number of buckets needed
                int bucketCount = (maxNum - minNum) / bucketSize + 1;

                // Initialize bucket arrays
                int[] bucketMin = new int[bucketCount];
                int[] bucketMax = new int[bucketCount];
                bool[] bucketUsed = new bool[bucketCount];

                // Distribute elements into buckets
                foreach (int num in nums)
                {
                    int bucketIndex = (num - minNum) / bucketSize;
                    bucketMin[bucketIndex] = bucketUsed[bucketIndex] ? Math.Min(bucketMin[bucketIndex], num) : num;
                    bucketMax[bucketIndex] = bucketUsed[bucketIndex] ? Math.Max(bucketMax[bucketIndex], num) : num;
                    bucketUsed[bucketIndex] = true;
                }

                // Calculate maximum gap between buckets
                int prevBucketMax = minNum;
                for (int i = 0; i < bucketCount; i++)
                {
                    if (bucketUsed[i])
                    {
                        maxDifference = Math.Max(maxDifference, bucketMin[i] - prevBucketMax);
                        prevBucketMax = bucketMax[i];
                    }
                }

                return maxDifference;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] sideLengths)
        {
            try
            {
                Array.Sort(sideLengths); // Sort the side lengths in non-decreasing order

                int maxPerimeter = 0;

                // Start from the end of the array to find the largest possible perimeter
                for (int i = sideLengths.Length - 1; i >= 2; i--)
                {
                    int side1 = sideLengths[i - 2];
                    int side2 = sideLengths[i - 1];
                    int side3 = sideLengths[i];

                    // If the sum of two shorter sides is greater than the longest side, it can form a triangle
                    if (side1 + side2 > side3)
                    {
                        maxPerimeter = side1 + side2 + side3; // Update the maximum perimeter
                        break; // No need to check further, as we found the largest perimeter
                    }
                }

                return maxPerimeter;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Iterate through the string until all occurrences of the part are removed
                while (s.Contains(part))
                {
                    // Find the leftmost occurrence of the part
                    int index = s.IndexOf(part);

                    // Remove the part from the string
                    s = s.Remove(index, part.Length);
                }

                // Return the modified string after removing all occurrences of the part
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}