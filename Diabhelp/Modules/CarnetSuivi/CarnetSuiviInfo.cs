using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.CarnetSuivi
{
    class CarnetSuiviInfo : IModuleInfo
    {
        // Internal Variables
        private String name;
        private String displayName;
        private Uri iconSource;
        private Boolean loaded;

        public CarnetSuiviInfo()
        {
            this.name = "CarnetSuivi";
            this.displayName = "Carnet de Suivi";
            this.iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png");
        }

        string IModuleInfo.Name
        {
            get
            {
                return name;
            }
        }

        string IModuleInfo.DisplayName
        {
            get
            {
                return displayName;
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
