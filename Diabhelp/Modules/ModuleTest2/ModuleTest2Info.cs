using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.ModuleTest2
{
    class ModuleTest2Info : IModuleInfo
    {
        // Internal Variables
        private String name;
        private Uri iconSource;
        private Boolean loaded;

        public ModuleTest2Info()
        {
            this.name = "ModuleTest2";
            this.iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png"); // TODO : Setup l'iconSource correctement via API (?)
        }

        string IModuleInfo.Name
        {
            get
            {
                return name;
            }
        }

        Uri IModuleInfo.IconSource
        {
            get
            {
                return iconSource;
            }
        }

        Boolean IModuleInfo.Loaded
        {
            get
            {
                return loaded;
            }

            set
            {
                this.loaded = value;
            }
        }
    }
}
