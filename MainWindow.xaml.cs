using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASU
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Класс для Listview
        public class ItemListBox
        {
            public string TypeOfFunc { get; set; }
            public string MeanOfFunc { get; set; }

            public ItemListBox(string TypeOfFunc, string MeanOfFunc)
            {
                this.TypeOfFunc = TypeOfFunc;
                this.MeanOfFunc = MeanOfFunc;
            }
        }

        //Класс, с помощбю которого можно создать список значений, которые будут автоматически заполнятся, если пользователь меняет функцию
        public class MemoryListBox
        {
            public string A { get; set; }
            public string B { get; set; }
            public MemoryListBox(string A, string B)
            {
                this.A = A;
                this.B = B;
            }
        }
        
        public List<MemoryListBox> memoryList = new List<MemoryListBox>();//Список, в котором хранятся данные полей (для атоматического заполнения при изменении функции)
        
        //Класс для Datagrid
        public class ItemDGBox
        {
            public string func_xy { get; set; }
            public string x { get; set; }
            public string y { get; set; }

            public ItemDGBox(string func_xy, string x, string y)
            {
                this.func_xy = func_xy;
                this.x = x;
                this.y = y;
            }
        }
        
        public List<ItemDGBox> itemsDG = new List<ItemDGBox>();//Список item-ов датагрида
        public MainWindow()
        {
            InitializeComponent();           
            List<ItemListBox> itemsListBox = new List<ItemListBox>();//Список item-ов listview

            //Добавление в список функций
            itemsListBox.Add(new ItemListBox("Линейная", "f(x, y) = ax + by° + c"));
            itemsListBox.Add(new ItemListBox("Квадратичная", "f(x, y) = ax² + by + c"));
            itemsListBox.Add(new ItemListBox("Кубическая", "f(x, y) = ax³ + by² + c"));
            itemsListBox.Add(new ItemListBox("4-ой степени", "f(x, y) = ax⁴ + by³ + c"));
            itemsListBox.Add(new ItemListBox("5-ой степени", "f(x, y) = ax⁵ + by⁴ + c"));
            
            LBox.ItemsSource = itemsListBox.ToList();//Вывод списка в listview            
            itemsDG.Add(new ItemDGBox("", "", ""));//Добавление нового пустого айтема для датагрид
            DGBox.ItemsSource = itemsDG.ToList();//Вывод пустого айтема в датагрид, чтобы пользователь мог ввести x и y

            //Заполнение списка данных полей начальными значениями 
            for (int i = 0; i < 5; i++)
            {
                memoryList.Add(new MemoryListBox("Введите A", "Введите B"));
            }

            LBox.SelectedIndex = 0;//Начальная выбранная функция - линейная
        }

        private void ABox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Логика маски для поля А
            if (ABox.Text == "Введите A")
            {
                ABox.Text = "";
            }
        }

        private void ABox_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (ABox.Text == "" || ABox.Text == null)
            //{
            //    ABox.Text = "Введите A";
            //}
        }

        private void BBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Логика маски для поля В
            if (BBox.Text == "Введите B")
            {
                BBox.Text = "";
            }
        }

        private void BBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (BBox.Text == "" || ABox.Text == null)
            //{
            //    BBox.Text = "Введите B";
            //}
        }

        private void CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Логика маски для выпадющего списка
            if (CBox.SelectedIndex != -1)
            {
                CLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                CLabel.Visibility = Visibility.Visible;
            }
        }

        private void LBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //При изменнении функции автоматически меняются значения в выпадающем списке (1, 10, 100 и тд)
            switch (LBox.SelectedIndex)
            {
                case 0:
                    {
                        int ind = CBox.SelectedIndex;
                        CBox.Items.Clear();
                        for(int i = 1; i <= 5; i++)
                        {
                            CBox.Items.Add(i);
                        }
                        CBox.SelectedIndex = ind;
                        break;
                    }
                case 1:
                    {
                        int ind = CBox.SelectedIndex;
                        CBox.Items.Clear();
                        for (int i = 1; i <= 5; i++)
                        {
                            CBox.Items.Add(i * 10);
                        }
                        CBox.SelectedIndex = ind;
                        break;
                    }
                case 2:
                    {
                        int ind = CBox.SelectedIndex;
                        CBox.Items.Clear();
                        for (int i = 1; i <= 5; i++)
                        {
                            CBox.Items.Add(i * 100);
                        }
                        CBox.SelectedIndex = ind;
                        break;
                    }
                case 3:
                    {
                        int ind = CBox.SelectedIndex;
                        CBox.Items.Clear();
                        for (int i = 1; i <= 5; i++)
                        {
                            CBox.Items.Add(i * 1000);
                        }
                        CBox.SelectedIndex = ind;
                        break;
                    }
                case 4:
                    {
                        int ind = CBox.SelectedIndex;
                        CBox.Items.Clear();
                        for (int i = 1; i <= 5; i++)
                        {
                            CBox.Items.Add(i * 10000);
                        }
                        CBox.SelectedIndex = ind;
                        break;
                    }
            }
            //Заполняем поля данными из списка данных для автоматического заполнения
            ABox.Text = memoryList[LBox.SelectedIndex].A;
            BBox.Text = memoryList[LBox.SelectedIndex].B;
        }

        private void DGBox_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            
        }

        private void DGBox_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Вытаскиваем значения из полей x и y
            var rowcontent = DGBox.Columns[1].GetCellContent(DGBox.SelectedItem);
            var rowcontent1 = DGBox.Columns[2].GetCellContent(DGBox.SelectedItem);
            if (rowcontent.Parent.ToString().Length != 36 && rowcontent1.Parent.ToString().Length != 36)//Если оба поля не пустые
            {
                if (LBox.SelectedItem == null || LBox.SelectedIndex < 0)//Если не выбрана функция
                {
                    MessageBox.Show("Не выбрана функция!");
                    DGBox.ItemsSource = itemsDG.ToList();
                }
                else
                {
                    if (ABox.Text == "" || BBox.Text == "" || CBox.SelectedItem == null || CBox.SelectedIndex < 0)//Если не заполнены поля А, В и С
                    {
                        MessageBox.Show("Введены не все коэффиценты!");
                        DGBox.ItemsSource = itemsDG.ToList();
                    }
                    else
                    {
                        //Приводим вытащенные значения в приемлемый вид
                        string CellX = rowcontent.Parent.ToString().Remove(0, 38);
                        string CellY = rowcontent1.Parent.ToString().Remove(0, 38);
                        int x, y;
                        //Парсим значения
                        int.TryParse(CellX, out x);
                        int.TryParse(CellY, out y);
                        if ((x == 0 && CellX != "0") || (y == 0 && CellY != "0"))//Проверка на то, чтобы в поля x и y не было введено некорректных символов
                        {
                            MessageBox.Show("X или Y введены неверно!");
                        }
                        else
                        {
                            //добавление значений в список для датагрида
                            itemsDG[DGBox.SelectedIndex].x = rowcontent.Parent.ToString().Remove(0, 38);
                            itemsDG[DGBox.SelectedIndex].y = rowcontent1.Parent.ToString().Remove(0, 38);
                            itemsDG[DGBox.SelectedIndex].func_xy = (Convert.ToInt32(ABox.Text) * Math.Pow(x, LBox.SelectedIndex + 1) + Convert.ToInt32(BBox.Text) * Math.Pow(y, LBox.SelectedIndex) + Convert.ToInt32(CBox.Text)).ToString();
                            if (DGBox.SelectedIndex == itemsDG.Count - 1)//если строка, которую пользователь изменял была последней в датагриде
                            {
                                itemsDG.Add(new ItemDGBox("", "", ""));//то добавить в список новую пустую функцию
                            }
                            DGBox.ItemsSource = itemsDG.ToList();//выводим все функции из списка в датагрид
                        }
                    }
                }
            }
        }

        private void ABox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ABox.Text != "Введите A" && ABox.Text != "")
            {
                string str = ABox.Text;
                int a;
                int.TryParse(ABox.Text, out a);//Парсим введённое значение
                if (a == 0 && ABox.Text != "0")//Если введённое значение содержит некорректные символы
                {
                    ABox.Text = str.Substring(0, str.Length - 1); //то удалить последний введённы символ
                    ABox.CaretIndex = ABox.Text.Length;//и перенести каретку в конец поля
                }
                memoryList[LBox.SelectedIndex].A = ABox.Text;//Запись введённого значения в список данных для автоматического заполнения полей
            }
        }

        private void BBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Всё то же самое, что и в ABox_TextChanged
            if (BBox.Text != "Введите B" && BBox.Text != "")
            {
                string str = BBox.Text;
                int a;
                int.TryParse(BBox.Text, out a);
                if (a == 0 && BBox.Text != "0")
                {
                    BBox.Text = str.Substring(0, str.Length - 1);
                    BBox.CaretIndex = BBox.Text.Length;
                }
                memoryList[LBox.SelectedIndex].B = BBox.Text;
            }
        }

        public int Testing(int index_l, int a, int b, int index_c, int x, int y)
        {
            int ind_of_res = itemsDG.Count - 1;
            LBox.SelectedIndex = index_l;
            ABox.Text = a.ToString();
            BBox.Text = b.ToString();
            CBox.SelectedIndex = index_c;
            itemsDG[ind_of_res].x = x.ToString();
            itemsDG[ind_of_res].y = y.ToString();
            //До этого момента логика работает правильно, дальше что-то ломается
            //Неизвестно, заполняется ли datagrid, потому что не получается его прочитать, хотя сделано всё также, как и в основном коде
            DGBox.ItemsSource = itemsDG.ToList();
            DGBox.SelectedIndex = ind_of_res;
            DGBox_CellEditEnding(null, null);
            var rowcontent = DGBox.Columns[0].GetCellContent(DGBox.Items[ind_of_res]);
            int result = Convert.ToInt32(rowcontent.Parent.ToString().Remove(0, 38));
            return result;
        }
    }
}
