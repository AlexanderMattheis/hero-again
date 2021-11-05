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
        private const int START_PUNKTE = 0;
        private const int START_ZEIT = 30;

        private int aktuelleFrageIndex = 0;

        #region Properties
        public string Frage
        {
            get => (string)GetValue(FrageProperty);
            set => SetValue(FrageProperty, value);
        }

        public static readonly DependencyProperty FrageProperty =
            DependencyProperty.Register(nameof(Frage), typeof(string), typeof(QuestionPage), new PropertyMetadata(Strings.StandardFrage));

        public string OptionA
        {
            get => (string)GetValue(OptionAProperty);
            set => SetValue(OptionAProperty, value);
        }

        public static readonly DependencyProperty OptionAProperty =
            DependencyProperty.Register(nameof(OptionA), typeof(string), typeof(QuestionPage), new PropertyMetadata(Strings.StandardOption));

        public string OptionB
        {
            get => (string)GetValue(OptionBProperty);
            set => SetValue(OptionBProperty, value);
        }

        public static readonly DependencyProperty OptionBProperty =
            DependencyProperty.Register(nameof(OptionB), typeof(string), typeof(QuestionPage), new PropertyMetadata(Strings.StandardOption));

        public string OptionC
        {
            get => (string)GetValue(OptionCProperty);
            set => SetValue(OptionCProperty, value);
        }

        public static readonly DependencyProperty OptionCProperty =
            DependencyProperty.Register(nameof(OptionC), typeof(string), typeof(QuestionPage), new PropertyMetadata(Strings.StandardOption));

        public string OptionD
        {
            get => (string)GetValue(OptionDProperty);
            set => SetValue(OptionDProperty, value);
        }

        public static readonly DependencyProperty OptionDProperty =
            DependencyProperty.Register(nameof(OptionD), typeof(string), typeof(QuestionPage), new PropertyMetadata(Strings.StandardOption));

        public int KorrekteAntwortIndex
        {
            get => (int)GetValue(KorrekteAntwortProperty);
            set => SetValue(KorrekteAntwortProperty, value);
        }

        public static readonly DependencyProperty KorrekteAntwortProperty =
            DependencyProperty.Register(nameof(KorrekteAntwortIndex), typeof(int), typeof(QuestionPage), new PropertyMetadata(-1));

        public int Punkte
        {
            get => (int)GetValue(PunkteProperty);
            set => SetValue(PunkteProperty, value);
        }

        public static readonly DependencyProperty PunkteProperty =
            DependencyProperty.Register(nameof(Punkte), typeof(int), typeof(QuestionPage), new PropertyMetadata(START_PUNKTE));

        public int Minuten
        {
            get => (int)GetValue(MinutenProperty);
            set => SetValue(MinutenProperty, value);
        }

        private static readonly DependencyProperty MinutenProperty =
            DependencyProperty.Register(nameof(Minuten), typeof(int), typeof(QuestionPage), new PropertyMetadata(START_ZEIT));
        #endregion

        public QuestionPage(int minuten)
        {
            InitializeComponent();
            LadeFrage(0);

            Minuten = minuten;
        }

        public void LadeFrage(int index)
        {
            FragenLoader.Frage frage = FragenLoader.Instanz.LadeXMLFragenKatalog(index);

            if (frage == null)
            {
                NavigationService.Navigate(new EndePage(Punkte));
                return;
            }

            Frage = frage.Text;
            OptionA = frage.OptionA;
            OptionB = frage.OptionB;
            OptionC = frage.OptionC;
            OptionD = frage.OptionD;
            KorrekteAntwortIndex = frage.korrektAntwort;
        }

        private void QuestionDisplay_OnErfolg(object sender, RoutedEventArgs e)
        {
            Punkte++;
            LadeFrage(++aktuelleFrageIndex);
        }

        private void QuestionDisplay_OnMisserfolg(object sender, RoutedEventArgs e)
        {
            LadeFrage(++aktuelleFrageIndex);
        }
    }
}
