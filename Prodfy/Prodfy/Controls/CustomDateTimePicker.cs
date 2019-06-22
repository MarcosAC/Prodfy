using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Prodfy.Controls
{
    public class CustomDateTimePicker : Entry, INotifyPropertyChanged
    {
        public DatePicker _datePicker { get; private set; } = new DatePicker() { MinimumDate = DateTime.Today, IsVisible = false };
        public TimePicker _timePicker { get; private set; } = new TimePicker() { IsVisible = false };

        string _stringFormat { get; set; }

        public string StringFormat
        {
            get => _stringFormat ?? "dd/MM/yyyy HH:mm";
            set => _stringFormat = value;
        }

        public DateTime DateTime
        {
            get => (DateTime)GetValue(DateTimeProperty);
            set
            {
                SetValue(DateTimeProperty, value);
                OnPropertyChanged("DateTime");
            }
        }

        private TimeSpan _time
        {
            get => TimeSpan.FromTicks(DateTime.Ticks);
            set => DateTime = new DateTime(DateTime.Date.Ticks).AddTicks(value.Ticks);
        }

        private DateTime _date
        {
            get => DateTime.Date;
            set => DateTime = new DateTime(DateTime.TimeOfDay.Ticks).AddTicks(value.Ticks);
        }

        BindableProperty DateTimeProperty = 
            BindableProperty.Create(
                "DateTime", 
                typeof(DateTime), 
                typeof(CustomDateTimePicker), 
                DateTime.Now, 
                BindingMode.TwoWay, 
                propertyChanged: DTPropertyChanged
            );        

        public CustomDateTimePicker()
        {
            BindingContext = this;
#pragma warning disable CS0612 // O tipo ou membro é obsoleto
            _datePicker.SetBinding<CustomDateTimePicker>(DatePicker.DateProperty, p => p._date);
#pragma warning restore CS0612 // O tipo ou membro é obsoleto

#pragma warning disable CS0612 // O tipo ou membro é obsoleto
            _timePicker.SetBinding<CustomDateTimePicker>(TimePicker.TimeProperty, p => p._time);
#pragma warning restore CS0612 // O tipo ou membro é obsoleto

            _timePicker.Unfocused += (sender, args) => _time = _timePicker.Time;
            _datePicker.Focused += (s, a) => UpdateEntryText();

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => _datePicker.Focus())
            });
            Focused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() => _datePicker.Focus());
            };
            _datePicker.Unfocused += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _timePicker.Focus();
                    _date = _datePicker.Date;
                    UpdateEntryText();
                });
            };
        }

        private void UpdateEntryText()
        {
            Text = DateTime.ToString(StringFormat);
        }

        static void DTPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var timePicker = (bindable as CustomDateTimePicker);
            timePicker.UpdateEntryText();
        }
    }
}
