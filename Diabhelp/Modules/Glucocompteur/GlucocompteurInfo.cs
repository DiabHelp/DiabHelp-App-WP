using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.Glucocompteur
{
    class GlucocompteurInfo : IModuleInfo
    {
        // Internal Variables
        private String name;
        private Uri iconSource;
        private Boolean loaded;

        public GlucocompteurInfo()
        {
            this.name = "Glucocompteur";
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
