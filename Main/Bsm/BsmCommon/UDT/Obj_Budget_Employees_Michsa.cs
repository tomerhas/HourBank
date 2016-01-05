using BsmCommon.UDT;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BsmCommon.UDT
{
    using System;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Xml.Serialization;
    using System.Xml.Schema;
   // using System.Data.SqlTypes;
    
    
    public class OBJ_BUDGET_EMPLOYEES_MICHSA : INullable, IOracleCustomType, IXmlSerializable {
        
        private bool m_IsNull;
         
        private System.DateTime m_TAARICH_IDKUN;
        
        private bool m_TAARICH_IDKUNIsNull;
        
        private int m_MEADKEN;
        
        private bool m_MEADKENIsNull;
        
      
        private System.DateTime m_CHODESH;
        
        private bool m_CHODESHIsNull;
        
        private decimal m_MISPAR_ISHI;
        
        private bool m_MISPAR_ISHIIsNull;
        
        private decimal m_MICHSA;
        
        private bool m_MICHSAIsNull;
        
        public OBJ_BUDGET_EMPLOYEES_MICHSA() {
            // TODO : Add code to initialise the object
            this.m_TAARICH_IDKUNIsNull = true;
            this.m_MEADKENIsNull = true;
            this.m_CHODESHIsNull = true;
            this.m_MISPAR_ISHIIsNull = true;
            this.m_MICHSAIsNull = true;
        }
        
        public OBJ_BUDGET_EMPLOYEES_MICHSA(string str) {
            // TODO : Add code to initialise the object based on the given string 
        }
        
        public virtual bool IsNull {
            get {
                return this.m_IsNull;
            }
        }
        
        public static OBJ_BUDGET_EMPLOYEES_MICHSA Null {
            get {
                OBJ_BUDGET_EMPLOYEES_MICHSA obj = new OBJ_BUDGET_EMPLOYEES_MICHSA();
                obj.m_IsNull = true;
                return obj;
            }
        }
        
    
        
        [OracleObjectMappingAttribute("TAARICH_IDKUN")]
        public System.DateTime TAARICH_IDKUN {
            get {
                return this.m_TAARICH_IDKUN;
            }
            set {
                this.m_TAARICH_IDKUN = value;
                this.m_TAARICH_IDKUNIsNull = false;
            }
        }
        
        public bool TAARICH_IDKUNIsNull {
            get {
                return this.m_TAARICH_IDKUNIsNull;
            }
            set {
                this.m_TAARICH_IDKUNIsNull = value;
            }
        }
        
        [OracleObjectMappingAttribute("MEADKEN")]
        public int MEADKEN {
            get {
                return this.m_MEADKEN;
            }
            set {
                this.m_MEADKEN = value;
                this.m_MEADKENIsNull = false;
            }
        }
        
        public bool MEADKENIsNull {
            get {
                return this.m_MEADKENIsNull;
            }
            set {
                this.m_MEADKENIsNull = value;
                
            }
        }
        
      
        
        [OracleObjectMappingAttribute("CHODESH")]
        public System.DateTime CHODESH {
            get {
                return this.m_CHODESH;
            }
            set {
                this.m_CHODESH = value;
                this.m_CHODESHIsNull = false;
            }
        }
        
        public bool CHODESHIsNull {
            get {
                return this.m_CHODESHIsNull;
            }
            set {
                this.m_CHODESHIsNull = value;
               
            }
        }
        
        [OracleObjectMappingAttribute("MISPAR_ISHI")]
        public decimal MISPAR_ISHI {
            get {
                return this.m_MISPAR_ISHI;
            }
            set {
                this.m_MISPAR_ISHI = value;
                this.m_MISPAR_ISHIIsNull = false;
            }
        }
        
        public bool MISPAR_ISHIIsNull {
            get {
                return this.m_MISPAR_ISHIIsNull;
            }
            set {
                this.m_MISPAR_ISHIIsNull = value;
            
            }
        }
        
        [OracleObjectMappingAttribute("MICHSA")]
        public decimal MICHSA {
            get {
                return this.m_MICHSA;
            }
            set {
                this.m_MICHSA = value;
                this.m_MICHSAIsNull = false;
            }
        }
        
        public bool MICHSAIsNull {
            get {
                return this.m_MICHSAIsNull;
            }
            set {
                this.m_MICHSAIsNull = value;
               
            }
        }
        
        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt) {
           
            if ((TAARICH_IDKUNIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "TAARICH_IDKUN", this.TAARICH_IDKUN);
            }
            if ((MEADKENIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "MEADKEN", this.MEADKEN);
            }
           
            if ((CHODESHIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "CHODESH", this.CHODESH);
            }
            if ((MISPAR_ISHIIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "MISPAR_ISHI", this.MISPAR_ISHI);
            }
            if ((MICHSAIsNull == false)) {
                Oracle.DataAccess.Types.OracleUdt.SetValue(con, pUdt, "MICHSA", this.MICHSA);
            }
        }
        
        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt) {
           
            this.TAARICH_IDKUNIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "TAARICH_IDKUN");
            if ((TAARICH_IDKUNIsNull == false)) {
                this.TAARICH_IDKUN = ((System.DateTime)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "TAARICH_IDKUN")));
            }
            this.MEADKENIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "MEADKEN");
            if ((MEADKENIsNull == false)) {
                this.MEADKEN = ((int)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "MEADKEN")));
            }
            
            this.CHODESHIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "CHODESH");
            if ((CHODESHIsNull == false)) {
                this.CHODESH = ((System.DateTime)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "CHODESH")));
            }
            this.MISPAR_ISHIIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "MISPAR_ISHI");
            if ((MISPAR_ISHIIsNull == false)) {
                this.MISPAR_ISHI = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "MISPAR_ISHI")));
            }
            this.MICHSAIsNull = Oracle.DataAccess.Types.OracleUdt.IsDBNull(con, pUdt, "MICHSA");
            if ((MICHSAIsNull == false)) {
                this.MICHSA = ((decimal)(Oracle.DataAccess.Types.OracleUdt.GetValue(con, pUdt, "MICHSA")));
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader) {
            // TODO : Read Serialized Xml Data
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer) {
            // TODO : Serialize object to xml data
        }
        
        public virtual XmlSchema GetSchema() {
            // TODO : Implement GetSchema
            return null;
        }
        
        public override string ToString() {
            // TODO : Return a string that represents the current object
            return "";
        }
        
        public static OBJ_BUDGET_EMPLOYEES_MICHSA Parse(string str) {
            // TODO : Add code needed to parse the string and get the object represented by the string
            return new OBJ_BUDGET_EMPLOYEES_MICHSA();
        }
    }
    
    // Factory to create an object for the above class
    [OracleCustomTypeMappingAttribute("HOUR_BANK.OBJ_BUDGET_EMPLOYEES_MICHSA")]
    public class OBJ_BUDGET_EMPLOYEES_MICHSAFactory : IOracleCustomTypeFactory {
        
        public virtual IOracleCustomType CreateObject() {
            OBJ_BUDGET_EMPLOYEES_MICHSA obj = new OBJ_BUDGET_EMPLOYEES_MICHSA();
            return obj;
        }
    }
}
