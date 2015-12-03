using BsmCommon.DataModels;
using Egged.Infrastructure.Menus.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsmWebApp.ViewModels
{
    public class LayoutViewModel
    {
        public List<SingleMenu> Menus { get; set; }
        public string Username { get; set; }
      //  public int NumYechidot { get; set; }
     //   public string MitkanName { get; set; }
        public Yechida MitkanName { get; set; }
        public SelectList Yechidot { get; set; }
        public string LastDateCalc { get; set; }

        public LayoutViewModel()
        {

        }

        public LayoutViewModel(List<SingleMenu> menus)
        {
            Menus = menus;
        }


    }
}