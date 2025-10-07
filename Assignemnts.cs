using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowsalya_Assignment.Assignment
{
    
        public static class InterviewAssignments
        {
            // 1. Check if two strings are anagrams
            // Case-insensitive, ignores whitespace (modify if you want strict behavior).
            public static bool IsAnagram(string a, string b)
            {

                if (a == null || b == null) return false;

                a = a.ToLower().Replace(" ", "");
                b = b.ToLower().Replace(" ", "");

                if (a.Length != b.Length) return false;

                char[] aChars = a.ToArray();
                char[] bChars = b.ToArray();

                Array.Sort(aChars);
                Array.Sort(bChars);

                return new string(aChars) == new string(bChars);                

            }

            // 2. Given s1 and s2, return true if s2 == rotate(s1, n) (rotate to the right by n places).
            // If you want left rotation, call with negative n or adjust accordingly.
            public static bool IsRotationByN(string s1, string s2, int n)
            {

                if (s1 == null || s2 == null) return false;
                if (s1.Length != s2.Length) return false;
                if (s1.Length == 0) return true;

                int len = s1.Length;
                n = n % len; // handle rotations larger than length
                if (n < 0) n += len; // handle negative rotations (left rotation)

                for (int i = 0; i < len; i++)
                {
                    int rotatedIndex = (i + n) % len; // index in s1 after rotation
                    if (s1[i] != s2[(i + n) % len])
                        return false;
                }
                return true;               
            }

            // 3. Remove adjacent duplicate characters repeatedly until none left
            // Example: "abbaca" -> "ca" (since abbaca -> aaca -> ca)
            public static string RemoveAdjacentDuplicates(string s)
            {
                if (string.IsNullOrEmpty(s)) return s;
                var stack = new StringBuilder();
                foreach (char c in s)
                {
                    if (stack.Length > 0 && stack[stack.Length - 1] == c)
                        stack.Length--; // pop
                    else
                        stack.Append(c);
                }
                return stack.ToString();
            }

            // 4. Check if string2 is a rotation of string1 (any rotation)
            // Classic trick: if s2 is substring of s1+s1 and lengths equal.
            public static bool IsRotation(string s1, string s2)
            {
                if (s1 == null || s2 == null) return false;
                if (s1.Length != s2.Length) return false;
                string doubled = s1 + s1;
                return doubled.Contains(s2);
            }

            // 5. Remove duplicates from an array (return unique elements preserving first-seen order)
            public static int[] RemoveDuplicatesPreserveOrder(int[] arr)
            {
                if (arr == null) return null;
                var seen = new HashSet<int>();
                var list = new List<int>();
                foreach (var x in arr)
                {
                    if (seen.Add(x))
                        list.Add(x);
                }
                return list.ToArray();
            }

            // 6. Intersection of two arrays (unique elements). Result order unspecified; we'll return in insertion order from nums1.

             public static int[] Intersection(int[] nums1, int[] nums2)
             {
                 if (nums1 == null || nums2 == null) return new int[0];
                 return nums1.Distinct().Where(x => nums2.Contains(x)).ToArray();
             }


            // 7. Reverse signed 32-bit integer. Return 0 on overflow.
            public static int ReverseInt(int x)
            {
                string s = Math.Abs(x).ToString();           
                char[] arr = s.ToCharArray();                
                Array.Reverse(arr);                          
                string rev = new string(arr);                
                if (int.TryParse(rev, out int num))          
                    return x < 0 ? -num : num;               
                return 0;                                    
            }
       

            // 8. Check palindrome phrase (ignore non-alphanumeric, case-insensitive)
            public static bool IsPalindromePhrase(string s)
            {

                if (s == null) return true;

                int i = 0, j = s.Length - 1;

                while (i < j)
                {
                    // Skip non-alphanumeric characters manually
                    while (i < j && !((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z') || (s[i] >= '0' && s[i] <= '9'))) i++;
                    while (i < j && !((s[j] >= 'a' && s[j] <= 'z') || (s[j] >= 'A' && s[j] <= 'Z') || (s[j] >= '0' && s[j] <= '9'))) j--;

                    // Compare letters/digits, ignoring case
                    char left = s[i];
                    char right = s[j];

                    if (left >= 'A' && left <= 'Z') left = (char)(left + 32);
                    if (right >= 'A' && right <= 'Z') right = (char)(right + 32);

                    if (left != right) return false;

                    i++;
                    j--;
                }

                return true;
              
            }

            // 9. Fibonacci series upto nth term (0-based): returns list of first n terms (n >= 1 return at least first term)
            // We'll define: n = number of terms to return. Example n=5 -> [0,1,1,2,3]

            public static void FibonacciSeries(int n)
            {
                if (n <= 0) return;

                long first = 0, second = 1;

                for (int i = 0; i < n; i++)
                {
                    Console.Write(first + " ");
                    long next = first + second;
                    first = second;
                    second = next;
                }
            }            

            // 10. Wildcard matching: pattern supports '?' (one char) and '*' (any sequence, incl empty)
            // DP solution O(m*n)
            public static bool IsWildcardMatch(string s, string p)
            {
                if (s == null || p == null) return false;
                int n = s.Length, m = p.Length;
                var dp = new bool[n + 1, m + 1];
                dp[0, 0] = true;
                // patterns starting with * can match empty string
                for (int j = 1; j <= m; j++)
                {
                    if (p[j - 1] == '*') dp[0, j] = dp[0, j - 1];
                    else dp[0, j] = false;
                }
                for (int i = 1; i <= n; i++) dp[i, 0] = false;

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        if (p[j - 1] == '?'
                            || p[j - 1] == s[i - 1])
                        {
                            dp[i, j] = dp[i - 1, j - 1];
                        }
                        else if (p[j - 1] == '*')
                        {
                            // '*' matches empty sequence (dp[i, j-1]) OR matches one more char from s (dp[i-1, j])
                            dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = false;
                        }
                    }
                }
                return dp[n, m];
            }

            // 11. Longest Common Subsequence (return length)
            public static int LongestCommonSubsequence(string A, string B)
            {
                if (A == null || B == null) return 0;
                int n = A.Length, m = B.Length;
                var dp = new int[n + 1, m + 1];
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        if (A[i - 1] == B[j - 1])
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        else
                            dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
                return dp[n, m];
            }

            
        }
        
}
