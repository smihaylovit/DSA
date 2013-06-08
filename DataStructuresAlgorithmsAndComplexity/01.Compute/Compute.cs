/* The expected running time is quadratic time O(N*N).
 * The number of elementary steps is ~ N*N.*/

using System;

public class Compute
{
    static int numberOfElementarySteps = 0;

    static void Main()
    {
        const int N = 100;
        
        int[] array = new int[N];

        long count = ComputeFunc(array);

        Console.WriteLine("N = {0}", N);
        Console.WriteLine("N * N = {0} * {1} = {2}", N, N, N * N);
        Console.WriteLine("The number of elementary steps is ~ {0}.", numberOfElementarySteps);
    }

    //Runs in quadratic time O(N*N)
    static long ComputeFunc(int[] arr)
    {
        long count = 0;

        //The first cycle iterates N times.
        for (int i = 0; i < arr.Length; i++) 
        {
            numberOfElementarySteps++;

            int start = 0;
            int end = arr.Length - 1;
            
            //For each iteration of the first cycle, the second one iterates N times as well. 
            //It's because on every step either "start" gets increased by one or "end" decreased by one.
            //Thus the difference between "start" and "end", from N at the begining, will be decreased by 
            //exactly 1 on each step and so the second cycle iterates N times as well.
            while (start < end)
            {
                numberOfElementarySteps++;

                if (arr[start] < arr[end])
                {
                    start++;
                    count++;             
                }
                else
                {
                    end--;
                }
            }
        }

        return count;
    }
}