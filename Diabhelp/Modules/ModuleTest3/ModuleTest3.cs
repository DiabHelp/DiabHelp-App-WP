using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Diabhelp.Modules.ModuleTest3
{
    /// <summary>
    /// Test Module loader class
    /// </summary>

    class ModuleTest3 : IModule
    {
        private Frame frame;
        private String name = "ModuleTest3";
        private Uri iconSource = null;
        public ModuleTest3()
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
            Debug.WriteLine("ModuleTest3 navigate");
            if (this.frame != null)
                this.frame.Navigate(typeof(ModuleTest3Page));
            else
                Debug.WriteLine("You fucked up : this.frame of ModuleTest3 is null");
            Debug.WriteLine("ModuleTest3 navigate OK");
        }

        public void start(Frame frame)
        {
            Debug.WriteLine("ModuleTest3 navigate 2nd function");
            if (frame != null)
                frame.Navigate(typeof(ModuleTest3Page));
            else
                Debug.WriteLine("You fucked up : this.frame of ModuleTest3 is null");
            Debug.WriteLine("ModuleTest3 navigate OK");
        }

        public void setFrame(Frame frame)
        {
            Debug.WriteLine("ModuleTest3 setFrame");
            if (frame == null)
                Debug.WriteLine("WTF : Tu me donne une frame nulle dans setFrame, ok, connard");
            this.frame = frame;
        }
    }
}
