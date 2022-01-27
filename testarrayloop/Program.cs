

namespace TestA
{
    public class Program
    {
        public static int[,] arr2D = { { 54, 60, 11 }, { 500, 602, 100 }, { 100, 200, 300 } };
        public static void Main()
        {
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                int temp = 0;
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    temp += arr2D[i,j];
                }
                Console.WriteLine("SUM: "+temp.ToString());
            }
        }
    }
}