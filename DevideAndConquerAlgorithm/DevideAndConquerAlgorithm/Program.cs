using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevideAndConquerAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            try
            {
                stopwatch.Start();
                int[] numbersList = GenerateMillionNumbers().ToArray();
                stopwatch.Stop();
                Console.WriteLine("Time taken for generating 10000000  numbers in milliseconds : " + stopwatch.Elapsed.TotalMilliseconds);

                // Finding Peak in normal fashion
                stopwatch.Reset();
                stopwatch.Start();
                int peak = FindPeakInSimpleManner(numbersList);
                stopwatch.Stop();
                Console.WriteLine("Peak Value is :" + peak);
                Console.WriteLine("Time taken for finding peak in simple manner : " + stopwatch.Elapsed.TotalMilliseconds);

                //Finding Peak using devide and conquer algo
                stopwatch.Reset();
                stopwatch.Start();
                int divideAndConquerPeak = FindPeakUsingDivideAndConquer(numbersList);
                stopwatch.Stop();
                Console.WriteLine("Peak Value is :" + divideAndConquerPeak);
                Console.WriteLine("Time taken for finding peak in Devide and Conquer manner : " + stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception found " + ex.Message);
            }
            Console.ReadLine();
        }

        private static int FindPeakUsingDivideAndConquer(int[] numbersList)
        {
            int peak = 0;
            int length = numbersList.Length;
            int middleIndex = length/2;
            int pointer = 0;
            do
            {  
                pointer = (length- middleIndex) / 2;
                if (numbersList[middleIndex] > numbersList[middleIndex - 1])
                {
                    peak = numbersList[middleIndex];
                    middleIndex = middleIndex + pointer;                    
                }
                else {
                    peak = numbersList[middleIndex];
                    middleIndex = middleIndex - pointer;
                }
                
            } while (pointer > 0 && pointer < numbersList.Length);

            return peak;
        }

        private static int FindPeakInSimpleManner(int[] numbersList)
        {
            int peak = 0;
            int length = numbersList.Length;
            for (int i = 0; i < length; i++)
            {
                if (peak <= numbersList[i])
                    peak = numbersList[i];
            }
            return peak;
        }

        private static List<int> GenerateMillionNumbers()
        {
            List<int> numbers = new List<int>();
            for (int i = -5000000; i <= 5000000; i++)
            {
                numbers.Add(i);
            }
            Console.WriteLine("Numbers Generated Successfully");
            return numbers;
        }
    }
}
