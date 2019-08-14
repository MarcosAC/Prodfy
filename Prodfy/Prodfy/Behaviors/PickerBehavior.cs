using System;
using Xamarin.Forms;

namespace Prodfy.Behaviors
{
    public class PickerBehavior : Behavior<Picker>
    {
        public static readonly BindableProperty PickerSelecionadoProperty =
            BindableProperty.Create(
            propertyName: "PickerSelecionado",
            returnType: typeof(string),
            declaringType: typeof(PickerBehavior),
            defaultValue: null,
            propertyChanged: PickerSelecionadoPropertyChanged
            );

        public string PickerSelecionado
        {
            get { return (string)GetValue(PickerSelecionadoProperty); }
            set { SetValue(PickerSelecionadoProperty, value); }
        }

        private static void PickerSelecionadoPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (PickerBehavior)bindable;
            behavior.PickerSelecionado = (string)newValue;
        }

        protected override void OnAttachedTo(Picker picker)
        {
            picker.Focused += OnPickerClicked;
            base.OnAttachedTo(picker);
        }

        protected override void OnDetachingFrom(Picker picker)
        {
            picker.Focused -= OnPickerClicked;
            base.OnDetachingFrom(picker);
        }

        private void OnPickerClicked(object sender, FocusEventArgs args)
        {
            Picker pickerSelecionado = ((Picker)sender);

            if (pickerSelecionado == ((Picker)sender).FindByName("PickerLote"))
            {
                var pickerPontoControle = ((Picker)sender).FindByName("PickerPontoControle");
                
                if (pickerPontoControle == ((Picker)sender).FindByName("PickerPontoControle"))
                    ((Picker)sender).IsEnabled = false;                
            }

            if (pickerSelecionado == ((Picker)sender).FindByName("PickerPontoControle"))
            {
                if (((Picker)sender).ItemsSource == null)
                {
                    ((Picker)sender).IsEnabled = false;
                    App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um LOTE para gerar a lista de PONTOS DE CONTROLE", "Ok");                    
                }
                else
                {
                    var pickerEstagio = ((Picker)sender).FindByName("PickerEstagio");
                    if (pickerEstagio == ((Picker)sender).FindByName("PickerEstagio"))
                        ((Picker)sender).IsEnabled = true;
                }                
            }

            if (pickerSelecionado == ((Picker)sender).FindByName("PickerEstagio"))
            {
                if (((Picker)sender).ItemsSource == null)
                {
                    ((Picker)sender).IsEnabled = false;
                    App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um PONTO DE CONTROLE para gerar a lista de ESTÁGIOS", "Ok");
                }                    
            }

            


            //if (((Picker)sender).ItemsSource == null)
            //{
            //    if (pickerSelecionado.Equals(((Picker)sender).FindByName("PickerPontoControle")))
            //    {
            //        ((Picker)sender).IsEnabled = false;
            //        App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um LOTE para gerar a lista de PONTOS DE CONTROLE", "Ok");
            //    }

            //    if (pickerSelecionado.Equals(((Picker)sender).FindByName("PickerEstagio")))
            //    {
            //        ((Picker)sender).IsEnabled = false;
            //        App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um PONTO DE CONTROLE para gerar a lista de ESTÁGIOS", "Ok");
            //    }
            //}
        }
    }    
}


//if (pickerSelecionado.Equals(((Picker)sender).FindByName("pontocontrole")))
//{
//    //((Picker)sender).IsEnabled = false;
//    App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um LOTE para gerar a lista de PONTOS DE CONTROLE", "Ok");
//    ((Picker)sender).Unfocus();
//}

//if (pickerSelecionado.Equals(((Picker)sender).FindByName("estagio")))
//{
//    //((Picker)sender).IsEnabled = false;
//    App.Current.MainPage.DisplayAlert("ALERTA", "Selecione um PONTO DE CONTROLE para gerar a lista de ESTÁGIOS", "Ok");
//}