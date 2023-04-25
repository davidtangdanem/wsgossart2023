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
using System.IO.Compression;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace GossartService
{
    public partial class CotiresService
    {
        public  void movePhotos(string source,  string filter)
        {
            try
            {

                List<String> MyMusicFiles = Directory
                                   .GetFiles(source, filter, SearchOption.TopDirectoryOnly).ToList();

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    string directoryName =Left( Right(mFile.Name, 18),8);
                    Log(directoryName, "", "movePhotos2", "");
                    DirectoryInfo dirInfo = new DirectoryInfo(source+"\\"+directoryName);
                    if (dirInfo.Exists == false)
                        Directory.CreateDirectory(source + "\\" + directoryName);

                    string photoname = Left(mFile.Name, mFile.Name.Length - 19) + ".jpg";
                    if (new FileInfo(dirInfo + "\\" + photoname).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + photoname);
                        
                    }
                    else
                    {
                        
                        mFile.MoveTo(source + "\\err\\" +DateTime_to_YYYYMMDDhhmmss(0)+"_"+photoname);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message, "", "movePhotos2", "");
                int i = 0;
                i++;
               

            }
        }

        public  void moveSign(string source, string filter)
        {
            try
            {

                List<String> MyMusicFiles = Directory
                                   .GetFiles(source, filter, SearchOption.TopDirectoryOnly).ToList();

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    string directoryName = Left(Right(mFile.Name, 18), 8);
                    
                    DirectoryInfo dirInfo = new DirectoryInfo(source + "\\" + directoryName);
                    if (dirInfo.Exists == false)
                        Directory.CreateDirectory(source + "\\" + directoryName);

                    //string photoname = Left(mFile.Name, mFile.Name.Length - 19) + ".jpg";

                    string photoname = mFile.Name;
                    if (new FileInfo(dirInfo + "\\" + photoname).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + photoname);
                    }
                    else
                    {
                        mFile.MoveTo(source + "\\err\\" + photoname);
                    }
                }
            }
            catch (Exception ex)
            {
                int i = 0;
                i++;

            }
        }

        public static void moveFiles(string source, string dest, string filter)
        {
            try
            {


                String directoryName = dest;
                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                if (dirInfo.Exists == false)
                    Directory.CreateDirectory(directoryName);

                List<String> MyMusicFiles = Directory
                                   .GetFiles(source, filter, SearchOption.TopDirectoryOnly).ToList();

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        public  void moveFiles2(string source, string dest)
        {
            try
            {

               // Log(source, "moveFiles12", "", "test");
               // Log(dest, "moveFiles22", "", "test");
                String directoryName = dest;
                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                if (dirInfo.Exists == false)
                    Directory.CreateDirectory(directoryName);

                List<String> MyMusicFiles = Directory
                                   .GetFiles(source, "*.*", SearchOption.TopDirectoryOnly).ToList();

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log(ex.Message, "moveFiles2", "", "test");

            }
        }
        public static void moveFiles(string source, string dest)
        {
            try
            {


                String directoryName = dest;
                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                if (dirInfo.Exists == false)
                    Directory.CreateDirectory(directoryName);

                List<String> MyMusicFiles = Directory
                                   .GetFiles(source, "*.*", SearchOption.TopDirectoryOnly).ToList();

                foreach (string file in MyMusicFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        public static string Left(string chaine, int len)
        {
            try
            {
                chaine = chaine.Substring(0, len);
                return chaine;
            }
            catch (Exception)
            {


            }
            return chaine;
        }
        public static string Right(string chaine, int len)
        {
            try
            {
                chaine = chaine.Substring(chaine.Length - len, len);
                return chaine;
            }
            catch (Exception)
            {


            }
            return chaine;
        }

        static public string split(string str, string field, string defaultvalue)
        {
            try
            {
                if (defaultvalue == null) defaultvalue = "";
                string value;
                string query = "";
                int ifld = 0;
                if (str == null || str == "") return "";
                while ((value = GiveFldEx(str, ifld++, "|", "finfin")) != "finfin")
                {
                    if (value != "")
                        query += " " + field + "='" + value + "' OR ";
                }
                if (str.Length > 0)
                {
                    query = query.Substring(0, query.Length - 4);
                    query = " and (" + query + ") ";
                }


                if (query.Equals("") && defaultvalue.Equals("") == false)
                {
                    query = " and (" + field + "='" + defaultvalue + "' ) ";
                }

                return query;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        static public string split2(string str, string field, string field2, string defaultvalue)
        {
            try
            {
                if (defaultvalue == null) defaultvalue = "";
                string value;
                string query = "";
                int ifld = 0;
                if (str == null || str == "") return "";
                while ((value = GiveFldEx(str, ifld++, "|", "finfin")) != "finfin")
                {
                    if (value != "")
                    {
                        query += " " + field + "='" + value + "' OR ";
                        query += " " + field2 + "='" + value + "' OR ";
                    }
                        
                }
                if (str.Length > 0)
                {
                    query = query.Substring(0, query.Length - 4);
                    query = " and (" + query + ") ";
                }


                if (query.Equals("") && defaultvalue.Equals("") == false)
                {
                    query = " and (" + field + "='" + defaultvalue + "' ) ";
                }

                return query;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        static public DataTable GetData(string conString, string query )
        {
            try
            {

                SqlCommand cmd = new SqlCommand(query);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;

                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                               
                            sda.Fill(dt);
                            con.Close();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                String toto;
                toto = ex.Message;
                

            }
            return null;
        }
        static public DataTable GetData2(string conString, string query,ref string message)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(query);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;

                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {

                            sda.Fill(dt);
                               con.Close();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                String toto;
                toto = ex.Message;
                message = ex.Message;

            }
            return null;
        }
        static public DataTable GetData(string conString, string query,string name)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(query);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;

                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable(name))
                        {
                                
                            sda.Fill(dt);
                            con.Close();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
            return null;
        }
        static public DataTable GetData(SqlConnection con, string query )
        {
            try
            {

                SqlCommand cmd = new SqlCommand(query);
               
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;

                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            //    con.Close();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
               
            }
            catch (Exception)
            {


            }
            return null;
        }
        //on va générer un mot de passe à partir de l'identifiant et du jour
        public static string generatePwd(string id,int maxlen)
        {
            string pwd = id + DateTime_to_YYYYMMDDhhmmss(0);

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwd);
            byte[] hash = md5.ComputeHash(inputBytes);
 
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            string val=sb.ToString();
            return Right(val, maxlen);
 
        }

        //on va générer un mot de passe à partir de l'identifiant et du jour
        public static string computeHash(string text)
        {
            string pwd = text;

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
     

        public static int WeekNumber(DateTime value)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek,
                                                                     DayOfWeek.Monday);

        }

        static public int ExecuteNonQuery2(string stCommand, SqlConnection con)
        {
            int result = 0;
            try
            {
                string strInsert = stCommand;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strInsert;

                result = (int)cmd.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                return result;

            }
            return result;

        }
        public static float convertToFloat(string val)
        {
            try
            {
                val = "0" + val;
                return float.Parse(val);
            }
            catch (Exception ex)
            {
                return 0;

            }
        }
        public static int convertToInt(string val)
        {
            try
            {

                return Int32.Parse(val);
            }
            catch(Exception ex)
            {
                return 0;

            }
        }
        public static byte[] GZCompress(byte[] data)
        {
    /*        MemoryStream ms = new MemoryStream();
               ms.Write(data,0,data.Length);
               GZipStream Compress = new GZipStream(ms, CompressionMode.Compress);
            Compress.Write(data,0,data.Length);
            Compress.
     * */
            MemoryStream ms = new MemoryStream();
            GZipStream ds = new GZipStream(ms, CompressionMode.Compress, true);
            ds.Write(data, 0, data.Length);
            ds.Close();
            ms.Position = 0;
            byte[] compressed = new byte[ms.Length + 4]; // an extra 4 bytes for original data length
            Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, compressed, 0, 4);
            ms.Read(compressed, 4, compressed.Length - 4);
            return compressed;
        }
        static public string DateTime_to_YYYYMMDD(DateTime dt)
        {
            string sdt = "";
            sdt = String.Format("{0}{1:00}{2:00}",
                dt.Year,
                dt.Month,
                dt.Day
                );

            return sdt;

        }
        static public string DateTime_to_YYYYMMDD (int delta)
        {
            string dt = "";
            dt = String.Format("{0}{1:00}{2:00}",
                DateTime.Now.AddDays(delta).Year,
                DateTime.Now.AddDays(delta).Month,
                DateTime.Now.AddDays(delta).Day             
                );

            return dt;

        }
        static public string DateTime_to_YYYYMMDDhhmmss(int delta)
        {
            string dt = "";
            dt = String.Format("{0}{1:00}{2:00}{3:00}{4:00}{5:00}",
                DateTime.Now.AddDays(delta).Year,
                DateTime.Now.AddDays(delta).Month,
                DateTime.Now.AddDays(delta).Day,
                DateTime.Now.AddDays(delta).Hour,
                DateTime.Now.AddDays(delta).Minute,
                DateTime.Now.AddDays(delta).Second
                );

            return dt;

        }
        public static byte[] Compress(byte[] data)
        {
            return GZCompress(data);
/*            MemoryStream ms = new MemoryStream();
            DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress, true);
            ds.Write(data, 0, data.Length);
            ds.Close();
            ms.Position = 0;
            byte[] compressed = new byte[ms.Length + 4]; // an extra 4 bytes for original data length
            Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, compressed, 0, 4);
            ms.Read(compressed, 4, compressed.Length - 4);
            return compressed;
 * */
        }

        public static byte[] Decompress(byte[] compressedData)
        {
            int dataLength = BitConverter.ToInt32(compressedData, 0);
            MemoryStream ms = new MemoryStream();
            ms.Write(compressedData, 4, compressedData.Length - 4);
            byte[] data = new byte[dataLength];
            ms.Position = 0;
            DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress);

            ds.Read(data, 0, data.Length);
            return data;
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        static public string GetVersion(string stFilePath)
        {
            string strVersion;
            if (stFilePath == "")
                strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            else
                strVersion = System.Reflection.Assembly.LoadFile(stFilePath).GetName().Version.ToString();

            //System.Version  objVersion =System.Reflection.Assembly.LoadFile(FilePath).GetName().Version
            return strVersion;
        }
        //on va lire les infos serveur dans le fichier infosrv.txt dans le repertoire du ws
        //dsn;login;pwd;
        public string ReadRegDBParams()
        {
            try
            {
                string odbc = GetRegistryValue(INI_KEY, INI_DSN, "");
                if (odbc.Equals("")) return "";



                return odbc;
            }
            catch (Exception ex)
            {
                Log(ex.Message,"registry","","");
            }
            return "";
          
        }
        public void SetRegistryValue(string stPath, string stKey, string stValue)
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(stPath);
                registryKey.SetValue(stKey, stValue);
                registryKey.Close();
            }
            catch(Exception ex)
            {
                Log(ex.Message,"registry","","");
            }

        }
        public string GetRegistryValue(string stPath, string stKey, string stDefault)
        {
            try
            {
                string stValue;
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(stPath);
                object obj = registryKey.GetValue(stKey);
                stValue = obj.ToString();
                registryKey.Close();
                if (stValue == "")
                    stValue = stDefault;
                return stValue;
            }
            catch (Exception ex)
            {
                return stDefault;
            }
        }
        public string GetFileMD5CheckSum(string fichier)
        {
            if (File.Exists(fichier))
            {
                System.IO.FileStream st = null;

                try
                {
                    System.Security.Cryptography.MD5CryptoServiceProvider check = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    st = System.IO.File.Open(fichier, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    
                
                    byte[] somme = check.ComputeHash (st);
                    string ret = "";
                    foreach (byte a in somme)
                    {
                        if ((a < 16))
                        {
                            ret += "0" + a.ToString("X");
                        }
                        else
                        {
                            ret += a.ToString("X");
                        }
                    }
                    return ret;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (st != null) st.Close();
                }
            }
            else
            {
                return "";
            }
            return "";
        }
        private string GiveFld(string stLine, int nNum, string pTok)
        {
            char[] delimiter = pTok.ToCharArray();
            string[] split = stLine.Split(delimiter);
            int i = 0;
            foreach (string st in split)
            {
                if (nNum == i)
                    return (st);
                i++;
            }
            return "END";
        }
        static public string GiveFldEx(string stLine, int nNum, string pTok, string emptyRetValue)
        {
            string[] delimiter = new string[1];
            delimiter[0] = pTok;
            string[] split = stLine.Split(delimiter, StringSplitOptions.None);
            int i = 0;
            foreach (string st in split)
            {
                if (nNum == i)
                    return (st);
                i++;
            }
            return emptyRetValue;
        }
  /*      public void Log(string stlog)
        {
            string stPath = HttpContext.Current.Server.MapPath("~/") +"\\";

            //  stPath = Directory.GetCurrentDirectory() + "\\log.txt";
            stPath += "log.txt";
            TextWriter m_Log = new StreamWriter(stPath, true, System.Text.Encoding.Default);

            string stLine = DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + ";";
            stLine += stlog;
            m_Log.WriteLine(stLine);

            m_Log.Close();
        }
   * */
        void createDirectory(string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (Exception ex)
            {
            }

        }
       
        public void Log(string stlog,string typefile,string scenario,string login)
        {
            string datelog = DateTime.Now.ToString("yy-MM-dd HH-mm-ss-ffff");
          //  string stPath = HttpContext.Current.Server.MapPath("~/") + "log\\" + datelog.Substring(0, 8) + "\\";
            string stPath = DIR_SAN_LOCAL + "\\bunddl\\gossart\\log\\" + datelog.Substring(0, 8) + "\\";
            createDirectory(stPath);

            //  stPath = Directory.GetCurrentDirectory() + "\\log.txt";
            stPath += "log_"+login+"_"+datelog+"_"+scenario+"_"+typefile+".txt";
            TextWriter m_Log = new StreamWriter(stPath, true, System.Text.Encoding.Default);

            string stLine =datelog + ";";
            stLine += stlog;
            m_Log.WriteLine(stLine);

            m_Log.Close();
        }
        public void Log(string stLogin,string stPwd,string stScenar,string stFilterClient,string fonction, string msg, string exception)
        {
            string stQueryLog = "";
            try
            {
             
              
                //on nettoie les chaines de car des quotes
                msg = msg.Replace("'", "''");
                exception = exception.Replace("'", "''");
                fonction = fonction.Replace("'", "''");
                string stFilterClientInsert = stFilterClient.Replace("'", "''");

                stQueryLog = "INSERT INTO " + TABLENAME_WS_LOG +
                    " (" +
                    FIELD_LOG_ACTION + "," +
                    FIELD_LOG_LOGIN + "," +
                    FIELD_LOG_PWD + "," +
                    FIELD_LOG_SCENARIO + "," +
                    FIELD_LOG_MESSAGE + "," +
                    FIELD_LOG_EXCEPTION + "," +
                    FIELD_LOG_FONCTION + "," +
                    FIELD_LOG_FILTRE +
                    ")  VALUES (" +
                    "'AUTH'," +
                    "'" + stLogin + "'," +
                    "'" + stPwd + "'," +
                    "'" + stScenar + "'," +
                    "'" +  msg+ "'," +
                    "'" + exception+ "'," +
                    "'" + fonction + "'," +
                    "'" + stFilterClientInsert + "'" +
                    ")";

                /*   OdbcConnection odbc_connexion = new OdbcConnection(stConnStringZRWS);
                odbc_connexion.Open();
                //CreateZRWSTables(ref odbc_connexion);
                //
                OdbcCommand m_myCommandPropLin = new OdbcCommand("select * from toto", odbc_connexion);




                m_myCommandPropLin.CommandText = stQueryLog;
                m_myCommandPropLin.ExecuteNonQuery();
                odbc_connexion.Close();
                */ 
                //on ecrit pas dans un fichier si c'est l'auth, ca ferait trop de fichiers
                if (fonction.Equals("Auth")==false)
                    Log(stQueryLog, "err", stScenar, stLogin);
                
                
            }
            catch(Exception ex)
            {
                Log(ex.Message+"¤"+stQueryLog,"errwritinlog",stScenar,stLogin);
            }
      
        }

        static public bool ExecuteNonQuery(string stCommand, SqlConnection con)
        {
            try
            {
                string strInsert = stCommand;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strInsert;

                int result = cmd.ExecuteNonQuery();
                if (result == 0) return false;
            }
            catch (SqlException ex)
            {
                return false;
                
            }
            return true;
            
        }
        static public bool ExecuteNonQuery(string stCommand, string stConnString)
        {
            try
            {
                 SqlConnection con = null;
                    
                                   
                con = new SqlConnection(stConnString);
                con.Open();
                string strInsert = stCommand;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strInsert;

                int result = cmd.ExecuteNonQuery();

                
                con.Close();

            }
            catch (SqlException ex)
            {
                return false;

            }
            return true;

        }

        static public string split(string str, string field, string defaultvalue,string sep,bool like)
        {
            try
            {
                if (defaultvalue == null) defaultvalue = "";
                string value;
                string query = "";

                string carlike = "";
                if (like == true)
                    carlike = "%";

                int ifld = 0;
                if (str == null || str == "") return "";
                while ((value = GiveFldEx(str, ifld++, sep, "finfin")) != "finfin")
                {
                    if (value != "")
                    {
                        if (like==true)
                            query += " " + field + " like '" + value + carlike + "' OR ";
                        else
                            query += " " + field + "='" + value + carlike + "' OR ";
                    }
                }
                if (str.Length > 0)
                {
                    query = query.Substring(0, query.Length - 4);
                    query = " and (" + query + ") ";
                }


                if (query.Equals("") && defaultvalue.Equals("") == false)
                {
                    query = " and (" + field + "='" + defaultvalue + "' ) ";
                }

                return query;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }
}