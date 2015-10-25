using Egged.Infrastructure.Menus.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels
{
    public class LayoutViewModel
    {
        public List<SingleMenu> Menus { get; set; }
        public string Username { get; set; }

        public LayoutViewModel()
        {

        }

        public LayoutViewModel(List<SingleMenu> menus)
        {
            Menus = menus;
        }
    }
}