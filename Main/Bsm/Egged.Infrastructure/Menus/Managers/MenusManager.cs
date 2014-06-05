using Egged.Infrastructure.Menus.DataModels;
using Egged.Infrastructure.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egged.Infrastructure.Menus.Managers
{
    public class MenusManager : IMenusManager
    {
        private List<SingleMenu> _menuList;

        public MenusManager()
        {
            _menuList = new List<SingleMenu>();
        }
        public void AddMenu(SingleMenu menu)
        {
            _menuList.Add(menu);
        }

        public List<SingleMenu> GetMenusForRole(string role = "")
        {
            if (string.IsNullOrWhiteSpace(role))
                return _menuList.Where(menu => menu.ForRoles.Count() == 0).ToList();
            else
                return _menuList.Where(menu => menu.ForRoles.Contains(role)).ToList();
        }
    }
}
