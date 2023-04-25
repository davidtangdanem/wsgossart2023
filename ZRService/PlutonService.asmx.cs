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

//%Windir%/Microsoft.NET/Framework/v2.0.50727/aspnet_regiis.exe -i
namespace GossartService
{
    /// <summary>
    /// Description résumée de Service1
    /// </summary>
    [WebService(Namespace = "http://www.gossartws.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public partial class CotiresService : System.Web.Services.WebService
    {
        static bool bVersion=false;
 
        public const string INI_KEY = "SOFTWARE\\danem\\gossart\\";
        public const string INI_DSN = "CONNSTRING";

        //public static string DIR_SAN = "\\\\192.168.4.34\\san";// HttpContext.Current.Server.MapPath("~/");//
        //sd15
        public static string DIR_SAN = "C:\\danem\\san";// HttpContext.Current.Server.MapPath("~/");//

        //10.10.25.10
        //public static string DIR_SAN = "E:\\san";// HttpContext.Current.Server.MapPath("~/");//

        public static string DIR_SAN_LOCAL = HttpContext.Current.Server.MapPath("~/")+"\\sanGossart";// ;//

        public static string DIR_LOCAL =  HttpContext.Current.Server.MapPath("~/");


        string GLOBAL_login = "rr5eeEEre&§&";
        string GLOBAL_pwd = "azeff&EE11Eeerdfgdfg";

        private string Auth_PDA(string stLogin, string stPwd,string mac)
        {
            try
            {
                
                stConnStringZRWS = ReadRegDBParams();

                string stmessage = "";
                string querySrv = "select case when mainid=0 then id else mainid end socid,* from distrib_users where (email='" + stLogin + "' or loginmort='"+stLogin+"' )  and pwd='" + stPwd + "' and (idnotif='" + mac + "' or isnull(idnotif,'')='') and type in ('4')";
                DataTable dt = GetData2(stConnStringZRWS, querySrv,ref stmessage);
                if(stmessage!="")
                  Log( " mesdt=" + stmessage, "err_auth", "", stLogin);
                if (dt.Rows.Count == 0)
                    return "";

                
                return dt.Rows[0]["socid"].ToString()+"|"+stConnStringZRWS;// "Data Source=sd3.danem.fr;Initial Catalog=negos_dlp2;Persist Security Info=True;User ID=kiventou;Password=demo1234";
            }
            catch (SystemException ex)
            {
                //Log(ex.Message.ToString());
                // MessageBox.Show(ex.Message.ToString()); 
                Log(ex.Message + " connstring=" + stConnStringZRWS, "err_auth", "", stLogin);
                return "";
            }

        }

        private string Auth(string stLogin, string stPwd )
        {
            try
            {
                if (stLogin == GLOBAL_login && stPwd == GLOBAL_pwd)
                {
                }
                else
                    return "";

                stConnStringZRWS = ReadRegDBParams();
                return stConnStringZRWS;// "Data Source=sd3.danem.fr;Initial Catalog=negos_dlp2;Persist Security Info=True;User ID=kiventou;Password=demo1234";
            }
            catch (SystemException ex)
            {
                //Log(ex.Message.ToString());
               // MessageBox.Show(ex.Message.ToString()); 
                Log(ex.Message + " connstring=" + stConnStringZRWS, "err_auth", "", stLogin);
                return "";
            }
           
        }
    }
}
