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
        //TODO : Screen size :  Classe publique globale OU ressource comme android si possible
        int ROW_SIZE = 3;

        private List<StackPanel> nestedPaneList;

        public ModulesScreen()
        {
            this.InitializeComponent();
        }


        /* // CLEANUP
        private void loadModules()
        {
            moduleList = new List<IModule>();
            Debug.WriteLine("enter LoadModule");

            // On ajoute les modules à la liste des modules


            // Get la liste des modules activés
            //TODO : Get ça depuis le catalogue.
            // (JSON ? AppData ?)
            String[] classNames = new string[] { "ModuleTest", "ModuleTest2", "ModuleTest3", "ModuleTest2", "ModuleTest2", "ModuleTest2", "ModuleTest2" };

            IModule module;

            // Instancie une classe par module loadé

            foreach (String name in classNames)
            {
                Debug.WriteLine("Loading module : " + name);
                Type type = Type.GetType("Diabhelp.Modules." + name + "." + name);
                if (type != null)
                {
                    module = (IModule)Activator.CreateInstance(type);
                    moduleList.Add(module);
                }
                else // DEBUG 
                {
                    Debug.WriteLine("Failed to load module : " + name);
                }
            }

            //displayModuleList();
        }
        */

        private void displayModuleList(List<IModule> moduleList)
        {
            if (nestedPaneList == null)
                nestedPaneList = new List<StackPanel>();
            Debug.WriteLine("enter displayModuleList");
            int size = moduleList.Count;
            int rows = (int)Math.Ceiling((decimal)size / ROW_SIZE);
            Debug.WriteLine("displayModuleList : calculated row size = " + rows);

            for (int n = 0; n < rows; n++)
            {
                StackPanel newPanel = new StackPanel();
                newPanel.Orientation = Orientation.Horizontal;
                nestedPaneList.Add(newPanel);
                Debug.WriteLine("displayModuleList : add stackpannel nb " + n);
            }
            if (moduleList != null && moduleList.Count > 0)
            {
                for (int i = 0; i < moduleList.Count; i++)
                {
                    IModule module = moduleList[i] as IModule;
                    Debug.WriteLine("enter foreach moduleList : ");
                    Debug.WriteLine(module.getName());

                    // Calcul de la position du ModuleLayout
                    int position = (int)Math.Ceiling((decimal)(i + 1) / ROW_SIZE) - 1;
                    Debug.WriteLine("ModuleLayout position : " + position);

                    // On crée l'objet graphique lié au module, et on lui donne sa classe et la frame principale
                    ModuleLayout view = new ModuleLayout(module);
                    nestedPaneList[position].Children.Add(view);
                    Debug.WriteLine("end foreach moduleList");

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
                Debug.WriteLine("ModuleScreen::displayModuleList");

                displayModuleList(moduleLoader.getLoadedModules());
            }
        }
    }
}