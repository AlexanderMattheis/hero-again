using Hero.Pages.QuestionPageHelper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hero.Pages
{
    /// <summary>
    /// Interaktionslogik für QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        private int aktuelleFrageIndex;

        private QuestionPageViewModel viewModel;

        public QuestionPage(int minuten)
        {
            InitializeComponent();
            this.viewModel = (QuestionPageViewModel)DataContext;
            this.viewModel.Minuten = minuten;

            LadeFrage(0);
            Loaded += Geladen;
        }

        private void Geladen(object sender, RoutedEventArgs e) // nur zur Sicherheit
        {
            NavigationService.RemoveBackEntry();
            Loaded -= Geladen;
        }

        public void LadeFrage(int index)
        {
            FragenLoader.Frage frage = FragenLoader.Instanz.LadeXMLFragenKatalog(index);

            if (frage == null)
            {
                NavigationService.Navigate(new EndePage(this.viewModel.Punkte));
                return;
            }

            this.viewModel.Frage = frage;
        }

        private void QuestionDisplay_OnErfolg(object sender, RoutedEventArgs e)
        {
            this.viewModel.Punkte++;
            LadeFrage(++aktuelleFrageIndex);
        }

        private void QuestionDisplay_OnMisserfolg(object sender, RoutedEventArgs e)
        {
            LadeFrage(++this.aktuelleFrageIndex);
        }

        private void StatusBar_OnFinish(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) // Event kann noch gefeuert werden, wenn die Question Page gelöscht wird
            {
                NavigationService.Navigate(new EndePage(this.viewModel.Punkte));
            }
        }
    }
}
