using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Diabhelp.Modules.ModuleTest
{
    /// <summary>
    /// Test Module loader class
    /// </summary>

    class ModuleTest : IModule
    {
        private Frame frame;
        private String name = "ModuleTest";
        private Uri iconSource = null;
        public ModuleTest()
        {
            Debug.WriteLine("ModuleTest init");
            //iconSource = new Uri("Assets/diab_logo_max.png");
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
                this.frame.Navigate(typeof(ModuleTestPage));
            else
                Debug.WriteLine("You fucked up : this.frame of ModuleTest is null");
            Debug.WriteLine("ModuleTest navigate OK");
        }

        public void start(Frame frame)
        {
            Debug.WriteLine("ModuleTest navigate 2nd function");
            if (frame != null)
                frame.Navigate(typeof(ModuleTestPage));
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
