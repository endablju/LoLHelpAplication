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

namespace LoLHelpAplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _model;
        public MainWindow()
        {
            InitializeComponent();
            _model = new MainWindowViewModel();
            this.DataContext = _model;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            playerWindow player = new playerWindow();
            if (!(String.IsNullOrEmpty(searchTextBox.Text)))
            {
                player.PlayerLabel.Content = "Player: " + searchTextBox.Text;
                //player.Show();
                player.DataContext = _model;
                //if ()
                player.Show();
                //this.Close();
            }
            
        }

        
    }
}
