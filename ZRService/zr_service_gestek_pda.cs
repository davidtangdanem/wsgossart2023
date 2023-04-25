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
        [SoapHeader("SecuredHeader")]
        [WebMethod]
        public byte[] querySrvb(string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10)
        {
            string login = this.SecuredHeader.Login;
            string pwd = this.SecuredHeader.Password;
            string fonction = this.SecuredHeader.Fonction;
            string societe = this.SecuredHeader.Societe;
            string macId = this.SecuredHeader.MacId;

            return querySrvNSb(fonction, login, pwd,macId, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10);

        }
        [SoapHeader("SecuredHeader")]
        [WebMethod]
        public string querySrvt(string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10)
        {
            string login = this.SecuredHeader.Login;
            string pwd = this.SecuredHeader.Password;
            string fonction = this.SecuredHeader.Fonction;
            string societe = this.SecuredHeader.Societe;
            string macId = this.SecuredHeader.MacId;

            return querySrvNSt(fonction, login, pwd, macId, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10);



        }
        public byte[] querySrvNSb(string fonction, string login, string pwd, string macId,string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10)
        {

            if (fonction == "getChargementOfTheDay")
            {
                return getChargementOfTheDay(login, pwd, macId, prm1,prm2);
            }
            if (fonction == "getChargementOfTheDay2")
            {
                return getChargementOfTheDay2(login, pwd, macId, prm1, prm2);
            }
            if (fonction == "getRamasseAllDay")
            {
                return getRamasseAllDay(login, pwd, macId, prm1);
            }
            if (fonction == "getRamasseEntDay")
            {
                return getRamasseEntDay(login, pwd, macId, prm1);
            }
            if (fonction == "getRamasseLinDay")
            {
                return getRamasseLinDay(login, pwd, macId, prm1);
            }
            if (fonction == "getChargementAmiens")
            {
                return getChargementAmiens(login, pwd, macId, prm1, prm2);
            }
            if (fonction == "getChargementAmiensV2")
            {
                return getChargementAmiensV2(login, pwd, macId, prm1, prm2);
            }
            if (fonction == "getChargementAdrOfTheDay")
            {
                return getChargementAdrOfTheDay(login, pwd, macId, prm1, prm2);
            }
           
            if (fonction == "PDA_getClients")
            {
                return PDA_getClients(login, pwd, macId);
            }
            if (fonction == "PDA_getParams")
            {
                return PDA_getParams(login, pwd, macId);
            }
            
            //Update_MDP_getSecretCode
            return null;
        }
        public string querySrvNSt(string fonction, string login, string pwd, string macId, string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10)
        {
 
            if (fonction == "PDA_chargementOK")
            {
                return PDA_chargementOK(login, pwd, macId, prm1);
            }
            if (fonction == "PDA_ramasseOK")
            {
                return PDA_ramasseOK(login, pwd, macId, prm1);
            }

            
            if (fonction == "PDA_livraisonOK")
            {
                return PDA_livraisonOK(login, pwd, macId, prm1);
            }
            if (fonction == "PDA_MiseEnTournee")
            {
                return PDA_MiseEnTournee(login, pwd, macId, prm1);
            }
            if (fonction == "PDA_OrdreTournee")
            {
                return PDA_OrdreTournee(login, pwd, macId, prm1);
            }

            if (fonction == "PDA_chargementSignature")
            {
                return PDA_chargementSignature(login, pwd, macId, prm1);
            }
            if (fonction == "PDA_livraisonSignature")
            {
                return PDA_livraisonSignature(login, pwd, macId, prm1);
            }      
            return "";
        }

        public byte[] PDA_getClients(string login,string pwd, string mac)
        {
             string stConnString = Auth_PDA(login, pwd, mac);
             if (stConnString != "")
             {
                 string query = @"select        
                [CODECLIENT]       
                ,[RAISOC]
                ,[ADRES1]
                ,[ADRES2]
                ,[CPOST]
                ,[VILLE]
                ,[PAYS]
                ,[CONTACT]
                ,[TELEP]
                ,[FAX]       
                
                ,[COMMENTAIRE]
                ,[CODETOURNEE]
                ,[JOURPASSAGE]
                ,[NUMJOURPASSAGE]       
                ,[LATITUDE]
                ,[LONGITUDE]
                ,[DATEDEPART]
                ,[FREQVIS]
                ,[ORDREPASSAGE]
                ,[PASSAGEEXCEPT1]
                ,[CODECLIENTPERE] 
                from t_negos_clients  ";

                 return ExecExInsertHdrZip(query, "site_client2");
             }

             return null;
        }
        
         public byte[] PDA_getParams(string login,string pwd, string mac)
         {
               string stConnString = Auth_PDA(  login,  pwd,   mac);
               string codesoc = GiveFld(stConnString, 0, "|");
               stConnString = GiveFld(stConnString, 1, "|");  

               if (stConnString != "")
               {
                   string query = @"SELECT DISTINCT  prm_table, prm_coderec, prm_lbl, 
                    prm_comment, prm_actif, prm_value, prm_order
                    FROM     T_NEGOS_PARAMS where prm_soccode='" + codesoc + "' union select 'USER',cast (id as varchar), loginmort,email,'1',type,id from distrib_users where ( id=" + codesoc + " or mainid=" + codesoc + ")"+" and loginmort="+login+"  and type in ('4')";
               


                   return ExecExInsertHdrZip(query, "kems_param");
               }

               return null;
         }

         [SoapHeader("SecuredHeader")]
        [WebMethod]
         public bool PDA_SendFileEx(string stFile, Byte[] buffer, long size, int type)
         {
             string stPath = "";
             try
             {
                 string login = this.SecuredHeader.Login;
                 string pwd = this.SecuredHeader.Password;
                 string mac = this.SecuredHeader.MacId; ;
                 string stConnString = Auth_PDA(login, pwd, mac);
                 string codesoc = GiveFld(stConnString, 0, "|");
                 if (stConnString != "")
                 {
                     string stDirScenar = GiveFld(stConnString, 1, "|");
                     //signatures
                     if (type == 1)
                     {
                        //stPath = HttpContext.Current.Server.MapPath("~/") + GiveFld(stConnString, 1, "|") + "\\signatures\\";
                        //stPath = HttpContext.Current.Server.MapPath("~/") + "bunddl\\gossart\\" + codesoc + "\\signatures\\";
                        //stPath = DIR_SAN + "\\bunddl\\gossart\\" + codesoc + "\\signatures\\";
                        stPath = DIR_LOCAL + "\\bunddl\\gossart\\" + codesoc + "\\signatures\\";

                    }
                     //photos
                     if (type == 2)
                     {
                        // stPath = HttpContext.Current.Server.MapPath("~/") + GiveFld(stConnString, 1, "|") + "\\photos\\";
                        // stPath = HttpContext.Current.Server.MapPath("~/") + "bunddl\\gossart\\"+codesoc+"\\photos\\";
                        // stPath = DIR_SAN + "\\bunddl\\gossart\\" + codesoc + "\\photos\\";
                        stPath = DIR_LOCAL + "\\bunddl\\gossart\\" + codesoc + "\\photos\\";

                    }
                    //signatures entrepot
                    if (type == 3)
                    {
                        //stPath = HttpContext.Current.Server.MapPath("~/") + GiveFld(stConnString, 1, "|") + "\\signatures\\";
                        //stPath = HttpContext.Current.Server.MapPath("~/") + "bunddl\\gossart\\" + codesoc + "\\signatures\\";
                        //stPath = DIR_SAN + "\\bunddl\\gossart\\" + codesoc + "\\signatures\\";
                        stPath = DIR_LOCAL + "\\bunddl\\gossart\\" + codesoc + "\\signatures_entrepot\\";

                    }



                    //  stPath = HttpContext.Current.Server.MapPath("~/") + GiveFld(stConnString, 1, "|") + "\\";
                    Directory.CreateDirectory(stPath);

                     //if (buffer.Length < 500) return false;
                     if (buffer.Length != size) return false;
                     File.WriteAllBytes(stPath + stFile, buffer);
                     return true;

                 }
                 else
                 {
                     return false;
                 }
             }
             catch (Exception ex)
             {
                 Log("","", "", "",  "SendFile", stPath + stFile, ex.Message);
             }
             return false;
         }


        public byte[] getChargementOfTheDay(string login, string pwd, string mac, string codelivreur,string jour)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))
             
                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)
                query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 from kems_data
                where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')     and (      dat_idx04='"+codelivreur+ @"'      or dat_idx04='' or dat_idx04 is null)
                union
                select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 from kems_data
                where dat_type=402 and  soc_code='" + codesoc + "'  and ( dat_data25='" + codelivreur + "' or dat_data25='LOADINGSERVER') and dat_data21='1'  and (isnull(dat_data23,'') not in ('1','0') or val_data33=1) ";
                //livraison on envoi les colis qui n'ont pas été déjà livrés et qui n'ont pas eu un pb de chargement, et qui ont été enlevé par le livreur

                Log(query, "_getChargementOfTheDay", "", login);
                return ExecExInsertHdrZip2(query, "kems_data");
            }
            return null;
        }
        public byte[] getRamasseAllDay(string login, string pwd, string mac, string codelivreur)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))

                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)
                query = @"select CODE_SOC , CODE_RAMASSE,DATE_TOURNEE,CODE_CLIENT,CODE_ENTREPOT,CODE_ARTICLE,LIBELLE_ARTICLE,QUANTITE,DEPOT FROM V_RAMASSE  where CODE_TOURNEE='"+ codelivreur + "' ORDER BY CODE_CLIENT,CODE_RAMASSE ,CODE_ARTICLE ";
                Log(query,  "_getRamasseAllDay", "", login);
                return ExecExInsertHdrZip2(query, "Ramasse");
            }
            return null;
        }

        public byte[] getRamasseEntDay(string login, string pwd, string mac, string codelivreur)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))

                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)
                query = @"select CODE_SOC,CODE_RAMASSE,CODE_CLIENT,CODE_TOURNEE,DATE_TOURNEE,CODE_ENTREPOT,FREE1,FREE2,FREE3,FREE4,FREE5,FREE6,FREE7,FREE8,FREE9,FREE10 FROM V_RAMASSE_ENT  where CODE_TOURNEE='" + codelivreur + "' and dat_idx08 is null ORDER BY CODE_CLIENT,CODE_RAMASSE ";
                Log(query, "_getRamasseEntDay", "", login);
                return ExecExInsertHdrZip2(query, "Ramasse");
            }
            return null;
        }

        public byte[] getRamasseLinDay(string login, string pwd, string mac, string codelivreur)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))

                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)
                query = @"select CODE_SOC ,CODE_TOURNEE ,CODE_RAMASSE,CODE_ARTICLE,LIBELLE_ARTICLE,QUANTITE,INFOX,DEPOT,ETAT,NUMDOC,TYPE,LIBRE1,LIBRE2,LIBRE3,LIBRE4,LIBRE5,LIBRE6,LIBRE7,LIBRE8,LIBRE9,LIBRE10 FROM V_RAMASSE_LIN  where CODE_TOURNEE='" + codelivreur + "'  and dat_idx08 is null ORDER BY CODE_RAMASSE,CODE_ARTICLE ";
                Log(query, "_getRamasseLinDay", "", login);
                return ExecExInsertHdrZip2(query, "Ramasse_Article ");
            }
            return null;
        }

        public byte[] getChargementOfTheDay2(string login, string pwd, string mac, string codelivreur, string jour)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            String stdate = DateTime_to_YYYYMMDD(0);
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))

                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)

                /*  query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                  dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18,dat_data56 from kems_data
                  where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')     and (      dat_idx04='" + codelivreur + @"'      or dat_idx04='' or dat_idx04 is null)
                  union
                  select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                  dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data
                  where dat_type=402 and  soc_code='" + codesoc + "'  and ( ( dat_data25='" + codelivreur + "' and dat_data26='" + codelivreur + "'   ) or dat_data25='LOADINGSERVER') and dat_data21='1'  and (isnull(dat_data23,'') not in ('1','0') or val_data33=1) " +
                   " union select dat_idx09, val_data31, dat_data15, dat_data21, soc_code, cli_code, dat_type, dat_idx01, dat_idx02, dat_idx03, dat_idx04,case when isnull(dat_idx05,'')= '' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,  dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data where dat_type = 402 and soc_code = '" + codesoc + "'  and( dat_data26 = '" + codelivreur + "' or dat_data25 = 'LOADINGSERVER') and dat_data21 = '1'  and(isnull(dat_data23, '') not in ('1', '0') or val_data33 = 1) " +
                 "union  select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')= '' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16, dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data where dat_type = 402 and soc_code = '" + codesoc + "'  and (dat_data25 = '" + codelivreur + "' or dat_data25 = 'LOADINGSERVER')  and dat_data19 = 'COLIS ABSENT SUR LE QUAI AU CHARGEMENT' and dat_data21 = 'A'  and (isnull(dat_data23, '') not in ('1', '0') or val_data33 = 1) and dat_data13 = '"+stdate+"' ";
                  */

                query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
               dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18,dat_data56 from kems_data
               where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')     and (      dat_idx04='" + codelivreur + @"'      or dat_idx04='' or dat_idx04 is null)
               union
               select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
               dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data
               where dat_type=402 and  soc_code='" + codesoc + "'  and ( ( dat_data25='" + codelivreur + "' and dat_data26='" + codelivreur + "'   ) or dat_data25='LOADINGSERVER') and dat_data21='1'  and (isnull(dat_data23,'') not in ('1','0') or val_data33=1) " +
               " union select dat_idx09, val_data31, dat_data15, dat_data21, soc_code, cli_code, dat_type, dat_idx01, dat_idx02, dat_idx03, dat_idx04,case when isnull(dat_idx05,'')= '' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,  dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data where dat_type = 402 and soc_code = '" + codesoc + "'  and( dat_data26 = '" + codelivreur + "' or dat_data25 = 'LOADINGSERVER') and dat_data21 = '1'  and(isnull(dat_data23, '') not in ('1', '0') or val_data33 = 1) ";

                query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 ,dat_data56 from kems_data
                where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')     and (      dat_idx04='" + codelivreur + @"'      or dat_idx04='' or dat_idx04 is null)
                union
                select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18,dat_data56 from kems_data
                where dat_type=402 and  soc_code='" + codesoc + "'  and ( dat_data25='" + codelivreur + "' or dat_data25='LOADINGSERVER') and dat_data21='1'  and (isnull(dat_data23,'') not in ('1','0') or val_data33=1) ";


                Log(query, "_getChargementOfTheDay2", "", login);

                return ExecExInsertHdrZip2(query, "kems_data");
            }
            return null;
        }
        public byte[] getChargementAmiens(string login, string pwd, string mac, string codelivreur, string jour)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            jour = DateTime_to_YYYYMMDD(5);
            if (stConnString != "")
            {
                //where dat_type=402 and  soc_code='" + codesoc + @"' and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>'' and dat_idx04='"+codelivreur+@"'  ))

                string query = "";
                //enlevement
                //on envoi les colis non chargés ET ( dans la tournée du gars qui se connect OU qui n'ont pas été affecté)
                //query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                //dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 from kems_data
                //where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')     and (      dat_idx04='" + codelivreur + @"'      or dat_idx04='' or dat_idx04 is null)
              //  union
              //  select dat_idx09, val_data31, dat_data15, dat_data21,soc_code,cli_code,dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
               // dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 from kems_data
               // where dat_type=402 and  soc_code='" + codesoc + "'  and ( dat_data25='" + codelivreur + "' or dat_data25='LOADINGSERVER') and dat_data21='1'  and (isnull(dat_data23,'') not in ('1','0') or val_data33=1) ";
                //livraison on envoi les colis qui n'ont pas été déjà livrés et qui n'ont pas eu un pb de chargement, et qui ont été enlevé par le livreur

                query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,'405' as dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 , distrib_users.nom as dat_data24 from kems_data 
                 INNER JOIN
                      T_NEGOS_PARAMS ON .kems_data.dat_idx04 = T_NEGOS_PARAMS.prm_coderec
                      INNER JOIN
                      dbo.T_NEGOS_PARAMS AS T_NEGOS_PARAMS_1 ON dbo.kems_data.dat_idx05 = T_NEGOS_PARAMS_1.prm_coderec
                      INNER JOIN
                      distrib_users ON distrib_users.id = dbo.kems_data.dat_idx04

                where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')  AND 
                     ( (dbo.T_NEGOS_PARAMS.prm_table = 'SECTSQ') and 
                      (T_NEGOS_PARAMS_1.prm_table = 'SECDEMANDEUR') )  and (      T_NEGOS_PARAMS.prm_lbl='" + codelivreur + @"'   ) and dat_data15>=CONVERT(VARCHAR(8), GETDATE() - 5, 112)  
                    UNION 
                    select * from View_
where dat_data15=CONVERT(VARCHAR(8), GETDATE() - 0, 112)   and (     dat_idx04='" + codelivreur + @"'   )
                   union
                  select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,'405' as dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 , distrib_users.nom as dat_data24 from kems_data 
                 INNER JOIN
                      T_NEGOS_PARAMS ON .kems_data.dat_idx04 = T_NEGOS_PARAMS.prm_coderec
                INNER JOIN
                      dbo.T_NEGOS_PARAMS AS T_NEGOS_PARAMS_1 ON dbo.kems_data.dat_idx05 = T_NEGOS_PARAMS_1.prm_coderec
                   INNER JOIN
                      distrib_users ON distrib_users.id = dbo.kems_data.dat_idx04

                where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')  AND 
                      ((dbo.T_NEGOS_PARAMS.prm_table = 'SECTAB')  and 
                      (T_NEGOS_PARAMS_1.prm_table = 'SECDEMANDEUR') )    and (      T_NEGOS_PARAMS.prm_lbl='" + codelivreur + @"'   ) and dat_data15>=CONVERT(VARCHAR(8), GETDATE() - 5, 112) ";
                //(T_NEGOS_PARAMS_1.prm_table = 'SECDEMANDEUR') )    and (      T_NEGOS_PARAMS.prm_lbl='" + codelivreur + @"'   ) and dat_data15>='" + jour + @"'";

                //Log(query,  "_Chargement_Amiens", "", login);
                return ExecExInsertHdrZip2(query, "kems_data");
            }
            return null;
        }
        public byte[] getChargementAmiensV2(string login, string pwd, string mac, string codelivreur, string jour)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            jour = DateTime_to_YYYYMMDD(5);
            if (stConnString != "")
            {
                
                string query = "";

                query = @"select dat_idx09,val_data31,dat_data15,dat_data21, soc_code,cli_code,'405' as dat_type,dat_idx01,dat_idx02,dat_idx03, dat_idx04,case when isnull(dat_idx05,'')='' then 99 else dat_idx05 end dat_idx05,dat_idx06,dat_idx08,dat_data14,dat_data16,
                  case when isnull(T_NEGOS_CLIENTS.RAISOC,'')='' then T_NEGOS_CLIENTS.NOM else T_NEGOS_CLIENTS.RAISOC end dat_data01,dat_data02,dat_data03,dat_data05,dat_data06,dat_data08,dat_data10,dat_data11,dat_data12,dat_data13,dat_data17,dat_data18 , distrib_users.nom as dat_data24 from kems_data 
                 INNER JOIN
                      T_NEGOS_PARAMS ON .kems_data.dat_idx04 = T_NEGOS_PARAMS.prm_coderec 
                      INNER JOIN
                      dbo.T_NEGOS_PARAMS AS T_NEGOS_PARAMS_1 ON dbo.kems_data.dat_idx05 = T_NEGOS_PARAMS_1.prm_coderec
                      INNER JOIN
                      distrib_users ON distrib_users.id = dbo.kems_data.dat_idx04
                    INNER JOIN
                      T_NEGOS_CLIENTS ON T_NEGOS_CLIENTS.CODECLIENT = dbo.kems_data.cli_code

                where dat_type=402 and  soc_code='" + codesoc + @"' and  isnull(dat_data21,'') not in ('1','0','A')  AND 
                     ( (dbo.T_NEGOS_PARAMS.prm_table = 'SECTDEPOT') and  
                      (T_NEGOS_PARAMS_1.prm_table = 'SECDEMANDEURV2') )  and (      T_NEGOS_PARAMS.prm_lbl='" + codelivreur + @"'   ) and (      T_NEGOS_PARAMS_1.prm_comment='" + codelivreur + @"'   )  and dat_data15>=CONVERT(VARCHAR(8), GETDATE() - 5, 112)  
                    UNION 
                    select * from View_ramassecolis where dat_data15=CONVERT(VARCHAR(8), GETDATE() - 0, 112)   and (     dat_idx04='" + codelivreur + @"'   )";                 
                Log(query, "_getChargementAmiensV2", "", login);
                return ExecExInsertHdrZip2(query, "kems_data");
            }
            return null;
        }
        public byte[] getChargementAdrOfTheDay(string login, string pwd, string mac, string codelivreur, string jour)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            if (stConnString != "")
            {
                //on envoi les adresses de colis
                //sans date de chargement (data14)
                //ET dont l etat de chargement n'est pas défini (data21)
                //ET donc la date de tournee n'est pas positionnée (data13) OU positionnée pour le livreur qui  se connecte
                //UNION
                //l'etat de livraison non défini (data23) ou dont letat de livraison est avis de passage
                string
                     query = @" SELECT    
                      dbo.T_NEGOS_CLIENTS.CODECLIENT, dbo.T_NEGOS_CLIENTS.RAISOC, dbo.T_NEGOS_CLIENTS.NOM, dbo.T_NEGOS_CLIENTS.PRENOM, 
                      dbo.T_NEGOS_CLIENTS.ADRES1, dbo.T_NEGOS_CLIENTS.ADRES2, dbo.T_NEGOS_CLIENTS.CPOST, dbo.T_NEGOS_CLIENTS.VILLE, dbo.T_NEGOS_CLIENTS.PAYS, 
                      dbo.T_NEGOS_CLIENTS.TEL1, dbo.T_NEGOS_CLIENTS.TEL2, dbo.T_NEGOS_CLIENTS.ADR_EMAIL, dbo.T_NEGOS_CLIENTS.COMMENTAIRE, 
                      dbo.T_NEGOS_CLIENTS.TYPE
                      FROM       
                      dbo.T_NEGOS_CLIENTS where dbo.T_NEGOS_CLIENTS.VISIBLE IS NULL and CLILABO='23'  and RAISOC <>'CLIENT INCONNU' and TELEVENTE IS NULL ";

                /* query = @" SELECT    
                       dbo.T_NEGOS_CLIENTS.CODECLIENT, dbo.T_NEGOS_CLIENTS.RAISOC, dbo.T_NEGOS_CLIENTS.NOM, dbo.T_NEGOS_CLIENTS.PRENOM, 
                       dbo.T_NEGOS_CLIENTS.ADRES1, dbo.T_NEGOS_CLIENTS.ADRES2, dbo.T_NEGOS_CLIENTS.CPOST, dbo.T_NEGOS_CLIENTS.VILLE, dbo.T_NEGOS_CLIENTS.PAYS, 
                       dbo.T_NEGOS_CLIENTS.TEL1, dbo.T_NEGOS_CLIENTS.TEL2, dbo.T_NEGOS_CLIENTS.ADR_EMAIL, dbo.T_NEGOS_CLIENTS.COMMENTAIRE, 
                       dbo.T_NEGOS_CLIENTS.TYPE
                       FROM         dbo.kems_data LEFT JOIN
                       dbo.T_NEGOS_CLIENTS ON dbo.T_NEGOS_CLIENTS.CODECLIENT = dbo.kems_data.dat_idx06
                       WHERE dat_type=402 and  soc_code='" + codesoc + @"'  
                        and (isnull(dat_data14,'')=''  ) and isnull(dat_data21,'') not in ('1','0','A')  and ((isnull(dat_data13,'')=''  ) or   (isnull(dat_data13,'')<>''   ))   

                       union 
                       SELECT      
                       dbo.T_NEGOS_CLIENTS.CODECLIENT, dbo.T_NEGOS_CLIENTS.RAISOC, dbo.T_NEGOS_CLIENTS.NOM, dbo.T_NEGOS_CLIENTS.PRENOM, 
                       dbo.T_NEGOS_CLIENTS.ADRES1, dbo.T_NEGOS_CLIENTS.ADRES2, dbo.T_NEGOS_CLIENTS.CPOST, dbo.T_NEGOS_CLIENTS.VILLE, dbo.T_NEGOS_CLIENTS.PAYS, 
                       dbo.T_NEGOS_CLIENTS.TEL1, dbo.T_NEGOS_CLIENTS.TEL2, dbo.T_NEGOS_CLIENTS.ADR_EMAIL, dbo.T_NEGOS_CLIENTS.COMMENTAIRE, 
                       dbo.T_NEGOS_CLIENTS.TYPE
                       FROM         dbo.kems_data LEFT JOIN
                       dbo.T_NEGOS_CLIENTS ON dbo.T_NEGOS_CLIENTS.CODECLIENT = dbo.kems_data.cli_code
                       WHERE dat_type=402 and  soc_code='" + codesoc + @"'  and ( isnull(dat_data23,'') not in ('1','0','A')  or val_data33=1) ";//and dat_idx04='" + codelivreur + @"'

                 //  WHERE dat_type=402 and  soc_code='" + codesoc + @"'  and (dat_data25='" + codelivreur + "' or dat_data25='LOADINGSERVER') and dat_data21='1'  and ( isnull(dat_data23,'') not in ('1','0')  or val_data33=1) ";
                */
                //Log(query, "getChargementAdrOfTheDay", "", login);
                return ExecExInsertHdrZip(query, "SITE_CLIENT");
            }
            return null;
        }

      

        public string PDA_chargementOK(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                SqlCommand cmd = new SqlCommand("");

                SqlConnection con = null;
                    con = new SqlConnection(stConnString);
                    con.Open();
                    ExecuteNonQuery("BEGIN TRANSACTION", con);
                    bool bres = false; 
                    int i = 0;
                    string stiordreliv = "";
                    int iordreliv = 1;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");
                       
                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon=="") break;
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string etat = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string manu = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string codeenlevement = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string motif = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string AMPM = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string codeclient = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string colislat = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string colislon = GiveFldEx(packagecolis, ++y, ";", "finn");


                        //ordre colis 
                        string selectorder = "select val_data31  from kems_data where dat_idx04='" + livreur + "' and dat_type=402 and soc_code='" + codesoc + "' and dat_data21 = '1'  and isnull(dat_data16,'')='' and dat_data13='" + Left(date, 8) + "' order by val_data31 desc ";
                        Log(selectorder, "PDA_ORDRELIVSELECT2", "", login);
                        DataTable dtordre = GetData(stConnString, selectorder);
                        if (dtordre.Rows.Count > 0)
                        {
                            Log(selectorder, "PDA_ORDRELIVSELECT3", "", login);
                             stiordreliv = dtordre.Rows[0]["val_data31"].ToString();
                            Log(stiordreliv, "PDA_ORDRELIVSELECT1", "", login);

                            // iordreliv = convertToInt(stiordreliv);
                            //iordreliv= iordreliv+1;
                        }
                        
                        string stiordreliv1 = iordreliv.ToString();
                        Log(selectorder + "_" + stiordreliv1, "PDA_ORDRELIVSELECT", "", login);

                         /*stiordreliv = iordreliv.ToString();
                         query = "update kems_data set val_data31='"+ stiordreliv + "'  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data21 = '1' and isnull(dat_data14,'')!='' and isnull(dat_data16,'')='' ";
                         ExecuteNonQuery(query, con);
                         Log(query, "PDA_ORDRELIV", "", login);
                         
                        iordreliv++;*/


                        // Information param motif 
                        string motifcode = motif;
                        if(motifcode!="")
                        {
                            string select4 = "select *  from T_NEGOS_PARAMS where  prm_lbl='" + motif + "' and prm_soccode='" + codesoc + "' and prm_table='MOTIFENLEV' ";
                            DataTable dt4 = GetData(stConnString, select4);
                             if (dt4.Rows.Count > 0)
                             {

                                 motifcode = dt4.Rows[0]["prm_coderec"].ToString();

                             }
                         }

                        

                        // Information distri_user 
                        string loginimport = livreur;
                        string select3 = "select *  from distrib_users where id='" + livreur + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();
                           
                        }
                        

                      
                        int brese = 0;
                        string select = @"SELECT count(*) FROM kems_data where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                        brese = ExecuteNonQuery2(select, con);
                        if (brese > 0)
                        {
                            bres = true;
                        }
                        else
                            bres = false;
                      
                        string CliLivr_nom = "CLIENT INCONNU";
                        string CliLivr_prenom ="";
                        string CliLivr_adr1 ="";
                        string CliLivr_adr2 ="";
                        string CliLivr_cp = "";
                        string CliLivr_ville = "";
                        string CliLivr_email = "";
                        string CliLivr_tel1 = "";
                        string CliLivr_tel2 = "";
                        string CliLivr_raisoc = "";
                        string CliLivr_service = "";
                        string CliLivr_codeenlevement = codeenlevement;
                        string CliLivr_numbon = numbon;

                        // Information client 
                        string select1 = "select *  from t_negos_clients where codeclient='" + codeclient + "' and clilabo='" + codesoc + "'";
                        DataTable dt = GetData(stConnString, select1);
                        if (dt.Rows.Count > 0)
                        {
                            
                             CliLivr_nom = dt.Rows[0]["NOM"].ToString();
                             CliLivr_prenom = dt.Rows[0]["PRENOM"].ToString();
                             CliLivr_adr1 = dt.Rows[0]["ADRES1"].ToString();
                             CliLivr_adr2 = dt.Rows[0]["ADRES2"].ToString();
                             CliLivr_cp = dt.Rows[0]["CPOST"].ToString();
                             CliLivr_ville = dt.Rows[0]["VILLE"].ToString();
                             CliLivr_email = dt.Rows[0]["ADR_EMAIL"].ToString();
                             CliLivr_tel1 = dt.Rows[0]["TEL1"].ToString();
                             CliLivr_tel2 = dt.Rows[0]["TEL2"].ToString();
                             CliLivr_raisoc = dt.Rows[0]["RAISOC"].ToString();
                             CliLivr_service = dt.Rows[0]["SERVICE"].ToString();


                        }
                        else
                        {
                            //insert
                           String  query1 = @"insert into t_negos_clients (CLILABO,CODECLIENT,
                                    MOTDIRECTEUR,CT_NUMPAYEUR,CODVRP,DATCRE,RAISOC )  VALUES ( " +

                                    "'" + controlFld(codesoc) + "'," +
                                    "'" + controlFld(codeclient) + "'," +
                                    "'" + controlFld(CliLivr_numbon) + "'," +
                                    "'" + controlFld(CliLivr_codeenlevement) + "'," +
                                    "'" + controlFld(livreur) + "'," +
                                    "'" + controlFld(date) + "'," +
                                    
                                    "'" + controlFld(CliLivr_nom) + "')";


                            ExecuteNonQuery(query1, con);
                           // ExecuteNonQuery("COMMIT TRANSACTION", con);

                        }
                        // Information Enlevement

                        string CliEnlev_nom = "";
                        string CliEnlev_prenom = "";
                        string CliEnlev_adr1 ="";
                        string CliEnlev_adr2 = "";
                        string CliEnlev_cp = "";
                        string CliEnlev_ville = "";
                        string CliEnlev_email = "";
                        string CliEnlev_tel1 = "";
                        string CliEnlev_tel2 = "";
                        string CliEnlev_commentaire = "";
                        string CliEnlev_raisoc = "";
                        string CliEnlev_service = "";

                        string select2 = "select *  from t_negos_clients where codeclient='" + codeenlevement + "' and clilabo='" + codesoc + "'";
                         DataTable dt1 = GetData(stConnString, select2);
                        if (dt1.Rows.Count > 0)
                        {

                             CliEnlev_nom = dt1.Rows[0]["NOM"].ToString();
                             CliEnlev_prenom = dt1.Rows[0]["PRENOM"].ToString();
                             CliEnlev_adr1 = dt1.Rows[0]["ADRES1"].ToString();
                             CliEnlev_adr2 = dt1.Rows[0]["ADRES2"].ToString();
                             CliEnlev_cp = dt1.Rows[0]["CPOST"].ToString();
                             CliEnlev_ville = dt1.Rows[0]["VILLE"].ToString();
                             CliEnlev_email = dt1.Rows[0]["ADR_EMAIL"].ToString();
                             CliEnlev_tel1 = dt1.Rows[0]["TEL1"].ToString();
                             CliEnlev_tel2 = dt1.Rows[0]["TEL2"].ToString();
                             CliEnlev_commentaire = dt1.Rows[0]["COMMENTAIRE"].ToString();
                             CliEnlev_raisoc = dt1.Rows[0]["RAISOC"].ToString();
                             CliEnlev_service = dt1.Rows[0]["SERVICE"].ToString();

                        }
                        
                        string query = "";
                        if (bres == false)
                        {

                            String FORCE = "FORCE - " + livreur;
                            if (controlFld(motif) == "")
                                motif ="";

                                query = @"insert into kems_data (dat_type,soc_code,
                                    cli_code,dat_idx09,val_data31, dat_idx01,dat_idx03,dat_idx05, dat_data10  , dat_idx06,dat_data15,dat_data13 ,dat_data18 , dat_idx04,dat_data12    ,
                            dat_data14,dat_data01,dat_data02,dat_data03,dat_data04,dat_data05,dat_data06,dat_data07,dat_data08,dat_data09,dat_data11,dat_idx07,
                           dat_data40 ,dat_data41,dat_data42,dat_data43,dat_data44,dat_data45,dat_data46,dat_data47,dat_data48,dat_data49,dat_data50,dat_idx02
                                       
                              ,dat_data25,dat_data26,dat_data21,dat_data22,cde_code ,dat_data52,dat_data19, dat_data51,date_envoi,user_code)  VALUES (402, " +
                                        "'" + controlFld(codesoc) + "'," +
                                        "'" + controlFld(codeclient) + "'," +
                                        "'" + controlFld("") + "'," +
                                        "'" + controlFld("1") + "'," +
                                        "'" + controlFld(numbon) + "'," +
                                        "'" + controlFld("") + "'," +//bon.NUMCOLISTRANSP dat_idx03
                                        "'" + controlFld(livreur) + "'," +//bon.USERCREAT dat_idx05
                                        "'" + controlFld("") + "'," +//bon.COMMENT dat_data10
                                        "'" + controlFld("") + "'," +//bon.NUMADR dat_idx06
                                        "'" + controlFld(Left(date,8)) + "'," +//dat_data15
                                        "'" + controlFld(Left(date, 8)) + "'," +//dat_data13
                                        "'" + controlFld(AMPM) + "'," +//dat_data18
                                        "'" + controlFld(livreur) + "'," +//bon.LIVREURPREVU dat_idx04
                                        "'" + date + "'," +//dat_data12
                                         "'" + date + "'," +//dat_data14
                                        "'" + controlFld(CliLivr_raisoc) + "'," +//NOM dat_data01
                                        "'" + controlFld(CliLivr_prenom) + "'," +// PRENOM dat_data02
                                        "'" + controlFld(CliLivr_adr1) + "'," +//ADRES1 dat_data03
                                        "'" + controlFld(CliLivr_adr2) + "'," +//ADRES2 dat_data04
                                        "'" + controlFld(CliLivr_cp) + "'," +//CPOST dat_data05
                                        "'" + controlFld(CliLivr_ville) + "'," +//VILLE dat_data06
                                        "'" + controlFld(CliLivr_email) + "'," +//ADR_MAIL dat_data07
                                        "'" + controlFld(CliLivr_tel1) + "'," +//TEL1 dat_data08
                                        "'" + controlFld(CliLivr_tel2) + "'," +//TEL2 dat_data09
                                        "'" + controlFld(CliLivr_raisoc) + "'," +//RAISOC dat_data11
                                        "'" + controlFld(CliLivr_service) + "'," +//SERVICE dat_idx07
                                        "'" + controlFld(CliEnlev_nom) + "'," +//dat_data40
                                        "'" + controlFld(CliEnlev_prenom) + "'," +//dat_data41
                                        "'" + controlFld(CliEnlev_adr1) + "'," +//dat_data42
                                        "'" + controlFld(CliEnlev_adr2) + "'," +//dat_data43
                                        "'" + controlFld(CliEnlev_cp) + "'," +//dat_data44
                                        "'" + controlFld(CliEnlev_ville) + "'," +//dat_data45
                                        "'" + controlFld(CliEnlev_email) + "'," +//dat_data46
                                        "'" + controlFld(CliEnlev_tel1) + "'," +//dat_data47
                                        "'" + controlFld(CliEnlev_tel2) + "'," +//dat_data48
                                        "'" + controlFld(CliEnlev_commentaire) + "'," +//dat_data49
                                        "'" + controlFld(CliEnlev_raisoc) + "'," +//dat_data50
                                        "'" + controlFld(CliEnlev_service) + "',"+//dat_idx02
                                        "'" + controlFld(livreur) + "',"+//dat_data25
                                        "'" + controlFld(livreur) + "'," +//dat_data26
                                        "'" + controlFld(etat) + "',"+//dat_data21
                                        "'" + controlFld(manu) + "',"+//dat_data22
                                        "'" + controlFld(codeenlevement) + "',"+//cde_code
                                         "'" + controlFld("1") + "'," +//dat_data52
                                          "'" + controlFld(motif) + "',"+//dat_data19
                                           "'" + controlFld(loginimport) + "'," +//dat_data51
                                           "'" + controlFld(FORCE) + "'," +//dat_envoi
                                        "'" + controlFld(livreur) + "')";

                            //        LogColis(con, societe, bon.NUMCOLISINTERNE, controlFld(bon.USERCREAT), date, "", "", "CREATE", "", "");

                            Log(query, numbon + "_PDA_chargementOK_FORCE", "", login);
                            ExecuteNonQuery(query, con);
                           // ExecuteNonQuery("COMMIT TRANSACTION", con);

                        }
                        else
                        {



                            //si enlevement pas fait
                            //on remet les dates à 0
                            stiordreliv = iordreliv.ToString();
                            if (etat != "1")
                            {

                                // query = "update kems_data set dat_data19='" + controlFld(motif) + "', cde_code='" + codeenlevement + "',dat_data14='" + date + "',  dat_data21='" + etat + "', dat_data22='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data25='" + livreur + "',dat_data26='" + livreur + "'  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                                query = "update kems_data set dat_data19='" + controlFld(motif) + "', cde_code='" + codeenlevement + "',dat_data14='" + date + "',  dat_data21='" + etat + "', dat_data22='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data25='" + livreur + "'  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";

                            }
                            else
                            {
                                query = "update kems_data set dat_data19='" + controlFld(motif) + "', cde_code='" + codeenlevement + "',dat_data14='" + date + "', dat_data21='" + etat + "', dat_data22='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data25='" + livreur + "'  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                                //Log(query, numbon+ "_PDA_chargementOK_etat_1", "", login);
                            }
                            Log(query, numbon+ "_PDA_chargementOK", "", login);

                            ExecuteNonQuery(query, con);


                        }

                        if ((motifcode == "SURCHARGE CAMION" ||  motif == "SURCHARGE CAMION - RESTE A QUAI") && AMPM == "PM")
                        {


                            //query = "update kems_data set dat_data19='SURCHARGE CAMION - RESTE A QUAI', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "',dat_data26='" + livreur + "',dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";
                            query = "update kems_data set dat_data19='SURCHARGE CAMION - RESTE A QUAI', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "' ,dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";

                            ExecuteNonQuery(query, con);
                           
                        }

                        if ((motifcode == "SURCHARGE CAMION" || motif == "SURCHARGE CAMION - RESTE A QUAI") && AMPM == "AM")
                        {
                            
                            query = "update kems_data set dat_data19='', cde_code='" + codeenlevement + "' ,  dat_data21 = null,dat_data14='' , dat_data22='',dat_data18='PM' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='AM' ";

                            ExecuteNonQuery(query, con);
                            
                           
                        }

                        //COLIS ABSENT SUR LE QUAI AU CHARGEMENT
                        if ((motifcode == "COLIS ABSENT SUR LE" || motif == "COLIS ABSENT SUR LE QUAI AU CHARGEMENT") && AMPM == "PM")
                        {

                            //query = "update kems_data set dat_data19='COLIS ABSENT SUR LE QUAI AU CHARGEMENT', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "',dat_data26='" + livreur + "',dat_data18=''  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";
                            query = "update kems_data set dat_data19='COLIS ABSENT SUR LE QUAI AU CHARGEMENT', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "',dat_data18=''  where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";


                            ExecuteNonQuery(query, con);
                            
                        }

                        if ((motifcode == "COLIS ABSENT SUR LE" || motif == "COLIS ABSENT SUR LE QUAI AU CHARGEMENT") && AMPM == "AM")
                        {
                            //query = "update kems_data set dat_data19='COLIS ABSENT SUR LE QUAI AU CHARGEMENT', cde_code='" + codeenlevement + "' ,  dat_data21 = 'A',dat_data14='' , dat_data22='',dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='AM' ";
                            query = "update kems_data set dat_data19='COLIS ABSENT SUR LE QUAI AU CHARGEMENT', cde_code='" + codeenlevement + "' ,  dat_data21 = 'A',dat_data14='' , dat_data22='',dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='AM' ";

                            ExecuteNonQuery(query, con);
                         
                        }
                        
                        //FERME CE JOUR - REST
                        if ((motifcode == "FERME - RESTE A QUAI" || motif == "FERME - RESTE A QUAI") && AMPM == "PM")
                        {
                            //  query = "update kems_data set dat_data19='FERME - RESTE A QUAI', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "',dat_data26='" + livreur + "',dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";
                            query = "update kems_data set dat_data19='FERME - RESTE A QUAI', cde_code='" + codeenlevement + "',dat_data14='',  dat_data21='A', dat_data22='',dat_data25='" + livreur + "',dat_data18='' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='PM' ";

                            ExecuteNonQuery(query, con);
                            
                          
                        }

                        if ((motifcode == "FERME - RESTE A QUAI" || motif == "FERME - RESTE A QUAI") && AMPM == "AM")
                        {
                            query = "update kems_data set dat_data19='', cde_code='" + codeenlevement + "' ,  dat_data21 = null,dat_data14='' , dat_data22='',dat_data18='PM' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'  and dat_data18='AM' ";

                            ExecuteNonQuery(query, con);
                            
                        
                        }
                        

                       


                        //et on log
                        LogColisLatLon(con, codesoc, numbon, livreur, date, motif, etat, "LOADING", manu, codeenlevement,colislat,colislon);


                        // ExecuteNonQuery(query, con);
                        // Log(query, "PDA_CHARGEMENTOK", "", login);

                       



                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {
                    Log(ex.Message + "", "error PDA_chargementOK", "", login);
                  //  Log(ex.Message + "", "_ERROR_PDA_CHARGEMENTOK", "", login);
                    //  LogColis(con, codesoc, numbon, livreur, date, motif, etat, "ERROR", manu, codeenlevement);
                    return "err:"+ex.Message;
                }

                return "";
            }
            return "err";
        }


        public string PDA_ramasseOK(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            string query = "";
            string staaaammjjhhmmss = DateTime_to_YYYYMMDDhhmmss(0);
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;
                    con = new SqlConnection(stConnString);
                    con.Open();
                    ExecuteNonQuery("BEGIN TRANSACTION", con);
                    bool bres = false;
                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon == "") break;
                        string code_client = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string code_article = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string code_tournee = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string qte_ramasse = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date_qte_ramasse = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string qte_entrepot = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date_qte_entrepot = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string etat = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string nom_signature = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string nom_signatureclient = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string jpg_signature = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string jpg_signatureclient = GiveFldEx(packagecolis, ++y, ";", "finn");

                        staaaammjjhhmmss = DateTime_to_YYYYMMDDhhmmss(0);






                        query = @"insert into kems_data (dat_type,soc_code,
                            cli_code,cde_code,pro_code,dat_idx01,dat_idx03,dat_idx04,dat_idx05,dat_idx06,dat_idx07,dat_idx08,dat_idx09,dat_idx10,dat_data01,dat_data02,dat_data51)  VALUES (84, " +
                            "'" + controlFld(codesoc) + "'," +
                            "'" + controlFld(code_client) + "'," +
                            "'" + controlFld(numbon) + "'," +
                            "'" + controlFld(code_article) + "'," +
                            "'" + controlFld(code_tournee) + "'," +
                            "'" + controlFld(date) + "'," +
                            "'" + controlFld(qte_ramasse) + "'," +
                            "'" + controlFld(date_qte_ramasse) + "'," +
                            "'" + controlFld(qte_entrepot) + "'," +
                            "'" + controlFld(date_qte_entrepot) + "'," +
                            "'" + controlFld(etat) + "'," +
                            "'" + controlFld(nom_signature) + "'," +
                            "'" + controlFld(nom_signatureclient) + "'," +
                            "'" + controlFld(jpg_signature) + "'," +
                            "'" + controlFld(jpg_signatureclient) + "',"+
                            "'" + controlFld(staaaammjjhhmmss) + "')";



                        ExecuteNonQuery(query, con);


                        Log(query, numbon+"_PDA_RAMASSEOK", "", login);


                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {
                    Log(ex.Message + "", "Error_PDA_RAMASSEOK", "", login);
                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }

        public string PDA_MiseEnTournee(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;


                    con = new SqlConnection(stConnString);
                    con.Open();

                    ExecuteNonQuery("BEGIN TRANSACTION", con);

                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon == "") break;
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date = GiveFldEx(packagecolis, ++y, ";", "finn");
                     

                        string query = "";


                        query = "update kems_data set val_data31='99', dat_data13='" + date + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                     
                      


                        ExecuteNonQuery(query, con);

                         

                        LogColis(con, codesoc, numbon, livreur, date, "", "", "TOURNEE",  "", "");



                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {

                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }
        public string PDA_OrdreTournee(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;


                    con = new SqlConnection(stConnString);
                    con.Open();

                    ExecuteNonQuery("BEGIN TRANSACTION", con);

                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon == "") break;
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string ordre = GiveFldEx(packagecolis, ++y, ";", "finn");


                        string query = "";


                        query = "update kems_data set  val_data31='" + ordre + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";




                        ExecuteNonQuery(query, con);



                    //    LogColis(con, codesoc, numbon, livreur, ordre, "", "", "TOURNEE", "", "");



                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {

                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }
        public string PDA_livraisonOK(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;


                    con = new SqlConnection(stConnString);
                    con.Open();

                    ExecuteNonQuery("BEGIN TRANSACTION", con);

                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon == "") break;
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string etat = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string manu = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string date = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string codeenlevement = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string motif = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string avis = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string colislat = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string colislon = GiveFldEx(packagecolis, ++y, ";", "finn");



                        // Information param motif 
                        string motifcode = motif;
                        if (motifcode != "")
                        {
                            string select4 = "select *  from T_NEGOS_PARAMS where  prm_lbl='" + motif + "' and prm_soccode='" + codesoc + "' and prm_table='MOTIFLIVR' ";
                            DataTable dt4 = GetData(stConnString, select4);
                            if (dt4.Rows.Count > 0)
                            {

                                motifcode = dt4.Rows[0]["prm_coderec"].ToString();

                            }
                        }

                        // Information distri_user 
                        string loginimport = livreur;
                        string select3 = "select *  from distrib_users where id='" + livreur + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();

                        }

                        string query = "";

                        if (etat == "1")
                        {
                            query = "update kems_data set val_data33=0, dat_data20='" + controlFld(motif) + "', val_data32={ fn IFNULL(val_data32, 0) }+1, vis_code='" + codeenlevement + "',dat_data16='" + date + "', dat_data23='" + etat + "', dat_data24='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                        }
                        else
                        {
                            if (avis=="1")
                                query = "update kems_data set val_data33=" + avis + ", dat_data20='" + controlFld(motif) + "', val_data32={ fn IFNULL(val_data32, 0) }+1, vis_code='" + codeenlevement + "',  dat_data23='" + etat + "', dat_data24='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                            else
                                query = "update kems_data set val_data33=0, dat_data20='" + controlFld(motif) + "', val_data32={ fn IFNULL(val_data32, 0) }+1, vis_code='" + codeenlevement + "',dat_data16='" + date + "', dat_data23='" + etat + "', dat_data24='" + manu + "',dat_data51='" + loginimport + "',dat_idx04='" + livreur + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                     
                        }
                        Log(query, numbon+"_PDA_livraisonOK", "", login);


                        ExecuteNonQuery(query, con);

                        //ROUTE IMPRATICABLE /
                        if ((motifcode == "ROUTE IMPRATICABLE /" || motif == "ROUTE IMPRATICABLE / ACCES IMPOSSIBLE en LIVRAISON"))
                        {
                            query = "update kems_data set dat_data20='ROUTE IMPRATICABLE / ACCES IMPOSSIBLE en LIVRAISON', cde_code='" + codeenlevement + "',dat_data16='',  dat_data23='A', dat_data24='',dat_data25='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "'   ";
                            
                           // Log(query, numbon + "_PDA_livraisonOK_routeimpraticable", "", login);
                            ExecuteNonQuery(query, con);
                        }

                       

                        //FERME - CONGES
                        if (motifcode == "FERME - CONGES")
                        {
                            query = "update kems_data set dat_data23= null, dat_data16= null,dat_data24= null, val_data32= null,val_data33= null, vis_code='" + codeenlevement + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                          //  Log(query, numbon + "_PDA_livraisonOK_ferme", "", login);
                            ExecuteNonQuery(query, con);
                        }

                        //OUVERTURE TARDIVE
                        if (motifcode == "OUVERTURE TARDIVE")
                        {
                            query = "update kems_data set dat_data23= null, dat_data16= null,dat_data24= null, val_data32= null,val_data33= null, vis_code='" + codeenlevement + "',dat_data26='" + livreur + "' where dat_type=402 and soc_code='" + codesoc + "' and dat_idx01='" + numbon + "' ";
                         //   Log(query, numbon + "_PDA_livraisonOK_ouverturetardive", "", login);
                            ExecuteNonQuery(query, con);
                        }




                        //si enlevement pas ok on log l'action
                         
                            if (avis=="1") motif="Avis de passage";

                        LogColisLatLon(con, codesoc, numbon, livreur, date, motif, etat, "DELIVERY", manu, codeenlevement,colislat,colislon);
                           
                       

                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {
                    
                   // Log(ex.Message + "", "error_PDA_livraisonOK", "", login);

                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }
        void LogColis(SqlConnection con, string codesoc, string numbon, string livreur, string date, string motif, string etat, string action, string manu, string codeenlevement)
        {
            string query = @"INSERT INTO  [T_NEGOS_LOGCOLIS]
                                   ([soc_code]
                                   ,[numcolis]
                                   ,[livreur]
                                   ,[datepassage]
                                   ,[motif]
                                    ,[etat]
                                   ,[action]
                                    ,[manu]
                                    ,codeaction
                                   ,[commentaire])
                             VALUES
                                   ('" + controlFld(codesoc) + @"'
                                   ,'" + controlFld(numbon) + @"'
                                   ,'" + controlFld(livreur) + @"'
                                   ,'" + date + @"'
                                   ,'" + controlFld(motif) + @"'
                                  ,'" + controlFld(etat) + @"'
                                   ,'" + action + @"'
                                    ,'" + controlFld(manu) + @"'
                                    ,'" + controlFld(codeenlevement) + @"'
                                   ,'')";

            ExecuteNonQuery(query, con);
        }
        void LogColisLatLon(SqlConnection con, string codesoc, string numbon, string livreur, string date, string motif, string etat, string action, string manu, string codeenlevement,string lat,string lon)
        {
            string query = @"INSERT INTO  [T_NEGOS_LOGCOLIS]
                                   ([soc_code]
                                   ,[numcolis]
                                   ,[livreur]
                                   ,[datepassage]
                                   ,[motif]
                                    ,[etat]
                                   ,[action]
                                    ,[manu]
                                    ,codeaction
                                    ,[lat]
                                    ,[lon]
                                   ,[commentaire]
                                    
                                    )
                             VALUES
                                   ('" + controlFld(codesoc) + @"'
                                   ,'" + controlFld(numbon) + @"'
                                   ,'" + controlFld(livreur) + @"'
                                   ,'" + date + @"'
                                   ,'" + controlFld(motif) + @"'
                                  ,'" + controlFld(etat) + @"'
                                   ,'" + action + @"'
                                    ,'" + controlFld(manu) + @"'
                                    ,'" + controlFld(codeenlevement) + @"'
                                    ,'" + controlFld(lat) + @"'
                                    ,'" + controlFld(lon) + @"'
                                   ,'')";

            Log(query, "", "logcolis", "test");
            ExecuteNonQuery(query, con);
        }
        public string PDA_chargementSignature(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;


                    con = new SqlConnection(stConnString);
                    con.Open();

                    ExecuteNonQuery("BEGIN TRANSACTION", con);

                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" ||  numbon=="") break;
                        string signataire = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string fichier = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string datecharg = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string nbcolis = GiveFldEx(packagecolis, ++y, ";", "0");

                        int brese = 0;

                        string select = @"SELECT count(*) FROM kems_data where dat_type=403 and soc_code='" + codesoc + "' and cde_code='" + numbon + "' and val_data31='" + nbcolis + "' ";
                        Boolean bres=false;
                        brese = ExecuteNonQuery2(select, con);
                        if (brese > 0)
                        {
                            bres = true;
                        }
                        else
                            bres = false;
                      //  ExecuteNonQuery("COMMIT TRANSACTION", con);
                        string query = "";
                        if(bres==false)
                        {
                            query = "insert into kems_data (dat_type,soc_code,cde_code,dat_data08,dat_data09,dat_data14,val_data31,dat_idx01) values (403," +
                             "'" + codesoc + "'," +
                             "'" + numbon + "'," +
                             "'" + controlFld(signataire) + "'," +
                             "'" + controlFld(fichier) + "'," +
                             "'" + controlFld(datecharg) + "'," +
                             "'" + nbcolis + "'," +
                             "'" + controlFld(livreur) + "')";
                            Log(query, numbon + "_PDA_chargementSignature", "", login);
                            ExecuteNonQuery(query, con);
                           
                        }


                        //query = "update kems_data set dat_idx08='"+nbcolis+"' where dat_type=402 and cde_code='"+numbon+"'";
                        //ExecuteNonQuery(query, con);

                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {
                   // Log(ex.Message+"",  "error_PDA_chargementSignature", "", login);
                    
                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }

        public string PDA_livraisonSignature(string login, string pwd, string mac, string numbons)
        {
            string stConnString = Auth_PDA(login, pwd, mac);
            string codesoc = GiveFld(stConnString, 0, "|");
            codesoc = "23";
            stConnString = GiveFld(stConnString, 1, "|");
            if (stConnString != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;


                    con = new SqlConnection(stConnString);
                    con.Open();

                    ExecuteNonQuery("BEGIN TRANSACTION", con);

                    int i = 0;
                    do
                    {
                        string packagecolis = GiveFldEx(numbons, i, "|", "finn");

                        int y = 0;
                        string numbon = GiveFldEx(packagecolis, y, ";", "finn");
                        if (numbon == "finn" || numbon == "") break;
                        string signataire = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string fichier = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string datecharg = GiveFldEx(packagecolis, ++y, ";", "finn");
                        string livreur = GiveFldEx(packagecolis, ++y, ";", "finn");

                        string query = "insert into kems_data (dat_type,soc_code,cde_code,dat_data08,dat_data09,dat_data14,dat_idx01) values (404," +
                            "'" + codesoc + "'," +
                            "'" + numbon + "'," +
                            "'" + controlFld(signataire) + "'," +
                            "'" + controlFld(fichier) + "'," +
                            "'" + controlFld(datecharg) + "'," +
                            "'" + controlFld(livreur) + "')";
                        Log(query, numbon+"_PDA_livraisonSignature", "", login);
                        ExecuteNonQuery(query, con);
                    

                        i++;
                    } while (1 == 1);
                    ExecuteNonQuery("COMMIT TRANSACTION", con);
                    con.Close();

                }
                catch (Exception ex)
                {
                   // Log(ex.Message + "", "error_PDA_livraisonSignaturee", "", login);
                    return "err:" + ex.Message;
                }

                return "";
            }
            return "err";
        }
    };
}
