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

namespace GossartService
{
    public partial class CotiresService
    {
        //////////////////////////////////////////////////////////////////////////        
        //TABLES WS
        public const string TABLENAME_WS_SOC = "zrws_soc";
        public const string FIELD_SOC_SOC_ID = "soc_id";
        public const string FIELD_SOC_SOC_NAME = "soc_name";
        public const string FIELD_SOC_SOC_CONNSTRING = "soc_connstring";

        public const string TABLENAME_WS_SOCSCENAR = "zrws_scenarsoc";
        public const string FIELD_SOCSCENAR_ID = "scenarsoc_id";
        public const string FIELD_SOCSCENAR_SOC_ID = "soc_id";
        public const string FIELD_SOCSCENAR_NAME = "scenarsoc_name";
        public const string FIELD_SOCSCENAR_TEXT = "scenarsoc_text";
        public const string FIELD_SOCSCENAR_TARGETTABLE = "scenarsoc_targettable";

        public const string TABLENAME_WS_USER = "zrws_user";
        public const string FIELD_USER_ID = "user_id";
        public const string FIELD_USER_LOGIN = "user_login";
        public const string FIELD_USER_PWD = "user_pwd";
        public const string FIELD_USER_SOC_ID = "soc_id";
        public const string FIELD_USER_ACTIVE = "user_active";
        public const string FIELD_USER_ALIAS = "user_alias";

        public const string TABLENAME_WS_LOG = "zrws_entrylog";
        public const string FIELD_LOG_IDX = "idx";
        public const string FIELD_LOG_ACTION = "action";
        public const string FIELD_LOG_LOGIN = "login";
        public const string FIELD_LOG_PWD = "pwd";
        public const string FIELD_LOG_SCENARIO = "scenario";
        public const string FIELD_LOG_FILTRE = "filtre";
        public const string FIELD_LOG_FONCTION = "fonction";
        public const string FIELD_LOG_MESSAGE = "message";
        public const string FIELD_LOG_EXCEPTION = "exception";
        public const string FIELD_LOG_DATECONN = "dateconn";
        public const string FIELD_LOG_RESOLU = "resolu";
        public const string FIELD_LOG_LASTACTIONUSER = "lastactionuser";

        public const string TABLENAME_WS_USERSCENAR = "zrws_scenaruser";
        public const string FIELD_USERSCENAR_SOC_ID = "soc_id";
        public const string FIELD_USERSCENAR_SOCSCENAR_ID = "scenarsoc_id";
        public const string FIELD_USERSCENAR_ID = "scenaruser_id";
        public const string FIELD_USERSCENAR_USER_ID = "user_id";
        public const string FIELD_USERSCENAR_NAME = "scenaruser_name";
        public const string FIELD_USERSCENAR_TEXT = "scenaruser_text";


        public const string SEP_FLD = ";";
        public const string SEP_LINE = "\n";
        public const string ENGINE_ORACLE = "ORACLE";
        public const string ENGINE_SQLSERVER = "SQL SERVER";

        public string stConnStringZRWS = "";
        public string Engine = "";

        public const string ALIAS  = "$alias$";
        public const string NOM = "$nom$";
        
    };
}
