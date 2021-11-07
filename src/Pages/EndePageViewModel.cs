namespace Hero.Pages
{
    public class EndePageViewModel : ViewModel
    {
        private int punkte;

        public int Punkte
        {
            get => this.punkte;
            set
            {
                this.punkte = value;
                FeurePropertyChanged();
            }
        }

        public string FinalePunktzahlString { get; }
        public string NeustartString { get; }
        public string VerlassenString { get; }

        public EndePageViewModel()
        {
            Punkte = 0;

            FinalePunktzahlString = Strings.FinalePunktzahl;
            NeustartString = Strings.Neustart;
            VerlassenString = Strings.Verlassen;
        }
    }
}