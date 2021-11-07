namespace Hero.Pages
{
    public class StartPageViewModel : ViewModel
    {
        private const int START_MINUTEN = 30;

        private int minuten;

        public int Minuten
        {
            get => this.minuten;
            set
            {
                this.minuten = value;
                FeurePropertyChanged();
            }
        }

        public string MinutenString { get; }

        public StartPageViewModel()
        {
            Minuten = START_MINUTEN;
            MinutenString = Strings.Minuten;
        }
    }
}
