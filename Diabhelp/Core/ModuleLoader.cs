using Diabhelp.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Core
{

    class ModuleLoader
    {
        // Get la liste des modules activés
        //TODO : Get ça depuis le catalogue.
        // (JSON ? AppData ?)
        //NOTE : pour le moment on prend le nom pour différencier les modules vu qu'il y en aura pas avec un nom identique
        // Si le module existe pas ça crash pas mais ça display des trucs chelou
        private ArrayList loadedModules = new ArrayList { "ModuleTest", "ModuleTest2"};
        private ArrayList availableModules = new ArrayList { "ModuleTest", "ModuleTest2", "ModuleTest3"};

        // GROS TODO PUTAIN SARACE : ModuleInfo qui demande pas d'instancier le module

        private List<IModule> createIModuleList(ArrayList toCreate)
        {
            List<IModule> moduleList = new List<IModule>();
            Debug.WriteLine("enter getLoadedModules");

            IModule module;

            // Instancie une classe par module loadé

            foreach (String name in toCreate)
            {
                Debug.WriteLine("Loading module : " + name);
                Type type = Type.GetType("Diabhelp.Modules." + name + "." + name);
                if (type != null)
                {
                    module = (IModule)Activator.CreateInstance(type);
                    moduleList.Add(module);
                }
                else /* DEBUG */
                {
                    Debug.WriteLine("Failed to load module : " + name);
                }
            }
            return moduleList;
        }

        // TODO pour ces 2 là : Classe ModuleInfo qui permet de get Name + Icone sans instancier tout le merdier
        public ArrayList getLoadedModulesInfo()
        {
            return loadedModules;
        }

        public ArrayList getAvailableModulesInfo()
        {
            return availableModules;
        }

        public List<IModule> getAvailableModules()
        {
            return createIModuleList(availableModules);
        }

        public List<IModule> getLoadedModules()
        {
            return createIModuleList(loadedModules);
        }

        public bool addModule(String name)
        {
            if (loadedModules.Contains(name) || !availableModules.Contains(name))
            {
                return false;
            }
            loadedModules.Add(name);
            loadedModules.Sort();
            return true;
        }

        public bool removeModule(String name)
        {

            if (!loadedModules.Contains(name))
            {
                return false;
            }
            loadedModules.Remove(name);
            loadedModules.Sort();
            return true;
        }
    }
}
