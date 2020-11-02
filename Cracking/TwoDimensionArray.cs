using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking
{
    public static class TwoDimensionArray<T>
    {
        public static void RotateClockWise(char[][]arr)
        {
            // get length of arr
            var length = arr.Length;
            // get layers of arr
            var numOfLayer = length / 2;
            
            // first iteration : in scope of layers
            for (var i = 0; i < numOfLayer; i++)
            {
                // per layer define the first and last
                var first = i;
                var last = length - 1 - i;

                // second iteration: in scope of one layer
                for (var j = 0; j < last - i; j++)
                {
                    // copy the top
                    var copy = arr[first][first + j];
                    // left to top
                    arr[first][first + j] = arr[last - j][first];
                    // bot to left
                    arr[last - j][first] = arr[last][last - j];
                    // right to bot
                    arr[last][last - j] = arr[first + j][last];
                    // top to right
                    arr[first + j][last] = copy;
                }

            }

        }
    }
}
    