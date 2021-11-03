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

        public static readonly DependencyProperty PunktAnzahlProperty =
            DependencyProperty.Register(nameof(Punkte), typeof(int), typeof(StatusBar), new PropertyMetadata(START_PUNKTE));

        public string Zeit
        {
            get => (string)GetValue(FrageProperty);
            set => SetValue(FrageProperty, value);
        }

        public static readonly DependencyProperty FrageProperty =
            DependencyProperty.Register(nameof(Zeit), typeof(string), typeof(StatusBar), new PropertyMetadata(START_ZEIT));
        #endregion

        public StatusBar()
        {
            InitializeComponent();

            zeitgeber = new DispatcherTimer(new TimeSpan(0, 0, 0, 1, 0),
                DispatcherPriority.Background, SetzeZeit, Dispatcher.CurrentDispatcher);

            startZeit = DateTime.Now;
            zeitgeber.Start();
        }

        private void SetzeZeit(object sender, EventArgs e)
            => Zeit = Convert.ToString(DateTime.Now - startZeit)[0..8];
    }
}
