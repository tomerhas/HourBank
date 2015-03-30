using BsmBL.DAL;
using BsmCommon.DataModels;
using BsmCommon.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.Managers
{
    public class GeneralManager : IGeneralManager
    {
        public List<Ezor> GetEzors()
        {
           
            List<Ezor> list = new List<Ezor>();
            using (var context = new KdsEntities())
            {
                //עודד - להוציא דיסטינקתים של אזורים
                var  zz = context.Ezors.Select(p =>  new { p.KOD_EZOR, p.TEUR_EZOR }).Distinct().ToList();//context.Ezors.GroupBy(p => new { p.KOD_EZOR, p.TEUR_EZOR }).Distinct().ToList();
                list = context.Ezors.ToList();
               return list;
            
            }
        }
    }
}
