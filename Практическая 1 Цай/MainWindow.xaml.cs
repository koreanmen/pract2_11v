using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_11;
using Lib_11Mas;

namespace Практическая_1_Цай
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,]? mas;

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    bool f1;
        //    f1 = Int32.TryParse(tbv.Text,out int n);
        //    if (f1)
        //    {
        //        n = Convert.ToInt32(tbv.Text);
        //        string s = "";
        //        Random rnd = new Random();
        //        for (int i = 0; i < n; i++)
        //        {
        //            int x = rnd.Next(1, n);
        //            s += x + " ";
        //        }
        //        tbs.Text = s;
        //        float mult = 0;
        //        Class1.Func(n, s, out mult);
        //        tbr.Text = mult.ToString();
        //    }
        //    else MessageBox.Show("Введите верные значения","Ошибка",MessageBoxButton.OK);
        //}

        // О программе
        private void MenuItem_inf(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Цай Владислав, ИСП-31, Практическая 2, Вариант-11 \r\nВвести n целых чисел(>0 или <0). Найти разницу чисел. \r\nРезультат вывести на экран.", "Информация",MessageBoxButton.OK);
        }
        //Очистить
        private void MenuItem_Clear(object sender, RoutedEventArgs e)
        {
            tbrez.Clear();
            tbdiapmin.Clear();
            tbdiapmax.Clear();
            tbkol.Clear();
            dataGrid.ItemsSource= null;
            mas = null;

        }
        // Выход
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void tbv_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    tbr.Clear();
        //    tbs.Clear();
        //}
        
        //Сохранить
        private void MenuItem_save(object sender, RoutedEventArgs e)
        {
            Mas.Save(mas);
        }

        // Открыть
        private void MenuItem_open(object sender, RoutedEventArgs e)
        {
            mas = Mas.Open();
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        // Заполнить
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int randMin = Convert.ToInt32(tbdiapmin.Text);
            int randMax = Convert.ToInt32(tbdiapmax.Text);
            if (int.TryParse(tbkol.Text, out int number))
            {
                mas = Mas.Fill(randMin, randMax,1, number);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Введите корректные значения", "Ошибк");
        }

        //Ввод из ячейки в массив
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            int indRow = e.Row.GetIndex();
            int indColumn = e.Column.DisplayIndex;
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out int newValue))
            {
                mas[indRow, indColumn] = newValue;
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else
            {
                e.Cancel = true;
            }
        }

        //Решение
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                tbrez.Text = Class1.Func(mas).ToString();
            }
        }

        //Создать
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            int kol = Convert.ToInt32(tbkol.Text);
            mas=new int[1,kol];
            dataGrid.ItemsSource= VisualArray.ToDataTable(mas).DefaultView;
        }
    }
}