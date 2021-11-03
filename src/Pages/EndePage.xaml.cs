using System.Windows;
using System.Windows.Controls;

namespace Hero.Pages
{
    /// <summary>
    /// Interaktionslogik für EndePage.xaml
    /// </summary>
    public partial class EndePage : Page
    {
        private const int START_PUNKTE = 0;

        public int Punkte
        {
            get => (int)GetValue(PunktAnzahlProperty);
            set => SetValue(PunktAnzahlProperty, value);
        }

        public static readonly DependencyProperty PunktAnzahlProperty =
            DependencyProperty.Register(nameof(Punkte), typeof(int), typeof(EndePage), new PropertyMetadata(START_PUNKTE));

        public EndePage(int anzahlPunkte)
        {
            InitializeComponent();
            Punkte = anzahlPunkte;
        }

        private void NeustartButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnzahlTeamsPage());
        }

        private void VerlassenButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
