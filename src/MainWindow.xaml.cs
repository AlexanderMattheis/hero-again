using Hero.Pages;
using System.Diagnostics;
using System.Windows;

namespace Hero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AnzeigeFrame.Content = new StartPage();
        }
    }
}
