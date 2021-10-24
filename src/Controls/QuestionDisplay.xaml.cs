using System.Windows;
using System.Windows.Controls;

namespace Hero.Controls
{
    /// <summary>
    /// Interaktionslogik für QuestionDisplay.xaml
    /// </summary>
    public partial class QuestionDisplay : UserControl
    {
        public string Question
        {
            get => (string)GetValue(QuestionProperty);
            set => SetValue(QuestionProperty, value);
        }

        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register(nameof(Question), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(string.Empty));

        #region Options
        public string OptionA
        {
            get => (string)GetValue(OptionAProperty);
            set => SetValue(OptionAProperty, value);
        }

        public static readonly DependencyProperty OptionAProperty =
            DependencyProperty.Register(nameof(OptionA), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(string.Empty));

        public string OptionB
        {
            get => (string)GetValue(OptionBProperty);
            set => SetValue(OptionBProperty, value);
        }

        public static readonly DependencyProperty OptionBProperty =
            DependencyProperty.Register(nameof(OptionB), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(string.Empty));

        public string OptionC
        {
            get => (string)GetValue(OptionCProperty);
            set => SetValue(OptionCProperty, value);
        }

        public static readonly DependencyProperty OptionCProperty =
            DependencyProperty.Register(nameof(OptionC), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(string.Empty));

        public string OptionD
        {
            get => (string)GetValue(OptionDProperty);
            set => SetValue(OptionDProperty, value);
        }

        public static readonly DependencyProperty OptionDProperty =
            DependencyProperty.Register(nameof(OptionD), typeof(string), typeof(QuestionDisplay), new PropertyMetadata(string.Empty)); 
        #endregion

        public QuestionDisplay()
        {
            InitializeComponent();
            Loaded += (_, _) => InitialisiereControl();
        }

        public void InitialisiereControl()
        {
            Question = Strings.DefaultQuestion;

            OptionA = Strings.DefaultOption;
            OptionB = Strings.DefaultOption;
            OptionC = Strings.DefaultOption;
            OptionD = Strings.DefaultOption;
        }
    }
}
