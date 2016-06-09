using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsmWebApp.ViewModels.Home
{
    public class HomeViewModel
    {
        public DateTime Today { get; set; }
        public string UserName { get; set; }
        public string Error { get; set; }
        public int SessionEnd { get; set; }
        public bool HasError 
        {
            get 
            {
                if (!string.IsNullOrWhiteSpace(Error))
                    return true;
                return false;
            }
        }

        public string ImgSrc { get; set; }
    }
}