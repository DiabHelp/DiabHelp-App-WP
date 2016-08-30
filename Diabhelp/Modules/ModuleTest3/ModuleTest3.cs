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
                this.frame.Navigate(typeof(ModuleTest3Page));
        }

        public void start(Frame frame)
        {
            if (frame != null)
                frame.Navigate(typeof(ModuleTest3Page));
        }

        public void setFrame(Frame frame)
        {
            this.frame = frame;
        }
    }
}
