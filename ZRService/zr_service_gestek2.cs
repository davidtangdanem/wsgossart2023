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
using Danem.suite.common;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace GossartService
{
    public partial class CotiresService
    {
        //Cotires - listing client
         //code client - raisoc - ville - cp - technicien 
        
  

        
        public string dailyReport(string login,string pwd)
        {
            try
            {
                if (login == "toto" && pwd == "grit&z")
                {

                    string stConnString = Auth("", "");

                    string query = "select * from dailyreport";
                    DataTable dt2 = GetData(stConnString, query, "state");
                    string json = ConvertDataTabletoString(dt2);
                    return json;
                }
                else
                    return "";
            
            }
            catch (Exception)
            {

                return "";
            }
           
        }



    };




}
