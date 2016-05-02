﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmCommon.Interfaces.Dal
{
    public interface IChangesDal
    {
        DataTable GetChangesShaotNosafot(int KodEzor, DateTime Month, int isuk, int KodMitkan);
        void AddTakzivLeMitkan(int p_mitkan, DateTime p_chodesh, int p_id_takziv, int p_kamut, string p_reason, int p_user);
        void AddNewTakziv(int p_id_takziv, string p_teur, int p_kamut, string p_reason, int p_user);

        void SaveChangeMitkan(int p_mitkan, DateTime p_chodesh, int p_erech, string p_reason, int p_user, int p_type);
        void SaveReductionMitkan(int p_mitkan, DateTime p_chodesh, int p_kamut, string p_reason, int p_user);
    }
}
