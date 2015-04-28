using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrismDataTemplateExample.Models
{
    public class DataBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChangedAuto([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}