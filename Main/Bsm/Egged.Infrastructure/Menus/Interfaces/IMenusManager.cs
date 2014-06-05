using Egged.Infrastructure.Menus.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egged.Infrastructure.Menus.Interfaces
{
    public interface IMenusManager
    {
        void AddMenu(SingleMenu menu);
        List<SingleMenu> GetMenusForRole(string role = "");
    }
}
