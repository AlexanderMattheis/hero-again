using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hero.Pages
{
    /// <summary>
    /// Interaktionslogik für AnzahlTeamsPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            Loaded += Geladen;
        }

        private void Geladen(object sender, RoutedEventArgs e) // nur zur Sicherheit
        {
            NavigationService.RemoveBackEntry();
            Loaded -= Geladen;
        }

        private void StartPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigationService.Navigate(new QuestionPage(((StartPageViewModel)DataContext).Minuten));
            }
        }
    }
}
