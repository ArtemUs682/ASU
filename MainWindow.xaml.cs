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
        public List<ItemDGBox> itemsDG = new List<ItemDGBox>();
        public MainWindow()
        {
            InitializeComponent();
            List<ItemListBox> itemsListBox = new List<ItemListBox>();
            itemsListBox.Add(new ItemListBox("Линейная", "f(x, y) = ax + by° + c"));
            itemsListBox.Add(new ItemListBox("Квадратичная", "f(x, y) = ax² + by + c"));
            itemsListBox.Add(new ItemListBox("Кубическая", "f(x, y) = ax³ + by² + c"));
            itemsListBox.Add(new ItemListBox("4-ой степени", "f(x, y) = ax⁴ + by³ + c"));
            itemsListBox.Add(new ItemListBox("5-ой степени", "f(x, y) = ax⁵ + by⁴ + c"));
            LBox.ItemsSource = itemsListBox.ToList();
            itemsDG.Add(new ItemDGBox("", "", ""));
            DGBox.ItemsSource = itemsDG.ToList();
        }

        private void ABox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(ABox.Text == "Введите A")
            {
                ABox.Text = "";
            }
        }

        private void ABox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ABox.Text == "" || ABox.Text == null)
            {
                ABox.Text = "Введите A";
            }
        }

        private void BBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (BBox.Text == "Введите B")
            {
                BBox.Text = "";
            }
        }

        private void BBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (BBox.Text == "" || ABox.Text == null)
            {
                BBox.Text = "Введите B";
            }
        }

        private void CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        }

        private void DGBox_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            
        }

        private void DGBox_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var rowcontent = DGBox.Columns[1].GetCellContent(DGBox.SelectedItem);
            var rowcontent1 = DGBox.Columns[2].GetCellContent(DGBox.SelectedItem);
            if (rowcontent.Parent.ToString().Length != 36 && rowcontent1.Parent.ToString().Length != 36)
            {
                if (LBox.SelectedItem == null || LBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Не выбрана функция!");
                    DGBox.ItemsSource = itemsDG.ToList();
                }
                else
                {
                    if (ABox.Text == "" || BBox.Text == "" || CBox.SelectedItem == null || CBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("Введены не все коэффиценты!");
                        DGBox.ItemsSource = itemsDG.ToList();
                    }
                    else
                    {
                        string CellX = rowcontent.Parent.ToString().Remove(0, 38);
                        string CellY = rowcontent1.Parent.ToString().Remove(0, 38);
                        int x, y;
                        int.TryParse(CellX, out x);
                        int.TryParse(CellY, out y);
                        if ((x == 0 && CellX != "0") || (y == 0 && CellY != "0"))
                        {
                            MessageBox.Show("X или Y введены неверно!");
                        }
                        else
                        {
                            itemsDG[DGBox.SelectedIndex].x = rowcontent.Parent.ToString().Remove(0, 38);
                            itemsDG[DGBox.SelectedIndex].y = rowcontent1.Parent.ToString().Remove(0, 38);
                            itemsDG[DGBox.SelectedIndex].func_xy = (Convert.ToInt32(ABox.Text) * Math.Pow(x, LBox.SelectedIndex + 1) + Convert.ToInt32(BBox.Text) * Math.Pow(y, LBox.SelectedIndex) + Convert.ToInt32(CBox.Text)).ToString();
                            if (DGBox.SelectedIndex == itemsDG.Count - 1)
                            {
                                itemsDG.Add(new ItemDGBox("", "", ""));
                            }
                            DGBox.ItemsSource = itemsDG.ToList();
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
                int.TryParse(ABox.Text, out a);
                if (a == 0 && ABox.Text != "0")
                {
                    ABox.Text = str.Substring(0, str.Length - 1);
                    ABox.CaretIndex = ABox.Text.Length;
                }
            }
        }

        private void BBox_TextChanged(object sender, TextChangedEventArgs e)
        {
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
            }
        }
    }
}
