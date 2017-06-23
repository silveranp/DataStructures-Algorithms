using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = AnagaramSearch("abababb", "bab");
        }

        private static List<int> AnagaramSearch(string text, string pattern)
        {
            List<int> output = new List<int>();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern)) { return output; }

            int n1 = text.Length;
            int n2 = pattern.Length;

            if (n1 < n2) { return output; }

            char[] hash1 = null;
            char[] hash2 = ConstructHash(pattern);

            for (int i = 0; i <= n1 - n2; i++)
            {
                string substring = text.Substring(i, n2);
                if (i == 0)
                {
                    hash1 = ConstructHash(text.Substring(0, n2));
                }
                else
                {
                    hash1[substring.Last()]++;
                    hash1[text[i - 1]]--;
                }
                if (CompareHashes(hash1, hash2))
                {
                    output.Add(i);
                }
            }
            return output;
        }

        private static bool CompareHashes(char[] hash1, char[] hash2)
        {
            if (hash1.Length != hash2.Length) { return false; }

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i]) { return false; }
            }
            return true;
        }

        private static char[] ConstructHash(string s)
        {
            char[] hash = new char[256];
            foreach (char c in s)
            {
                hash[(int)c]++;
            }

            return hash;
        }
    }
}
