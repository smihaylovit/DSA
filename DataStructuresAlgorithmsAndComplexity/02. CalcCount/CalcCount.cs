/* Best case - All elements at first column are not even:
 * The expected running time is linear time O(N).
 * The number of elementary steps is ~ N.
 * 
 * Average case - Half of the elements of the first column are even:
 * The expected running time is quadratic time O(N*M).
 * The number of elementary steps is ~ N + M*N/2 ~ (M+2)*N/2.
 * 
 * Worst case - All elements of the first column are even:
 * The expected running time is quadratic time O(N*M).
 * The number of elementary steps is ~ N + M*N ~ (M+1)*N.
 * 
 * Amortized time - N iterations for the first cyce plus averaged 
 * over time for the second cycle which iterates M times for each 
 * of 0 to N number of operations in different cases:
 * The amortized running time is quadratic time O(N*M).
 * The number of elementary steps is ~ N + N*(N+1)*M/2/N ~ N + M*(N+1)/2.
 * 
 * The expected running time is quadratic time O(N*M).
 */

using System;

public class CalcCount
{
    static int numberOfElementarySteps = 0;

    static void Main()
    {
        const int N = 4;
        const int M = 5;

        int[,] array_best = new int[N, M]
        {
            {3, 4, 8, 6, 8},
            {5, 2, 1, 0, 5},
            {7, 1, 3, 9, 4},
            {9, 1, 6, 6, 3}
        };

        long count = CalcCountFunc(array_best);

        Console.WriteLine("N = {0}", N);
        Console.WriteLine("The number of elementary steps for best case is ~ {0}.", numberOfElementarySteps);
        Console.WriteLine();

        int[,] array_avg = new int[N, M]
        {
            {2, 4, 8, 6, 8},
            {5, 2, 1, 0, 5},
            {6, 1, 3, 9, 4},
            {9, 1, 6, 6, 3}
        };

        numberOfElementarySteps = 0;
        count = CalcCountFunc(array_avg);

        Console.WriteLine("N = {0}", N);
        Console.WriteLine("M = {0}", M);
        Console.WriteLine("(M + 2) * N / 2 = ({0} + 2) * {1} / 2 = {2}", M, N, (M + 2) * N / 2);
        Console.WriteLine("The number of elementary steps for average case is ~ {0}.", numberOfElementarySteps);
        Console.WriteLine();

        int[,] array_worst = new int[N, M]
        {
            {2, 4, 8, 6, 8},
            {4, 2, 1, 0, 5},
            {6, 1, 3, 9, 4},
            {8, 1, 6, 6, 3}
        };

        numberOfElementarySteps = 0;
        count = CalcCountFunc(array_worst);

        Console.WriteLine("N = {0}", N);
        Console.WriteLine("M = {0}", M);
        Console.WriteLine("(M + 1) * N = ({0} + 1) * {1} = {2}", M, N, (M + 1) * N);
        Console.WriteLine("The number of elementary steps for average case is ~ {0}.", numberOfElementarySteps);
        Console.WriteLine();
    }

    //Runs in quadratic time O(N*M)
    static long CalcCountFunc(int[,] matrix)
    {
        long count = 0;

        //The first cycle iterates N times.
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            numberOfElementarySteps++;

            //This statement is true from 0 to N times or average N/2 times.
            if (matrix[row, 0] % 2 == 0)
            {
                //The second cycle iterates M times but not for each iteration of the first one for sure. 
                //In the average case (if half of the numbers in the first column are even) this 
                //cycle iterates M*N/2 times.
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    numberOfElementarySteps++;

                    if (matrix[row, col] > 0)
                    {
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
}