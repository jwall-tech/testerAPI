

namespace TestA
{
    public class Program
    {
        public static int[,] arr2D = { { 54, 60, 11 }, {500,602,100} };
        public static void Main()
        {
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                int[] arr = { };
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    List<int> larr = arr.ToList();
                    larr.Add(arr2D[i, j]);
                    arr = larr.ToArray();
                    //Console.WriteLine(arr[0]);
                }

                int[] sorted = Sort.SortSeq(arr);

                if (sorted.Length % 2 == 0)
                {
                    var MedL = sorted.Length / 2;
                    var MedH = MedL + 1;
                    var Med = (MedL + MedH) / 2;
                    Med = sorted[Med];
                    Console.WriteLine("ROW MEDIAN: " + Med.ToString());
                }
                else
                {
                    float Med = sorted.Length / 2;
                    Math.Round(Med);
                    var MedT = sorted[(int) Med];
                    Console.WriteLine("ROW MEDIAN: " + MedT.ToString());
                }
            }
        }
    }
}