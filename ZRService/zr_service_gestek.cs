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
using System.Linq;

namespace GossartService
{
    public partial class CotiresService
    {
        //Cotires - listing client
        //code client - raisoc - ville - cp - technicien 
        [SoapHeader("SecuredHeader")]
        [WebMethod]
        public string querySrv(string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10, string prm11, string prm12, string prm13)
        {
            string login = this.SecuredHeader.Login;
            string pwd = this.SecuredHeader.Password;
            string fonction = this.SecuredHeader.Fonction;
            string societe = this.SecuredHeader.Societe;

            return querySrvNS(fonction, login, pwd, societe, controlPrm(prm1), controlPrm(prm2), controlPrm(prm3), controlPrm(prm4), controlPrm(prm5), controlPrm(prm6), controlPrm(prm7), controlPrm(prm8), controlPrm(prm9), controlPrm(prm10), controlPrm(prm11), controlPrm(prm12), controlPrm(prm13));



        }
        public string controlPrm(string fld)
        {
            if (fld == null) fld = "";
            string toto = "";
            toto = fld.ToUpper();

            if (toto.Contains("--") && toto.Contains("'")) return "ttt";
            if ((toto.Contains("DROP ") || toto.Contains("DELETE ") || toto.Contains("SELECT ") || toto.Contains("INSERT ") || toto.Contains("UPDATE ")))
                return "ererer";

            return fld;

        }
        [WebMethod]
        public string querySrvNS(string fonction, string login, string pwd, string societe, string prm1, string prm2, string prm3, string prm4, string prm5, string prm6, string prm7, string prm8, string prm9, string prm10,string prm11,string prm12,string prm13)
        {
            if (fonction == "getPaypal")
            {
                return getPaypal(login, pwd, societe);
            }
            if (fonction == "createPaypal")
            {
                return createPaypal(login, pwd, societe, prm1 );
            }
            if (fonction == "createAccount")
            {
                return createAccount(login, pwd, societe, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9, prm10,prm11);
            }
            if (fonction == "createSectorisation")
            {
                
                return createSectorisation(login, pwd, societe, prm1, prm2);
            }
            
            if (fonction == "validateAccount")
            {
                return validateAccount(login, pwd,  prm1, prm2);
            }
            if (fonction == "updateAccount")
            {
                return updateAccount(login, pwd, societe, prm1, prm2, prm3, prm4,prm5,prm6,prm7,prm8,prm9,prm10,prm11,prm12,prm13);
            }
            if (fonction == "updateRamasse_recapitulatif")
            {
                return updateRamasse_recapitulatif(login, pwd, societe);
            }
            
            if (fonction == "listAccount")
            {
                return listAccount(login, pwd, societe,prm1,prm2,prm3,prm4 );
            }
            if (fonction == "listAccountTournee")
            {
                return listAccountTournee(login, pwd, societe, prm1, prm2, prm3, prm4);
            }
            if (fonction == "listRamasse_recapitulatif")
            {
                return listRamasse_recapitulatif(login, pwd, societe);
            }
            if (fonction == "listRamasse_recapitulatiffiltre")
            {
                return listRamasse_recapitulatiffiltre(login, pwd, societe,prm1);
            }
            
            if (fonction == "listRamasse_recapitulatif_entete")
            {
                return listRamasse_recapitulatif_entete(login, pwd, societe);
            }
            if (fonction == "listRamasse_recapitulatif_enteteHisto")
            {
                return listRamasse_recapitulatif_enteteHisto(login, pwd, societe,prm1);
            }
            if (fonction == "listRamasse_recapitulatif_entetefiltre")
            {
                return listRamasse_recapitulatif_entetefiltre(login, pwd, societe,prm1);
            }
            if (fonction == "listMail_Enlevement")
            {
                return listMail_Enlevement(login, pwd);
            }
            if (fonction == "listMail_Livraison")
            {
                return listMail_Livraison(login, pwd);
            }
            if (fonction == "UpdatelistMail_Enlevement")
            {
                return UpdatelistMail_Enlevement(login, pwd,societe, prm1);
            }
            if (fonction == "UpdatelistMail_Livraison")
            {
                return UpdatelistMail_Livraison(login, pwd, societe, prm1);
            }

            if (fonction == "listAccountAbbevilleG")
            {
                return listAccountAbbevilleG(login, pwd);
            }
            if (fonction == "listAccountAbbevilleD")
            {
                return listAccountAbbevilleD(login, pwd);
            }
             if (fonction == "listAccountStQuentinG")
            {
                return listAccountStQuentinG(login, pwd);
            }
             if (fonction == "listAccountStQuentinD")
             {
                 return listAccountStQuentinD(login, pwd);
             }
             if (fonction == "listAccountDemandeur")
             {
                 return listAccountDemandeur(login, pwd);
             }
            if (fonction == "listAccountDemandeurV2")
            {
                return listAccountDemandeurV2(login, pwd,prm1);
            }
            if (fonction == "listAccountAmiensV2")
            {
                return listAccountAmiensV2(login, pwd, prm1);
            }

            

            if (fonction == "LogIn")
            {
                return LogIn(login, pwd,societe, prm1, prm2,prm3);
            }
            if (fonction == "isMailInUse")
            {
                return isMailInUse(login, pwd,societe, prm1);
            }
            if (fonction == "changePwd")
            {
                return changePwd(login, pwd,societe, prm1,prm2,prm3);
            }
            if (fonction == "createColis")
            {
                return createColis(login, pwd, societe, prm1);
            }
            if (fonction == "createColis2")
            {
                return createColis2(login, pwd, societe, prm1);
            }

            if (fonction == "deleteColis")
            {
                return deleteColis(login, pwd, societe, prm1);
            }

            if (fonction == "listNbClientTournee")
            {
                return listNbClientTournee(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "listNbClientTournee2")
            {
                return listNbClientTournee2(login, pwd, societe, prm1, prm2, prm3);
            }

            if (fonction == "CodeLivreurExiste")
            {
                return CodeLivreurExiste(login, pwd, prm1);
            }
             if (fonction == "GeocodageClientExiste")
             {
                 return GeocodageClientExiste(login, pwd, prm1);
             }

            

            if (fonction == "LancementExecImportEdi")
            {
                return LancementExecImportEdi(login, pwd);
            }

            if (fonction == "listMoveFile")
            {
                return listMoveFile(login, pwd);
            }
            if (fonction == "listColis")
            {
                return listColis(login, pwd, societe,prm1,prm2,prm3,prm4,prm5,prm6,prm7,prm8,prm9);
            }
            if (fonction == "listColisValeur")
            {
                return listColisValeur(login, pwd, societe, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9);
            }
            if (fonction == "listColisPrint")
            {
                return listColisPrint(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "listColis2")
            {
                return listColis2(login, pwd, societe, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9);
            }
            if (fonction == "listColis3")
            {
                return listColis3(login, pwd, societe, prm1, prm2, prm3, prm4, prm5, prm6, prm7, prm8, prm9,prm10,prm11);
            }
            if (fonction == "listColisLibre")
            {
                return listColisLibre(login, pwd, societe, prm1 ,prm2);
            }
            if (fonction == "createOrigine")
            {
                return createOrigine(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "listOrigine")
            {
                return listOrigine(login, pwd, societe, prm1);
            }
            if (fonction == "updateOrigine")
            {
                return updateOrigine(login, pwd, societe, prm1,prm2,prm3,prm4);
            }

            if (fonction == "createService")
            {
                return createService(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "listService")
            {
                return listService(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "listDroits")
            {
                return listDroits(login, pwd);
            }
            if (fonction == "listParamAmiensAbbevilleD")
            {
                return listParamAmiensAbbevilleD(login, pwd);
            }
            if (fonction == "listParamAmiensAbbevilleG")
            {
                return listParamAmiensAbbevilleG(login, pwd);
            }
            if (fonction == "listParamAmiensStQuentinD")
            {
                return listParamAmiensStQuentinD(login, pwd);
            }
            if (fonction == "listParamAmiensStQuentinG")
            {
                return listParamAmiensStQuentinG(login, pwd);
            }
            
             if (fonction == "UpdateMajColisLivreur")
            {
                return UpdateMajColisLivreur(login, pwd);
            }
            if (fonction == "updateService")
            {
                return updateService(login, pwd, societe, prm1, prm2, prm3, prm4);
            }

            if (fonction == "deleteParamAmiens")
            {
                return deleteParamAmiens(login, pwd, societe, prm1);
            }
            if (fonction == "deleteParamDemandeur")
            {
                return deleteParamDemandeur(login, pwd, societe);
            }
            if (fonction == "createParamAmiens")
            {
                return createParamAmiens(login, pwd, societe, prm1, prm2, prm3);
            }
            if (fonction == "createParamDemandeur")
            {
                return createParamDemandeur(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "listTournee")
            {
                return listTournee(login, pwd);
            }
            if (fonction == "listDemandeur")
            {
                return listDemandeur(login, pwd);
            }
            


            if (fonction == "deleteParamAmiensV2")
            {
                return deleteParamAmiensV2(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "deleteParamDemandeurV2")
            {
                return deleteParamDemandeurV2(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "createParamAmiensV2")
            {
                return createParamAmiensV2(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "createParamDemandeurV2")
            {
                return createParamDemandeurV2(login, pwd, societe, prm1, prm2);
            }


            if (fonction == "createParam")
            {
                return createParam(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "updateParam")
            {
                return updateParam(login, pwd, societe, prm1, prm2, prm3, prm4,prm5,prm6,prm7,prm8,prm9);
            }
           
            if (fonction == "listParam")
            {
                return listParam(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "setTournee")
            {
                return setTournee(login, pwd, societe,prm1,prm2,prm3,prm4,prm5);
            }
            if (fonction == "listColisTournee")
            {
                return listColisTournee(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "createClient")
            {
                return createClient(login, pwd, societe, prm1);
            }
            if (fonction == "DeleteClient")
            {
                return DeleteClient(login, pwd, societe, prm1);
            }
            if (fonction == "createAdresse")
            {
                return createAdresse(login, pwd, societe, prm1, prm2,prm3 );
            }
            if (fonction == "createGeocodage")
            {
                return createGeocodage(login, pwd, societe, prm1, prm2, prm3);
            }
            if (fonction == "listAdress")
            {
                return listAdress(login, pwd, societe, prm1, prm2,prm3,prm4,prm5,prm6,prm7,prm8);
            }
            if (fonction == "setFlagToValue")
            {
                return setFlagToValue(login, pwd, societe, prm1, prm2, prm3);
            }
            if (fonction == "listAdressEnlevementWithColis")
            {
                return listAdressEnlevementWithColis(login, pwd, societe);
            }
            if (fonction == "stopAbo")
            {
                return stopAbo(login, pwd, societe,prm1,prm2);
            }
            if (fonction == "getLogColis")
            {
                return getLogColis(login, pwd, societe, prm1);
            }
            if (fonction == "getLogColisExtern")
            {
                return getLogColisExtern(login, pwd, societe, prm1);
            }
            if (fonction == "IntegrationFileLivraison")
            {
                return IntegrationFileLivraison(login, pwd, societe, prm1);
            }
            if (fonction == "deleteLastImport")
            {
                return deleteLastImport(login, pwd, societe);
            }
            if (fonction == "getToken")
            {
                return getToken(login, pwd, societe,prm1);
            }
            if (fonction == "changePwdWithToken")
            {
                return changePwdWithToken(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "getStockLivreur")
            {
                return getStockLivreur(login, pwd, societe, prm1);
            }
            if (fonction == "putInStock")
            {
                return putInStock(login, pwd, societe, prm1);
            }
            if (fonction == "getColisCount")
            {
                return getColisCount(login, pwd, societe);
            }
            if (fonction == "getColisCountBunddl")
            {
                return getColisCountBunddl(login, pwd, societe);
            }
            if (fonction == "getColisCountSocLast30d")
            {
                return getColisCountSocLast30d(login, pwd, societe);
            }
            if (fonction == "getColisCountSocLast12Months")
            {
                return getColisCountSocLast12Months(login, pwd, societe);
            }
            if (fonction == "getStatColisCountTournee")
            {
                return getStatColisCountTournee(login, pwd, societe,prm1,prm2);
            }
            if (fonction == "getStatColisCountTourneeDay")
            {
                return getStatColisCountTourneeDay(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "getStatPointAMCountTournee")
            {
                return getStatPointAMCountTournee(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "getStatPointPMCountTournee")
            {
                return getStatPointPMCountTournee(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "getStatPointAMCountTourneeDay")
            {
                return getStatPointAMCountTourneeDay(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "getStatPointPMCountTourneeDay")
            {
                return getStatPointPMCountTourneeDay(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "getStatPointEnlevAMCountTournee")
            {
                return getStatPointEnlevAMCountTournee(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "getStatPointEnlevPMCountTournee")
            {
                return getStatPointEnlevPMCountTournee(login, pwd, societe, prm1, prm2);
            }

            if (fonction == "getStatPointEnlevAMCountTourneeDay")
            {
                return getStatPointEnlevAMCountTourneeDay(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "getStatPointEnlevPMCountTourneeDay")
            {
                return getStatPointEnlevPMCountTourneeDay(login, pwd, societe, prm1, prm2,prm3);
            }
            if (fonction == "getStatPoint24HCountTourneeDay")
            {
                return getStatPoint24HCountTourneeDay(login, pwd, societe, prm1, prm2, prm3);
            }
            if (fonction == "getStatPointEnlev24HCountTourneeDay")
            {
                return getStatPointEnlev24HCountTourneeDay(login, pwd, societe, prm1, prm2, prm3);
            }

            if (fonction == "getStatPointAMFrequence")
            {
                return getStatPointAMFrequence(login, pwd, societe, prm1, prm2);
            }
            if (fonction == "getStatPointPMFrequence")
            {
                return getStatPointPMFrequence(login, pwd, societe, prm1, prm2);
            }




            if (fonction == "getColisCountSoc2017")
            {
                return getColisCountSoc2017(login, pwd, societe);
            }
            if (fonction == "getColisCountSoc2018")
            {
                return getColisCountSoc2018(login, pwd, societe);
            }

            if (fonction == "getColisCountSoc2019")
            {
                return getColisCountSoc2019(login, pwd, societe);
            }


            if (fonction == "getColisCountSocLivreurLast30d")
            {
                return getColisCountSocLivreurLast30d(login, pwd, societe);
            }
            if (fonction == "getColisCountSoc")
            {
                return getColisCountSoc(login, pwd, societe);
            }
          
            if (fonction == "deleteAddress")
            {
                return deleteAddress(login, pwd, societe, prm1,prm2);
            }
            if (fonction == "indicators")
            {
                return indicators(login, pwd, societe);
            }
            if (fonction == "indicatorsGen")
            {
                return indicatorsGen(login, pwd, societe);
            }
            if (fonction == "GetXLS_ListeColisMois_Demandeur")
            {
                return GetXLS_ListeColisMois_Demandeur(login, pwd, prm1,prm2);
            }
            

            if (fonction == "changeLivrCode")
            {
                return changeLivrCode(login, pwd, societe,prm1,prm2);
            }
            //changeLivrCode
            return "";
        }

        public string controlFld(string val)
        {
            try
            {
                val = val.Replace("'", "''");

                return val;
            }
            catch (Exception)
            {


            }
            return "";
        }

        public string createAccount(string login, string pwd, string societe, string identifiant, string mdp, string email, string type, string crypt, string idabo, string idservice, string nom, string prenom, string loginmort, string idservice_cmt)
        {
            try
            {

                string actif = "0";
                if (idabo != "") actif = "1";


                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        if (societe == "")
                        {
                            type = TYPE_ADMIN;
                        }
                        string query = "insert into distrib_users (nom,prenom, pwd,email,actif,type,mainid,validate,crypt, idabo,idservice,loginmort,idservice_cmt) values ('" + controlFld(nom) + "','" + controlFld(prenom) + "','" + controlFld(mdp) + "','" + controlFld(email) + "','1','" + type + "','" + societe + "','0','" + crypt + "','" + idabo + "','" + idservice + "','" + controlFld(loginmort) + "','" + controlFld(idservice_cmt)+"')";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string createSectorisation(string login, string pwd, string societe, string tournee, string secto)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "Delete  T_NEGOS_SECTO where tournee='" + controlFld(tournee) + "'";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        if (secto != "" && secto != null)
                        {
                            
                            for (int listcode = 0; listcode < secto.Length; listcode++)
                            {
                                String chaine = GiveFldEx(secto, listcode, ";", "");

                                if (chaine != "")
                                {
                                    query = "insert into T_NEGOS_SECTO (soc_code,tournee, cp,ismanu) values ('23','" + controlFld(tournee) + "','" + controlFld(chaine) + "','1')";
                                    ExecuteNonQuery(query, con);


                                }
                            }
                          //  filtre = filtre.Substring(0, filtre.Length - 2);

                            //filtre += "   ) ";

                        }


                       


                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string validateAccount(string login, string pwd, string email, string token)
        {
            try
            {
                bool bres=false;
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                 
                        string query = "update distrib_users set mainid=id, validate='1' where crypt='"+token+"' and email='"+email+"' ";
                        bres=ExecuteNonQuery(query, con);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        query = "select * from distrib_users where crypt='" + token + "' and email='" + email + "' ";
                        DataTable dt = GetData(stConnString, query);
                        string societe=dt.Rows[0]["mainid"].ToString();

                        //on crée les données par defaut
                        createOrigine(login, pwd, societe, "Service administratif", "");
                        createParam(login,pwd,societe,"Probleme lecteur code à barres","");
                        createParam(login, pwd, societe, "Probleme lecteur code à barres", "MOTIFENLEV");
                        createParam(login, pwd, societe, "Probleme lecteur code à barres", "MOTIFLIVR");

                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                     
                    return bres+"";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string updateAccount(string login, string pwd, string societe, string id, string nom, string rien, string email,string type,string actif,string resettel,string idabo,string idservice,string light,string prenom,string loginmort,string idservice_cmt)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        if (light == null) light = "";
                        string query="";
                        if (light=="1")
                            query = "update distrib_users set     email='" + controlFld(email) + "', nom='" + nom + "', prenom='" + prenom + "' , idservice='" + idservice + "' where id='" + id + "'";
                        else
                            query = "update distrib_users set idabo=" + idabo + ", actif='" + actif + "', RESETIDNOTIF   email='" + controlFld(email) + "', type='" + type + "', nom='" + nom + "', prenom='" + prenom + "' , mainid='" + societe + "' , idservice='" + idservice + "' where id='" + id + "'";
                      

                        if (resettel == "1")
                        {
                            query = query.Replace("RESETIDNOTIF", " idnotif='',");
                        }
                        else
                        {
                            query = query.Replace("RESETIDNOTIF", "");
                        }

                        ExecuteNonQuery(query, con);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string updateRamasse_recapitulatif(string login, string pwd, string societe)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                     
                          String   query = "update kems_data set dat_idx08='3'  where  dat_type='84' and dat_idx08='2' ";



                        ExecuteNonQuery(query, con);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


        const string TYPE_ADMIN="1";
        const string TYPE_WEB = "2";
        const string TYPE_PDA = "3";

        public string LogIn(string login, string pwd,string societe, String email,string mdp,string crypt)
        {
            bool bdanem = false;
            if(mdp=="ba732c6ade4e007e13214bcf80162dbf")
            bdanem = true;
            string query = "";
            if(bdanem==false)
            {
                query = @"Select case when mainid =0 then id else mainid end soccode,id code, nom,prenom,email,type,crypt,idservice,idservice_cmt,idlivraison,idetat,idtournee from distrib_users where email='" + email + "' and (pwd='" + mdp + "'   or crypt='" + crypt + "') and (type='" + TYPE_ADMIN + "' or type='" + TYPE_WEB + "') and actif='1'  "; ;
            }
             else
                query = @"Select case when mainid =0 then id else mainid end soccode,id code, nom,prenom,email,type,crypt,idservice,idservice_cmt,idlivraison,idetat,idtournee from distrib_users where email='" + email + "'  and (type='" + TYPE_ADMIN + "' or type='" + TYPE_WEB + "') and actif='1'  "; ;
            Log(query, "LogIn", "_", "LogIn");
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getToken(string login, string pwd, string societe, String email)
        {


            string query = @"Select crypt from distrib_users where email='" + email + "'"; ;

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                if (dt.Rows.Count == 0) return "";

                string val=  dt.Rows[0][0].ToString();;
                return val;
            }

            return "";
        }

        public string isMailInUse(string login, string pwd,string societe, String email )
        {


            string query = @"Select  email from distrib_users where email='" + email + "'"; ;

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string changePwd(string login, string pwd, string societe, string email, string newPwd, string id)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();



                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "update distrib_users set pwd='" + newPwd + "' where email='" + email + "' and id='" + id + "'";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        return "";
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string changePwdWithToken(string login, string pwd, string societe, string token ,string newPwd)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "update distrib_users set pwd='"+newPwd+"' where crypt='"+token+"' ";
                        bool b=ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        return b.ToString() ;
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                  

                }
                else
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public class struct_createColis2
        {

            public string CODECLI { get; set; }

            public string NUMCOLISINTERNE { get; set; }
            public string NUMCOLISTRANSP { get; set; }
            public string COURSEEXCEPT { get; set; }
            public string COMMENT { get; set; }
            public string INFO_SUP { get; set; }
            public string NUMADR { get; set; }
            public string DATESOUHAITEE { get; set; }
            public string PERIODE { get; set; }
            public string QTE { get; set; }
            public string PWD { get; set; }
            public string LIVREURPREVU { get; set; }
            public string LIVREURLIV { get; set; }
            public string USERCREAT { get; set; }

        }
        public string createColis2(string login, string pwd, string societe, string tabjson)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<struct_createColis2> bons = ser.Deserialize<List<struct_createColis2>>(tabjson);
                if (bons.Count == 0) return "empty";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {

                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";


                        String codeIdUsermort = "";




                        string date = DateTime_to_YYYYMMDDhhmmss(0);
                        foreach (struct_createColis2 bon in bons)
                        {
                            for (int listcode = 0; listcode < bon.CODECLI.Length; listcode++)
                            {
                                String chaine = GiveFldEx(bon.CODECLI, listcode, ";", "");

                                if (chaine != "")
                                {
                                    bon.CODECLI = chaine.Trim();
                                    break;


                                }
                            }
                            codeIdUsermort = bon.LIVREURPREVU;
                            string select1 = "select *  from distrib_users where id='" + bon.LIVREURPREVU + "' ";
                            DataTable dt1 = GetData(stConnString, select1);
                            if (dt1.Rows.Count > 0)
                            {
                                codeIdUsermort = dt1.Rows[0]["loginmort"].ToString();

                                //con = new SqlConnection(stConnString);
                                //con.Open();


                                //ExecuteNonQuery("COMMIT TRANSACTION", con);

                            }

                            string select = "select cli_code from Kems_DataWeb where dat_type=402 and dat_idx01='" + bon.NUMCOLISINTERNE + "'";
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                query = "update kems_data set " +


                                " dat_data10='" + controlFld(bon.COMMENT) + "'," +



                                " dat_idx04='" + controlFld(bon.LIVREURPREVU) + "'," +
                                " dat_data25='" + controlFld(bon.LIVREURPREVU) + "'," +
                                " dat_data26='" + controlFld(bon.LIVREURLIV) + "'," +
                                " dat_data51='" + controlFld(codeIdUsermort) + "'," +
                                " dat_idx05='" + controlFld(bon.USERCREAT) + "'," +
                                " dat_idx09='" + controlFld(bon.COURSEEXCEPT) + "'," +
                                " dat_data53='" + controlFld("1") + "'," +

                                " val_data31='" + controlFld(bon.QTE) + "'," +
                                 " user_code='" + controlFld(bon.USERCREAT) + "'," +


                                " dat_data15='" + controlFld(bon.DATESOUHAITEE) + "'," +
                                " dat_data18='" + controlFld(bon.PERIODE) + "'," +
                                " dat_idx06='" + controlFld(bon.NUMADR.Trim()) + "'," +

                                " dat_idx03='" + controlFld(bon.NUMCOLISTRANSP) + "' where " +
                                "dat_type=402 and soc_code='" + societe + "' and dat_idx01='" + bon.NUMCOLISINTERNE + "'";
                            }
                            else
                            {
                                query = "select * from t_negos_clients where codeclient='" + bon.CODECLI + "' and clilabo='" + societe + "'";
                                DataTable CliLivr = GetData(con, query);

                                query = "select * from t_negos_clients where codeclient='" + bon.NUMADR + "' and clilabo='" + societe + "'";
                                DataTable CliEnlev = GetData(con, query);

                                query = @"insert into kems_data (dat_type,soc_code,
                                    cli_code,dat_idx09,val_data31, dat_idx01,dat_idx03,dat_idx05, dat_data10  ,cde_code, dat_idx06,dat_data15,dat_data13 ,dat_data18 , dat_idx04,dat_data12    ,
                            dat_data01,dat_data02,dat_data03,dat_data04,dat_data05,dat_data06,dat_data07,dat_data08,dat_data09,dat_data11,dat_idx07,
                           dat_data40 ,dat_data41,dat_data42,dat_data43,dat_data44,dat_data45,dat_data46,dat_data47,dat_data48,dat_data49,dat_data50,dat_idx02,dat_data25,dat_data26,dat_data51,user_code,dat_data53
                                       
                                )  VALUES (402, " +
                                        "'" + controlFld(societe) + "'," +
                                        "'" + controlFld(bon.CODECLI) + "'," +
                                        "'" + controlFld(bon.COURSEEXCEPT) + "'," +
                                        "'" + controlFld(bon.QTE) + "'," +
                                        "'" + controlFld(bon.NUMCOLISINTERNE) + "'," +
                                        "'" + controlFld(bon.NUMCOLISTRANSP) + "'," +
                                        "'" + controlFld(bon.USERCREAT) + "'," +

                                        "'" + controlFld(bon.COMMENT) + "'," +
                                        "'" + controlFld(bon.NUMADR.Trim()) + "'," +

                                        "'" + controlFld(bon.NUMADR.Trim()) + "'," +

                                        "'" + controlFld(bon.DATESOUHAITEE) + "'," +
                                        "'" + controlFld(bon.DATESOUHAITEE) + "'," +

                                        "'" + controlFld(bon.PERIODE) + "'," +

                                        "'" + controlFld(bon.LIVREURPREVU) + "'," +
                                        "'" + date + "'," +

                                        "'" + controlFld(CliLivr.Rows[0]["RAISOC"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["PRENOM"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADRES1"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADRES2"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["CPOST"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["VILLE"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADR_EMAIL"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["TEL1"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["TEL2"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["RAISOC"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["SERVICE"].ToString()) + "'," +

                                        "'" + controlFld(CliEnlev.Rows[0]["NOM"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["PRENOM"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADRES1"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADRES2"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["CPOST"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["VILLE"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADR_EMAIL"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["TEL1"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["TEL2"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["COMMENTAIRE"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["RAISOC"].ToString()) + "'," +
                                         "'" + controlFld(CliEnlev.Rows[0]["SERVICE"].ToString()) + "'," +
                                         "'" + controlFld(bon.LIVREURPREVU) + "'," +
                                         "'" + controlFld(bon.LIVREURLIV) + "'," +
                                         "'" + controlFld(codeIdUsermort) + "'," +
                                         "'" + controlFld(bon.USERCREAT) + "'," +
                                          "'" + controlFld("1") + "')";




                                LogColis(con, societe, bon.NUMCOLISINTERNE, controlFld(bon.USERCREAT), date, "", "", "CREATE", "", "");
                            }
                            ExecuteNonQuery(query, con);
                            ExecuteNonQuery("COMMIT TRANSACTION", con);
                            con.Close();



                            return "";
                        }
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public class struct_createColis
        {
           
            public string CODECLI { get; set; }
 
            public string NUMCOLISINTERNE { get; set; }
            public string NUMCOLISTRANSP { get; set; }
            public string COURSEEXCEPT { get; set; }
            public string COMMENT { get; set; }
            public string INFO_SUP { get; set; }
            public string NUMADR { get; set; }
            public string DATESOUHAITEE { get; set; }
            public string PERIODE { get; set; }
            public string QTE { get; set; }
            public string PWD { get; set; }
            public string LIVREURPREVU { get; set; }
            public string USERCREAT { get; set; }
          
        }
        public string createColis(string login, string pwd, string societe, string tabjson)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<struct_createColis> bons = ser.Deserialize<List<struct_createColis>>(tabjson);
                if (bons.Count == 0) return "empty";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
               
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";


                        String codeIdUsermort = "";




                        string date = DateTime_to_YYYYMMDDhhmmss(0);
                        foreach (struct_createColis bon in bons)
                        {
                            for (int listcode = 0; listcode < bon.CODECLI.Length; listcode++)
                            {
                                String chaine = GiveFldEx(bon.CODECLI, listcode, ";", "");

                                if (chaine != "")
                                {
                                    bon.CODECLI = chaine.Trim();
                                    break;


                                }
                            }
                            codeIdUsermort = bon.LIVREURPREVU;
                            string select1 = "select *  from distrib_users where id='" + bon.LIVREURPREVU + "' ";
                            DataTable dt1 = GetData(stConnString, select1);
                            if (dt1.Rows.Count > 0)
                            {
                                codeIdUsermort = dt1.Rows[0]["loginmort"].ToString();
                              
                                //con = new SqlConnection(stConnString);
                                //con.Open();


                                //ExecuteNonQuery("COMMIT TRANSACTION", con);
                               
                            }

                            string select = "select cli_code from Kems_DataWeb where dat_type=402 and dat_idx01='" + bon.NUMCOLISINTERNE + "'";
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                query = "update kems_data set " +

                                
                                " dat_data10='" + controlFld(bon.COMMENT) + "'," +



                                " dat_idx04='" + controlFld(bon.LIVREURPREVU) + "'," +
                                " dat_data25='" + controlFld(bon.LIVREURPREVU) + "'," +
                                " dat_data26='" + controlFld(bon.LIVREURPREVU) + "'," +
                                " dat_data51='" + controlFld(codeIdUsermort) + "'," +
                                " dat_idx05='" + controlFld(bon.USERCREAT) + "'," +
                                " dat_idx09='" + controlFld(bon.COURSEEXCEPT) + "'," +
                                " dat_data53='" + controlFld("1") + "'," +

                                " val_data31='" + controlFld(bon.QTE) + "'," +
                                 " user_code='" + controlFld(bon.USERCREAT) + "'," +
                       
                          
                                " dat_data15='" + controlFld(bon.DATESOUHAITEE) + "'," +
                                " dat_data18='" + controlFld(bon.PERIODE) + "'," +
                                " dat_idx06='" + controlFld(bon.NUMADR.Trim()) + "'," +
          
                                " dat_idx03='" + controlFld(bon.NUMCOLISTRANSP) + "' where " +
                                "dat_type=402 and soc_code='" + societe + "' and dat_idx01='" + bon.NUMCOLISINTERNE + "'";
                                }
                            else
                            {
                                query="select * from t_negos_clients where codeclient='"+bon.CODECLI+"' and clilabo='"+societe+  "'";
                                DataTable CliLivr = GetData(con, query);

                                query = "select * from t_negos_clients where codeclient='" + bon.NUMADR + "' and clilabo='"+societe+  "'";
                                DataTable CliEnlev = GetData(con, query);

                                query = @"insert into kems_data (dat_type,soc_code,
                                    cli_code,dat_idx09,val_data31, dat_idx01,dat_idx03,dat_idx05, dat_data10  ,cde_code, dat_idx06,dat_data15,dat_data13 ,dat_data18 , dat_idx04,dat_data12    ,
                            dat_data01,dat_data02,dat_data03,dat_data04,dat_data05,dat_data06,dat_data07,dat_data08,dat_data09,dat_data11,dat_idx07,
                           dat_data40 ,dat_data41,dat_data42,dat_data43,dat_data44,dat_data45,dat_data46,dat_data47,dat_data48,dat_data49,dat_data50,dat_idx02,dat_data25,dat_data26,dat_data51,user_code,dat_data53
                                       
                                )  VALUES (402, " +
                                        "'" + controlFld(societe) + "'," +
                                        "'" + controlFld(bon.CODECLI) + "'," +
                                        "'" + controlFld(bon.COURSEEXCEPT) + "'," +
                                        "'" + controlFld(bon.QTE) + "'," +
                                        "'" + controlFld(bon.NUMCOLISINTERNE) + "'," +
                                        "'" + controlFld(bon.NUMCOLISTRANSP) + "'," +
                                        "'" + controlFld(bon.USERCREAT) + "'," +

                                        "'" + controlFld(bon.COMMENT) + "'," +
                                        "'" + controlFld(bon.NUMADR.Trim()) + "'," +

                                        "'" + controlFld(bon.NUMADR.Trim()) + "'," +

                                        "'" + controlFld(bon.DATESOUHAITEE) + "'," +
                                        "'" + controlFld(bon.DATESOUHAITEE) + "'," +

                                        "'" + controlFld(bon.PERIODE) + "'," +

                                        "'" + controlFld(bon.LIVREURPREVU) + "'," +
                                        "'" + date + "'," +

                                        "'" + controlFld(CliLivr.Rows[0]["RAISOC"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["PRENOM"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADRES1"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADRES2"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["CPOST"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["VILLE"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["ADR_EMAIL"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["TEL1"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["TEL2"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["RAISOC"].ToString()) + "'," +
                                        "'" + controlFld(CliLivr.Rows[0]["SERVICE"].ToString()) + "'," +

                                        "'" + controlFld(CliEnlev.Rows[0]["NOM"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["PRENOM"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADRES1"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADRES2"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["CPOST"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["VILLE"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["ADR_EMAIL"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["TEL1"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["TEL2"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["COMMENTAIRE"].ToString()) + "'," +
                                        "'" + controlFld(CliEnlev.Rows[0]["RAISOC"].ToString()) + "'," +
                                         "'" + controlFld(CliEnlev.Rows[0]["SERVICE"].ToString()) + "',"+
                                         "'" + controlFld(bon.LIVREURPREVU) + "'," +
                                         "'" + controlFld(bon.LIVREURPREVU) + "'," +
                                         "'" + controlFld(codeIdUsermort) + "'," +
                                         "'" + controlFld(bon.USERCREAT) + "'," +
                                          "'" + controlFld("1") + "')";
                                       

                                
                            
                                LogColis(con, societe, bon.NUMCOLISINTERNE, controlFld(bon.USERCREAT), date, "", "", "CREATE", "", "");
                            }
                            ExecuteNonQuery(query, con);
                            ExecuteNonQuery("COMMIT TRANSACTION", con);
                            con.Close();

                     

                            return "";
                        }
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string listAdressColis(string login, string pwd, string societe, string cp, string numadrenlevement)
        {
            cp = split(cp, "dat_data05", "", " ", true);

            string query = @"Select distinct cli_code CODECLI, 
                dat_data01 NOM,dat_data02 PRENOM,dat_data03 ADR1,dat_data04 ADR2,dat_data05 CP,dat_data06 VILLE,
                dat_data07 EMAIL,dat_data08 TEL1,dat_data09 TEL2, dat_data10 COMMENT, dat_data11 SOCIETE,dat_data17 URGENCE,dat_data18 PERIODE,
                cli.commentaire INFO_SUP
                  from Kems_DataWeb
  left join t_negos_clients cli on cli.clilabo='" + societe + @"' and codeclient=cli_code                               
left join t_negos_params orig on orig.prm_soccode='" + societe + @"' and orig.prm_table='ORIGINE' and orig.prm_coderec=dat_idx02 
                left join distrib_users usr on   usr.id=dat_idx04 and (usr.mainid='" + societe + "' or usr.id='" + societe + @"')
                where dat_type=402 and soc_code='" + societe + "'  FILTRECP FILTREADR and (dat_data13='' or dat_data13 is null)  ";


            query = query.Replace("FILTRECP", cp);


            if (numadrenlevement == null || numadrenlevement == "")
                query = query.Replace("FILTREADR", "");
            else
                query = query.Replace("FILTREADR", " and dat_idx06 ='" + numadrenlevement + "'");


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listNbClientTournee(string login, string pwd, string societe, string codetournee, string date)
        {
           ;

            string query = @"Select distinct qte 
                  from V_NbClientTournee_SITE
  
                where dat_data15='" + date + "'  and dat_idx04='" + codetournee.Trim() + "' ";

           


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listNbClientTournee2(string login, string pwd, string societe, string codetournee, string date, string date2)
        {
           // movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            //moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");

            string query = @"Select distinct qte ,periode,dat_data15
                  from V_NbClientTournee_SITE
  
                where  (dat_data15>='" + date + "' and dat_data15<='" + date2 + "' )  and dat_idx04='" + codetournee.Trim() + "' order by periode ";




            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                Log(query, "listNbClientTournee2", "", "test");
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }


        public string deleteColis(string login, string pwd, string societe, string codeinterne)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();



                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "delete from kems_data where dat_type=402 and soc_code='"+societe+"' and dat_idx01='"+codeinterne+"'";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        return "";
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string CodeLivreurExiste(string login, string pwd, string code)
        {
            try
            {
                String stres = "Error";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;
                    bool bres = false;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();



                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        int brese = 0;
                        string query = "select count(*) from distrib_users where loginmort='" + code + "'";
                        brese = ExecuteNonQuery2(query, con);
                        if (brese > 0)
                        {
                            bres = true;
                        }
                        else
                            bres = false;



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        if (bres == false)
                        {
                            stres = "Error";
                        }
                        else
                            stres = "Existe";
                    }
                    catch (Exception ex)
                    {

                          return "Error";
                    }

                    return stres;

                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception ex)
            {

                return "Error";
            }


        }
        public string GeocodageClientExiste(string login, string pwd, string code)
        {
            try
            {
                String stres = "Error";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;
                    bool bres = false;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();



                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        int brese = 0;
                        string query = "select count(*) from T_NEGOS_CLIENTS where CODECLIENT='" + code + "' and LONGITUDE !='' ";
                        brese = ExecuteNonQuery2(query, con);
                        if (brese > 0)
                        {
                            bres = true;
                        }
                        else
                            bres = false;



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        if (bres == false)
                        {
                            stres = "Error";
                        }
                        else
                            stres = "Existe";
                    }
                    catch (Exception ex)
                    {

                        return "Error";
                    }

                    return stres;

                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception ex)
            {

                return "Error";
            }


        }


        public string changeLivrCode(string login, string pwd, string societe, string codeinterne,string newcode)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                            string select = "select *  from t_negos_clients where codeclient='"+newcode+"' and clilabo='"+societe+"'";
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                string raisoc=dt.Rows[0]["RAISOC"].ToString();
                                string adr1=dt.Rows[0]["ADRES1"].ToString();
                                string adr2=dt.Rows[0]["ADRES2"].ToString();
                                string cp=dt.Rows[0]["CPOST"].ToString();
                                string ville=dt.Rows[0]["VILLE"].ToString();
                                string nom=dt.Rows[0]["NOM"].ToString();
                                string prenom=dt.Rows[0]["PRENOM"].ToString();
                                string email=dt.Rows[0]["ADR_EMAIL"].ToString();
                                string tel1 = dt.Rows[0]["TEL1"].ToString();
                                string tel2 = dt.Rows[0]["TEL2"].ToString();
                                
                                con = new SqlConnection(stConnString);
                                con.Open();



                                ExecuteNonQuery("BEGIN TRANSACTION", con);

                                string query = "update kems_data set dat_data10='',cli_code='" + newcode + "',dat_data01='" + nom + "',dat_data02='" + prenom + "', dat_data03='" + adr1 + "', dat_data04='" + adr2 + "', dat_data05='" + cp + "', dat_data06='" + ville + "',   dat_data09='" + tel2 + "',dat_data08='" + tel1 + "', dat_data07='" + email + "'  where dat_type=402 and soc_code='" + societe + "' and dat_idx01='" + codeinterne + "'";
                                ExecuteNonQuery(query, con);



                                ExecuteNonQuery("COMMIT TRANSACTION", con);
                                con.Close();
                            }
                        return "";
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string deleteAccount(string login, string pwd, string societe, string id)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();



                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "delete from distrib_users where mainid='" + societe + "' and idx='" + id + "'";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        return "";
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        [WebMethod]
        public void moveFiles()
        {
            movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");
            Log(DIR_SAN, "movephotos1", "", "test");
        }
        public string listColis(string login, string pwd, string societe,string creatuser,string listecolis,string datedeb,string datefin ,string ishisto,string datecritere,string uncolis,string codeadrenlevement,string codeadrlivraison)
        {
           // movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            //moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");

            societe ="23";
            string query = @"Select TOP 100 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  cli.horairesouverture HORAIRESOUVERTURE, enlev.horairesouverture e_horairesouverture, enlev.bureau e_bureau,enlev.service e_service, enlev.nom e_nom,enlev.prenom e_prenom,  enlev.raisoc e_raisoc,enlev.cpost e_cpost,enlev.ville e_ville,enlev.adres1 e_adr1,enlev.adres2 e_adr2,enlev.tel1 e_tel1, enlev.tel2 e_tel2,enlev.adr_email e_adr_email,enlev.commentaire e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                cli.nom NOM,cli.prenom PRENOM,cli.adres1 ADR1,cli.adres2 ADR2,cli.cpost CP,cli.ville VILLE,
                cli.adr_email EMAIL,cli.bureau BUREAU,cli.service SERVICE,  cli.tel1 TEL1,cli.tel2 TEL2, colis.dat_data10 COMMENT, cli.raisoc SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,cli.commentaire INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE
                from Kems_DataWeb colis
                
                left join t_negos_clients cli on cli.clilabo=colis.soc_code and cli.codeclient=colis.cli_code   
                 left join t_negos_clients enlev on enlev.clilabo=colis.soc_code and enlev.codeclient=colis.dat_idx06                
                 left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB FILTREDATEFIN order by colis.id desc";

            query = @"Select  TOP 150 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT,colis.initial
                from Kems_DataWeb colis
                
                  left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB  order by colis.dat_data13 desc  ";
                //where colis.dat_type = 402 and colis.soc_code = '" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB order by colis.dat_data13 desc ";


            if (creatuser=="" || creatuser==null)
                query = query.Replace("FILTRELIVREUR", "");
            else
            {
                 if (creatuser=="75" )
                 {
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%'  ) ");
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '0000%'  ) ");
                   // query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'   ) ");
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='119' or colis.user_code='" + creatuser + "' or colis.user_code='104' or colis.user_code='119'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'  ) ");
                 }
                 else
                {
                    if (creatuser == "119")
                    {
                        //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%'  ) ");
                        //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '0000%'  ) ");
                        // query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'   ) ");
                        query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='118'  ) ");
                    }
                    else
                        query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "' ) ");
                }
                    
                     

            }


            
            string filtrecolis = split(listecolis, "colis.dat_idx01", "");
            query = query.Replace("FILTRELISTECOLIS", filtrecolis);// " and (colis.dat_idx01 like '%" + colis + "%' or colis.dat_idx03 like '%" + colis + "%')  "

            if (uncolis == "" || uncolis == null)
                query = query.Replace("FILTREUNCOLIS", "");
            else
                query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%'   )");
            // query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%' or   colis.dat_dat_data56 like '%" + uncolis + "%'   )");

            if (codeadrenlevement == "" || codeadrenlevement == null)
                query = query.Replace("FILTREADRENLEV", "");
            else
                query = query.Replace("FILTREADRENLEV", " and colis.dat_idx06='" + codeadrenlevement + "'");

            if (codeadrlivraison == "" || codeadrlivraison == null)
                query = query.Replace("FILTREADRLIVR", "");
            else
                query = query.Replace("FILTREADRLIVR", " and colis.cli_code='" + codeadrlivraison + "'");
         

            string fieldDate = "";
            if (datecritere == "1")
            {
                //fieldDate = "dat_data12";
                fieldDate = "dat_data15";

               
            }
            else
                if (datecritere == "2")
                {
                    fieldDate = "dat_data13";
                }
                else
                    if (datecritere == "3")
                    {
                        fieldDate = "dat_data14";
                    }
                    else
                        if (datecritere == "4")
                        {
                            fieldDate = "dat_data16";
                        }
                        

            if (datedeb == "" || datedeb == null)
                query = query.Replace("FILTREDATEDEB", "");
            else
                 query = query.Replace("FILTREDATEDEB", "  and colis."+fieldDate+ " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "'   ");
               // query = query.Replace("FILTREDATEDEB", " and (colis."+fieldDate+" >= '" + datedeb + "000000' or colis."+fieldDate+" >= '" + datedeb + "000000' )");

          /*  if (datefin == "" || datefin == null)
                query = query.Replace("FILTREDATEFIN", "");
            else
                query = query.Replace("FILTREDATEFIN", " and (colis."+fieldDate+" <= '" + datefin + "999999' or colis."+fieldDate+" <= '" + datefin + "999999' )");
            */
            if (ishisto == "0" ||  ishisto == "" || ishisto == null)//les colis pas livré ou echec livraison et avis de passage
                query = query.Replace("FILTREHISTO", " and (isnull(colis.dat_data23,'')='' or (isnull(colis.dat_data23,'')='0') and isnull(colis.val_data33,'')='1'  ) ");
                //query = query.Replace("FILTREHISTO", "");
            else
                query = query.Replace("FILTREHISTO",  "");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                Log(query, "listColis", "", "test");
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }


        public string listColisValeur(string login, string pwd, string societe, string creatuser, string listecolis, string datedeb, string datefin, string ishisto, string datecritere, string uncolis, string codeadrenlevement, string codeadrlivraison)
        {
            societe = "23";
            string query = @"Select TOP 100 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  cli.horairesouverture HORAIRESOUVERTURE, enlev.horairesouverture e_horairesouverture, enlev.bureau e_bureau,enlev.service e_service, enlev.nom e_nom,enlev.prenom e_prenom,  enlev.raisoc e_raisoc,enlev.cpost e_cpost,enlev.ville e_ville,enlev.adres1 e_adr1,enlev.adres2 e_adr2,enlev.tel1 e_tel1, enlev.tel2 e_tel2,enlev.adr_email e_adr_email,enlev.commentaire e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                cli.nom NOM,cli.prenom PRENOM,cli.adres1 ADR1,cli.adres2 ADR2,cli.cpost CP,cli.ville VILLE,
                cli.adr_email EMAIL,cli.bureau BUREAU,cli.service SERVICE,  cli.tel1 TEL1,cli.tel2 TEL2, colis.dat_data10 COMMENT, cli.raisoc SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,cli.commentaire INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE
                from Kems_DataWeb colis
                
                left join t_negos_clients cli on cli.clilabo=colis.soc_code and cli.codeclient=colis.cli_code   
                 left join t_negos_clients enlev on enlev.clilabo=colis.soc_code and enlev.codeclient=colis.dat_idx06                
                 left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB FILTREDATEFIN order by colis.id desc";

            query = @"Select  TOP 150 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT
                from Kems_DataWeb colis
                
                  left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB  order by colis.dat_data13 desc ";


            if (creatuser == "" || creatuser == null)
                query = query.Replace("FILTRELIVREUR", "");
            else
            {
                if (creatuser == "75")
                {
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%'  ) ");
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '0000%'  ) ");
                    // query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'   ) ");
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '000%'   ) ");
                }
                else
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "' ) ");


            }



            string filtrecolis = split2(listecolis, "colis.dat_idx01", "colis.dat_data56", "");
            query = query.Replace("FILTRELISTECOLIS", filtrecolis);// " and (colis.dat_idx01 like '%" + colis + "%' or colis.dat_idx03 like '%" + colis + "%')  "

            if (uncolis == "" || uncolis == null)
                query = query.Replace("FILTREUNCOLIS", "");
            else
                query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%'  or   colis.dat_data56 like '%" + uncolis + "%'   )");
            // query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%' or   colis.dat_dat_data56 like '%" + uncolis + "%'   )");

            if (codeadrenlevement == "" || codeadrenlevement == null)
                query = query.Replace("FILTREADRENLEV", "");
            else
                query = query.Replace("FILTREADRENLEV", " and colis.dat_idx06='" + codeadrenlevement + "'");

            if (codeadrlivraison == "" || codeadrlivraison == null)
                query = query.Replace("FILTREADRLIVR", "");
            else
                query = query.Replace("FILTREADRLIVR", " and colis.cli_code='" + codeadrlivraison + "'");


            string fieldDate = "";
            if (datecritere == "1")
            {
                //fieldDate = "dat_data12";
                fieldDate = "dat_data15";


            }
            else
                if (datecritere == "2")
            {
                fieldDate = "dat_data13";
            }
            else
                    if (datecritere == "3")
            {
                fieldDate = "dat_data14";
            }
            else
                        if (datecritere == "4")
            {
                fieldDate = "dat_data16";
            }


            if (datedeb == "" || datedeb == null)
                query = query.Replace("FILTREDATEDEB", "");
            else
                query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            // query = query.Replace("FILTREDATEDEB", " and (colis."+fieldDate+" >= '" + datedeb + "000000' or colis."+fieldDate+" >= '" + datedeb + "000000' )");

            /*  if (datefin == "" || datefin == null)
                  query = query.Replace("FILTREDATEFIN", "");
              else
                  query = query.Replace("FILTREDATEFIN", " and (colis."+fieldDate+" <= '" + datefin + "999999' or colis."+fieldDate+" <= '" + datefin + "999999' )");
              */
            if (ishisto == "0" || ishisto == "" || ishisto == null)//les colis pas livré ou echec livraison et avis de passage
                query = query.Replace("FILTREHISTO", " and (isnull(colis.dat_data23,'')='' or (isnull(colis.dat_data23,'')='0') and isnull(colis.val_data33,'')='1'  ) ");
            //query = query.Replace("FILTREHISTO", "");
            else
                query = query.Replace("FILTREHISTO", "");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                //DataTable dt = GetData(stConnString, query);

                string json = query;// ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listMoveFile(string login, string pwd)
        {
            //10.10.25.10
            //moveFiles2("F:\\gossart.nomadia-app.com\\inetpub\\wwwroot\\wsgossart\\bunddl\\gossart\\23\\photos", DIR_SAN + "\\bunddl\\gossart\\23\\photos");
            //moveFiles2("F:\\gossart.nomadia-app.com\\inetpub\\wwwroot\\wsgossart\\bunddl\\gossart\\23\\signatures", DIR_SAN + "\\bunddl\\gossart\\23\\signatures");


            movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");
            Log(DIR_SAN, "movephotos", "", "test");
            string query = @"Select TOP 1  datee from androidtable_dashboard_2017   ";


          
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                //DataTable dt = GetData(stConnString, query);

                string json = query;// ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string LancementExecImportEdi(string login, string pwd)
        {

         
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                SqlCommand cmd = new SqlCommand("");

                SqlConnection con = null;
                int bres = 0;
                String bsue = "";

                try
                {
                    con = new SqlConnection("Data Source = localhost\\SD15; Initial Catalog = Gossart; Persist Security Info = True; User ID = sa; Password = aie+2018");
                   con.Open();

                    //SqlConnection sqlConnObj = new SqlConnection(stConnString);

                    SqlCommand sqlCmd = new SqlCommand("importEDIprod", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();

                    SqlCommand sqlCmd1 = new SqlCommand("importEdiAcromProd", con);
                    sqlCmd1.CommandType = CommandType.StoredProcedure;
                    sqlCmd1.ExecuteNonQuery();

                    SqlCommand sqlCmd2 = new SqlCommand("gossart_doublongeode", con);
                    sqlCmd2.CommandType = CommandType.StoredProcedure;
                    sqlCmd2.ExecuteNonQuery();


                    con.Close();



                    /*      ExecuteNonQuery("BEGIN TRANSACTION", con);
                      bres = ExecuteNonQuery2("EXEC Gossart_T_RAMASSE_AR", con);

                      if (bres > 0)
                      {
                          bsue = "true";
                      }
                      else
                          bsue = "false";


                      ExecuteNonQuery("COMMIT TRANSACTION", con);
                      con.Close();*/


                }
                catch (Exception ex)
                {

                    return "aaaa " + stConnString;
                }

                return "true";

            }
            return "pas";



        }
        public string listColisPrint(string login, string pwd, string societe, string creatuser, string listecolis)
        {
            //movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            //moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");

            societe = "23";
         
            String query = @"Select  TOP 100 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT
                from Kems_DataWeb colis
                
                  left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTRELIVREUR FILTRELISTECOLIS  order by colis.dat_data13 desc";


            if (creatuser == "" || creatuser == null)
                query = query.Replace("FILTRELIVREUR", "");
            else
            {
                if (creatuser == "75")
                {
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'  ) ");
                }
                else
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "' ) ");


            }



            string filtrecolis = split(listecolis, "colis.dat_idx01", "");
            query = query.Replace("FILTRELISTECOLIS", filtrecolis);// " and (colis.dat_idx01 like '%" + colis + "%' or colis.dat_idx03 like '%" + colis + "%')  "

         
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listColis2(string login, string pwd, string societe, string creatuser, string listecolis, string datedeb, string datefin, string ishisto, string datecritere, string uncolis, string codeadrenlevement, string codeadrlivraison)
        {
           // movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            //moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");

            societe = "23";
            string query = @"Select TOP 100 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  cli.horairesouverture HORAIRESOUVERTURE, enlev.horairesouverture e_horairesouverture, enlev.bureau e_bureau,enlev.service e_service, enlev.nom e_nom,enlev.prenom e_prenom,  enlev.raisoc e_raisoc,enlev.cpost e_cpost,enlev.ville e_ville,enlev.adres1 e_adr1,enlev.adres2 e_adr2,enlev.tel1 e_tel1, enlev.tel2 e_tel2,enlev.adr_email e_adr_email,enlev.commentaire e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                cli.nom NOM,cli.prenom PRENOM,cli.adres1 ADR1,cli.adres2 ADR2,cli.cpost CP,cli.ville VILLE,
                cli.adr_email EMAIL,cli.bureau BUREAU,cli.service SERVICE,  cli.tel1 TEL1,cli.tel2 TEL2, colis.dat_data10 COMMENT, cli.raisoc SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,cli.commentaire INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE
                from Kems_DataWeb colis
                
                left join t_negos_clients cli on cli.clilabo=colis.soc_code and cli.codeclient=colis.cli_code   
                 left join t_negos_clients enlev on enlev.clilabo=colis.soc_code and enlev.codeclient=colis.dat_idx06                
                 left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB FILTREDATEFIN order by colis.id desc";

            query = @"Select  TOP 150 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT
                from Kems_DataWeb colis
                
                  left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB  order by colis.dat_data13 desc ";


            if (creatuser == "" || creatuser == null)
                query = query.Replace("FILTRELIVREUR", "");
            else
            {
                if (creatuser == "75")
                {
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%'  ) ");
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '0000%'  ) ");
                    // query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'   ) ");
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '000%'   ) ");
                }
                else
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "' ) ");


            }



            string filtrecolis = split2(listecolis, "colis.dat_idx01", "colis.dat_data56", "");
            query = query.Replace("FILTRELISTECOLIS", filtrecolis);// " and (colis.dat_idx01 like '%" + colis + "%' or colis.dat_idx03 like '%" + colis + "%')  "

            if (uncolis == "" || uncolis == null)
                query = query.Replace("FILTREUNCOLIS", "");
            else
                query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%'  or   colis.dat_data56 like '%" + uncolis + "%'   )");
            // query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%' or   colis.dat_dat_data56 like '%" + uncolis + "%'   )");

            if (codeadrenlevement == "" || codeadrenlevement == null)
                query = query.Replace("FILTREADRENLEV", "");
            else
                query = query.Replace("FILTREADRENLEV", " and colis.dat_idx06='" + codeadrenlevement + "'");

            if (codeadrlivraison == "" || codeadrlivraison == null)
                query = query.Replace("FILTREADRLIVR", "");
            else
                query = query.Replace("FILTREADRLIVR", " and colis.cli_code='" + codeadrlivraison + "'");


            string fieldDate = "";
            if (datecritere == "1")
            {
                //fieldDate = "dat_data12";
                fieldDate = "dat_data15";


            }
            else
                if (datecritere == "2")
            {
                fieldDate = "dat_data13";
            }
            else
                    if (datecritere == "3")
            {
                fieldDate = "dat_data14";
            }
            else
                        if (datecritere == "4")
            {
                fieldDate = "dat_data16";
            }


            if (datedeb == "" || datedeb == null)
                query = query.Replace("FILTREDATEDEB", "");
            else
                query = query.Replace("FILTREDATEDEB", "  and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "'   ");
            // query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            // query = query.Replace("FILTREDATEDEB", " ( and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "' )  ");
            //query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            //query = query.Replace("FILTREDATEDEB", " ( and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "' )  ");
            //query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            // query = query.Replace("FILTREDATEDEB", " and (colis."+fieldDate+" >= '" + datedeb + "000000' or colis."+fieldDate+" >= '" + datedeb + "000000' )");

            /*  if (datefin == "" || datefin == null)
                  query = query.Replace("FILTREDATEFIN", "");
              else
                  query = query.Replace("FILTREDATEFIN", " and (colis."+fieldDate+" <= '" + datefin + "999999' or colis."+fieldDate+" <= '" + datefin + "999999' )");
              */
            if (ishisto == "0" || ishisto == "" || ishisto == null)//les colis pas livré ou echec livraison et avis de passage
                query = query.Replace("FILTREHISTO", " and (isnull(colis.dat_data23,'')='' or (isnull(colis.dat_data23,'')='0') and isnull(colis.val_data33,'')='1'  ) ");
            //query = query.Replace("FILTREHISTO", "");
            else
                query = query.Replace("FILTREHISTO", "");

            string stConnString = Auth(login, pwd);
            //Log("", "", "", "", "Debut", query, "");
            //Log("test", "debut", "_", "test1");
            //Log(" mesdt=debut" , "err_auth", "", "test");
            if (stConnString != "")
            {
                Log(query , "listcolis2", "", "test");
                DataTable dt = GetData(stConnString, query);
                // Log("", "", "", "", "Debut GetData", query, "");
              //  Log("test", "GetData", "_", "test1");

                string json = ConvertDataTabletoString(dt);
                //Log("test", "json", "_", "test1");
                //   Log("", "", "", "", "fain GetData", json, "");
               // Log(query, "listColis2", "", login);
                return json;
            }

            return "";
        }

        public string listColis3(string login, string pwd, string societe, string creatuser, string listecolis, string datedeb, string datefin, string ishisto, string datecritere, string uncolis, string codeadrenlevement, string codeadrlivraison, String motif, String heure)
        {
            // movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            //moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");

            societe = "23";
            string query = @"Select TOP 100 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  cli.horairesouverture HORAIRESOUVERTURE, enlev.horairesouverture e_horairesouverture, enlev.bureau e_bureau,enlev.service e_service, enlev.nom e_nom,enlev.prenom e_prenom,  enlev.raisoc e_raisoc,enlev.cpost e_cpost,enlev.ville e_ville,enlev.adres1 e_adr1,enlev.adres2 e_adr2,enlev.tel1 e_tel1, enlev.tel2 e_tel2,enlev.adr_email e_adr_email,enlev.commentaire e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                cli.nom NOM,cli.prenom PRENOM,cli.adres1 ADR1,cli.adres2 ADR2,cli.cpost CP,cli.ville VILLE,
                cli.adr_email EMAIL,cli.bureau BUREAU,cli.service SERVICE,  cli.tel1 TEL1,cli.tel2 TEL2, colis.dat_data10 COMMENT, cli.raisoc SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,cli.commentaire INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE
                from Kems_DataWeb colis
                
                left join t_negos_clients cli on cli.clilabo=colis.soc_code and cli.codeclient=colis.cli_code   
                 left join t_negos_clients enlev on enlev.clilabo=colis.soc_code and enlev.codeclient=colis.dat_idx06                
                 left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB FILTREDATEFIN order by colis.id desc";

            query = @"Select  TOP 150 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT
                from Kems_DataWeb colis
                
                  left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB  order by colis.dat_data13 desc ";

            
                if (motif != "" )
                {
                    query = @"Select  TOP 150 colis.dat_data15 DATESOUHAITEE, colis.user_code CREATUSER,  '' HORAIRESOUVERTURE,'' e_horairesouverture, '' e_bureau,colis.dat_idx02 e_service, colis.dat_data40 e_nom,colis.dat_data41 e_prenom, colis.dat_data50 e_raisoc,colis.dat_data44 e_cpost,colis.dat_data45 e_ville,colis.dat_data42 e_adr1,colis.dat_data43 e_adr2,colis.dat_data47 e_tel1, colis.dat_data48 e_tel2,colis.dat_data46 e_adr_email,colis.dat_data49 e_info_sup,   colis.dat_data51 LIVREURPREVU, colis.dat_idx07,  hdrlivr.dat_data09 SIGNLIVR, hdrlivr.dat_data08 SIGNATAIRELIVR,hdrenlev.val_data31 NBRCOLISEXCEPT, hdrenlev.dat_data08 SIGNATAIREENLEV, hdrenlev.dat_data09 SIGNENLEV,   
                    colis.dat_data19 MOTIFENLEV, colis.dat_data20 MOTIFLIVR, colis.dat_data21 ETATENLEV, colis.dat_data22 ENLEVMANUEL, colis.dat_data23 ETATLIVR ,
                    colis.dat_data24 LIVRMANUEL,colis.dat_data26 LIVREURLIVRAISON,
                    colis.dat_data25 LIVREURENLEV,  colis.cli_code CODECLI,colis.dat_idx01 NUMCOLISINTERNE,colis.dat_idx03 NUMCOLISTRANSP, 
                    colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                    colis.dat_data07 EMAIL,'' BUREAU,colis.dat_idx07 SERVICE, colis.dat_data08 TEL1,colis.dat_data09 TEL2, colis.dat_data10 COMMENT, colis.dat_data11 SOCIETE,colis.dat_idx09 URGENCE,colis.dat_data18 PERIODE,colis.dat_data10 INFO_SUP,
                    colis.dat_data12 DATECREA,colis.dat_data13 DATETOUR,colis.dat_data14 DATECHARGE,colis.dat_data15 DATEPRES,colis.dat_data16 DATELIVR,colis.val_data32 NBRPRES  ,colis.dat_idx06 NUMADR ,colis.dat_data51 TOURNEE,colis.cde_code CLI_ENLEV,colis.dat_data56 ANCIEN_FORMAT
                    from Kems_DataWeb colis
                
                    left join Kems_DataWeb hdrenlev on     hdrenlev.soc_code=colis.soc_code and hdrenlev.dat_type=403 and hdrenlev.cde_code=colis.cde_code and hdrenlev.dat_data14=colis.dat_data14
                    INNER JOIN T_NEGOS_LOGCOLIS as logColis on  logColis.soc_code=colis.soc_code and logColis.numcolis=colis.dat_idx01 and logColis.action ='LOADING' FILTRELOGMOTIF
                    left join Kems_DataWeb hdrlivr on     hdrlivr.soc_code=colis.soc_code and hdrlivr.dat_type=404 and hdrlivr.cde_code=colis.vis_code
                    where colis.dat_type=402 and colis.soc_code='" + societe + "' FILTREHISTO   FILTREADRENLEV FILTREADRLIVR FILTRELIVREUR FILTRELISTECOLIS FILTREUNCOLIS FILTREDATEDEB  order by colis.dat_data13 desc, colis.dat_data14 desc ";

                 }

            if (creatuser == "" || creatuser == null)
                query = query.Replace("FILTRELIVREUR", "");
            else
            {
                if (creatuser == "75")
                {
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%'  ) ");
                    //query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '0000%'  ) ");
                    // query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%'   ) ");
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.user_code='104'  or colis.dat_data25='104'  or colis.dat_data25 ='" + creatuser + "'  or colis.dat_idx01 like '0000%' or colis.dat_idx01 like 'TD00%' or colis.dat_data56 like '000%'   ) ");
                }
                else
                    query = query.Replace("FILTRELIVREUR", " and ( colis.user_code='" + creatuser + "' or colis.dat_data25 ='" + creatuser + "' ) ");


            }



            string filtrecolis = split2(listecolis, "colis.dat_idx01", "colis.dat_data56", "");
            query = query.Replace("FILTRELISTECOLIS", filtrecolis);// " and (colis.dat_idx01 like '%" + colis + "%' or colis.dat_idx03 like '%" + colis + "%')  "

            if (uncolis == "" || uncolis == null)
                query = query.Replace("FILTREUNCOLIS", "");
            else
                query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%'  or   colis.dat_data56 like '%" + uncolis + "%'   )");
            // query = query.Replace("FILTREUNCOLIS", " and   ( colis.dat_idx01 like '%" + uncolis + "%' or   colis.dat_dat_data56 like '%" + uncolis + "%'   )");

            if (codeadrenlevement == "" || codeadrenlevement == null)
                query = query.Replace("FILTREADRENLEV", "");
            else
                query = query.Replace("FILTREADRENLEV", " and colis.dat_idx06='" + codeadrenlevement + "'");

            if (codeadrlivraison == "" || codeadrlivraison == null)
                query = query.Replace("FILTREADRLIVR", "");
            else
                query = query.Replace("FILTREADRLIVR", " and colis.cli_code='" + codeadrlivraison + "'");


            string fieldDate = "";
            if (datecritere == "1")
            {
                //fieldDate = "dat_data12";
                fieldDate = "dat_data15";


            }
            else
                if (datecritere == "2")
            {
                fieldDate = "dat_data13";
            }
            else
                    if (datecritere == "3")
            {
                fieldDate = "dat_data14";
            }
            else
                        if (datecritere == "4")
            {
                fieldDate = "dat_data16";
            }


            if (datedeb == "" || datedeb == null)
                query = query.Replace("FILTREDATEDEB", "");
            else
                query = query.Replace("FILTREDATEDEB", "  and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "'   ");
            // query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            // query = query.Replace("FILTREDATEDEB", " ( and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "' )  ");
            //query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            //query = query.Replace("FILTREDATEDEB", " ( and colis." + fieldDate + " >= '" + datedeb + "'  and colis." + fieldDate + " <= '" + datefin + "' )  ");
            //query = query.Replace("FILTREDATEDEB", " and colis." + fieldDate + " = '" + datedeb + "' ");
            // query = query.Replace("FILTREDATEDEB", " and (colis."+fieldDate+" >= '" + datedeb + "000000' or colis."+fieldDate+" >= '" + datedeb + "000000' )");

            /*  if (datefin == "" || datefin == null)
                  query = query.Replace("FILTREDATEFIN", "");
              else
                  query = query.Replace("FILTREDATEFIN", " and (colis."+fieldDate+" <= '" + datefin + "999999' or colis."+fieldDate+" <= '" + datefin + "999999' )");
              */
            if (ishisto == "0" || ishisto == "" || ishisto == null)//les colis pas livré ou echec livraison et avis de passage
                query = query.Replace("FILTREHISTO", " and (isnull(colis.dat_data23,'')='' or (isnull(colis.dat_data23,'')='0') and isnull(colis.val_data33,'')='1'  ) ");
            //query = query.Replace("FILTREHISTO", "");
            else
                query = query.Replace("FILTREHISTO", "");

            if(motif !="")
            {
                
                query = query.Replace("FILTRELOGMOTIF", "  and logColis.motif = '" + motif + "'  and logColis.datepassage like'"+datedeb+""+ heure + "%'" );

            }

            string stConnString = Auth(login, pwd);
            //Log("", "", "", "", "Debut", query, "");
            //Log("test", "debut", "_", "test1");
            //Log(" mesdt=debut" , "err_auth", "", "test");
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);
                // Log("", "", "", "", "Debut GetData", query, "");
                //  Log("test", "GetData", "_", "test1");

                string json = ConvertDataTabletoString(dt);
                //Log("test", "json", "_", "test1");
                //   Log("", "", "", "", "fain GetData", json, "");
                //Log(query, "listColis2", "", login);
                return json;
            }

            return " ";
        }


        public string listColisLibre(string login, string pwd, string societe, string cp, string numadrenlevement)
        {
            cp = split(cp, "dat_data05", "", " ", true);

            string query = @"Select cli_code CODECLI,dat_idx01 NUMCOLISINTERNE,dat_idx03 NUMCOLISTRANSP,orig.prm_lbl ORIGINE,
                dat_data01 NOM,dat_data02 PRENOM,dat_data03 ADR1,dat_data04 ADR2,dat_data05 CP,dat_data06 VILLE,
                dat_data07 EMAIL,dat_data08 TEL1,dat_data09 TEL2, dat_data10 COMMENT, dat_data11 SOCIETE,dat_data17 URGENCE,dat_data18 PERIODE,cli.commentaire INFO_SUP,
                dat_data12 DATECREA,dat_data13 DATETOUR,dat_data14 DATECHARGE,dat_data15 DATEPRES,dat_data16 DATELIVR,val_data32 NBRPRES ,usr.nom LIVREUR from Kems_DataWeb
  left join t_negos_clients cli on cli.clilabo='" + societe + @"' and codeclient=cli_code                               
left join t_negos_params orig on orig.prm_soccode='" + societe + @"' and orig.prm_table='ORIGINE' and orig.prm_coderec=dat_idx02 
                left join distrib_users usr on   usr.id=cast (dat_idx04 as integer) and (usr.mainid='" + societe + "' or usr.id='" + societe + @"')
                where dat_type=402 and soc_code='" + societe + "' FILTREADR  and ( (isnull(dat_data21,'')<>'1') and isnull(dat_data23,'')<>'1')  and (isnull( dat_data13,'')=''  or dat_data13<'TODAY' ) and isnull( dat_data14,'')=''";
            
            //FILTRECP FILTREADR and (dat_data13='' or dat_data13 is null or dat_data13<'TODAY' or dat_data21<>'1') and ((dat_data14='' or dat_data14 is null ) or (dat_data14<>'' and dat_data14 is not null and dat_data21<>'1') )";


            
            query = query.Replace("TODAY", DateTime_to_YYYYMMDD(0));

            if (numadrenlevement == null || numadrenlevement == "")
                query = query.Replace("FILTREADR", "");
            else
                query = query.Replace("FILTREADR", " and dat_idx06 ='" + numadrenlevement + "'");


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listRamasse_recapitulatif(string login, string pwd, string societe)
        {
           

        string query = @"Select CODE_SOC ,CODE_RAMASSE,CODE_CLIENT,CODE_TOURNEE,DATE_TOURNEE ,CODE_ARTICLE, LIBELLE_ARTICLE ,QUANTITE,DEPOT,QTE_RAMASSE,QTE_ENTREPOT , SIGNATURE,DATE_RECEPTION , INFOX,RAISOC, ETAT,NUMDOC,TYPE from V_RAMASSE_RECAPITULATIF FILTRE  ORDER BY DEPOT, CODE_TOURNEE,CODE_CLIENT,CODE_RAMASSE ,INFOX,CODE_ARTICLE";

            query = query.Replace("FILTRE", "WHERE DATE_TOURNEE = CONVERT(VARCHAR(8), GETDATE(), 112) ");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listRamasse_recapitulatiffiltre(string login, string pwd, string societe,string coderamasse)
        {


            // string query = @"Select CODE_SOC ,CODE_RAMASSE,CODE_CLIENT,CODE_TOURNEE,DATE_TOURNEE ,CODE_ARTICLE, LIBELLE_ARTICLE ,QUANTITE,DEPOT,QTE_RAMASSE,QTE_ENTREPOT , SIGNATURE,DATE_RECEPTION , INFOX,RAISOC, ETAT,NUMDOC,LIBRE2,TYPE from V_RAMASSE_RECAPITULATIF FILTRE ORDER BY DATE_TOURNEE,DEPOT, CODE_TOURNEE,CODE_CLIENT,CODE_RAMASSE ,INFOX,CODE_ARTICLE ";
            string query = @"Select CODE_SOC ,CODE_RAMASSE,CODE_CLIENT,CODE_TOURNEE,DATE_TOURNEE ,CODE_ARTICLE, LIBELLE_ARTICLE ,QUANTITE,DEPOT,QTE_RAMASSE,QTE_ENTREPOT , SIGNATURE,DATE_RECEPTION , INFOX,RAISOC, ETAT,NUMDOC,LIBRE2,TYPE from V_RAMASSE_RECAPITULATIF FILTRE ORDER BY DATE_TOURNEE desc , DEPOT, CODE_TOURNEE,CODE_CLIENT,CODE_RAMASSE ,INFOX,CODE_ARTICLE ";

            if (coderamasse == null || coderamasse == "")
                query = query.Replace("FILTRE", "   ");
            else
                query = query.Replace("FILTRE", " WHERE CODE_RAMASSE ='" + coderamasse + "' ");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                Log(query, "listRamasse_recapitulatiffiltre", "", login);
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);
                //Log(query, "listRamasse_recapitulatiffiltre", "", login);

                return json;
            }

            return "";
        }
        public string listRamasse_recapitulatif_entete(string login, string pwd, string societe)
        {


            string query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

            //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE = CONVERT(VARCHAR(8), GETDATE(), 112) ");
            query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) = CONVERT(VARCHAR(8), GETDATE(), 112) ");




            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);
               // Log(query, "listRamasse_recapitulatif_entete", "", login);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listRamasse_recapitulatif_enteteHisto(string login, string pwd, string societe,string type)
        {
            string query = "";
            if (type=="1")
            {
                 query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE(), 112)");

            }
            if (type == "2")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-60, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-30, 112)");

            }
            if (type == "3")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-90, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-60, 112)");

            }
            if (type == "4")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-120, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-90, 112)");

            }
            if (type == "5")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-150, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-120, 112)");

            }
            if (type == "6")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-180, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-150, 112)");

            }
            /*
            if (type == "2")
            {
                 query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-60, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-30, 112)");

            }

            if (type == "3")
            {
                 query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-90, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-60, 112)");

            }
            if (type == "4")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-120, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-90, 112)");

            }
            if (type == "5")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-210, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-120, 112)");

            }
            
            if (type == "6")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-180, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-150, 112)");

            }
            if (type == "7")
            {
                query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08, DATEHEURE,DATEHEURERECEPT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY DATEHEURE desc ,CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT";

                //query = query.Replace("FILTRE", " WHERE DATE_TOURNEE >= CONVERT(VARCHAR(8), GETDATE()-30, 112)  AND DATE_TOURNEE < CONVERT(VARCHAR(8), GETDATE(), 112)");
                query = query.Replace("FILTRE", " WHERE Left( DATEHEURE,8) >= CONVERT(VARCHAR(8), GETDATE()-210, 112)  AND Left( DATEHEURE,8) < CONVERT(VARCHAR(8), GETDATE()-180, 112)");

            }*/


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);
                Log(query, "listRamasse_recapitulatif_enteteHisto", "", login);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listRamasse_recapitulatif_entetefiltre(string login, string pwd, string societe,string coderamasse)
        {


            string query = @"Select CODE_SOC, CODE_RAMASSE, CODE_CLIENT, CODE_TOURNEE, DATE_TOURNEE, SIGNATAIRE_ENTREPOT, SIGNATAIRE_CLIENT, RAISOC, ADRES1, CPOST, VILLE, dat_idx08,JPG_ENTREPOT,JPG_CLIENT
                from V_RAMASSE_RECAPITULATIFENT FILTRE ORDER BY CODE_TOURNEE,CODE_RAMASSE, CODE_CLIENT ";

            if (coderamasse == null || coderamasse == "")
                query = query.Replace("FILTRE", "");
            else
                query = query.Replace("FILTRE", " WHERE CODE_RAMASSE ='" + coderamasse + "' ");


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                Log(query, "listRamasse_recapitulatif_entetefiltre", "", login);
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listMail_Enlevement(string login, string pwd)
        {


        string query = @"Select EMAIL ,MOTIF,NUMCOLISINTERNE,NUMCOLISEXTERNE,DATECOLIS ,DATEHEURESTATUE, CODECLIENT,NOM,TOURNEE from V_EMAIL_ENLEVEMENT ORDER BY MOTIF";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listMail_Livraison(string login, string pwd)
        {


            string query = @"Select EMAIL ,MOTIF,NUMCOLISINTERNE,NUMCOLISEXTERNE,DATECOLIS ,DATEHEURESTATUE, CODECLIENT,NOM,TOURNEE from V_EMAIL_LIVRAISON ORDER BY MOTIF";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string UpdatelistMail_Enlevement(string login, string pwd, string societe, string numcolis)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update kems_data  set  dat_data60='1'  where dat_type='402' and dat_idx01='" + numcolis + "'";
                        ExecuteNonQuery(query, con);

                      

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string UpdatelistMail_Livraison(string login, string pwd, string societe, string numcolis)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update kems_data  set  dat_data61='1'  where dat_type='402' and dat_idx01='" + numcolis + "'";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string listAccountTournee(string login, string pwd, string societe, string nom, string email, string prenom, String loginmort)
        {
            string query = " select u.idservice,u.idservice_cmt idservice_cmt  ,u.crypt,u.id code,  u.nom,u.prenom,u.email,u.actif,u.type,abo.id_profile,abo.id,abo.couleur,u.loginmort from distrib_users u left join t_negos_abo abo on abo.id=u.idabo  where u.type='4' and mainid='" + societe + "' FILTRENOM FILTREPRENOM FILTREEMAIL FILTRELOGINMORT order by u.nom";
            if (nom != "")
            {
                query = query.Replace("FILTRENOM", " and u.nom like '%" + nom + "%'");
            }
            else
                query = query.Replace("FILTRENOM", " ");

            if (prenom != "")
            {
                query = query.Replace("FILTREPRENOM", " and u.prenom like '%" + prenom + "%'");
            }
            else
                query = query.Replace("FILTREPRENOM", " ");

            if (email != "")
            {
                query = query.Replace("FILTREEMAIL", " and u.email like '%" + email + "%'");
            }
            else
                query = query.Replace("FILTREEMAIL", " ");

            if (loginmort != "")
            {
                query = query.Replace("FILTRELOGINMORT", " and u.loginmort like '%" + loginmort + "%'");
            }
            else
                query = query.Replace("FILTRELOGINMORT", " ");


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        
        public string listAccount(string login, string pwd, string societe,string nom,string email,string prenom,String loginmort )
        {
            string query = " select u.idservice,u.idservice_cmt idservice_cmt  ,u.crypt,u.id code,  u.nom,u.prenom,u.email,u.actif,u.type,abo.id_profile,abo.id,abo.couleur,u.loginmort from distrib_users u left join t_negos_abo abo on abo.id=u.idabo  where  mainid='" + societe + "' FILTRENOM FILTREPRENOM FILTREEMAIL FILTRELOGINMORT order by u.nom";
            if (nom  != "")
            {
                query = query.Replace("FILTRENOM", " and u.nom like '%"+nom+  "%'");
            }
            else
                query = query.Replace("FILTRENOM", " ");

            if (prenom != "")
            {
                query = query.Replace("FILTREPRENOM", " and u.prenom like '%" + prenom + "%'");
            }
            else
                query = query.Replace("FILTREPRENOM", " ");

            if (email != "")
            {
                query = query.Replace("FILTREEMAIL", " and u.email like '%" + email + "%'");
            }
            else
                query = query.Replace("FILTREEMAIL", " ");

            if (loginmort != "")
            {
                query = query.Replace("FILTRELOGINMORT", " and u.loginmort like '%" + loginmort + "%'");
            }
            else
                query = query.Replace("FILTRELOGINMORT", " ");

            
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }


        public string listAccountAbbevilleG(string login, string pwd)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountAbbevilleG ";
            


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listAccountAbbevilleD(string login, string pwd)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountAbbevilleD ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listAccountDemandeur(string login, string pwd)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountDemandeur ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }



        public string listAccountAmiensV2(string login, string pwd, String codeselectionne )
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountAmiensV3 where tourneeselectionne='" + codeselectionne + "' order by  loginmort ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

          

                return json;
            }

            return "";
        }

        public string listAccountDemandeurV2(string login, string pwd,String codeselectionne)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountDemandeurV3 where tourneeselect='"+codeselectionne+ "' order by  nom ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                
                return json;
            }

            return "";
        }
        public string listAccountStQuentinG(string login, string pwd)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountStQuentinG ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listAccountStQuentinD(string login, string pwd)
        {
            string query = " select idservice,idservice_cmt  ,crypt,code,  nom,prenom,email,actif,type,id_profile,id,couleur,loginmort,etat from v_listAccountStQuentinD ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listOrigine(string login, string pwd, string societe,string actif)
        {
            string query = "select prm_coderec code, prm_lbl nom ,prm_actif actif,prm_comment detail from t_negos_params where prm_soccode='" + societe + "' FILTREACTIF  and prm_table='ORIGINE' order by prm_lbl";

            if (actif!=null && actif != "")
            {
                query = query.Replace("FILTREACTIF", " and prm_actif='" + actif + "'");
            }
            else
                query = query.Replace("FILTREACTIF", " ");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listService(string login, string pwd, string societe, string actif,string codecli)
        {
            string query = "select prm_coderec code, prm_lbl nom ,prm_actif actif,prm_comment detail from t_negos_params where prm_value='" + codecli + "' and prm_soccode='" + societe + "' FILTREACTIF  and prm_table='SERVICE' order by prm_lbl";

            if (actif != null && actif != "")
            {
                query = query.Replace("FILTREACTIF", " and prm_actif='" + actif + "'");
            }
            else
                query = query.Replace("FILTREACTIF", " ");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listDroits(string login, string pwd)
        {
            string query = "select prm_coderec code, prm_lbl nom ,prm_actif actif,prm_comment detail from t_negos_params where   FILTREACTIF  and prm_table='DROIT' order by prm_lbl";

           
                query = query.Replace("FILTREACTIF", "  prm_actif='1'");
           
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listParamAmiensAbbevilleG(string login, string pwd)
        {
            string query = "select prm_coderec code from t_negos_params where   prm_actif='1'   and prm_table='SECTAB' GROUP BY  prm_coderec  order by prm_coderec";


           
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listParamAmiensAbbevilleD(string login, string pwd)
        {
            string query = "select prm_lbl code from t_negos_params where   prm_actif='1'   and prm_table='SECTAB' GROUP BY  prm_lbl  order by prm_lbl";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listParamAmiensStQuentinG(string login, string pwd)
        {
            string query = "select prm_coderec code from t_negos_params where   prm_actif='1'   and prm_table='SECTSQ' GROUP BY  prm_coderec  order by prm_coderec";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listTournee(string login, string pwd)
        {
            string query = "select  code, nom,prenom,loginmort  from v_listTournee ORDER BY NOM ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listDemandeur(string login, string pwd)
        {
            string query = "select  code, nom,prenom,loginmort  from v_listDemandeur ORDER BY NOM ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listParamAmiensStQuentinD(string login, string pwd)
        {
            string query = "select prm_lbl code from t_negos_params where   prm_actif='1'   and prm_table='SECTSQ' GROUP BY  prm_lbl  order by prm_lbl";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string listParam(string login, string pwd, string societe, string actif,string table)
        {
            string query = "select prm_coderec code, prm_lbl nom ,prm_actif actif,prm_comment detail,prm_value coche, prm_cocheemail, prm_adremail from t_negos_params where prm_soccode='" + societe + "' FILTREACTIF  and prm_table='" + table + "' order by prm_lbl";

            if (actif != null && actif != "")
            {
                query = query.Replace("FILTREACTIF", " and prm_actif='" + actif + "'");
            }
            else
                query = query.Replace("FILTREACTIF", " ");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string createOrigine(string login, string pwd, string societe, string nom,string detail)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_actif,prm_soccode,prm_comment) values ('ORIGINE','"+Left( controlFld(nom),20)+  "','"+controlFld(nom)+"','1','"+societe+"','"+controlFld(detail)+"')";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string createService(string login, string pwd, string societe, string nom, string codecli)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_actif,prm_soccode,prm_comment,prm_value) values ('SERVICE','" + Left(controlFld(nom), 20) + "','" + controlFld(nom) + "','1','" + societe + "','','" + controlFld(codecli) + "')";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string createParam(string login, string pwd, string societe, string nom, string table)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_actif,prm_soccode ) values ('"+table+"','" + Left(controlFld(nom), 20) + "','" + controlFld(nom) + "','1','" + societe + "' )";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string deleteParamAmiensV2(string login, string pwd, string societe, string Tourneeselectionne, string Tourneeliste)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "delete from t_negos_params where prm_table='SECTDEPOT'  and prm_lbl='"+ Tourneeselectionne + "' and prm_coderec='" + Tourneeliste + "' and prm_order is null ";

                        ExecuteNonQuery(query, con);
                        

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string deleteParamDemandeurV2(string login, string pwd, string societe, string Tourneeselectionne, string Demandeurliste)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "delete from t_negos_params where prm_table='SECDEMANDEURV2' and  prm_comment='"+ Tourneeselectionne + "' and  prm_coderec='" + Demandeurliste + "'";

                        ExecuteNonQuery(query, con);




                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string deleteParamAmiens(string login, string pwd, string societe, string table)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "delete from t_negos_params where prm_table='SECTSQ' and prm_order is null ";

                        ExecuteNonQuery(query, con);

                         query = "delete from t_negos_params where prm_table='SECTAB' and prm_order is null ";

                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string deleteParamDemandeur(string login, string pwd, string societe)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "delete from t_negos_params where prm_table='SECDEMANDEUR' ";

                        ExecuteNonQuery(query, con);

                       


                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string createParamAmiens(string login, string pwd, string societe, string table, string coderec, string lbl)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                       
                       // string query = "delete from t_negos_params where prm_table='" + table + "' ";

                        //ExecuteNonQuery(query, con);

                        string loginimport = lbl;
                        string select3 = "select *  from distrib_users where id='" + lbl + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();

                        }

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_comment,prm_actif,prm_soccode ) values ('" + table + "','" + controlFld(coderec) + "','" + controlFld(lbl) + "','" + controlFld(loginimport) + "','1','" + societe + "' )";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                        Log(query, "createParamAmiens", "", login);
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string createParamDemandeur(string login, string pwd, string societe, string table, string coderec)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        // string query = "delete from t_negos_params where prm_table='" + table + "' ";

                        //ExecuteNonQuery(query, con);

                        string loginimport = coderec;
                        string select3 = "select *  from distrib_users where id='" + coderec + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();

                        }

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_comment,prm_actif,prm_soccode ) values ('" + table + "','" + controlFld(coderec) + "','" + controlFld(coderec) + "','" + controlFld(loginimport) + "','1','" + societe + "' )";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string createParamAmiensV2(string login, string pwd, string societe, string Tourneeselectionne,string Tourneeliste )
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        // string query = "delete from t_negos_params where prm_table='" + table + "' ";

                        //ExecuteNonQuery(query, con);

                        string loginimport = Tourneeselectionne;
                        string select3 = "select *  from distrib_users where id='" + Tourneeselectionne + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();

                        }

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_comment,prm_actif,prm_soccode ) values ('SECTDEPOT','" + controlFld(Tourneeliste) + "','" + controlFld(Tourneeselectionne) + "','" + controlFld(loginimport) + "','1','" + societe + "' )";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                        Log(query, "createParamAmiensV2", "", login);
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string createParamDemandeurV2(string login, string pwd, string societe, string codeselectionne,string codedemandeur)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        // string query = "delete from t_negos_params where prm_table='" + table + "' ";

                        //ExecuteNonQuery(query, con);

                        string loginimport = codeselectionne;
                        string select3 = "select *  from distrib_users where id='" + codeselectionne + "' ";
                        DataTable dt3 = GetData(stConnString, select3);
                        if (dt3.Rows.Count > 0)
                        {

                            loginimport = dt3.Rows[0]["loginmort"].ToString();

                        }

                        string query = "insert into t_negos_params (prm_table,prm_coderec,prm_lbl,prm_comment,prm_value,prm_actif,prm_soccode ) values ('SECDEMANDEURV2','" + controlFld(codedemandeur) + "','" + controlFld(codedemandeur) + "','" + controlFld(codeselectionne) + "','" + controlFld(loginimport) + "','1','" + societe + "' )";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string updateOrigine(string login, string pwd, string societe,string code, string nom,string actif,string detail)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update t_negos_params set prm_comment='" + controlFld(detail) + "',prm_lbl='" + controlFld(nom) + "', prm_actif='" + actif + "' where prm_table='ORIGINE'  and prm_coderec='" + code + "' and prm_soccode='" + societe + "'";
                        ExecuteNonQuery(query, con);

                        //si on desactive on efface si jamais utilisé
                        if (actif == "0")
                        {
                            query = "select top 1 * from Kems_DataWeb where dat_type='402' and dat_idx02='" + code + "' and soc_code='" + societe + "'";
                            DataTable dt=GetData(con, query);
                            if (dt.Rows.Count == 0)
                            {
                                query = "delete from t_negos_params where prm_table='ORIGINE' and prm_coderec='"+code+"' and prm_soccode='"+societe+"'";
                                ExecuteNonQuery(query, con);
                            }
                         

                        }
                        
                        

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string updateService(string login, string pwd, string societe, string code, string nom, string actif, string codecli)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update t_negos_params set prm_lbl='" + controlFld(nom) + "', prm_actif='" + actif + "' where prm_table='SERVICE'  and prm_value='" + codecli + "'  and prm_coderec='" + code + "' and prm_soccode='" + societe + "'";
                        ExecuteNonQuery(query, con);

                        //si on desactive on efface si jamais utilisé
                        if (actif == "0")
                        {
                            query = "select top 1 * from Kems_DataWeb where dat_type='402' and dat_idx07='" + code + "' and soc_code='" + societe + "'";
                            DataTable dt = GetData(con, query);
                            if (dt.Rows.Count == 0)
                            {
                                query = "delete from t_negos_params where prm_table='SERVICE' and prm_value='" + codecli + "' and prm_coderec='" + code + "' and prm_soccode='" + societe + "'";
                                ExecuteNonQuery(query, con);
                            }


                        }



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string UpdateMajColisLivreur(string login, string pwd)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update kems_data set dat_data26=dat_data25  where (dat_type = '402') AND (dat_data25 <> dat_data26) AND (dat_data16 IS NULL) AND (dat_data14 <> '') ";
                        ExecuteNonQuery(query, con);

                        //é
                        query = "update UPDATE kems_data SET cde_code = '01', dat_idx06 = '01', dat_data40 = '', dat_data42 = 'ZAC de l’epinette', dat_data44 = '02690', dat_data45 = 'URVILLERS', dat_data46 = 'TDPR', dat_data50 = 'TDPR' WHERE(dat_idx01 LIKE 'AC%') AND(dat_data40 = 'GOSSART') AND(dat_type = '402 ') AND(cde_code = '02') ";
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string updateParam(string login, string pwd, string societe, string code, string nom, string actif, string table,string type,string kdfld,string value,String cocheemail, string email)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        query = "update t_negos_params  set prm_lbl='" + controlFld(nom) + "', prm_actif='" + actif + "', prm_value='" + value + "', prm_cocheemail='" + controlFld(cocheemail) + "', prm_adremail='" + email + "'  where prm_table='" + table + "'  and prm_coderec='" + code + "' and prm_soccode='" + societe + "'";
                        ExecuteNonQuery(query, con);

                        //si on desactive on efface si jamais utilisé
                        if (actif == "0")
                        {
                            query = "select top 1 * from Kems_DataWeb where dat_type='" + type + "' and " + kdfld + "='" + code + "' and soc_code='" + societe + "'";
                            DataTable dt = GetData(con, query);
                            if (dt.Rows.Count == 0)
                            {
                                query = "delete from t_negos_params where prm_table='"+table+"' and prm_coderec='" + code + "' and prm_soccode='" + societe + "'";
                                ExecuteNonQuery(query, con);
                            }


                        }



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


        public string setTournee(string login, string pwd, string societe,string jour,string coderep,string numcolisinterne,string numtournee,string numadresseenlevement)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        
                        //on recoit tous les colis en meme temps donc on supprime ce qui avait été saisi précdemment
                        string delete = "update kems_data set dat_data13='' where dat_type=402 and dat_idx04='" + coderep + "' and dat_data13='" + jour + "' and dat_idx05='" + numtournee + "' and  soc_code='" + societe + "'";
                        ExecuteNonQuery(delete, con);
                        int i=0;
                        do{

                            string colis=GiveFldEx(numcolisinterne,i,";","FIN");
                            if (colis=="FIN" || colis=="" ) break;
                            string query = "";


                            // dat_idx06='"+numadresseenlevement+"',
                            query = "update kems_data set dat_idx05='"+numtournee+"', dat_idx04='"+coderep+"', dat_data13='" +jour + "',val_data31="+i+"  where  dat_type=402 and dat_idx01='" + colis + "' and  soc_code='" + societe + "'";

                            ExecuteNonQuery(query, con);

                     
                            i++;

                        }while(1==1);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string listColisTournee(string login, string pwd, string societe, string livreur,string date,string numtournee)
        {
            if (date == "") date = "toto";
            string query = @"Select colis.dat_data23 ETATLIVR , colis.dat_data21 ETATENLEV,cli_code CODECLI,dat_idx01 NUMCOLISINTERNE,dat_idx03 NUMCOLISTRANSP,orig.prm_lbl ORIGINE,
                dat_data01 NOM,dat_data02 PRENOM,dat_data03 ADR1,dat_data04 ADR2,dat_data05 CP,dat_data06 VILLE,
                dat_data07 EMAIL,dat_data08 TEL1,dat_data09 TEL2, dat_data10 COMMENT, dat_data11 SOCIETE,dat_data17 URGENCE,dat_data18 PERIODE,
                dat_data12 DATECREA,dat_data13 DATETOUR,dat_data14 DATECHARGE,dat_data15 DATEPRES,dat_data16 DATELIVR,val_data32 NBRPRES ,usr.nom LIVREUR ,cli.commentaire INFO_SUP
                ,dat_idx06 NUMADRENLVT,clienlev.adres1 ENLT_ADR1,clienlev.adres2 ENLT_ADR2,clienlev.cpost ENLT_CPOST,clienlev.ville ENLT_VILLE,clienlev.raisoc ENLT_RAISOC,clienlev.pays ENLT_PAYS
                from Kems_DataWeb colis
                left join t_negos_clients cli on cli.clilabo='" + societe+ @"' and cli.codeclient=cli_code
                left join t_negos_clients clienlev on clienlev.clilabo='" + societe + @"' and clienlev.codeclient=dat_idx06
              
                 left join t_negos_params orig on orig.prm_soccode='" + societe + @"' and orig.prm_table='ORIGINE' and orig.prm_coderec=dat_idx02 
                left join distrib_users usr on   usr.id=dat_idx04 and (usr.mainid='" + societe + "' or usr.id='" + societe + @"')
                where dat_type=402 and soc_code='" + societe + "' and dat_idx05='"+numtournee+"' and dat_idx04='"+livreur+"' and (dat_data13='"+date+ "') order by val_data31";
         
            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }


        public string listAdress(string login, string pwd, string societe, string type,string nom,string cp,string ville,string code,string raisoc,string prenom,string nonattribue)
        {

            string query = @"SELECT creatuser,horairesouverture, bureau,service, codepere, id,nom,prenom,clilabo soccode,codeclient,raisoc,adres1,adres2,cpost,ville,pays,tel1,tel2,commentaire,type,adr_email,mdp pwd,codvrp ,coderegion ,NOGRATUIT,IMP_DEMANDE,IMP_RAMASSAGE ,MDP2 
                FROM [T_NEGOS_CLIENTS] cli where cli.clilabo='" + societe + "' and visible is null  FILTRESOC FILTREPRENOM FILTRENOM FILTRECP FILTREVILLE FILTRECODECLI FILTRENONATTRIBUE order by  isnull(nom,'')+ isnull(raisoc,'')+isnull(service,'') ";

            /*
                *     string query = @"SELECT aff.ville aff_ville, aff.cpost aff_cpost, aff.raisoc aff_raisoc, cli.codepere, cli.id,cli.nom,cli.prenom,cli.clilabo soccode,cli.codeclient,cli.raisoc,cli.adres1,cli.adres2,cli.cpost,cli.ville,cli.pays,cli.tel1,cli.tel2,cli.commentaire,cli.type,cli.adr_email,cli.mdp pwd
               FROM [T_NEGOS_CLIENTS] cli left join t_negos_clients aff on cli.codepere=aff.codeclient where cli.clilabo='" + societe + "' and  cli.type='" + type + "' FILTRESOC FILTREPRENOM FILTRENOM FILTRECP FILTREVILLE FILTRECODECLI order by raisoc ";

                */

            if (nom == "" || nom == null)               
                query = query.Replace("FILTRENOM", "");
            else
                query = query.Replace("FILTRENOM", " and nom like '%" + nom + "%'");

            if (prenom == "" || prenom == null)
                query = query.Replace("FILTREPRENOM", "");
            else
                query = query.Replace("FILTREPRENOM", " and prenom like '%" + prenom + "%'");

            if (raisoc == "" || raisoc == null)
                query = query.Replace("FILTRESOC", "");
            else
                query = query.Replace("FILTRESOC", " and raisoc like '%" + raisoc + "%'");

            if (cp == "" || cp == null)
                query = query.Replace("FILTRECP", "");
            else
                query = query.Replace("FILTRECP", " and cpost like '" + cp + "%'");


            if (ville == "" || ville == null)
                query = query.Replace("FILTREVILLE", "");
            else
                query = query.Replace("FILTREVILLE", " and ville like '%" + ville + "%'");

            if (code == "" || code == null)
                query = query.Replace("FILTRECODECLI", "");
            else
                query = query.Replace("FILTRECODECLI", " and codeclient = '" + code + "'");


            if (nonattribue == "false" || nonattribue == "" || nonattribue == null)
                query = query.Replace("FILTRENONATTRIBUE", "");
            else
                query = query.Replace("FILTRENONATTRIBUE", " and CODVRP = '60'");

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string listAdressEnlevementWithColis(string login, string pwd, string societe)
        {

            string query = @"SELECT dat_idx06,sum(case when colis.dat_idx06 is null then 0 else 1 end) nbcolis, nom,prenom,clilabo soccode,codeclient,raisoc,adres1,adres2,cpost,ville,pays,tel1,tel2,commentaire,type,adr_email
                FROM [T_NEGOS_CLIENTS] 
                left join Kems_DataWeb colis on colis.dat_idx06=codeclient and   (colis.dat_data14='' or colis.dat_data14 is null) and   (colis.dat_data13='' or colis.dat_data13 is null)
               
                
                where clilabo='" + societe+"' and  type='E'   "+
                @" group by dat_idx06,nom,prenom,clilabo  ,codeclient,raisoc,adres1,adres2,cpost,ville,pays,tel1,tel2,commentaire,type,adr_email
                order by raisoc";

           

            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public class struct_createAdr
        {
            public string CODECLI { get; set; }
            public string CODEPERE { get; set; }
            public string RAISOC { get; set; }
            public string ADR1 { get; set; }
            public string ADR2 { get; set; }
            public string CP { get; set; }
            public string VILLE { get; set; }
            public string EMAIL { get; set; }
            public string TEL1 { get; set; }
            public string TEL2 { get; set; }
            public string COMMENT { get; set; }
            public string PAYS { get; set; }
            public string PWD { get; set; }
            public string NOM { get; set; }
            public string PRENOM { get; set; }
            public string BUREAU { get; set; }
            public string SERVICE { get; set; }
            public string HORAIRESOUVERTURE { get; set; }
        }

        public class struct_createClient
        {



            public string SOCIETE { get; set; }
            public string CODECLI { get; set; }
            public string NOM { get; set; }
            public string PRENOM { get; set; }
            public string ADR1 { get; set; }
            public string ADR2 { get; set; }
            public string CP { get; set; }
            public string VILLE { get; set; }
            public string EMAIL { get; set; }
            public string TEL1 { get; set; }
            public string PAYS { get; set; }
            public string TOURNEE { get; set; }
            public string IMP_DEMANDE { get; set; }
            public string IMP_RAMASSAGE { get; set; }

        }

        public string createClient(string login, string pwd, string societe, string tabjson)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<struct_createClient> bons = ser.Deserialize<List<struct_createClient>>(tabjson);
                if (bons.Count == 0) return "empty";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";

                        foreach (struct_createClient bon in bons)
                        {
                            string select = "select CODECLIENT from t_negos_clients where codeclient='" + bon.CODECLI + "'";

                            // Information distri_user 
                            string loginmort = bon.TOURNEE;
                            string select3 = "select *  from distrib_users where id='" + bon.TOURNEE + "' ";
                            DataTable dt3 = GetData(stConnString, select3);
                            if (dt3.Rows.Count > 0)
                            {

                                loginmort = dt3.Rows[0]["loginmort"].ToString();

                            }
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                query = "update t_negos_clients set " +


                                " CODVRP='" + controlFld(bon.TOURNEE) + "'," +
                                " CODEREGION='" + controlFld(loginmort) + "'," +
                                " IMP_DEMANDE='" + controlFld(bon.IMP_DEMANDE) + "'," +
                                " IMP_RAMASSAGE='" + controlFld(bon.IMP_RAMASSAGE) + "'" +


                                " where " +
                                "CODECLIENT='" + bon.CODECLI + "'";



                            }

                            ExecuteNonQuery(query, con);
                            ExecuteNonQuery("COMMIT TRANSACTION", con);
                            con.Close();

                            return "";
                        }
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }
        public string DeleteClient(string login, string pwd, string societe, string codeclient)
        {
            try
            {
               
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";
                        
                        query = "update t_negos_clients set " +

                        " VISIBLE='2'" +
         
                        " where " +
                        "CODECLIENT='" + controlFld(codeclient) + "'";

                        ExecuteNonQuery(query, con);
                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                        return "";
                        
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string createAdresse(string login, string pwd, string societe,string type, string tabjson,string creatuser)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<struct_createAdr> bons = ser.Deserialize<List<struct_createAdr>>(tabjson);
                if (bons.Count == 0) return "empty";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";

                        foreach (struct_createAdr bon in bons)
                        {
                            string select = "select CODECLIENT from t_negos_clients where codeclient='"+bon.CODECLI+"'";
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                query = "update t_negos_clients set " +
                                 
                                " RAISOC='" + controlFld(bon.RAISOC) + "'," +
                                 " CODEPERE='" + controlFld(bon.CODEPERE) + "'," +
                                " ADRES1='" + controlFld(bon.ADR1) + "'," +
                                " ADRES2='" + controlFld(bon.ADR2) + "'," +
                                " CPOST='" + controlFld(bon.CP) + "'," +
                                " VILLE='" + controlFld(bon.VILLE) + "'," +
                                " PAYS='" + controlFld(bon.PAYS) + "'," +

                                " NOM='" + controlFld(bon.NOM) + "'," +
                                " PRENOM='" + controlFld(bon.PRENOM) + "'," +
                                " BUREAU='" + controlFld(bon.BUREAU) + "'," +
                                " SERVICE='" + controlFld(bon.SERVICE) + "'," +

                                " TEL1='" + controlFld(bon.TEL1) + "'," +
                                " TEL2='" + controlFld(bon.TEL2) + "'," +
                                 " MDP='" + controlFld(bon.PWD) + "'," +
                                " COMMENTAIRE='" + controlFld(bon.COMMENT) + "'," +
                                " HORAIRESOUVERTURE='" + controlFld(bon.HORAIRESOUVERTURE) + "'," +
                                " ADR_EMAIL='" + controlFld(bon.EMAIL) + "'" +
                               
                                " where " +
                                "CODECLIENT='"+bon.CODECLI+"' and CLILABO='" + societe + "' ";

                            }
                            else
                            {

                                query = @"insert into t_negos_clients (CREATUSER,CLILABO,CODECLIENT, 
                                    RAISOC,ADRES1,ADRES2,CPOST,VILLE,PAYS,
                                    TEL1,TEL2,MDP,COMMENTAIRE,NOM,PRENOM,BUREAU,SERVICE,ADR_EMAIL   ,CODEPERE    ,HORAIRESOUVERTURE ,TYPE  ,CODVRP        
                                )  VALUES (  " +
                                        "'" + controlFld(creatuser) + "'," +
                                        "'" + controlFld(societe)       + "'," +
                                        "'" + controlFld(bon.CODECLI)   + "'," +
                                            "'" + controlFld(bon.RAISOC) + "'," +
                                        "'" + controlFld(bon.ADR1)      + "'," +
                                        "'" + controlFld(bon.ADR2)      + "'," +
                                        "'" + controlFld(bon.CP)        + "'," +
                                        "'" + controlFld(bon.VILLE)     + "'," +
                                        "'" + controlFld(bon.PAYS)      + "'," +
                                        "'" + controlFld(bon.TEL1)      + "'," +
                                        "'" + controlFld(bon.TEL2)      + "'," +
                                        "'" + controlFld(bon.PWD)       + "'," +
                                        "'" + controlFld(bon.COMMENT)   + "'," +
                                        "'" + controlFld(bon.NOM) + "'," +
                                        "'" + controlFld(bon.PRENOM) + "'," +
                                        "'" + controlFld(bon.BUREAU) + "'," +
                                        "'" + controlFld(bon.SERVICE) + "'," +    
                                        "'" + controlFld(bon.EMAIL)     + "'," +
                                        "'" + controlFld(bon.CODEPERE) + "'," +
                                         "'" + controlFld(bon.HORAIRESOUVERTURE) + "'," +
                                        "'" + type + "'," +
                                          "'" + controlFld("60") + "'" +
                                        ")";

                            }
                            ExecuteNonQuery(query, con);
                            ExecuteNonQuery("COMMIT TRANSACTION", con);
                            con.Close();

                            return "";
                        }
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string createGeocodage(string login, string pwd, string societe, string codeclient, string lon, string lat)
        {
            try
            {
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string update = "";

                        string query = "update t_negos_clients set LONGITUDE='"+lon+"',LATITUDE='"+lat+"' where codeclient='" + codeclient + "'";

                        query = query.Replace("THESET", update);
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();

                      
                        
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        //step =1 // chargement
        //step =2 // tournee
        //step =3 // chargement
        //step =4 // derniere presentation
        //step =5 // livraison
        public string setFlagToValue(string login, string pwd, string societe, string codecolis,string dateto,string step)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string update="";
                     /*   if (step == "1")
                            update = "dat_data12='" + dateto + "'";
                        if (step == "2")
                            update = "dat_data13='" + dateto + "'";*/
                        if (step == "3")
                            update = "dat_data14='" + dateto + "' , dat_data21='1', dat_data25='LOADINGSERVER' ";
                  /*      if (step == "4")
                            update = "dat_data15='" + dateto + "'";
                        if (step == "5")
                            update = "dat_data16='" + dateto + "'";
                   * */

                        string query = "update kems_data set THESET where soc_code='" + societe + "' and dat_idx01='" +codecolis +"'" ;

                        query = query.Replace("THESET",update);
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }



        public string putInStock(string login, string pwd, string societe, string codecolis)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string update = "";
                     
                        string query = "update kems_data set dat_data25='LOADINGSERVER' where soc_code='" + societe + "' and dat_idx01='" + codecolis + "'";

                        query = query.Replace("THESET", update);
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string deleteAddress(string login, string pwd, string societe, string id,string codecli)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string update = "";

                        string query = "delete from t_negos_clients where clilabo='" + societe + "'  and codeclient='" + codecli + "'"; ;

                        
                        ExecuteNonQuery(query, con);



                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public class struct_abo
        {
            public string IDABO { get; set; }
            public string DATEDEBUT { get; set; }
            public string DATEFIN { get; set; }
            public string NB_LICENCE { get; set; }
            public string ID_PAYER { get; set; }
            public string ID_PROFILE { get; set; }
            public string ACTIF { get; set; }
            public string COULEUR { get; set; }
            public string PU { get; set; }
          
        }
        public string createPaypal(string login, string pwd, string societe,  string tabjson)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<struct_abo> bons = ser.Deserialize<List<struct_abo>>(tabjson);
                if (bons.Count == 0) return "empty";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);
                        string query = "";

                        foreach (struct_abo bon in bons)
                        {
                            if (bon.IDABO==null || bon.IDABO=="") bon.IDABO="-1";

                            string select = "select * from t_negos_abo where id='" + bon.IDABO + "'";
                            DataTable dt = GetData(stConnString, select);
                            if (dt.Rows.Count > 0)
                            {
                                query = "update t_negos_abo set " +

                                " ACTIF='" + controlFld(bon.ACTIF) + "' " +
                                 
                                

                                " where " +
                                "id='" + bon.IDABO + "'  ";

                            }
                            else
                            {

                                query = @"insert into t_negos_abo (DATEDEBUT,DATEFIN, 
                                    NBLICENCE,ID_PAYER,ID_SOCIETE,prixunit,ID_PROFILE,COULEUR,ACTIF          
                                )  VALUES (  " +
                                        "'" + controlFld(bon.DATEDEBUT) + "'," +
                                        "'" + controlFld(bon.DATEFIN) + "'," +
                                        "'" + controlFld(bon.NB_LICENCE) + "'," +
                                        "'" + controlFld(bon.ID_PAYER) + "'," +
                                        "'" + controlFld(societe) + "'," +
                                        "'" + controlFld(bon.PU) + "'," +
                                        "'" + controlFld(bon.ID_PROFILE) + "'," +
                                        "'" + controlFld(bon.COULEUR) + "'," +
                                        "'" + controlFld(bon.ACTIF) + "'" +
                                        
                                        ")";

                            }
                            ExecuteNonQuery(query, con);
                            ExecuteNonQuery("COMMIT TRANSACTION", con);
                            con.Close();

                            return "";
                        }
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "NOK";

                }
                else
                {
                    return "NOK";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string getPaypal(string login, string pwd, string societe)
        {

            string query = @"select datefin, sum( case when u.id is null then 0 else 1 end) cntused,abo.nblicence,prixunit, abo.id,abo.datedebut,abo.datefin,abo.id_payer,abo.id_societe,abo.actif,abo.id_profile,abo.couleur 
from t_negos_abo abo left join distrib_users u on id_societe=mainid     and idabo=abo.id  
where id_societe=" + societe+@" and ( datefin is null or datefin='' or datefin>='"+DateTime_to_YYYYMMDD(0)+  @"') 

group by datefin, abo.nblicence, abo.id,abo.datedebut,abo.datefin,abo.id_payer,abo.id_societe,abo.actif,abo.id_profile,abo.couleur,prixunit ";



            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getStockLivreur(string login, string pwd, string societe,string livreur)
        {

            string query = "";

            //les colis   non livré sans code livreur, donc au dépot
            if (livreur == "")
            {
                query = @"select cli_code CODECLI,dat_idx01 NUMCOLISINTERNE,dat_idx03 NUMCOLISTRANSP ,
                dat_data01 NOM,dat_data02 PRENOM,dat_data03 ADR1,dat_data04 ADR2,dat_data05 CP,dat_data06 VILLE,
                dat_data07 EMAIL,dat_data08 TEL1,dat_data09 TEL2, dat_data10 COMMENT, dat_data11 SOCIETE,dat_data17 URGENCE,dat_data18 PERIODE,
                dat_data12 DATECREA,dat_data13 DATETOUR,dat_data14 DATECHARGE,dat_data15 DATEPRES,dat_data16 DATELIVR,val_data32 NBRPRES  from Kems_DataWeb
                where dat_type=402 and soc_code='" + societe + "' and isnull(dat_data25,'')=''   and isnull(dat_data23,'') not in ('1','0')";
    
            }
            else
            {
                //les colis  non livré avec code livreur donc dans un camion
                query = @"select cli_code CODECLI,dat_idx01 NUMCOLISINTERNE,dat_idx03 NUMCOLISTRANSP ,
                dat_data01 NOM,dat_data02 PRENOM,dat_data03 ADR1,dat_data04 ADR2,dat_data05 CP,dat_data06 VILLE,
                dat_data07 EMAIL,dat_data08 TEL1,dat_data09 TEL2, dat_data10 COMMENT, dat_data11 SOCIETE,dat_data17 URGENCE,dat_data18 PERIODE,
                dat_data12 DATECREA,dat_data13 DATETOUR,dat_data14 DATECHARGE,dat_data15 DATEPRES,dat_data16 DATELIVR,val_data32 NBRPRES  
                from Kems_DataWeb where dat_type=402 and soc_code='" + societe + "' and isnull(dat_data25,'')='" + livreur + "' and isnull(dat_data21,'')='1'  and isnull(dat_data23,'') not in ('1','0')";
            }


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getLogColis(string login, string pwd, string societe,string codecolis)
        {

            string query = @"SELECT l.*
              FROM [T_NEGOS_LOGCOLIS] l
              inner join Kems_DataWeb d on d.soc_code=l.soc_code
              where numcolis='" + codecolis+"' and (datepassage)< (d.dat_data14) and d.dat_type=402  order by id desc ";

            query = @"SELECT 
                       [numcolis]
                      ,usr.prenom livreur
                      ,[datepassage]
                      ,[motif]
                
                      ,[action]
                      ,[commentaire]
                      ,[etat]
                      ,[manu]
                      ,[codeaction]
                      ,enl.dat_data09 signenl
                      ,liv.dat_data09 signliv
                      ,[lat]
                      ,[lon]


              FROM [T_NEGOS_LOGCOLIS] l
              left join Kems_DataWeb enl on enl.dat_type=403 and numcolis = enl.cde_code and l.soc_code=enl.soc_code
               left join Kems_DataWeb liv on liv.dat_type=404 and numcolis = liv.cde_code and l.soc_code=liv.soc_code
        left join distrib_users usr on   usr.id=cast(livreur as integer) and (usr.mainid=l.soc_code)
where l.soc_code='" + societe + "'  and  numcolis='" + codecolis + "' GROUP BY [numcolis],usr.prenom ,[datepassage] ,[motif] ,[action] ,[commentaire]  ,[etat] ,[manu] ,[codeaction], enl.dat_data09 , liv.dat_data09,[lat],[lon]  order by datepassage desc";

        
            
        //  where l.soc_code='" + societe+ "'  and  numcolis='"+codecolis+"'  order by l.id desc ";



           //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
           //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getLogColisExtern(string login, string pwd, string societe, string codecolis)
        {

            string query  = @"SELECT 
                      colis.soc_code
                      ,[numcolis]
                      ,usr.login livreur
                      ,[datepassage]
                      ,[motif]               
                      ,[action]
                      ,[commentaire]
                      ,[etat]
                      ,[manu]
                      ,[codeaction],
                      enl.dat_data09 signenl,
                      liv.dat_data09 signliv,
                      colis.dat_data01 NOM,colis.dat_data02 PRENOM,colis.dat_data03 ADR1,colis.dat_data04 ADR2,colis.dat_data05 CP,colis.dat_data06 VILLE,
                      colis.dat_data07 EMAIL,colis.dat_data08 TEL1,colis.dat_data09 TEL2,colis.dat_idx03 NUMCOLISTRANSP,colis.dat_data11 SOCIETE,colis.dat_idx01 NUMCOLISINTERNE
                FROM [T_NEGOS_LOGCOLIS] l
                left join Kems_DataWeb enl on enl.dat_type=403 and codeaction = enl.cde_code and l.soc_code=enl.soc_code
                left join Kems_DataWeb liv on liv.dat_type=404 and codeaction = liv.cde_code and l.soc_code=liv.soc_code
                left join distrib_users usr on   usr.id=cast(livreur as integer) and (usr.mainid=l.soc_code)
                left join Kems_DataWeb colis on colis.dat_idx01=numcolis
        
                where    numcolis='" + codecolis + "' or colis.dat_idx03='"+codecolis+"' order by l.id desc ";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string stopAbo(string login, string pwd, string societe, string datefin, string idabo)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "update t_negos_abo set datefin='" + datefin + "',dateheuremodifabo=getdate() where id_profile='" + idabo+"'";
                        ExecuteNonQuery(query, con);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


        /*
         * sutcutre attendue
         * codeclient,raison sociale,nom,prenom, adresse1,adresse2, cpost,ville, pays,tel1,tel2,email,commentaire
         */
        public string IntegrationFileLivraison(string login, string pwd, string societe, string filepath)
        {
            try
            {
                string query = "";
                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");
                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        query = "update t_negos_clients set lastimport=0 where cli_labo='" + societe + "'";
                        ExecuteNonQuery(query, con);

                        

                        int counter = 0;
                        string line;

                        // Read the file and display it line by line.
                        System.IO.StreamReader file =
                           new System.IO.StreamReader(filepath);
                        while ((line = file.ReadLine()) != null)
                        {
                            //lecture de la 1ere ligne, on passe
                            if (counter == 0)
                            {

                            }
                            else
                            {
                                string codecli= Left(controlFld(GiveFldEx(line, 0, ";", "FIN")), 50) ;
                                codecli=codecli.Replace(",","");
                                codecli=codecli.Replace(".","");

                                query = "INSERT INTO T_NEGOS_CLIENTS (LASTIMPORT,CLILABO,DATCRE,TYPE,CODECLIENT,RAISOC,NOM,PRENOM,ADRES1,ADRES2,CPOST,VILLE,PAYS,TEL1,TEL2,ADR_EMAIL,COMMENTAIRE) values ("+
                                "'1'," +
                                "'" + societe + "'," +
                                "'"+DateTime_to_YYYYMMDD(0)+"'," +
                                "'L'," +
                                "'" +codecli+ "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 1, ";", "FIN")), 100) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 2, ";", "FIN")), 50) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 3, ";", "FIN")), 50) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 4, ";", "FIN")), 100) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 5, ";", "FIN")), 100) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 6, ";", "FIN")), 15) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 7, ";", "FIN")), 50) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 8, ";", "FIN")), 20) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 9, ";", "FIN")), 20) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 10, ";", "FIN")), 20) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 11, ";", "FIN")), 100) + "'," +
                                "'" + Left(controlFld(GiveFldEx(line, 12, ";", "FIN")), 255) + "'" +
                                
                                ")";

                                ExecuteNonQuery(query, con);
                            }

                            Console.WriteLine(line);
                            counter++;
                        }
                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        file.Close();
                  
                        File.Delete(filepath);

                        //on dedoublonne
                        query = @"delete from t_negos_clients where id in (
                            select id  from t_negos_clients c2   where c2.clilabo="+societe+" and  c2.id < any ( select c1.id from t_negos_clients c1 where c1.clilabo="+societe+" and  c2.id<>c1.id and c2.codeclient=c1.codeclient)  )";

                        ExecuteNonQuery(query, con);
                       
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }


       

        public string deleteLastImport(string login, string pwd, string societe)
        {
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    SqlCommand cmd = new SqlCommand("");

                    SqlConnection con = null;

                    try
                    {
                        con = new SqlConnection(stConnString);
                        con.Open();

                        ExecuteNonQuery("BEGIN TRANSACTION", con);

                        string query = "delete from t_negos_clients where lastimport=1 and clilabo='" + societe+"'";
                        ExecuteNonQuery(query, con);

                        ExecuteNonQuery("COMMIT TRANSACTION", con);
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }

                    return "OK";

                }
                else
                {
                    return "bad connstring";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

        public string getColisCount(string login, string pwd, string societes)
        {

            string query = @"select sum(cnt) cnt from (
SELECT   count(*) cnt FROM  Kems_DataWeb where dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1
union select count from countcolis) x ";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string cnt=dt.Rows[0]["cnt"].ToString();

                return cnt;
            }

            return "";
        }

        public string getColisCountBunddl(string login, string pwd, string societes)
        {

            string query = @" SELECT   count(*) cnt FROM  Kems_DataWeb where dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string cnt = dt.Rows[0]["cnt"].ToString();

                return cnt;
            }

            return "";
        }

        public string getColisCountSoc(string login, string pwd, string societes)
        {

            string query = @"SELECT  108000000 + count(*) cnt FROM  kems_data where dat_type=402 and soc_code='"+societes+"'  and isnull(dat_data16,'') <>'' and dat_data23=1 ";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string cnt = dt.Rows[0]["cnt"].ToString();

                return cnt;
            }

            return "";
        }
        public string getColisCountSocLast30d(string login, string pwd, string societes )
        {

            string query = @"SELECT left(dat_data16,8) datee, count(*) cnt FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8)>getdate()-180 group by left(dat_data16,8) order by  left(dat_data16,8)";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getColisCountSocLast12Months(string login, string pwd, string societes)
        {

            string query = @"SELECT left(dat_data16,8) datee, count(*) cnt FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8)>getdate()-1095 group by left(dat_data16,8) order by  left(dat_data16,8)";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getStatColisCountTournee(string login, string pwd, string societes, string tournee,string annee)
        {
            string query = "";
            // Information distri_user 
            string tourneeid = tournee;
            string loginmort = "";
            Boolean bloginmortexist = true;
           
            string stConnString1 = Auth(login, pwd);
            if (stConnString1 != "")
            {

               
                string select3 = "select *  from distrib_users where id='" + tournee + "' ";
              
                DataTable dt3 = GetData(stConnString1, select3);
                if (dt3.Rows.Count > 0)
                {

                    loginmort = dt3.Rows[0]["loginmort"].ToString();
                    if (loginmort == "")
                        bloginmortexist = false;

                }
               
            }
            



            if (bloginmortexist == true)
            {
                query = @"SELECT left(dat_data16,6) datee, count(*) cnt, dat_data26 as tournee FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,4)='" + annee + "' and dat_data26='" + tournee + "' group by left(dat_data16,6) ,dat_data26  order by  left(dat_data16,6)";

            }
            else
             query = @"SELECT left(dat_data16,6) datee, count(*) cnt, dat_idx05 as tournee FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,4)='"+ annee + "' and dat_idx05='" + tournee+ "' group by left(dat_data16,6) ,dat_idx05  order by  left(dat_data16,6)";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message+"  "+ query;
            }

            return " test ";
        }

        public string getStatColisCountTourneeDay(string login, string pwd, string societes, string tournee, string annee, string annee2)
        {
            string query = "";
            // Information distri_user 
            string tourneeid = tournee;
            string loginmort = "";
            Boolean bloginmortexist = true;
            string stConnString1 = Auth(login, pwd);
            if (stConnString1 != "")
            {


                string select3 = "select *  from distrib_users where id='" + tournee + "' ";
                DataTable dt3 = GetData(stConnString1, select3);
                if (dt3.Rows.Count > 0)
                {

                    loginmort = dt3.Rows[0]["loginmort"].ToString();
                    if (loginmort == "")
                        bloginmortexist = false;

                }
            }

            if(tournee=="0")
            {
                query = @"SELECT left(dat_data16,8) datee, count(*) cnt FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8)>='" + annee + "' and left(dat_data16,8)<='" + annee2 + "'  and dat_data26 <>'' group by left(dat_data16,8)   order by  left(dat_data16,8)";

            }
            else
            {
                if (bloginmortexist == true)
                {
                    query = @"SELECT left(dat_data16,8) datee, count(*) cnt, dat_data26 as tournee FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8)>='" + annee + "' and left(dat_data16,8)<='" + annee2 + "'  and dat_data26='" + tournee + "' group by left(dat_data16,8) ,dat_data26  order by  left(dat_data16,8)";

                }
                else
                    query = @"SELECT left(dat_data16,8) datee, count(*) cnt, dat_idx05 as tournee FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1  and left(dat_data16,8)>='" + annee + "' and left(dat_data16,8)<='" + annee2 + "'  and dat_idx05='" + tournee + "' group by left(dat_data16,8) ,dat_idx05  order by  left(dat_data16,8)";

              
            }

            
            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);
                    return json;



                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointAMCountTournee(string login, string pwd, string societes, string tournee, string annee)
        {
            string query = "";
            // Information distri_user 
            string tourneeid = tournee;
            string loginmort = "";
            Boolean bloginmortexist = true;
            string stConnString1 = Auth(login, pwd);
            if (stConnString1 != "")
            {


                string select3 = "select *  from distrib_users where id='" + tournee + "' ";
                DataTable dt3 = GetData(stConnString1, select3);
                if (dt3.Rows.Count > 0)
                {

                    loginmort = dt3.Rows[0]["loginmort"].ToString();
                    if (loginmort == "")
                        bloginmortexist = false;

                }
            }



            //if (bloginmortexist == true)
            {
                query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeSITE_AM3 where  left(dates,4)='" + annee + "' and tournee='" + tournee + "' order by  datee ";

            }
            //else
              //  query = @"SELECT left(dat_data16,6) datee, count(*) cnt, dat_idx05 as tournee FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,4)='" + annee + "' and dat_idx05='" + tournee + "' group by left(dat_data16,6) ,dat_idx05  order by  left(dat_data16,6)";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointPMCountTournee(string login, string pwd, string societes, string tournee, string annee)
        {
            string query = "";
          
                query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeSITE_PM3 where  left(dates,4)='" + annee + "' and tournee='" + tournee + "' order by  datee ";

         
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }

        public string getStatPointAMCountTourneeDay(string login, string pwd, string societes, string tournee, string annee,string annee2)
        {
            string query = "";
           

          
            if(tournee=="0")
            {
                query = @"SELECT dates as datee, qte as cnt   FROM  V_FrequenceClientTourneeSITE_AM4ALLTOURNEE where  left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "'  order by  datee ";

            }
            else
                query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeSITE_AM3DAY where  left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "' and tournee='" + tournee + "' order by  datee ";

           
            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointPMCountTourneeDay(string login, string pwd, string societes, string tournee, string annee,string annee2)
        {
            string query = "";

            if (tournee == "0")
            {
                query = @"SELECT dates as datee, qte as cnt FROM  V_FrequenceClientTourneeSITE_PM4ALLTOURNEE where  left(dates,8)>='" + annee + "' and  left(dates,8)<='" + annee2 + "'  order by  datee ";

            }
            else
             query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeSITE_PM3DAY where  left(dates,8)>='" + annee + "' and  left(dates,8)<='" + annee2 + "'  and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }


        public string getStatPointEnlevAMCountTournee(string login, string pwd, string societes, string tournee, string annee)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeEnlevSITE_AM3 where  left(dates,4)='" + annee + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointEnlevPMCountTournee(string login, string pwd, string societes, string tournee, string annee)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeEnlevSITE_PM3 where  left(dates,4)='" + annee + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointEnlevAMCountTourneeDay(string login, string pwd, string societes, string tournee, string annee,string annee2)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeEnlevSITE_AM3 where   left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointEnlevPMCountTourneeDay(string login, string pwd, string societes, string tournee, string annee,string annee2)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeEnlevSITE_PM3 where  left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }

        public string getStatPoint24HCountTourneeDay(string login, string pwd, string societes, string tournee, string annee, string annee2)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeSITE_PM4DAY_24H_SUM where  left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getStatPointEnlev24HCountTourneeDay(string login, string pwd, string societes, string tournee, string annee, string annee2)
        {
            string query = "";

            query = @"SELECT dates as datee, qte as cnt,  tournee FROM  V_FrequenceClientTourneeEnlevSITE_PM4DAY_24H_SUM where  left(dates,8)>='" + annee + "' and left(dates,8)<='" + annee2 + "' and tournee='" + tournee + "' order by  datee ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }


        public string getStatPointAMFrequence(string login, string pwd, string societes, string nom, string annee)
        {
            string query = "";

            query = @"SELECT NOM, ADRESSE,CODEPOSTAL,VILLE,DATES, QTE,CLI_CODE   FROM  V_FrequenceClientTournee_XLS_AM where  left(DATES,4)='" + annee + "'  and CLI_CODE ='" +nom + "' order by  DATES ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }

        public string getStatPointPMFrequence(string login, string pwd, string societes, string nom, string annee)
        {
            string query = "";

            query = @"SELECT NOM, ADRESSE,CODEPOSTAL,VILLE,DATES ,QTE,CLI_CODE   FROM  V_FrequenceClientTournee_XLS_PM where  left(DATES,4)='" + annee + "'  and CLI_CODE ='" + nom + "' order by  DATES ";


            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }
        public string getColisCountSoc2017(string login, string pwd, string societes)
        {

            

            string query = @"SELECT  datee, cnt FROM  androidtable_dashboard_2017  order by datee";
            //string query = @"SELECT left(dat_data16,8) datee, count(*) cnt FROM  Kems_DataWeb where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8) like'2017%' group by left(dat_data16,8) order by  left(dat_data16,8)";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getColisCountSoc2018(string login, string pwd, string societes)
        {
            moveSign(DIR_SAN + "\\bunddl\\gossart\\23\\signatures", "*.jpg");


            string query = @"SELECT  datee, cnt FROM  androidtable_dashboard_2018  order by datee";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getColisCountSoc2019(string login, string pwd, string societes)
        {

            movePhotos(DIR_SAN + "\\bunddl\\gossart\\23\\photos", "*.jpg");
            
         

            string query = @"SELECT  datee, cnt FROM  androidtable_dashboard_2019  order by datee";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string getColisCountSocLivreurLast30d(string login, string pwd, string societes)
        {

            string query = @"SELECT u.login,dat_data26 livreur, count(*) cnt FROM  Kems_DataWeb left join distrib_users u on dat_data26=u.id where soc_code='" + societes + "' and  dat_type=402  and isnull(dat_data16,'') <>'' and dat_data23=1 and left(dat_data16,8)>getdate()-180 group by u.login, dat_data26";

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);

                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }

        public string indicators(string login, string pwd, string societes)
        {

            string query = @"
                SELECT 'COLISLIVR' type,count(*) cnt
                  FROM  [Kems_DataWebIndicators]
                  where dat_type=402 and dat_data23='1' and soc_code='SOCCODE'
                  union 
                  SELECT 'CLIENTLIVR',count(distinct(cli_code)) cnt
                  FROM [Kems_DataWebIndicators]
                  where dat_type=402 and dat_data23='1' and soc_code='SOCCODE'
                    union 
                  SELECT 'MOYLIVRJOUR',round(cast(count(*) as float)/cast((count(distinct(left(dat_data16,8)))) as float),2) cnt
                  FROM  [Kems_DataWebIndicators]
                  where dat_type=402 and dat_data23='1' and soc_code='SOCCODE'
                  union
                  SELECT 'URGENCE', round( ( sum(  case when dat_idx09 ='1' then 1 else 0 end) / cast(count(*) as float))*100,2)  cnt
                  FROM  [Kems_DataWebIndicators]
                  where dat_type=402 and dat_data23='1' and soc_code='SOCCODE'";

            query = query.Replace("SOCCODE", societes);

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);
                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
        public string GetXLS_ListeColisMois_Demandeur(string login, string pwd,  string AAAAMM, string DEMANDEUR)
        {
            string query = "";

            query = @"SELECT [nocolis],[nom],[adresse],[cp],[ville],[datelivraison_souhaite],[date_enlevement],[date_livraison],[ampm],[motif_enlevement],[motif_livraison]   FROM  XLS_ListeColisMois_Demandeur where  datelivraison_souhaite like'" + AAAAMM + "%' and demandeur='" + DEMANDEUR + "'  order by  datelivraison_souhaite ";



            try
            {

                string stConnString = Auth(login, pwd);
                if (stConnString != "")
                {
                    DataTable dt = GetData(stConnString, query);

                    string json = ConvertDataTabletoString(dt);

                    return json;
                }
            }
            catch (Exception ex)
            {

                return "err: " + ex.Message + "  " + query;
            }

            return "" + query;
        }

        public string indicatorsGen(string login, string pwd, string societes)
        {

            string query = @"select  email,soc_code,sum(cntcreat) cntcreat,sum(cntlivr) cntlivr,sum(creathier) creathier ,sum(livrhier) livrhier,sum(creattoday) creattoday,sum(livrtoday) livrtoday from (
                SELECT login,email,colis.soc_code,count(*) cntcreat,sum(case when dat_data23='1' then 1 else 0 end) as cntlivr,0 as creathier,0 as livrhier ,0 creattoday,0 livrtoday
                  FROM  [Kems_DataWeb] colis
  
                  inner join distrib_users u on u.id=colis.soc_code
                   where dat_type=402 and u.id not in (21,5)
                  group by colis.soc_code,email
  
                 union
 
                 SELECT login,email,colis.soc_code,0,0,count(*)  creathier,sum(case when dat_data23='1' then 1 else 0 end) as cnthier ,0,0
                  FROM  [Kems_DataWeb] colis
  
                  inner join distrib_users u on u.id=colis.soc_code
                   where dat_type=402 and u.id not in (21,5) and (left(dat_data12,8)=CONVERT(VARCHAR(8), GETDATE()-1, 112) or  left(dat_data16,8)=CONVERT(VARCHAR(8), GETDATE()-1, 112)   )
                  group by colis.soc_code,login,email 
  
                   union
 
                 SELECT login,email,colis.soc_code,0,0,0,0,count(*)  creathier,sum(case when dat_data23='1' then 1 else 0 end) as cnthier 
                  FROM  [Kems_DataWeb] colis
  
                  inner join distrib_users u on u.id=colis.soc_code
                   where dat_type=402 and u.id not in (21,5) and (left(dat_data12,8)=CONVERT(VARCHAR(8), GETDATE(), 112) or  left(dat_data16,8)=CONVERT(VARCHAR(8), GETDATE(), 112)   )
                  group by colis.soc_code,login,email 
  
  
                  ) x
                  group by login,email,soc_code order by soc_code";

            query = query.Replace("SOCCODE", societes);

            //   union select dat_idx01,'',dat_data13,'','TOURNEE','','1','','' from kems_data left join t_negos_logcolis on dat_data13=datepassage and dat_type=402 and 
            //   action='TOURNEE'  and numcolis=dat_idx01 where  numcolis is null and dat_idx01='" + codecolis+"' order by datepassage desc";


            string stConnString = Auth(login, pwd);
            if (stConnString != "")
            {
                DataTable dt = GetData(stConnString, query);
                string json = ConvertDataTabletoString(dt);

                return json;
            }

            return "";
        }
    }
}
