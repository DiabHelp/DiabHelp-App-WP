using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Diabhelp.Modules
{
    /// <summary>
    /// Module Interface class
    /// </summary>
    public interface IModule
    {
        void start();
        String getName();
        String getDisplayName();
        Uri getIconSource();
        void setFrame(Frame frame);

    }
}
