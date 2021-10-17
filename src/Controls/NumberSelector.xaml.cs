using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hero.Controls
{
    /// <summary>
    /// Interaktionslogik für NumberSelector.xaml
    /// </summary>
    public partial class NumberSelector : UserControl
    {
        public int Wert
        {
            get { return (int)GetValue(CurrentProperty); }
            set { SetValue(CurrentProperty, value); }
        }

        public static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register(nameof(Wert), typeof(int), typeof(NumberSelector), new PropertyMetadata(0));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(int), typeof(NumberSelector), new PropertyMetadata(0));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(int), typeof(NumberSelector), new PropertyMetadata(0));

        public NumberSelector()
        {
            InitializeComponent();
            Loaded += (_, _) => InitialisiereControl();
        }

        public void InitialisiereControl()
        {
            if (Wert < Minimum)
            {
                Wert = Minimum;
            }

            if (Wert > Maximum)
            {
                Wert = Maximum;
            }

            // fokussiert Element automatisch und erlaubt so die Verwendung der Pfeiltasten
            Focusable = true;
            Keyboard.Focus(this);
        }

        private void DekrementiereWert(object sender, RoutedEventArgs e)
        {
            if (Wert > Minimum)
            {
                Wert--;
            }
        }

        private void InkrementiereWert(object sender, RoutedEventArgs e)
        {
            if (Wert < Maximum)
            {
                Wert++;
            }
        }
    }
}
