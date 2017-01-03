using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabhelp.Modules
{
    /// <summary>
    /// Module Info Interface class
    /// </summary>
    public interface IModuleInfo
    {
        String Name { get;}
        String DisplayName { get;}
        Uri IconSource { get; }
        Boolean Loaded { get; set; }
    }
}
