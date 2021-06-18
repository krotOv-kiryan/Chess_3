using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Chess.ViewModel;

namespace Chess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        //public Point GetMousePos() => Mouse.GetPosition(ChessBoard);

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var vm = (MainVM)this.DataContext;
            vm?.Square_clicked(e.GetPosition(ChessBoard));


            //?.Square_clicked(e.GetPosition(ChessBoard)); //
        }
    }
}
