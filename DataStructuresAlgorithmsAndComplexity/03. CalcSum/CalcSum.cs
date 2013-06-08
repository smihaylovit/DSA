/* The method is wrong in the task description. We should change the places
 * of the matrix.GetLength(0) and matrix.GetLength(1) expressions. That's 
 * because the first one returns the number of rows and the second one the 
 * number of columns and the first cycle should iterate through the columns,
 * not rows, and the second cycle the opposite accordingly. Otherwise the method 
 * will throw an exception IndexOutOfRange if N!=M. When we fix this bug we have 
 * the expected rinning time of the program is quadratic time O(N*M). That's
 * because the first cycle iterates M times for each recursive call of the method.
 * And the number of the calls to the method are exactly N - row, where row is the
 * parameter passed to the method. If row = 0, the number of elementary steps is ~
 * N*M and for the average case if we call the method with row = N/2, the number 
 * would be N*M/2. As a whole the method calculates the sum of the numbers in a
 * quadratic matrix from a specific row, so the running time is quadratic.
 * 
 * The expected running time is quadratic time O(N*M).
 * The number of elementary steps is ~ (N-row)*M, N*M/2 for avg case.
 */

using System;

public class CalcSum
{
    static int numberOfElementarySteps = 0;

    static void Main()
    {
        const int N = 4;
        const int M = 5;

        int[,] array = new int[N, M]
        {
            {3, 4, 8, 6, 8},
            {5, 2, 1, 0, 5},
            {7, 1, 3, 9, 4},
            {9, 1, 6, 6, 3}
        };

        long sum = CalcSumFunc(array, 2);

        Console.WriteLine("The sum of the rows from 2 to {0} is: {1}.", N - 1, sum);
        Console.WriteLine("N = {0}", N);
        Console.WriteLine("M = {0}", M);
        Console.WriteLine("(N - row) * M = ({0} - 2) * {1} = {2}", N, M, (N - 2) * M);
        Console.WriteLine("The number of elementary steps is ~ {0}.", numberOfElementarySteps);
        Console.WriteLine();

        numberOfElementarySteps = 0;
        sum = CalcSumFunc(array, 0);

        Console.WriteLine("The sum of the matrix elements is: {0}.", sum);
        Console.WriteLine("N = {0}", N);
        Console.WriteLine("M = {0}", M);
        Console.WriteLine("N * M = {0} * {1} = {2}", N, M, N * M);
        Console.WriteLine("The number of elementary steps is ~ {0}.", numberOfElementarySteps);
        Console.WriteLine();
    }

    //Fixed bug.
    //Runs in quadratic time O(N*M).
    static long CalcSumFunc(int[,] matrix, int row)
    {
        long sum = 0;

        //The first cycle iterates M times for each call of the method.
        //First it iterates for the row number passed with the parameter row.
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            numberOfElementarySteps++;
            sum += matrix[row, col];
        }

        //This statement is true until the last row of the matrix is reached.
        //Each recurssion call of the method inside the statement make another
        //M iterations of the first cycle. This means the sum is calculated for
        //all rows from row to N-1 inclusive which are exactly (N - row) rows.
        //So the first cycle iterates M times for each of (N - row) rows which
        //are if row = 0, N*M iterations.
        if (row + 1 < matrix.GetLength(0))
        {
            sum += CalcSumFunc(matrix, row + 1);
        }

        return sum;
    }
}