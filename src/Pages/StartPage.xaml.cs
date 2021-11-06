using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hero.Pages
{
    /// <summary>
    /// Interaktionslogik für AnzahlTeamsPage.xaml
    /// </summary>
    public partial class AnzahlTeamsPage : Page
    {
        private const int START_MINUTEN = 30;

        public int Minuten
        {
            get => (int)GetValue(MinutenProperty);
            set => SetValue(MinutenProperty, value);
        }

        public static readonly DependencyProperty MinutenProperty =
            DependencyProperty.Register(nameof(Minuten), typeof(int), typeof(AnzahlTeamsPage), new PropertyMetadata(START_MINUTEN));

        public AnzahlTeamsPage()
        {
            InitializeComponent();

            Loaded += Geladen;
        }

        private void Geladen(object sender, RoutedEventArgs e) // nur zur Sicherheit
        {
            NavigationService.RemoveBackEntry();
            Loaded -= Geladen;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigationService.Navigate(new QuestionPage(Minuten));
            }
        }
    }
}
