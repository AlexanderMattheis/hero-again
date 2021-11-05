using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Hero.Controls
{
    /// <summary>
    /// Interaktionslogik für StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        private const string START_ZEIT = "00:00:00";
        private const int START_PUNKTE = 0;

        private static DispatcherTimer zeitgeber;
        private DateTime startZeit;

        #region Events
        public int Punkte
        {
            get => (int)GetValue(PunktAnzahlProperty);
            set => SetValue(PunktAnzahlProperty, value);
        }

        private static readonly DependencyProperty PunktAnzahlProperty =
            DependencyProperty.Register(nameof(Punkte), typeof(int), typeof(StatusBar), new PropertyMetadata(START_PUNKTE));

        private string Zeit
        {
            get => (string)GetValue(FrageProperty);
            set => SetValue(FrageProperty, value);
        }

        private static readonly DependencyProperty FrageProperty =
            DependencyProperty.Register(nameof(Zeit), typeof(string), typeof(StatusBar), new PropertyMetadata(START_ZEIT));

        public int Minuten
        {
            get => (int)GetValue(MinutenProperty);
            set => SetValue(MinutenProperty, value);
        }

        public static readonly DependencyProperty MinutenProperty =
            DependencyProperty.Register(nameof(Minuten), typeof(int), typeof(StatusBar), new PropertyMetadata(0));
        #endregion

        public StatusBar()
        {
            InitializeComponent();
            Loaded += Geladen; // damit erst nach Platzierung und Initialisierung beginnt
        }

        public void Geladen(object sender, EventArgs e)
        {
            zeitgeber = new DispatcherTimer(new TimeSpan(0, 0, 0, 1, 0),
                DispatcherPriority.Background, SetzeZeit, Dispatcher.CurrentDispatcher);

            startZeit = DateTime.Now.AddMinutes(Minuten);
            zeitgeber.Start();
        }

        private void SetzeZeit(object sender, EventArgs e)
            => Zeit = Convert.ToString(startZeit - DateTime.Now)[0..8];
    }
}
