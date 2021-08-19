using platforma_1._0.Analyse;
using platforma_1._0.Core;
using System;
using System.Collections.Generic;
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

namespace platforma_1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> LinkList = new List<string>();
        ParserWorker<string[]> parser;
        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new Parser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            LinkList.AddRange(arg2);
            DataTb.Text = parser.Settings.BaseUrl + "\n" + String.Join("\n", LinkList.ToArray());


        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done");
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTb.Text = "Данные обновляются";
            parser.Settings = new ParserSettings();
            parser.Start();
        }

        

        private void AbortBtn_Click(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }

        private void StartBtn2_Click(object sender, RoutedEventArgs e)
        {
            parser.Settings = new ParserSettings();
            parser.Start();
        }

        private void StartBtn3_Click(object sender, RoutedEventArgs e)
        {
            parser.Settings = new ParserSettings();
            parser.Start();
        }
    }
}
