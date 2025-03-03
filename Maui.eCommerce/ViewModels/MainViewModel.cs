using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerce.ViewModels
{
    public class MainViewModel
    {
        //TO BIND TO FRONT END, HAVE A PROPERTY THAT IS ACCESSIBLE. YOU CAN'T BIND SOMETHING NOT A PROPERTY. 
        //XAML SCRIPT "{BINDING DISPLAY}" SAYS GO TO BINDING CONTEXT OF THIS VIEW, FIND A PROPERTY NAMED DISPLAY.
        public string Display
        {
            get
            {
                return "Hello, World!";
            }
        }
    }
}
