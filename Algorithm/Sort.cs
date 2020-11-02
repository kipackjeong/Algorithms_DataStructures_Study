using System;
using System.CodeDom.Compiler;
using System.Data.SqlClient;
using System.Threading;
using System.Xml.Schema;

namespace Algorithms
{
    public class Sort
    {
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            int index = Partition(arr, left, right);
            if (left < index - 1)
            {
                QuickSort(arr, left, index - 1);
            }
            if (index < right)
            {
                QuickSort(arr, index, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int temp;
            //int pivot = (left + right) / 2;
            //while (left <= right)
            //{
            //    while (arr[left] < arr[pivot])
            //    {
            //        left++;
            //    }
            //    while (arr[right] > arr[pivot])
            //    {
            //        right--;
            //    }
            //    if (left <= right)
            //    {
            //        temp = arr[left];
            //        arr[left] = arr[right];
            //        arr[right] = temp;
            //        left++;
            //        right--;
            //    }
            //}
            //return left;
            int pivot = arr[(left + right) / 2]; // pivot 구할때는 인덱스가 아니라 밸류로 구하자.
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
            return left;
        }

        public static void MaxHeapSort(int[] array)
        {
            // Create max Heap Structure
            // i starts from 1, because I want to start from the first child node.
            //for (int i = 1; i < array.Length; i++)
            //{
            //    int child = i;

            //    while (child != 0)// when child is 0; there would be no root to compare.
            //    {
            //        int root = (child - 1) / 2; // find root val;
            //        if (array[child] > array[root]) // if child val > root val
            //        {
            //            int temp = array[child]; // swap
            //            array[child] = array[root];
            //            array[root] = temp;
            //        }
            //        child = root; // move upward, becase we have for loop to iterate downward
            //    }
            //}
            int c = 1;
            while (c < array.Length)
            {
                int p = (c - 1) / 2;
                if (array[p] < array[c])
                {
                    int temp = array[p];
                    array[p] = array[c];
                    array[c] = temp;
                    c = p;
                }
                else
                {
                    c++;
                }
            }

            // Sort
            // Swap first and last value, and create heap structure while trimming down

            for (int i = array.Length - 1; i >= 0; i--) // trimming down from end.
            {
                // swap first val and last val
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                int root = 0;
                int child = 1; // start from first child(left)

                // child has to be less than i
                // because i is already trimmed
                while (child < i)
                {
                    // compare left and right child, get child with largest val.
                    if (array[child] < array[child + 1] && child < i - 1)
                    {
                        child++;
                    }
                    // compare largest child with it's root,
                    // if child is bigger, swap
                    if (array[child] > array[root])
                    {
                        // swap
                        temp = array[child];
                        array[child] = array[root];
                        array[root] = temp;
                    }
                    // moving down to find any value larger than current root.
                    root = child;
                    child = 2 * root + 1;
                    // initiate child here.
                }
            }
        }

        // MergeSort
        public static void MergeSort(int[] arr)
        {
            int[] tmp = new int[arr.Length];
            MergeSort(arr, tmp, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int[] tmp, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, tmp, start, mid);
                MergeSort(arr, tmp, mid + 1, end);
                Merge(arr, tmp, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int[] tmp, int start, int mid, int end)
        {
            for (int i = start; i <= end; i++)
            {
                tmp[i] = arr[i];
            }

            int part1 = start; //첫번째 배열의 첫번째 요소
            int part2 = mid + 1; // 두번째 배열의 첫번째 요소
            int index = start; // 저장할곳
            while (part1 <= mid && part2 <= end)
            {
                if (tmp[part1] <= tmp[part2])
                {
                    arr[index] = tmp[part1];
                    part1++;
                }
                else
                {
                    arr[index] = tmp[part2];
                    part2++;
                }

                index++;
            }

            for (int i = 0; i <= mid - part1; i++)
            {
                arr[index + i] = tmp[part1 + i];
            }
        }

        public static void QuickSort2(int[]arr)
        {
            QuickSort2(arr, 0, arr.Length - 1);
        }
        private static void QuickSort2(int[]arr, int start, int end)
        {
            int index = Partition2(arr, start, end);
            if (start < index - 1)
                QuickSort2(arr, start, index - 1);
            if (index < end)
                QuickSort2(arr, index, end);
        }

        private static int Partition2(int[]arr, int start, int end)
        {
            int pivot = arr[start + (end - start) / 2];
            while (start <= end)
            {
                while (arr[start] < pivot)
                {
                    start++;
                }
                while (arr[end] > pivot)
                {
                    end--;
                }
                if(start <= end)
                {
                    // swap
                    int temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;
                    start++;
                    end--;
                }
            }
            return start;
        }
        public static void HeapSort(int[] arr)
        {

            int c;
            int r;
            // create it to heap
            // need c  and   r
            // iterate over arr,
            for (var i = 1; i < arr.Length; i++)
            {
                c = i;
                while (c != 0)
                {
                    r = (c - 1) / 2;
                    // compare value c with r;
                    if (arr[c] > arr[r])
                    {
                        Swap(arr, c, r);
                    }
                    c = r;
                }
            }

            // Maxheap is created

            // Sort
            // swap end of the list with start of the list
            for (var i = arr.Length - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                r = 0;
                while ((r * 2) + 1 < i)
                {
                    c = (r * 2) + 1;
                    // compare two child nodes, and grab the largest
                    if (arr[c] < arr[c + 1] && c + 1 < i)
                        c++;

                    // compare c with root
                    if (arr[c] > arr[r])
                    {
                        Swap(arr, c, r);
                    }
                    r = c;
                }
            }
        }

        public static void QuickSort3(int[] arr)
        {
            QuickSort3(arr, 0 , arr.Length-1);
            
        }

        public static void QuickSort3(int[] arr, int l, int r)
        {
            int partitionIndex = Partition3(arr, l, r);
            
            if(l < partitionIndex - 1)
                QuickSort3(arr, l, partitionIndex-1);
            if (r > partitionIndex)
                QuickSort3(arr, partitionIndex, r);
        }

        private static int Partition3(int[]arr, int l, int r)
        {

            // find pivot point
            int p = arr[l + (r - l) / 2];

            while (l <= r)
            {
                while (arr[l] < p)
                    l++;
                while (arr[r] > p)
                    r--;
                if (l <= r)
                {
                    Swap(arr, l, r);
                    l++;
                    r++;
                }
            }

            return l;
        }




        private static void Swap(int[] arr, int c, int r)
        {
            int temp = arr[c];
            arr[c] = arr[r];
            arr[r] = temp;
        }
    }


}