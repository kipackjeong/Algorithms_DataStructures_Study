namespace Algorithms
{
    internal class IsPermutationStr
    {
        private static bool isPermutationCaseSensitive(string str1, string str2) // O(n), O(1)a
        {
            // iterate over str1
            var str1Sum = 0;
            var str2Sum = 0;
            foreach (var letter in str1)
            {
                str1Sum += (int)letter;
            }
            // iterate over str2
            foreach (var letter in str2)
            {
                str2Sum += (int)letter;
            }

            // compare result
            // if value is same; return true
            if (str1Sum == str2Sum)
            {
                return true;
            }
            // otherwise,
            else
            {// return false
                return false;
            }
        }

        private static bool isPermutationNotCaseSensitive(string str1, string str2) // O(n), O(1)
        {
            var str1Sum = 0;
            var str2Sum = 0;
            foreach (char letter in str1)
            {
                if ((int)letter > 96)
                {
                    str1Sum += (int)letter - 32;
                }
                else
                {
                    str1Sum += (int)letter;
                }
            }
            foreach (char letter in str2)
            {
                if ((int)letter > 96)
                {
                    str2Sum += (int)letter - 32;
                }
                else
                {
                    str2Sum += (int)letter;
                }
            }

            if (str1Sum == str2Sum)
            {
                return true;
            }

            return false;
        }
    }
}