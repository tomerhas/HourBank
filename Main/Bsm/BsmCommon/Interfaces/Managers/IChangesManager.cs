using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Changes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Managers
{
    public interface IChangesManager
    {
        List<BudgetChange> GetBudgetChanges(int KodYechida, DateTime Month);
        List<BudgetSpecialYechida> GetExtensionsBudget(int KodYechida, DateTime Month);
        List<BudgetReduction> GetReductionsBudget(int KodYechida, DateTime Month);

        List<BudgetChangesGrid> GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan);
        List<BudgetSpecial> GetBudgetSpecial();

        void AddTakzivLeMitkan(int p_mitkan, DateTime p_chodesh, int p_id_takziv, decimal p_kamut, string p_reason, int p_user);

        void AddNewTakziv(int p_id_takziv, string p_teur, decimal p_kamut, string p_reason, int p_user);
        void SaveChangeMitkan(int p_mitkan, DateTime p_chodesh, decimal p_erech, string p_reason, int p_user, int p_type);
         void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, decimal p_kamut, string p_reason, int p_user);
        int GetNextTakzivNumber();


    }
}
