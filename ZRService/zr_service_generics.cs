using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Data.Odbc;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace GossartService
{
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public partial class CotiresService
    {
        [WebMethod]
        public string Ping()
        {
            return "Reponse";

        }
        public class AuthHeader : SoapHeader
        {
            private string login;
            private string pwd;
            private string fonction;
            private string societe;
            private string macId;

            public string Login { get { return login; } set { login = value; } }
            public string Password { get { return pwd; } set { pwd = value; } }
            public string Fonction { get { return fonction; } set { fonction = value; } }
            public string Societe { get { return societe; } set { societe = value; } }
            public string MacId { get { return macId; } set { macId = value; } }
         }
        public AuthHeader SecuredHeader;

        [WebMethod]
        public string Bonjour(string stUser, string stPwd,string mac)
        {
            //Log("Bonjour," + stUser+"," +stPwd);
            string stConnString = Auth_PDA(stUser, stPwd,  mac);
            //   return stConnString + " " + HttpContext.Current.Server.MapPath("~/");
            if (stConnString != "")
                return "Bienvenue chez DANEM PLUTON WS version " + GetVersion("");
            else
            {
                return "Acces refusé";
            }
        }
        public string ConvertDataTabletoString(DataTable dt)
        {
            if (dt == null)
                return "";
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);            
        }

        /************************************************************************/
        /* requete insert ou le insert into n'est mentionné qu'une seule fois                                                                     */
        /************************************************************************/

        public byte[] ExecExInsertHdrZip(string stquery, string stTargetTable)
        {
            string stLineComplete = "";
            try
            {

                string stConnString = Auth(GLOBAL_login,GLOBAL_pwd);
                if (stConnString != "")
                {
                 
                    using (SqlConnection connection = new SqlConnection(stConnStringZRWS))
                    {
                        connection.Open();



                        SqlCommand m_myCommandPropLin = new SqlCommand(stquery, connection);

                        SqlDataReader drCompoPropLin = m_myCommandPropLin.ExecuteReader();



                        int nNbrLin = 0;
                        int nFldCount = 0;
                        string stReturnedRec = "INSERT INTO " + stTargetTable + " (";
                        if (drCompoPropLin.Read())
                        {
                            //crée l 'entete avec les noms des champs
                            for (int i = 0; i < drCompoPropLin.FieldCount; i++)
                            {
                                // if (fields[i] != "" && fields[i] != null)
                                stReturnedRec += drCompoPropLin.GetName(i) + ",";
                            }
                            stReturnedRec = stReturnedRec.Substring(0, stReturnedRec.Length - 1);
                            stReturnedRec += ") VALUES ";

                            string stFld = "";
                            string stInsert = stReturnedRec;
                            do
                            {

                                nNbrLin++;
                                stReturnedRec = "(";
                                for (int i = 0; i < drCompoPropLin.FieldCount; i++)
                                {
                                    // if (fields[i] != "" && fields[i] != null)
                                    {

                                        stFld = drCompoPropLin[i].ToString();
                                        if (stFld.Contains("'"))
                                            stFld = stFld.Replace("'", "''");
                                        if (stFld.Contains("\n"))
                                        {
                                            stFld = stFld.Replace("\n", "|");
                                            stFld = stFld.Replace("\r\n", "|");
                                        }
                                        if (stFld.Contains("\r"))
                                        {
                                            stFld = stFld.Replace("\r", "|");
                                           
                                        }
                                        stFld = stFld.Replace("  ", "");
                                        stReturnedRec += "'" + stFld + "',";
                                    }


                                }
                                stReturnedRec = stReturnedRec.Substring(0, stReturnedRec.Length - 1);
                                stReturnedRec += ")";

                                stLineComplete += stReturnedRec + SEP_LINE;
                                //  string stConnStringSpe = drCompoPropLin[0].ToString();
                            } while (drCompoPropLin.Read());

                            stLineComplete = stInsert + SEP_LINE + stLineComplete;

                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
           //             byte[] byt = System.Text.Encoding.ASCII.GetBytes(stLineComplete);

            if(stLineComplete!="")
            {
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(stLineComplete);
                return GZCompress(byt);
            }
            else
            {
                
                return null;
            }

           
            //return stLineComplete;
        }
        public byte[] ExecExInsertHdrZip2(string stquery, string stTargetTable)
        {
            string stLineComplete = "";
            try
            {

                string stConnString = Auth(GLOBAL_login, GLOBAL_pwd);
                if (stConnString != "")
                {

                    using (SqlConnection connection = new SqlConnection(stConnStringZRWS))
                    {
                        connection.Open();



                        SqlCommand m_myCommandPropLin = new SqlCommand(stquery, connection);

                        SqlDataReader drCompoPropLin = m_myCommandPropLin.ExecuteReader();



                        int nNbrLin = 0;
                        int nFldCount = 0;
                        string stReturnedRec = "INSERT INTO " + stTargetTable + " (";
                        if (drCompoPropLin.Read())
                        {
                            //crée l 'entete avec les noms des champs
                            for (int i = 0; i < drCompoPropLin.FieldCount; i++)
                            {
                                // if (fields[i] != "" && fields[i] != null)
                                stReturnedRec += drCompoPropLin.GetName(i) + ",";
                            }
                            stReturnedRec = stReturnedRec.Substring(0, stReturnedRec.Length - 1);
                            stReturnedRec += ") VALUES ";

                            string stFld = "";
                            string stInsert = stReturnedRec;
                            do
                            {

                                nNbrLin++;
                                stReturnedRec = "(";
                                for (int i = 0; i < drCompoPropLin.FieldCount; i++)
                                {
                                    // if (fields[i] != "" && fields[i] != null)
                                    {

                                        stFld = drCompoPropLin[i].ToString();
                                        if (stFld.Contains("'"))
                                            stFld = stFld.Replace("'", "''");
                                        if (stFld.Contains("\n"))
                                        {
                                            stFld = stFld.Replace("\n", "|");
                                            stFld = stFld.Replace("\r\n", "|");
                                        }
                                        if (stFld.Contains("\r"))
                                        {
                                            stFld = stFld.Replace("\r", "|");

                                        }
                                        stFld = stFld.Replace("  ", "");
                                        stReturnedRec += "'" + stFld + "',";
                                    }


                                }
                                stReturnedRec = stReturnedRec.Substring(0, stReturnedRec.Length - 1);
                                stReturnedRec += ")";

                                stLineComplete += stReturnedRec + SEP_LINE;
                                //  string stConnStringSpe = drCompoPropLin[0].ToString();
                            } while (drCompoPropLin.Read());

                            stLineComplete = stInsert + SEP_LINE + stLineComplete;
                           // Log(stLineComplete, "ExecExInsertHdrZip2", "", GLOBAL_login);

                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            //             byte[] byt = System.Text.Encoding.ASCII.GetBytes(stLineComplete);

            byte[] byt = System.Text.Encoding.UTF8.GetBytes(stLineComplete);
            return GZCompress(byt);
            //return stLineComplete;
        }
        /************************************************************************/
        /* execute une requete insert ou update en catchant l'erreur pour ne pas tout planter                                                                     */
        /************************************************************************/
        string ExecuteNonQuery(SqlCommand cmd)
        {
            string returnError = "";
            try
            {
                if (cmd.ExecuteNonQuery() == 0)
                {
                    //returnError = cmd.CommandText + "¤";
                }

            }
            catch (Exception ex)
            {
                returnError = ex.Message;
            }
            return returnError;
        }

        /************************************************************************/
        /* execute les requetes sur le serveur séparée par un ¤  
         * Le 1ere element est le INSERT INTO ... VALUES, les reste, les valeurs
         * Non securisé
         */
        /************************************************************************/

        public string UpdateSrvTableHdrSec(string login, string pwd, string mac, string stLine)
        {
           
            string returnError = "";
            string insert = "";
            string stQuery = "";
            try
            {

                //   stLine = "INSERT INTO KEMS_DATA (soc_code,cli_code,pro_code,vis_code,cde_code,dat_type,dat_idx01,dat_idx02,dat_idx03,dat_idx04,dat_idx05,dat_idx06,dat_idx07,dat_idx08,dat_idx09,dat_idx10,dat_data01,dat_data02,dat_data03,dat_data04,dat_data05,dat_data06,dat_data07,dat_data08,dat_data09,dat_data10,dat_data11,dat_data12,dat_data13,dat_data14,dat_data15,dat_data16,dat_data17,dat_data18,dat_data19,dat_data20,dat_data21,dat_data22,dat_data23,dat_data24,dat_data25,dat_data26,dat_data27,dat_data28,dat_data29,dat_data30,val_data31,val_data32,val_data33,val_data34,val_data35,val_data36,val_data37,val_data38,val_data39) VALUES ¤('','42','','bwl991012110711','','59','20110711','','','','','','','','','','','','0','20110711','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','')¤('','42','311','bwl991012110711','','58','9','','','','','','','','','','0.0','3','','','0','','','2','barquette map 400 g','103','','','','','','','','','','','','','','','','','','','','','','','','','','','','','f'')";
                string returnValue = "";

                string stLineComplete = "";

                string stConnString = Auth_PDA(login, pwd, mac);
                if (stConnString != "")
                {
                    using (SqlConnection connection = new SqlConnection(stConnStringZRWS))
                    {
                        connection.Open();

                        stQuery = GiveFld(stConnString, 1, "|");

                        SqlCommand m_myCommandPropLin = new SqlCommand(stQuery, connection);



                        Log(stLine, "brut", "UpdateSrvTableHdrSec", login);
                        insert = "";
                        m_myCommandPropLin.CommandText = "BEGIN TRANSACTION A";
                        ExecuteNonQuery(m_myCommandPropLin);
                        int i = 0;
                        while ((stQuery = GiveFldEx(stLine, i, "¤", "__fin")) != "__fin")
                        {
                            if (stQuery == "") break;

                            //le 1ere element est le insert into
                            if (i == 0)
                            {
                                insert = stQuery;

                            }
                            else
                            {

                                m_myCommandPropLin.CommandText = insert + stQuery;
                                // Log(insert + stQuery, "clean" ,"UpdateSrvTableHdrNonSec", login);
                                if ((returnValue = ExecuteNonQuery(m_myCommandPropLin)) != "")
                                {
                                    //returnError += returnValue;

//                                    Log(this.SecuredHeader.ConnectionId, login, pwd, "UPDATE", "", "UpdateSrvTableHdrSec", insert + stQuery, returnValue);
                                    //en cas d'erreur on rejete en bloc, on evite le commit de ce qui a deja marché
                                    return "err:" + returnValue;
                                }

                            }

                            i++;
                        }
                        m_myCommandPropLin.CommandText = "COMMIT TRANSACTION A";
                        ExecuteNonQuery(m_myCommandPropLin);

                    }
                }
                else
                {
                    return "Accès refusé";
                }
            }
            catch (Exception ex)
            {
                //Log(this.SecuredHeader.ConnectionId, login, pwd, "", "", "UpdateSrvTableHdrSec", insert + stQuery, ex.Message);
                return ex.Message;

            }
            return returnError;
        }
    }
}


				