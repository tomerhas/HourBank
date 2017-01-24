﻿using BsmCommon.DataModels.Budgets;
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

        List<BudgetChangesGrid> GetChangesShaotNosafot(DateTime Month, int isuk, int KodMitkan);
        List<BudgetSpecial> GetBudgetSpecial();

        void AddTakzivLeMitkan(int p_mitkan, DateTime p_chodesh, int p_id_takziv, float p_kamut, string p_reason, int p_user);

        void AddNewTakziv(int p_id_takziv, string p_teur, float p_kamut, string p_reason, int p_user);
        void SaveChangeMitkan(int p_mitkan_from, int p_mitkan_to, DateTime p_chodesh, float p_erech, string p_reason, int p_user);
        void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, float p_kamut, string p_reason, int p_user);
        int GetNextTakzivNumber();
        List<ChangeHistoryGrid> GetHistory(int p_mitkan, DateTime p_chodesh);
        bool IsYechidaBetokef(int kodYechida, DateTime month);
        List<BudgetSpecialYechida> GetTakzivHistory(int kodTakziv);

    }
}
