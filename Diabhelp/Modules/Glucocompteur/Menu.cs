using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules.Glucocompteur
{
    public class Menu
    {
        public ObservableCollection<Aliment> menuContent;
        public String menuName;

        public Menu(String name, ObservableCollection<Aliment> content)
        {
            this.menuContent = content;
            this.menuName = name;
            if (String.IsNullOrWhiteSpace(this.menuName))
            {
                this.menuName = "Indéfini";
            }
        }
    }
}
