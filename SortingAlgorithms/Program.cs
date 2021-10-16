using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of an array that you want to sort: ");
            int N = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                arr[i] = rnd.Next(30);
                Console.Write(arr[i] + " ");
            }
            if (arraySortedOrNot(arr, arr.Length) != 0)
            {
                Console.WriteLine("Array is sorted");
                Environment.Exit(0);
            }
            else
                Console.WriteLine();
            Console.WriteLine("Select which algorithm you want to perform:\n" +
                              "1.Insertion sort\n" +
                              "2.Bubble sort\n" +
                              "3.Quick sort\n" +
                              "4.Heap sort\n" +
                              "5.Merge sort\n" +
                              "6.All\n");
            int count = 0;
            char left;
            int left_number;
            char right;
            int right_number;

            try
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    throw new ArgumentNullException(paramName: nameof(input), message: "parameter can't be null.");
                }

                else if (input == "6")
                {
                    for (int i = 1; i < 6; i++)
                    {
                        ChooseAlgorithms(i, arr);
                    }
                }

                else if (input.Length > 1)

                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '-' || input[i] == ',')
                        {
                            left = input[i - 1];
                            left_number = int.Parse(left.ToString());
                            right = input[i + 1];
                            right_number = int.Parse(right.ToString());
                            if (input[i] == '-')
                            {
                                for (int j = left_number; j <= right_number; j++)
                                {
                                    ChooseAlgorithms(j, arr);
                                }
                            }

                            if (input[i] == ',' && count == 0)
                            {
                                ChooseAlgorithms(left_number, arr);
                                ChooseAlgorithms(right_number, arr);
                                count++;
                            }
                            else { ChooseAlgorithms(right_number, arr); }
                        }
                    }
                }

                else if (int.Parse(input) >= 1 && int.Parse(input) <= 5)
                {
                    ChooseAlgorithms(int.Parse(input), arr);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error message is: " + ex.Message);
            }
        }

        static int arraySortedOrNot(int[] arr, int n)
        {
            if (n == 1 || n == 0)
                return 1;

            if (arr[n - 1] < arr[n - 2])
                return 0;

            return arraySortedOrNot(arr, n - 1);
        }

        static void ChooseAlgorithms(int number, int[] arr)
        {
            var watch = new System.Diagnostics.Stopwatch();
            var memoryStart = System.GC.GetTotalMemory(true);
            watch.Start();
            switch (number)
            {
                case 1:
                    InsertionSort insertionSort = new InsertionSort();
                    insertionSort.Sort(arr);
                    insertionSort.Print(arr);
                    break;
                case 2:
                    BubbleSort bubbleSort = new BubbleSort();
                    bubbleSort.Sort(arr);
                    bubbleSort.Print(arr);
                    break;
                case 3:
                    QuickSort quickSort = new QuickSort();
                    quickSort.SortQuick(arr, 0, arr.Length - 1);
                    quickSort.Print(arr);
                    break;
                case 4:
                    HeapSort heapSort = new HeapSort();
                    heapSort.Sort(arr);
                    heapSort.Print(arr);
                    break;
                case 5:
                    MargeSort margeSort = new MargeSort();
                    margeSort.Sort(arr, 0, arr.Length - 1);
                    margeSort.Print(arr);
                    break;
                default:
                    throw new FormatException();
            }
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            var memoryEnd = System.GC.GetTotalMemory(true);

            Console.WriteLine("Total Memory: {0}", memoryEnd - memoryStart);
        }
    }
}
