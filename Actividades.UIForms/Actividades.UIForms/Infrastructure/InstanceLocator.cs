using Actividades.UIForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.UIForms.Infrastructure
{
    public class InstanceLocator
    {
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

        public MainViewModel Main { get; set; }
    }
}
