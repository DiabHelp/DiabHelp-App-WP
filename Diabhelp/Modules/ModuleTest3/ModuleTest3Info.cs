﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.ModuleTest3
{
    class ModuleTest3Info : IModuleInfo
    {
        // Internal Variables
        private String name;
        private Uri iconSource;
        private Boolean loaded;

        public ModuleTest3Info()
        {
            this.name = "ModuleTest3";
            this.iconSource = new Uri("ms-appx:///Assets/diab_logo_transparent.png");
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