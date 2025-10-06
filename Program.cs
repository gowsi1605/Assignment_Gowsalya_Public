using Gowsalya_Assignment.Assignment;
using System;

namespace Gowsalya_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {

                // 1
                Console.WriteLine("1. Anagram: 'The eyes' vs 'They see' -> " + InterviewAssignments.IsAnagram("The eyes", "They see"));
                //Console.WriteLine("1. Anagram: 'listen' vs 'silent' -> " + InterviewAssignments.IsAnagram("listen", "silent"));

                // 2
                Console.WriteLine("2. Rotation by n: rotate 'abcdef' by 2 -> 'efabcd' ? " +
                InterviewAssignments.IsRotationByN("abcdef", "efabcd", 2));

                // 3
                Console.WriteLine("3. Remove adjacent duplicates: 'abbaca' -> " + InterviewAssignments.RemoveAdjacentDuplicates("abbaca"));

                // 4
                Console.WriteLine("4. Is rotation (any): 'waterbottle' contains rotation 'erbottlewat'? " +
                InterviewAssignments.IsRotation("waterbottle", "erbottlewat"));

                // 5
                var arr = new int[] { 1, 2, 2, 3, 1 };
                Console.WriteLine("5. Remove duplicates from array [1,2,2,3,1] -> [" + string.Join(",", InterviewAssignments.RemoveDuplicatesPreserveOrder(arr)) + "]");

                // 6
                var inter = InterviewAssignments.Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
                Console.WriteLine("6. Intersection -> [" + string.Join(",", inter) + "]");

                // 7
                Console.WriteLine("7. Reverse int 123 -> " + InterviewAssignments.ReverseInt(123) + " ; -123 -> " + InterviewAssignments.ReverseInt(-123) + " ; overflow test 1534236469 -> " + InterviewAssignments.ReverseInt(1534236469));

                // 8
                Console.WriteLine("8. Palindrome phrase 'A man, a plan, a canal: Panama' -> " + InterviewAssignments.IsPalindromePhrase("A man, a plan, a canal: Panama"));

                // 9
                Console.Write("9. Fibonacci upto 7 terms -> [");
                InterviewAssignments.FibonacciSeries(7);   // This prints numbers directly
                Console.WriteLine("]");
                //Console.WriteLine("9. Fibonacci upto 7 terms -> [" + string.Join(",", InterviewAssignments.FibonacciSeries(7)) + "]");

                // 10
                Console.WriteLine("10. Wildcard match 'he?lo' vs 'hello' -> " + InterviewAssignments.IsWildcardMatch("hello", "he?lo"));
                Console.WriteLine("10. Wildcard match 'he*o' vs 'hero' -> " + InterviewAssignments.IsWildcardMatch("hero", "he*o"));

                // 11
                Console.WriteLine("11. LCS length A='abbcdgf', B='bbadcgf' -> " + InterviewAssignments.LongestCommonSubsequence("abbcdgf", "bbadcgf"));
            
        }
    }
}