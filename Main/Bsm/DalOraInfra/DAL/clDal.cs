﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using System.Configuration; 
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client; 
//using Oracle.DataAccess.Client; 
//using Oracle.DataAccess.Types;


namespace DalOraInfra.DAL
{
    public enum ParameterType
    {      
        ntOracleRefCursor = OracleDbType.RefCursor,
        ntOracleVarchar = OracleDbType.Varchar2,
        ntOracleChar = OracleDbType.Char,
        ntOracleLong = OracleDbType.Long,
        ntOracleInteger = OracleDbType.Int32,
        ntOracleDate = OracleDbType.Date,
        ntOracleInt64 = OracleDbType.Int64,
        ntOracleDecimal = OracleDbType.Decimal,    
        //ntOracleObject = OracleDbType.Object,
        //ntOracleArray = OracleDbType.Array,
        ntOracleClob =  OracleDbType.Clob,
        ntOracleBlob = OracleDbType.Blob
    }

    public enum ParameterDir
    {
        pdInput = ParameterDirection.Input,
        pdOutput = ParameterDirection.Output,
        pdInputOutput = ParameterDirection.InputOutput,
        pdReturnValue = ParameterDirection.ReturnValue
    }

    public class clDal : IDisposable
    {

        private string strConnectionString = (string)ConfigurationSettings.AppSettings["BSM_CONNECTION"];

    private OracleConnection conn;// = new OracleConnection(strConnectionString); 
    private OracleCommand cmd = new OracleCommand();
    private int _ArrayBindCount=0;
    
    private void Open() 
    {    
        try {
            if (conn == null || conn.State == ConnectionState.Closed)
            { conn = new OracleConnection(strConnectionString); }

            conn.Open(); 
        } 
        catch (Exception ex) {
            throw ex;
        } 
    } 
    
    private void Close() 
    {
        try
        {            
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;     
        }        
    } 
    
    private void CreateCommand(string cmdText, CommandType cmdType) 
    { 
       cmd.CommandText = cmdText; 
       cmd.CommandType = cmdType; 
    } 
    
    public void ClearCommand() 
    { 
      cmd.Parameters.Clear(); 
    } 
    
          
    public void AddParameter(string paramName, ParameterType paramType, object paramVal,
                             ParameterDir paramDirection)
    {
        OracleParameter param = default(OracleParameter);
        try
        {
            if ((paramVal == null))
            {
                paramVal = DBNull.Value;
            }
            else
            {

                if ((paramVal.ToString().Equals("")))
                {
                    paramVal = DBNull.Value;
                }
            }

            param = new OracleParameter(paramName, (OracleDbType)paramType, paramVal, (ParameterDirection)paramDirection);            
            cmd.Parameters.Add(param);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void AddParameter(string paramName, ParameterType paramType, object paramVal,
                             ParameterDir paramDirection, int paramSize)
    {
        try
        {
            OracleParameter param = default(OracleParameter);
            if ((paramVal == null))
            {
                paramVal = DBNull.Value;
            }
            else
            {

                if ((paramVal.ToString().Equals("")))
                {
                    paramVal = DBNull.Value;
                }
            }

            param = new OracleParameter(paramName, (OracleDbType)paramType, paramSize, paramVal, (ParameterDirection)paramDirection);            
            cmd.Parameters.Add(param);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void AddParameter(string paramName, ParameterType paramType, object paramVal,
                                ParameterDir paramDirection,  string paramUDTTypeName)
    {
        try
        { 
            OracleParameter param = default(OracleParameter);
            

            param = new OracleParameter(paramName, (OracleDbType)paramType, paramVal,  (ParameterDirection)paramDirection);
           // param.ArrayBindSize = new int[2];
            param.UdtTypeName = paramUDTTypeName;            
            cmd.Parameters.Add(param);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    //public IDataParameter AddParameterOutPut(string paramName, OracleDbType paramType)
    //{
    //    try
    //    {
    //        OracleParameter param = default(OracleParameter);
    //        param = new OracleParameter(paramName, paramType, ParameterDirection.Output);
    //        cmd.Parameters.Add(param);

    //        return param;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}

    //public void AddParameterReturn(string paramName, ParameterType paramType, int paramSize)
    //{
    //    try
    //    {
    //        OracleParameter param = default(OracleParameter);
    //        param = new OracleParameter(paramName, paramType, paramSize, ParameterDirection.ReturnValue);
    //        cmd.Parameters.Add(param);
    //    }
    //    catch(Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public OracleDataReader GetDataReader(string cmdText, CommandType cmdType)
    {
      Open();
      cmd.Connection = conn;
      CreateCommand(cmdText, cmdType);
      return cmd.ExecuteReader();
    }

    public void ExecuteSQL(string sSQL, ref DataTable dt)
    {
        OracleDataAdapter adapter = new OracleDataAdapter(); 
       
        try
        {
            Open();
            CreateCommand(sSQL, CommandType.Text);
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            adapter.Dispose();            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Close();
        }
    }

    public void ExecuteSQL(string sSQL)
    {        
        try
        {
         Open();
         CreateCommand(sSQL,CommandType.Text);
         cmd.Connection = conn;
         cmd.ArrayBindCount = _ArrayBindCount;
         cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
           throw ex;
        }
        finally
        {
            Close();
        }
    }

    public int ArrayBindCount
    {
        get { return _ArrayBindCount; }
        set { _ArrayBindCount = value; }
    }
    public void ExecuteSP(string sSPName, ref DataSet ds)
    {
        OracleDataAdapter adapter = new OracleDataAdapter();
       
        try
        {
            Open();
            CreateCommand(sSPName, CommandType.StoredProcedure);
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);

            adapter.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Close();
        }
    }

    public void ExecuteSP(string sSPName, ref DataTable dt)
    {
        OracleDataAdapter adapter = new OracleDataAdapter();
    
        try
        {
            Open();
            CreateCommand(sSPName, CommandType.StoredProcedure);
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            adapter.Dispose();         
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            Close();
        }
    }

     public void ExecuteSP(string sSPName)
     {
        try
        {
         Open();
         CreateCommand(sSPName,CommandType.StoredProcedure);
         cmd.Connection = conn;
         cmd.ExecuteNonQuery();         
        }
        catch (Exception ex)
        {
           throw ex;
        }
        finally
        {
            Close();
        }
    }

     //public void ExecuteSPBatch(long lBakashaId, int iMisparIshi,string sSPName)
     //{
     //    try
     //    {
     //       Open();
                                          
     //        CreateCommand(sSPName, CommandType.StoredProcedure);
     //        clLogBakashot.InsertErrorToLog(lBakashaId, iMisparIshi, "I", 0, null, "after CreateCommand");
                                          
     //        cmd.Connection = conn;
     //        cmd.ExecuteNonQuery();
     //        clLogBakashot.InsertErrorToLog(lBakashaId, iMisparIshi, "I", 0, null, "after ExecuteNonQuery");
                                          
     //    }
     //    catch (Exception ex)
     //    {
     //        throw ex;
     //    }
     //    finally
     //    {
     //        Close();
     //    }
     //}


     public string ExecuteScalar(string ReturnParamName)
    {
        try
        {
            Open();
            cmd.Connection = conn;
            cmd.ExecuteScalar();
            return cmd.Parameters[ReturnParamName].Value.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Close();
        }
       
    }

    public string GetValParam(string ParamName) 
    {
        return cmd.Parameters[ParamName].Value.ToString();
    }

    public object GetObjectParam(string ParamName)
    {
        return cmd.Parameters[ParamName].Value;
    }
    //public void InsertXML(string sXML, string sTableName, string[] ucols)
    //{
    //    try
    //    {
    //        //Open();
    //        //cmd.Connection = conn;
    //        //cmd.XmlCommandType = OracleXmlCommandType.Insert;
    //        //cmd.CommandText = sXML;
    //        //cmd.XmlSaveProperties.Table = sTableName;
    //        //cmd.XmlSaveProperties.UpdateColumnsList = ucols;
    //        //// Insert rows
    //        //int rows = cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        Close();
    //    }
    //}
    void IDisposable.Dispose()
    {
        cmd.Dispose();
        cmd = null;
    }


    public void ExecuteSP(string sSPName, ref DataSet ds, string TablesNames)
    {
        OracleDataAdapter adapter = new OracleDataAdapter();
        string OldName = "";
        string[] TablesNamesSplit;
        try
        {
            Open();
            CreateCommand(sSPName, CommandType.StoredProcedure);
            cmd.Connection = conn;
            cmd.CommandTimeout = 0;
            adapter.SelectCommand = cmd;
            TablesNamesSplit = TablesNames.Split(',');
            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                if (cmd.Parameters[i].OracleDbType == Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor)
                {
                    OldName = "Table";
                    if (i > 0) OldName += i;

                    adapter.TableMappings.Add(OldName, TablesNamesSplit[i]);
                }
            }
            adapter.Fill(ds);
            adapter.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    //public void ExecuteSP(string sSPName, ref DataSet ds,string TablesNames)
    //{
    //    OracleDataAdapter adapter = new OracleDataAdapter();
    //    string OldName="";
    //    string[] TablesNamesSplit;
    //    try
    //    {
    //        Open();
    //        CreateCommand(sSPName, CommandType.StoredProcedure);
    //        cmd.Connection = conn;
    //        adapter.SelectCommand = cmd;
    //        TablesNamesSplit = TablesNames.Split(',');
    //        //for (int i = 0; i < cmd.Parameters.Count; i++)
    //        //{
    //        //    if (cmd.Parameters[i].OracleDbType  == Oracle.DataAccess.Client.OracleDbType.RefCursor)
    //        //    {
    //        //        OldName="Table";
    //        //        if (i>0) OldName += i;

    //        //        adapter.TableMappings.Add(OldName, TablesNamesSplit[i]);
    //        //    }
    //        //}
    //        adapter.Fill(ds);

    //        adapter.Dispose();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        Close();
    //    }
    //}


    }

}
