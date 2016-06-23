using Diabhelp.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Diabhelp
{
    public sealed partial class ModuleLayout : UserControl
    {
        IModule module;

        public ModuleLayout(IModule module, Frame frame)
        {
            this.InitializeComponent();
            Debug.WriteLine("ModuleLayout init 2nd constructor");
            this.module = module;
            this.module.setFrame(frame);
            this.moduleName.Text = module.getName();
            Debug.WriteLine("ModuleLayout init 2nd constructor end");

        }

        public ModuleLayout(String name, Uri iconSource)
        {
            Debug.WriteLine("ModuleLayout init");
            this.InitializeComponent();
            this.moduleName.Text = name;
            //this.moduleIcon.Source = new BitmapImage(iconSource);
            Debug.WriteLine("ModuleLayout init ok");

        }

        private void launchModuleBtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("launchModuleBtn_Click ok");
            module.start();
        }
    }
}
