using Actividades.UIForms.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Actividades.UIForms.ViewModel
{
    public class LoginViewModel 
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);


        private async void Login()
        {
            if(string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Favor ingresa un correo electronico", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Favor ingresa una password", "Aceptar");
                return;
            }

            MainViewModel.GetInstance().Actividades = new ActividadesViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new ActividadesPage());

        }
    }
}
