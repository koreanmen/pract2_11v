
using Microsoft.Win32;
using System.Data;
using System.IO;

namespace Lib_11Mas
{

    /// ����� ��� ������ � ���������.
    public class Mas
    {
        /// ������� � �������������� ������ ������� �� 0 �� 50
        public static int[,] Fill(int min, int max,int row, int column)
        {
            Random rnd = new Random();
            int rNum = 0;
            int[,] mas = new int[row, column];
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    do
                    {
                        rNum = rnd.Next(min,max);
                    } while (rNum == 0);
                    mas[i, j] = rNum;
                }
            }
            return mas;
        }
        
        /// ����� ������ �� ����� ���������� *.txt �������� �������, � ���������� �� � ������
        public static int[,] Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "��� ����� (*.*)|*.*| ��������� ����� (.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "�������� �������";
            int row = 0;
            int column = 0;
            List<int> values = new List<int>();
            if (open.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        string[] valuesStr = line.Split(' ');
                        foreach (string valueStr in valuesStr)
                        {
                            if (Int32.TryParse(valueStr, out int value))
                            {
                                values.Add(value);
                                column++;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        row++;
                    }
                }
                column /= row;
                int indexList = 0;
                int[,] mas = new int[row, column];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i, j] = values[indexList];
                        indexList++;
                    }
                }
                return mas;
            }
            return null;
        }
        /// ����� ���������� ������ � ���� ������� *.txt
        public static void Save(int[,] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "��������� ����� (.txt) | *.txt";
            save.Title = "���������� �������";
            if (save.ShowDialog() == true && mas != null)
            {
                using (StreamWriter file = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < mas.GetLength(0); i++)
                    {
                        for (int j = 0; j < mas.GetLength(1); j++)
                        {
                            file.Write(mas[i, j].ToString());
                            if (j < mas.GetLength(1) - 1)
                            {
                                file.Write(" ");
                            }
                        }
                        file.WriteLine();
                    }
                }
            }
        }
    }
    /// ����� ��� �������������� ������� � DataGrid, ��������� �������� ����� � ��������� ������ �������
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    res.Columns.Add("" + (i), typeof(T));
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var row = res.NewRow();

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        row[j] = matrix[i, j];
                    }

                    res.Rows.Add(row);
                }
            }

            return res;
        }
    }

}