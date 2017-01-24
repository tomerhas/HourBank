using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Dal
{
    public interface IChangesDal
    {
        DataTable GetChangesShaotNosafot(DateTime Month, int isuk, int KodMitkan);
        DataTable GetBudgetSpecial();
        void AddTakzivLeMitkan(int p_mitkan, DateTime p_chodesh, int p_id_takziv, float p_kamut, string p_reason, int p_user);
        void AddNewTakziv(int p_id_takziv, string p_teur, float p_kamut, string p_reason, int p_user);

        void SaveChangeMitkan(int p_mitkan_from, int p_mitkan_to, DateTime p_chodesh, float p_erech, string p_reason, int p_user);
        void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, float p_kamut, string p_reason, int p_user);
        DataTable GetHistory(int p_mitkan, DateTime p_chodesh);
        DataTable GetTakzivHistory(int kodTakziv);
    }
}
