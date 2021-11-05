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
            get => (int)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }

        private static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register(nameof(Wert), typeof(int), typeof(NumberSelector), new PropertyMetadata(0));

        public int Minimum
        {
            get => (int)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        private static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(int), typeof(NumberSelector), new PropertyMetadata(0));

        public int Maximum
        {
            get => (int)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        private static readonly DependencyProperty MaximumProperty =
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

            // damit der Fokus nicht auf dem gedrückten Button verbleibt und Shortcuts wie die ENTER-Taste wirken
            Keyboard.Focus(this); 
        }

        private void InkrementiereWert(object sender, RoutedEventArgs e)
        {
            if (Wert < Maximum)
            {
                Wert++;
            }

            // damit der Fokus nicht auf dem gedrückten Button verbleibt und Shortcuts wie die ENTER-Taste wirken
            Keyboard.Focus(this);
        }
    }
}
