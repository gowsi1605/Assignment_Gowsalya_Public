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
                a = new string(a.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
                b = new string(b.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
                if (a.Length != b.Length) return false;

                var counts = new int[256];
                foreach (char c in a) counts[c]++;
                foreach (char c in b) counts[c]--;
                return counts.All(x => x == 0);
            }

            // 2. Given s1 and s2, return true if s2 == rotate(s1, n) (rotate to the right by n places).
            // If you want left rotation, call with negative n or adjust accordingly.
            public static bool IsRotationByN(string s1, string s2, int n)
            {
                if (s1 == null || s2 == null) return false;
                if (s1.Length != s2.Length) return false;
                int len = s1.Length;
                if (len == 0) return true; // both empty
                n = ((n % len) + len) % len; // normalize
                                             // rotate right by n -> last n characters move to front
                string rotated = s1.Substring(len - n) + s1.Substring(0, len - n);
                return rotated == s2;
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
                if (nums1 == null || nums2 == null) return Array.Empty<int>();
                var set2 = new HashSet<int>(nums2);
                var resSet = new HashSet<int>();
                var res = new List<int>();
                foreach (var x in nums1)
                {
                    if (set2.Contains(x) && resSet.Add(x))
                        res.Add(x);
                }
                return res.ToArray();
            }

            // 7. Reverse signed 32-bit integer. Return 0 on overflow.
            public static int ReverseInt(int x)
            {
                long result = 0; // use long to detect overflow
                int sign = x < 0 ? -1 : 1;
                long abs = Math.Abs((long)x);
                while (abs > 0)
                {
                    int digit = (int)(abs % 10);
                    result = result * 10 + digit;
                    if (result > int.MaxValue) return 0;
                    abs /= 10;
                }
                return (int)(result * sign);
            }

            // 8. Check palindrome phrase (ignore non-alphanumeric, case-insensitive)
            public static bool IsPalindromePhrase(string s)
            {
                if (s == null) return true;
                int i = 0, j = s.Length - 1;
                while (i < j)
                {
                    while (i < j && !char.IsLetterOrDigit(s[i])) i++;
                    while (i < j && !char.IsLetterOrDigit(s[j])) j--;
                    if (i < j)
                    {
                        if (char.ToLower(s[i]) != char.ToLower(s[j])) return false;
                        i++; j--;
                    }
                }
                return true;
            }

            // 9. Fibonacci series upto nth term (0-based): returns list of first n terms (n >= 1 return at least first term)
            // We'll define: n = number of terms to return. Example n=5 -> [0,1,1,2,3]
            public static List<long> FibonacciSeries(int n)
            {
                var res = new List<long>();
                if (n <= 0) return res;
                res.Add(0);
                if (n == 1) return res;
                res.Add(1);
                for (int i = 2; i < n; i++)
                {
                    long next = res[i - 1] + res[i - 2];
                    res.Add(next);
                }
                return res;
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
