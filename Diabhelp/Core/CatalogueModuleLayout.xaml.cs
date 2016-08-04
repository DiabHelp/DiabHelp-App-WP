using Diabhelp.Modules;
using System;
using System.Collections;
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

namespace Diabhelp.Core
{
    public sealed partial class CatalogueModuleLayout : UserControl
    {

        IModuleInfo module;
      public CatalogueModuleLayout(IModuleInfo module)
        {
            this.InitializeComponent();
            Debug.WriteLine("CatalogueLayout : ModuleLayout init 2nd constructor");
            this.module = module;
            this.moduleName.Text = module.Name;
            Debug.WriteLine("CatalogueLayout : ModuleLayout init 2nd constructor end");

        }

        void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("CatalogueLayout : Enter Image loaded");
            BitmapImage bitmapImage = new BitmapImage(this.module.IconSource);
            this.moduleIcon.Source = bitmapImage;
            Debug.WriteLine("End Image loaded");

        }

        void onImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Debug.WriteLine("CatalogueLayout : Enter onImageFailed : " + e.ErrorMessage);
            BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/diab_logo_transparent.png"));
            this.moduleIcon.Source = bitmapImage;
            Debug.WriteLine("CatalogueLayout : End onImagedFailed");
        }

        private void activateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("CatalogueModuleLayout::ActivateCheckBox_Checked");
        }
    }
}
