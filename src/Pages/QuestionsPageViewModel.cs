using static Hero.Pages.QuestionPageHelper.FragenLoader;

namespace Hero.Pages
{
    public class QuestionPageViewModel : ViewModel
    {
        private const int START_PUNKTE = 0;
        private const int START_MINUTEN = 30;

        private Frage frage;
        private int punkte;
        private int minuten;

        public Frage Frage
        {
            get => this.frage;
            set
            {
                this.frage = value;
                FeurePropertyChanged();
            }
        }

        public int Punkte
        {
            get => this.punkte;
            set
            {
                this.punkte = value;
                FeurePropertyChanged();
            }
        }

        public int Minuten
        {
            get => this.minuten;
            set
            {
                this.minuten = value;
                FeurePropertyChanged();
            }
        }

        public QuestionPageViewModel()
        {
            Frage = new Frage
            (
                Strings.StandardFrage,
                Strings.StandardOption,
                Strings.StandardOption,
                Strings.StandardOption,
                Strings.StandardOption,
                -1
            );

            Punkte = START_PUNKTE;
            Minuten = START_MINUTEN;
        }
    }
}
