using Prodfy.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prodfy.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string title = string.Empty;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected INavigationService NavigationService { get; set; }
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
    }
}
