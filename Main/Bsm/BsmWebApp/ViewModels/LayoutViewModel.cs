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

        public LayoutViewModel(List<SingleMenu> menus)
        {
            Menus = menus;
        }
    }
}