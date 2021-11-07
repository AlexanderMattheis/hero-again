using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hero
{
    public class ViewModel : INotifyPropertyChanged // erlaubt Benachrichtigung bzgl. Änderungen einer Eigenschaft
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void FeurePropertyChanged([CallerMemberName] string propertyName = "") // Name der Property wird übergeben, sofern leer
        {
            // was sich ändert (auch die darauf aufbauenden Eigenschaften müssen mit PropertyChanged aufgerufen werden)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
