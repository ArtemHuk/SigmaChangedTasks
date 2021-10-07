using System;
using System.Text;
namespace Task3._2
{
    public class MagicSquare
    {
        private int[,] magicSquare;
        private int size;
        public MagicSquare(int size = 3)
        { 
            GenerateMagicSquare(size);
        }

        public void GenerateMagicSquare(int size)
        {
            magicSquare = new int[size, size];
            this.size = size;
            int i = size / 2;
            int j = size - 1;

            for (int num = 1; num <= size * size;)
            {
                if (i == -1 && j == size) 
                {
                    j = size - 2;
                    i = 0;
                }
                else
                {
                    if (j == size)
                        j = 0;

                    if (i < 0)
                        i = size - 1;
                }
                if (magicSquare[i, j] != 0)
                {
                    j -= 2;
                    i++;
                    continue;
                }
                else
                    magicSquare[i, j] = num++;

                j++;
                i--; 
            }
        }
        public override string ToString()
        {
            StringBuilder temp=new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    temp.Append(string.Format("{0,4}" ,magicSquare[i, j])) ;
                }
                temp.Append("\n");
            }
            return temp.ToString();
        }
    }
}
