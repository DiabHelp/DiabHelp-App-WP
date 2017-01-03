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

        public ModuleLayout(IModule module)
        {
            this.InitializeComponent();
            this.module = module;
            this.module.setFrame(Window.Current.Content as Frame);
            this.moduleName.Text = module.getDisplayName();
        }

        void Image_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage(this.module.getIconSource());
            this.moduleIcon.Source = bitmapImage;
        }

        void onImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
          Debug.WriteLine("Enter onImageFailed : " + e.ErrorMessage);
          BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/diab_logo_transparent.png"));
          this.moduleIcon.Source = bitmapImage;
        }


        private void launchModuleBtn_Click(object sender, RoutedEventArgs e)
        {
            module.start();
        }
    }
}
