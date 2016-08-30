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

    public class ModuleLoader
    {
        // Get la liste des modules activés
        //NOTE : pour le moment on prend le nom pour différencier les modules vu qu'il y en aura pas avec un nom identique
        // Si le module existe pas ça crash pas mais ça display des trucs chelou
        //private ArrayList loadedModules = new ArrayList { "ModuleTest", "ModuleTest2"};

        // Ca doit être get depuis l'API ça
        private List<String> availableModules = new List<String> { "Glucocompteur", "ModuleTest", "ModuleTest2", "ModuleTest3"}; //Id au lieu de nom ? Surement vu que l'api doit faire ca
        private List<String> loadedModules = null;
        bool moduleListChanged = false;

        Windows.Storage.ApplicationDataContainer localSettings;
        // Alors oui on fait un Singleton, mais en l'occurence c'est adapté
        private static ModuleLoader instance;

        private ModuleLoader()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["LoadedModules"] == null)
            {

                Debug.WriteLine("LoadedModule Settings null");
                loadedModules = new List<String>();
                //Used to generate defaults loaded modules
                //localSettings.Values["LoadedModules"] = new string[] { "ModuleTest", "ModuleTest2" };

            }
            else
                loadedModules = new List<String>(localSettings.Values["LoadedModules"] as string[]);
        }

        public static ModuleLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleLoader();
                }
                return instance;
            }
        }
        
        private List<IModuleInfo> createIModuleInfoList(List<String> toCreate)
        {
            List<IModuleInfo> moduleInfoList = new List<IModuleInfo>();

            IModuleInfo module;

            // Instancie une classe par module loadé

            foreach (String name in toCreate)
            {
                //Debug.WriteLine("Loading module Info: " + name);
                //String debug = "Diabhelp.Modules." + name + "." + name + "Info";
                //Debug.WriteLine("Test type = " + debug);
                Type type = Type.GetType("Diabhelp.Modules." + name + "." + name + "Info");
                if (type != null)
                {
                    module = (IModuleInfo)Activator.CreateInstance(type);
                    module.Loaded = loadedModules.Contains(module.Name);
                    moduleInfoList.Add(module);
                    
                }
                else /* DEBUG */
                {
                    Debug.WriteLine("Failed to load module Info : " + name);
                }
            }
            return moduleInfoList;
        }

        private List<IModule> createIModuleList(List<String> toCreate)
        {
            List<IModule> moduleList = new List<IModule>();

            IModule module;

            // Instancie une classe par module loadé

            foreach (String name in toCreate)
            {
                //Debug.WriteLine("Loading module : " + name);
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

        public List<IModuleInfo> getLoadedModulesInfo()
        {
            return createIModuleInfoList(loadedModules);
        }

        public List<IModuleInfo> getAvailableModulesInfo()
        {
            return createIModuleInfoList(availableModules);
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
            moduleListChanged = true;
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
            moduleListChanged = true;
            return true;
        }

        public void saveModuleList()
        {
            if (this.moduleListChanged == true)
            {
                string[] modules = (string[])loadedModules.ToArray();
                if (modules.Length > 0)
                    localSettings.Values["LoadedModules"] = modules;
                else
                    localSettings.Values["LoadedModules"] = null;
                moduleListChanged = false;
            }
           
        }
    }
}
