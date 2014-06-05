using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egged.Infrastructure.Menus.DataModels
{
    public class SingleMenu
    {
        public SingleMenu()
        {
            ForRoles = new List<string>();
        }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public List<string> ForRoles { get; set; }
    }
}
