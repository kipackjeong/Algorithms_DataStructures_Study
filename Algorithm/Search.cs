namespace Algorithms
{
    public class Search
    {
        public static int BinarySearch(int[] arr, int val)
        {
            return BinarySearch(arr, 0, arr.Length - 1, val);
        }

        private static int BinarySearch(int[] arr, int start, int end, int val)
        {
            int mid = start + (end - start) / 2;
            if (mid == val)
            {
                return mid;
            }
            else if (mid < val)
            {
                return BinarySearch(arr, mid + 1, end, val);
            }
            else
            {
                return BinarySearch(arr, start, mid - 1, val);
            }
        }
    }
}