using System;

namespace Lib_11
{
    public class Class1
    {
        public static int Func(int[,]mas)
        {
            int diff = mas[0, 0];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1)-1; j++)
                {
                    diff -= mas[i, j+1];
                }
            }
            return diff;
        }
    }
}
