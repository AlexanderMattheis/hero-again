using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hero.Controls
{
    /// <summary>
    /// Interaktionslogik für QuestionDisplay.xaml
    /// </summary>
    public partial class QuestionDisplay : UserControl
    {
        private const string OPTION_A_BUTTON = "OptionAButton"; // Abweichung vom C#-Standard
        private const string OPTION_B_BUTTON = "OptionBButton";
        private const string OPTION_C_BUTTON = "OptionCButton";
        private const string OPTION_D_BUTTON = "OptionDButton";

        #region Felder
        private int selektierteAntwortIndex;
        #endregion

        #region Properties
        public string Frage
        {
            get => (string)GetValue(FrageProperty);
            set => SetValue(FrageProperty, value);
        }

        private static readonly DependencyProperty FrageProperty =
            DependencyProperty.Register(nameof(Frage), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(Strings.StandardFrage));

        public string OptionA
        {
            get => (string)GetValue(OptionAProperty);
            set => SetValue(OptionAProperty, value);
        }

        private static readonly DependencyProperty OptionAProperty =
            DependencyProperty.Register(nameof(OptionA), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(Strings.StandardOption));

        public string OptionB
        {
            get => (string)GetValue(OptionBProperty);
            set => SetValue(OptionBProperty, value);
        }

        private static readonly DependencyProperty OptionBProperty =
            DependencyProperty.Register(nameof(OptionB), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(Strings.StandardOption));

        public string OptionC
        {
            get => (string)GetValue(OptionCProperty);
            set => SetValue(OptionCProperty, value);
        }

        private static readonly DependencyProperty OptionCProperty =
            DependencyProperty.Register(nameof(OptionC), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(Strings.StandardOption));

        public string OptionD
        {
            get => (string)GetValue(OptionDProperty);
            set => SetValue(OptionDProperty, value);
        }

        private static readonly DependencyProperty OptionDProperty =
            DependencyProperty.Register(nameof(OptionD), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(Strings.StandardOption));
        #endregion

        #region Events
        public event RoutedEventHandler OnErfolg
        {
            add { AddHandler(OnErfolgEvent, value); }
            remove { RemoveHandler(OnErfolgEvent, value); }
        }

        private static readonly RoutedEvent OnErfolgEvent =
            EventManager.RegisterRoutedEvent(nameof(OnErfolg), RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(QuestionDisplay));

        public event RoutedEventHandler OnMisserfolg
        {
            add { AddHandler(OnMisserfolgEvent, value); }
            remove { RemoveHandler(OnMisserfolgEvent, value); }
        }

        private static readonly RoutedEvent OnMisserfolgEvent =
            EventManager.RegisterRoutedEvent(nameof(OnMisserfolg), RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(QuestionDisplay));
        #endregion

        public int AntwortIndex
        {
            get => (int)GetValue(AntwortProperty);
            set => SetValue(AntwortProperty, value);
        }

        private static readonly DependencyProperty AntwortProperty =
            DependencyProperty.Register(nameof(AntwortIndex), typeof(int), typeof(QuestionDisplay), new PropertyMetadata(-1));

        public QuestionDisplay()
        {
            InitializeComponent();
        }

        private void OptionButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selektierteAntwortIndex = ((Border)sender).Name switch
            {
                OPTION_A_BUTTON => 0,
                OPTION_B_BUTTON => 1,
                OPTION_C_BUTTON => 2,
                OPTION_D_BUTTON => 3,
                _ => throw new System.NotImplementedException(),
            };

            if (selektierteAntwortIndex == AntwortIndex - 1)
            {
                RaiseEvent(new RoutedEventArgs(OnErfolgEvent));
            }
            else
            {
                RaiseEvent(new RoutedEventArgs(OnMisserfolgEvent));
            }
        }
    }
}
