using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Diabhelp.Modules.Glucocompteur
{
    class Glucocompteur : IModule
    {
        private Frame frame;
        private String name = "Glucocompteur";
        private Uri iconSource = null;
        public Glucocompteur()
        {
            iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png");
        }


        public string getName()
        {
            return name;
        }

        public Uri getIconSource()
        {
            return iconSource;
        }

        public void start()
        {
            if (this.frame != null)
                this.frame.Navigate(typeof(GlucocompteurMainScreen));
        }

        public void setFrame(Frame frame)
        {
            this.frame = frame;
        }
    }
}
