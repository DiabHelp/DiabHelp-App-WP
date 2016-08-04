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
            Debug.WriteLine("ModuleTest init");
            iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png");
            Debug.WriteLine("ModuleTest init ok");
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
            Debug.WriteLine("ModuleTest navigate");
            if (this.frame != null)
                this.frame.Navigate(typeof(GlucocompteurMainScreen));
            else
                Debug.WriteLine("You fucked up : this.frame of ModuleTest is null");
            Debug.WriteLine("ModuleTest navigate OK");
        }

        public void setFrame(Frame frame)
        {
            Debug.WriteLine("ModuleTest setFrame");
            if (frame == null)
                Debug.WriteLine("WTF : Tu me donne une frame nulle dans setFrame, ok, connard");
            this.frame = frame;
        }
    }
}
