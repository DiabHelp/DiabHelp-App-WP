﻿using Diabhelp.Modules;
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




namespace Diabhelp.Core
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModulesScreen : Page
    {
        int ROW_SIZE = 3;

        private List<StackPanel> nestedPaneList;

        public ModulesScreen()
        {
            this.InitializeComponent();
        }

        private void displayModuleList(List<IModule> moduleList)
        {
            if (nestedPaneList == null)
                nestedPaneList = new List<StackPanel>();
            int size = moduleList.Count;
            int rows = (int)Math.Ceiling((decimal)size / ROW_SIZE);


            for (int n = 0; n < rows; n++)
            {
                StackPanel newPanel = new StackPanel();
                newPanel.Orientation = Orientation.Horizontal;
                nestedPaneList.Add(newPanel);
            }
            if (moduleList != null && moduleList.Count > 0)
            {
                for (int i = 0; i < moduleList.Count; i++)
                {
                    IModule module = moduleList[i] as IModule;

                    // Calcul de la position du ModuleLayout
                    int position = (int)Math.Ceiling((decimal)(i + 1) / ROW_SIZE) - 1;

                    // On crée l'objet graphique lié au module, et on lui donne sa classe
                    ModuleLayout view = new ModuleLayout(module);
                    nestedPaneList[position].Children.Add(view);
                }
            }
            foreach (StackPanel subPanel in nestedPaneList)
            {
                modulesPanel.Children.Add(subPanel);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("ModuleScreen::OnNavigatedTo");
            ModuleLoader moduleLoader = e.Parameter as ModuleLoader;
            if (moduleLoader != null)
            {
                // Ici c'est ok d'instancier le module vu que c'est pour launch
                displayModuleList(moduleLoader.getLoadedModules());
            }
        }
    }
}
