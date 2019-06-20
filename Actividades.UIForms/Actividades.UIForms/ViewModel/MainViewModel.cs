using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.UIForms.ViewModel
{
    public class MainViewModel 
    {
        private static MainViewModel _mainViewModel;



        public LoginViewModel Login { get; set; }


        public ActividadesViewModel Actividades { get; set; }

        public MainViewModel()
        {
            _mainViewModel = this;
        }

        public static MainViewModel GetInstance()
        {
            if (_mainViewModel == null)
                return new MainViewModel();

            return _mainViewModel;
        }

    }
}
