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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp
{
    /// <summary>
    /// Module Screen page
    /// </summary>

    public sealed partial class ModulesScreen : Page
    {
        private ArrayList moduleList;
        private Frame rootFrame;
        public ModulesScreen()
        {
            this.InitializeComponent();
            rootFrame = (Frame)Window.Current.Content;
            loadModules();
        }

        private void loadModules()
        {
            moduleList = new ArrayList();
            Debug.WriteLine("enter LoadModule");

            moduleList.Add(new Modules.ModuleTest.ModuleTest());
            displayModuleList();
        }

        private void displayModuleList()
        {
            Debug.WriteLine("enter displayModuleList");
            if (moduleList != null  && moduleList.Count > 0)
            {
                foreach (IModule module in moduleList)
                {
                    Debug.WriteLine("enter foreach moduleList : ");
                    Debug.WriteLine(module.getName());
                    ModuleLayout view = new ModuleLayout(module, rootFrame);
                    modulesGrid.Children.Add(view);
                }
            }
        }
    }
}
