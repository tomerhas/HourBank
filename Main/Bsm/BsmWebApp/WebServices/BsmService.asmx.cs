using BsmCommon.Interfaces.Managers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;


namespace BsmWebApp.WebServices
{
    /// <summary>
    /// Summary description for BsmService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BsmService : System.Web.Services.WebService
    {
        protected IUnityContainer _container;

        public BsmService(IUnityContainer container)
        {
            _container = container;

        }

        [WebMethod]
        public int GetOvedIdByName(string sName)
        {
            var manager = _container.Resolve<IBudgetManager>();
            var OvedId = manager.GetOvedIdByName(sName);

            return OvedId;// Json(OvedId, JsonRequestBehavior.AllowGet);
        }

        
        //public string GetOvedMisparIshi(string sName)
        //{
        //    string sMisparIshi = "";
    
        //    try
        //    {
        //        if (sName != string.Empty)
        //        {
        //            sMisparIshi = oOvdim.GetOvedMisparIshi(sName);
        //        }
        //        return sMisparIshi;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
