using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prodfy.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetProperty<T>(ref T storege, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storege, value))
                return;

            storege = value;
            OnPropertyChanged(propertyName);
        }

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public BaseViewModel(string title)
        {
            Title = title;
        }
    }
}
