using Hero.Pages;
using System.Windows;
using System.Windows.Input;

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
            AnzeigeFrame.Content = new AnzahlTeamsPage();
        }
    }
}
