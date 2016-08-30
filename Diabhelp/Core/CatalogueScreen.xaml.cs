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

namespace Diabhelp.Core
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatalogueScreen : Page
    {
         //TODO : Screen size : Classe publique globale OU ressource comme android si possible
        int ROW_SIZE = 3;

        private List<StackPanel> nestedPaneList;
        private List<IModule> moduleList;

        Frame mainScreenFrame;

        public CatalogueScreen()
        {
            this.InitializeComponent();
        }

        private void displayModuleList(List<IModuleInfo> moduleList)
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
                    IModuleInfo module = moduleList[i] as IModuleInfo;

                    // Calcul de la position du ModuleLayout
                    int position = (int)Math.Ceiling((decimal)(i + 1) / ROW_SIZE) - 1;

                    // On crée l'objet graphique lié au module, et on lui donne sa classe
                    CatalogueModuleLayout view = new CatalogueModuleLayout(module);

                    // On cable les events de la checkbox (Qu'on a passé en public dans le XAML avec x:FieldModifier="public") au add/remove du ModuleLoader
                    view.activateCheckBox.Checked += (sender, e) => ModuleLoader.Instance.addModule(module.Name) ;
                    view.activateCheckBox.Unchecked+= (sender, e) => ModuleLoader.Instance.removeModule(module.Name);
                    view.activateCheckBox.IsChecked = module.Loaded;
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
            Debug.WriteLine("Catalogue::OnNavigatedTo");

            base.OnNavigatedFrom(e);

            displayModuleList(ModuleLoader.Instance.getAvailableModulesInfo());
        }
    }
}
