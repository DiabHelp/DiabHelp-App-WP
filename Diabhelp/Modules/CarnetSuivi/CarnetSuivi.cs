using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Diabhelp.Modules.CarnetSuivi
{
    class CarnetSuivi : IModule
    {
        private Frame frame;
        private String name = "CarnetSuivi";
        private String displayName = "Carnet de Suivi";
        private Uri iconSource = null;
        public CarnetSuivi()
        {
            iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png");
        }


        public string getName()
        {
            return name;
        }

        public string getDisplayName()
        {
            return displayName;
        }

        public Uri getIconSource()
        {
            return iconSource;
        }

        public void start()
        {
            if (this.frame != null)
                this.frame.Navigate(typeof(CarnetSuiviMainScreen));
        }

        public void setFrame(Frame frame)
        {
            this.frame = frame;
        }
    }
}
