using System.Windows;
using System.Windows.Controls;

namespace Hero.Pages
{
    /// <summary>
    /// Interaktionslogik für EndePage.xaml
    /// </summary>
    public partial class EndePage : Page
    {
        public EndePage(int gesamtzahlPunkte)
        {
            InitializeComponent();
            ((EndePageViewModel)DataContext).Punkte = gesamtzahlPunkte;

            Loaded += Geladen;
        }

        private void Geladen(object sender, RoutedEventArgs e) // nur zur Sicherheit
        {
            NavigationService.RemoveBackEntry();
            Loaded -= Geladen;
        }

        private void NeustartButton_Click(object sender, RoutedEventArgs e) 
        {
            NavigationService.Navigate(new StartPage());
        }

        private void VerlassenButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
