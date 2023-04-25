using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Danem.suite.common
{
    public class Constos
    {
        public struct structCommande
        {
            public string code;
        }
        public struct structCli
        {
            public string code;
            public string rs;
            public string numero_adr;
            public string adr1;
            public string adr2;
            public string cp;
            public string ville;
            public string commentaire;
            public string lat;
            public string lon;
            public string tel;
            public double distance;
        };
        public struct structArt
        {
            public string codeart;
            public string name;
            public string filename;
            public int largeur_cm;
            public int hauteur_cm;
            public string rowValuesAtEntry;//valeur de la ligne quand on entre dedans. on comparera avec la valeur en sortant, afin de savoir si on sauve
            public bool knownSize; //on connait la taille au depart
            public int type;    //0 = client, 1=client defaut, 2 = MDD, 3 = Concurrent
        };

        static public  Color[] arrayColor ={
            Color.Blue,
            Color.Red,
            Color.Green,
            Color.Violet,
            Color.Black,
            Color.Pink,
            Color.Chocolate,
            Color.Lavender,
            Color.Peru,
            Color.Silver,
            Color.Tomato,
            Color.Yellow,
            Color.MintCream,
            Color.DarkOliveGreen,
            Color.DarkOrange,
            Color.DarkMagenta,
            Color.Cyan,
            Color.Gray,
            Color.IndianRed,
            Color.MintCream
        };

        public struct structKD
        {
            public string FIELD_KD_soc_code;
            public string FIELD_KD_cli_code;
            public string FIELD_KD_pro_code;
            public string FIELD_KD_vis_code;
            public string FIELD_KD_cde_code;
            public string FIELD_KD_dat_type;
            public string FIELD_KD_dat_idx01;
            public string FIELD_KD_dat_idx02;
            public string FIELD_KD_dat_idx03;
            public string FIELD_KD_dat_idx04;
            public string FIELD_KD_dat_idx05;
            public string FIELD_KD_dat_idx06;
            public string FIELD_KD_dat_idx07;
            public string FIELD_KD_dat_idx08;
            public string FIELD_KD_dat_idx09;
            public string FIELD_KD_dat_idx10;
            public string FIELD_KD_dat_data01;
            public string FIELD_KD_dat_data02;
            public string FIELD_KD_dat_data03;
            public string FIELD_KD_dat_data04;
            public string FIELD_KD_dat_data05;
            public string FIELD_KD_dat_data06;
            public string FIELD_KD_dat_data07;
            public string FIELD_KD_dat_data08;
            public string FIELD_KD_dat_data09;
            public string FIELD_KD_dat_data10;
            public string FIELD_KD_dat_data11;
            public string FIELD_KD_dat_data12;
            public string FIELD_KD_dat_data13;
            public string FIELD_KD_dat_data14;
            public string FIELD_KD_dat_data15;
            public string FIELD_KD_dat_data16;
            public string FIELD_KD_dat_data17;
            public string FIELD_KD_dat_data18;
            public string FIELD_KD_dat_data19;
            public string FIELD_KD_dat_data20;
            public string FIELD_KD_dat_data21;
            public string FIELD_KD_dat_data22;
            public string FIELD_KD_dat_data23;
            public string FIELD_KD_dat_data24;
            public string FIELD_KD_dat_data25;
            public string FIELD_KD_dat_data26;
            public string FIELD_KD_dat_data27;
            public string FIELD_KD_dat_data28;
            public string FIELD_KD_dat_data29;
            public string FIELD_KD_dat_data30;
            public string FIELD_KD_val_data31;
            public string FIELD_KD_val_data32;
            public string FIELD_KD_val_data33;
            public string FIELD_KD_val_data34;
            public string FIELD_KD_val_data35;
            public string FIELD_KD_val_data36;
            public string FIELD_KD_val_data37;
            public string FIELD_KD_val_data38;
            public string FIELD_KD_val_data39;
            public string FIELD_KD_val_data40;
            public string FIELD_KD_user_code;
            public string FIELD_KD_date_insert;
            public string FIELD_KD_date_update;
        };

        //Variable
        public static String SURCHARGECAMION = "SURCHARGE CAMION";
        //CLIENT

        public static String FIELD_CLI_CODECLIENT = "CODECLIENT";
        public static String FIELD_CLI_RAISOC = "RAISOC";
        public static String FIELD_CLI_ADR1 = "ADRES1";
        public static String FIELD_CLI_ADR2 = "ADRES2";
        public static String FIELD_CLI_CP = "CPOST";
        public static String FIELD_CLI_VILLE = "VILLE";
        public static String FIELD_CLI_TELEP = "TELEP";
        public static String FIELD_CLI_FAX = "FAX";
        public static String FIELD_CLI_COMMENTAIRE = "COMMENTAIRE";
        public static String FIELD_CLI_EMAIL = "ADR_EMAIL";
        public static String FIELD_CLI_LATITUDE = "LATITUDE";
        public static String FIELD_CLI_LONGITUDE = "LONGITUDE";
        public static String FIELD_CLI_FREQ = "FREQVIS";
        public static String FIELD_CLI_DATEDEPART = "DATEDEPART";
        public static String FIELD_CLI_JOURPASSAGE = "JOURPASSAGE";
        public static String FIELD_CLI_NUMJOURPASSAGE = "NUMJOURPASSAGE";
        public static String FIELD_CLI_CODETOURNEE = "CODETOURNEE";
        public static String FIELD_CLI_PASSAGEEXCEPT1 = "PASSAGEEXCEPT1";
        public static String FIELD_CLI_CODECLIENTPERE = "CODECLIENTPERE";


        public static int KD_TYPE_500COLIS = 500;
        public static String FIELD_500COLIS_CODECLIENT = "cli_code";
        public static String FIELD_500COLIS_CODEART = "pro_code";
        public static String FIELD_500COLIS_CODETOURNEE = "dat_idx01";
        public static String FIELD_500COLIS_TYPETITRE = "dat_idx04";
        public static String FIELD_500COLIS_QTE = "dat_data05";

        public static String FIELD_500COLIS_FLAG = "dat_data30";
        public static String FIELD_500COLIS_MONTANT = "val_data31";


        public static int KD_TYPE_501BONRETOUR = 501;
        public static String FIELD_501BONRETOUR_CODEART = "pro_code";
        public static String FIELD_501BONRETOUR_TYPETITRE = "dat_idx04";
        public static String FIELD_501BONRETOUR_BON = "dat_data05";
     


     //Planification
     
        public  static String FIELD_PLANI_NOINTERVENTION ="NOINTERVENTION";
        public  static String FIELD_PLANI_IDPDC ="IDPDC";
        public  static String FIELD_PLANI_CODE_ENS ="CODE_ENS";
        public  static String FIELD_PLANI_DATE_INTERVENTION ="DATE_INTERVENTION";
        public  static String FIELD_PLANI_HORAIRE ="HORAIRE";
        public  static String FIELD_PLANI_EQUIPE ="EQUIPE";
        public  static String FIELD_PLANI_OBSERVATION ="OBSERVATION";
        public  static String FIELD_PLANI_NOM_GARDIEN ="NOM_GARDIEN";
        public  static String FIELD_PLANI_TEL_GARDIEN ="TEL_GARDIEN";
        public  static String FIELD_PLANI_TYPE_RELEVE ="TYPE_RELEVE";
        public  static String FIELD_PLANI_TYPE_SUPPORT ="TYPE_SUPPORT";
        public  static String FIELD_PLANI_ACTION ="ACTION";
        public  static String FIELD_PLANI_MATERIEL_STOCK ="MATERIEL_STOCK";
        public  static String FIELD_PLANI_TYPE_INTER ="TYPE_INTER";
        public  static String FIELD_PLANI_FLUIDE ="FLUIDE";
        public  static String FIELD_PLANI_ETAT ="ETAT";
        public  static String FIELD_PLANI_DATETRI ="DATETRI";

public  static String FIELD_PLANI_ASK_DATE ="ASK_DATE";
public  static String FIELD_PLANI_ASK_WHO ="ASK_WHO";

      






        public const string IDS_LANG_FR = "Francais";
        public const string IDS_LANG_EN = "English";
        public const string IDS_LANG_OT = "Other";

        public const int IMG_FDR_TROU = 1;
        public const int IMG_FDR_PETITE_LATTE = 2;
        public const int IMG_FDR_GRANDE_LATTE = 3;

        public const int TAB_ARBO_AUTO = 0;
        public const int TAB_ARBO_MANU = 1;
        public const int TREENODE_MAX_SON = 5;

        public const int PRO_DEFAULT_HEIGHT = 33;
        public const int PRO_DEFAULT_WIDTH = 33;

        public const int ETAGERE_MAXCOUNT = 10;

        public struct listWidget
        {
            public string classname;
            public string description;
            public int id;
            public int fam;
            public bool specific;
        };

        /*
         * REGISTRY
         */
        public const string INI_KEY = "SOFTWARE\\danem\\suite\\";
        public const string INI_KEY_GENERAL = INI_KEY;
        public const string INI_KEY_PLUTON = "SOFTWARE\\danem\\pluton\\";
        public const string INI_KEY_MAPPC2 = "SOFTWARE\\danem\\mappc2\\";
        public const string INI_KEY_WS = "SOFTWARE\\danem\\WSDB\\";
        public const string INI_KEY_ERP = "SOFTWARE\\danem\\KEMS\\ERP\\";
        public const string INI_ERP_CODE = "ERP_CODE";
        public const string INI_ERP_IMG = "ERP_IMG";
        public const string INI_KEY_PDA = "SOFTWARE\\danem\\KEMS\\PDA\\";
        public const string INI_KEY_BDD = "SOFTWARE\\danem\\pluton\\bdd\\";


        public const string INI_DIR_VERIFUPLOAD = "dir_verifupload";
        public const string INI_DIR_VERIFDOWNLOAD = "dir_verifdownload";
        public const string INI_DIR_UPLOAD = "dir_upload";
        public const string INI_USERID = "userid";
        public const string INI_ACTIVESOC = "activeSoc";
        public const string INI_PDA_CODE = "PDA_CODE";
        public const string INI_MAPPC2_FONDDERAYON = "FondDeRayon";
        public const string INI_INSTALLDIR = "installDir";
        public const string INI_DATADIR = "dataDir";
        public const string INI_MAPPC2_PHOTOCATALOGUEPATH = "photos_catalogue_path";
        public const string INI_MAPPC2_PHOTODEFAUTPATH = "photo_defaut_path";
        public const string INI_MAPPC2_PHOTOMDDPATH = "photo_mdd_path";
        public const string INI_MAPPC2_PHOTOCONCPATH = "photo_conc_path";

        public const string INI_ARMOIRE1_NAME = "Armoire1";
        public const string INI_ARMOIRE2_NAME = "Armoire2";
        public const string INI_ARMOIRE3_NAME = "Armoire3";
        public const string INI_ARMOIRE4_NAME = "Armoire4";
        public const string INI_ARMOIRE5_NAME = "Armoire5";

        public const string INI_DSN = "DSN";
        public const string INI_DSN_PWD = "DSN_PWD";
        public const string INI_DSN_USER = "DSN_USER";
        public const string INI_DSN_ENGINE = "DSN_ENGINE";
        public const string INI_DSN_DECIMALVIRG = "DSN_DECIMALVIRGULE";
        public const string INI_DBNAME = "DBNAME";
        public const string INI_DBNAME_DEFAULT_VALUE = "picking2";//pour les impressions le nom de la base de données doit être connu

        //RPT's
        public const string RPT_INVENTAIRE_HISTO1 = "print_inventaire_histo1.rpt";
        public const string RPT_INVENTAIRE1= "print_inventaire1.rpt";
        public const string RPT_PREPACDE_HISTO1 = "print_prepacde_histo1.rpt";
        public const string RPT_PREPACDE_BL = "print_prepacde_bl.rpt";
        public const string RPT_PREPACDE_BL_RELIQUAT = "print_prepacde_bl_reliquat.rpt";
        public const string RPT_PREPACDE_COMMENT = "print_prepacde_comment.rpt";
        public const string RPT_PREPACDE_COMMENT_HISTO = "print_prepacde_comment_histo.rpt";
        public const string RPT_RECEPTCDE_HISTO1 = "print_receptcde_histo1.rpt";
        public const string RPT_PREPACDE_MANAGER2 = "print_prepacde_manager2.rpt";
        public const string RPT_RECEPTCDE_MANAGER1 = "print_receptcde_manager1.rpt";
        public const string RPT_PARITYSSPE_CDEFOURCOMPLET = "print_parspe_cdefourcomplet.rpt";//imprime une cde à prep avec le numcde pere
        public const string RPT_PARITYSSPE_CDEFOURCS= "print_parspe_cdefourcs.rpt";//imprime une cde de cs
        public const string RPT_PREPACDE_ETIQUETTEBAC = "print_prepacde_etiquettebac.rpt";
        public const string RPT_PREPACDE_ETIQUETTEPRODUITS= "print_etiquettes_produits.rpt";
        public const string RPT_BDC1 = "print_bdc1.rpt";

        //ODBC DE WS DANEM PAR DEFAUT
        public const string INI_WS_DSN = "DSN";
        public const string INI_WS_DSN_PWD = "DSN_PWD";
        public const string INI_WS_DSN_USER = "DSN_USER";
        public const string INI_WS_DSN_ENGINE = "DSN_ENGINE";

        //taille des widgets
        public const string INI_WD_TAUXPRES_X = "WD_TXPRES_X";
        public const string INI_WD_TAUXPRES_Y = "WD_TXPRES_Y";
        public const string INI_WD_TAUXPRES_H = "WD_TXPRES_H";
        public const string INI_WD_TAUXPRES_W = "WD_TXPRES_W";

        public const string ENGINE_ORACLE = "ORACLE";
        public const string ENGINE_SQLSERVER = "SQL SERVER";
     //   public const string ENGINE_ACCESS = "ACCESS";

        public const string INI_LANGUAGE = "Language";

        public const string INI_CURRENTLICENCEID = "CURRENTLICENCEID";
        public const string INI_MAJELAPSETIME = "MAJELAPSETIME";
        public const string INI_IDPDAADMIN = "IDPDAADMIN";
        public const string INI_LICENCEKEY = "LICENCEKEY";
        public const string INI_TRANSFERTDIR = "TRANSFERTDIR";
        public const string INI_IP_SRVDANEM = "IP_SRVDANEM";
        public const string INI_WORKINGDIR = "ISWORKINGDIR";
        public const string INI_APPDIR = "appdir";

        public static string WAV_GPS = "17216__meatball4u__countdown.wav";
        public static string WAV_ERROR = "67454__Splashdust__negativebeep.wav";
        /*
         * DIRECTORIES
         */
        public static string DWAV = "wav\\";
        public static string DAPPLICATIONDATA = "";
        public const string DIMPORT = "download\\";
        public const string DLOG = "traces\\";
        public const string DEXPORT = "upload\\";
        public const string DIMPORT_SAVE = "download\\save\\";
        public const string DEXPORT_SAVE = "upload\\save\\";
        public static string DDATABASE = "database\\";
        public static string DREPORT = "impressions\\";
        public static string DDOC = "documents\\";
        public static string DSAVE = "\\save\\";

        public const string FTRACE = "trace.txt";

        public const int TYPE_WIDGET_CRM = 1;
        public const int TYPE_WIDGET_RL = 2;
        public const int TYPE_WIDGET_CDE = 4;
        public const int TYPE_WIDGET_PREPACDE = 8;
        public const int TYPE_WIDGET_RECEPTCDE = 16;
        public const int TYPE_WIDGET_INVENTAIRE = 32;
        public const int TYPE_WIDGET_GESTION = 64;
        public const int TYPE_RIGHTS = 128;
        public const int TYPE_WIDGET_SAGE = 256;


        public const string CONFIG_DEFAULT = "Défaut";
        /*
         * FILES
         */
        public const string FILE_SCR_SCRIPT_PREFIX = "kems_scr";
        public const string FILE_SCR_SCRIPT_EXT = ".dat";
        public const string FILE_SCR_SCRIPT_ASK = ".ASK";
        public const string FILE_ZRUNNER_CLIENT = "zr_launch.exe";
        public const string FILE_ZRUNNER_SERVER = "zrunner.exe";
        public const string FILE_KEMS_DAT = "kems.sql";
        public const string FILE_KEMS_DATABASE_DEF = "kems_database.sqd";
        public const string FILE_DSC = "danem_suite_cfg.tsv";

        public const string FILE_KEMSAPP = "KemsFormDesigner.exe";
        public const string FILE_INFFILE = "kems_cab.inf";
        public const string FILE_CABWIZ = "cabwiz.exe";

        public const string POLICE_CODE39 = "C39T36L.TTF";

        #region TABLENAME_REFER
        public const string TABLENAME_REFER = "kems_refer";
        public const string FLD_REFER_NUMREF = "numref";
        public const string FLD_REFER_ENSEIGNE = "prm_ens_code";
        public const string FLD_REFER_TYPO = "prm_assort_code";
        public const string FLD_REFER_CODEART = "pro_code";
        public const string FLD_REFER_REGLE = "regle";
        #endregion

        #region TABLENAME_PARAM
        /************************************************************************/
        /* PARAM                                                                     */
        /************************************************************************/
        public const string TABLENAME_PARAM = "kems_param";
        public const string FLD_PARAM_SOC_CODE = "soc_code";
        public const string FLD_PARAM_TABLE = "prm_table";
        public const string FLD_PARAM_CODEREC = "prm_coderec";
        public const string FLD_PARAM_LBL = "prm_lbl";
        public const string FLD_PARAM_COMMENT = "prm_comment";
        public const string FLD_PARAM_ACTIF = "prm_actif";
        public const string FLD_PARAM_VALUE = "prm_value";
        public const string FLD_PARAM_ORDER = "prm_order";

        public const string PARAM_RAYON = "RAYON";
        public const string PARAM_TYPO = "TYPO";
        public const string PARAM_FAM1 = "FAM1";
        public const string PARAM_FAM2 = "FAM2";
        public const string PARAM_FAM3 = "FAM3";
        public const string PARAM_FAM4 = "FAM4";
        public const string PARAM_FAM5 = "FAM5";
        public const string PARAM_FAM6 = "FAM6";
        public const string PARAM_TYPECDE = "TYPECDE";
        public const string PARAM_MSGRELIQ = "MSGRELIQ";
        #endregion

        #region TABLENAME_PROD_FAM1
        /************************************************************************/
        /* FAMILLE 1 PRODUIT                                                                     */
        /************************************************************************/
        public const string TABLENAME_PROD_FAM1 = TABLENAME_PARAM;
        public const string FLD_PRFAM1_TABLE = FLD_PARAM_TABLE;
        public const string FLD_PRFAM1_CODE = FLD_PARAM_CODEREC;
        public const string FLD_PRFAM1_LBL = FLD_PARAM_LBL;
        public const string FLD_PRFAM1_ORDER = FLD_PARAM_ORDER;
        #endregion


        #region TABLENAME_CLIENT
        /************************************************************************/
        /* CLIENT                                                                     */
        /************************************************************************/
        public const string TABLENAME_CLIENT = "kems_client";
        public const string FLD_CLIENT_CLI_CODE = "cli_code";
        public const string FLD_CLIENT_CLI_RS = "cli_rs";
        public const string FLD_CLIENT_CLI_ADR1 = "cli_adr1";
        public const string FLD_CLIENT_CLI_ADR2 = "cli_adr2";
        public const string FLD_CLIENT_CLI_CP = "cli_cp";
        public const string FLD_CLIENT_CLI_VILLE = "cli_ville";
        public const string FLD_CLIENT_CLI_TEL = "cli_tel";
        public const string FLD_CLIENT_CLI_FAX = "cli_fax";
        public const string FLD_CLIENT_CLI_LAT = "cli_gps_lat";
        public const string FLD_CLIENT_CLI_LON = "cli_gps_lon";
        public const string FLD_CLIENT_ENS_CODE = "prm_ens_code";
        #endregion

        #region TABLENAME_CLIENTADR
        /************************************************************************/
        /* ADRESSES CLIENT                                                                     */
        /************************************************************************/
        public const string TABLENAME_CLIENTADR     = "T_NEGOS_CLIENTS_ADRESSES";
        public const string FLD_CLIENTADR_CODESOC   = "CODE_SOC";
        public const string FLD_CLIENTADR_CODEVRP   = "CODEVRP";
        public const string FLD_CLIENTADR_NUMLIN    = "LI_NO";
        public const string FLD_CLIENTADR_CODECLI   = "CODECLI";
        public const string FLD_CLIENTADR_ADR1      = "LI_ADRESSE";
        public const string FLD_CLIENTADR_ADR2      = "LI_COMPLEMENT";
        public const string FLD_CLIENTADR_CP        = "LI_CODEPOSTAL";
        public const string FLD_CLIENTADR_VILLE     = "LI_VILLE";
        public const string FLD_CLIENTADR_PAYS      = "LI_PAYS";
        public const string FLD_CLIENTADR_CONTACT   = "LI_CONTACT";
        public const string FLD_CLIENTADR_INTITULE  = "LI_INTITULE";
        public const string FLD_CLIENTADR_TEL       = "LI_TELEPHONE";
        public const string FLD_CLIENTADR_FAX       = "LI_TELECOPIE";
        public const string FLD_CLIENTADR_PAYS_OLD  = "PAYS";
        public const string FLD_CLIENTADR_GSM       = "GSM";
        public const string FLD_CLIENTADR_EMAIL     = "EMAIL";
        public const string FLD_CLIENTADR_PRINCIPAL = "LI_PRINCIPAL";
        public const string FLD_CLIENTADR_TYPE      = "TYPE";
        #endregion


        /************************************************************************/
        /* PROSPECT _NEGOS                                                               */
        /************************************************************************/
        #region TABLENAME_PROSPECT_NEGOS
        public const string TABLENAME_PROSPECT_NEGOS = "T_NEGOS_CLIENTS";
        public const string FLD_PROSPECTNEGOS_SOC_CODE = "clilabo";
        public const string FLD_PROSPECTNEGOS_CLI_CODE = "codeclient";
        public const string FLD_PROSPECTNEGOS_LIVR_CODE = "codelivr";
        public const string FLD_PROSPECTNEGOS_DATEMAJ = "DATMAJ";
        public const string FLD_PROSPECTNEGOS_DATCREA = "DATCRE";
        public const string FLD_PROSPECTNEGOS_ANNULATION = "ANNLOG";
        public const string FLD_PROSPECTNEGOS_ALARM_CODE = "CODEALARME";
        public const string FLD_PROSPECTNEGOS_MOTDIR = "MOTDIRECTEUR";
        public const string FLD_PROSPECTNEGOS_CIVIL = "CIVILITE";
        public const string FLD_PROSPECTNEGOS_RS = "RAISOC";
        public const string FLD_PROSPECTNEGOS_ADR1 = "ADRES1";
        public const string FLD_PROSPECTNEGOS_ADR2 = "ADRES2";
        public const string FLD_PROSPECTNEGOS_CP = "CPOST";
        public const string FLD_PROSPECTNEGOS_VILLE = "VILLE";
        public const string FLD_PROSPECTNEGOS_PAYS = "PAYS";
        public const string FLD_PROSPECTNEGOS_CONTACT = "CONTACT";
        public const string FLD_PROSPECTNEGOS_TEL = "TELEP";
        public const string FLD_PROSPECTNEGOS_FAX = "FAX";
        public const string FLD_PROSPECTNEGOS_SIRET = "SIRET";
        public const string FLD_PROSPECTNEGOS_CODEAPE = "CODEAPE";
        public const string FLD_PROSPECTNEGOS_CODEACT = "CODEACTIVITE";
        public const string FLD_PROSPECTNEGOS_MODELIVR = "MODELIVR";
        public const string FLD_PROSPECTNEGOS_CONDLIVR = "CONDILIVR";
        public const string FLD_PROSPECTNEGOS_CATCOMPT = "CATCOMPT";
        public const string FLD_PROSPECTNEGOS_CATTARIF = "CATTARIF";
        public const string FLD_PROSPECTNEGOS_RELIQ = "RELIQUAT";
        public const string FLD_PROSPECTNEGOS_REMISE = "REMISE";
        public const string FLD_PROSPECTNEGOS_ESCOMPTE = "ESCOMPTE";
        public const string FLD_PROSPECTNEGOS_CODEDEVISE = "CODEDEVISE";
        public const string FLD_PROSPECTNEGOS_FAMREMISE = "FAMREMISE";
        public const string FLD_PROSPECTNEGOS_MOYREGL = "MOYRGL";
        public const string FLD_PROSPECTNEGOS_NOGRAT = "NOGRATUIT";
        public const string FLD_PROSPECTNEGOS_CODEVRP = "CODVRP";
        public const string FLD_PROSPECTNEGOS_CODEREGION = "CODEREGION";
        public const string FLD_PROSPECTNEGOS_FAMCLI = "FAM_CLIENT";
        public const string FLD_PROSPECTNEGOS_EMAIL = "ADR_EMAIL";
        public const string FLD_PROSPECTNEGOS_DATEDERCDE = "DATDERCDE";
        public const string FLD_PROSPECTNEGOS_COMMENT = "COMMENTAIRE";
        public const string FLD_PROSPECTNEGOS_ENSEIGNE = "ENSEIGNE";
        public const string FLD_PROSPECTNEGOS_NUMPRINC = "CG_NUMPRINC";
        public const string FLD_PROSPECTNEGOS_NUMPAYEUR = "CT_NUMPAYEUR";
        public const string FLD_PROSPECTNEGOS_SITE = "CT_SITE";
        public const string FLD_PROSPECTNEGOS_NUMTVA = "NOTVA";
        public const string FLD_PROSPECTNEGOS_CATALOGUE = "CATALOGUE";
        public const string FLD_PROSPECTNEGOS_CODETOURNEE = "CODETOURNEE";
        public const string FLD_PROSPECTNEGOS_JOURPASSAGE = "JOURPASSAGE";
        public const string FLD_PROSPECTNEGOS_TELEVENTE = "TELEVENTE";
        public const string FLD_PROSPECTNEGOS_SOUSFAM = "SOUSFAMILLECLIENT";
        public const string FLD_PROSPECTNEGOS_TYPE = "TYPE";//P=prospect
        #endregion

        #region TABLENAME_PRODUIT
        /************************************************************************/
        /* kems_produit                                                                     */
        /************************************************************************/
        public const string TABLENAME_PRODUIT = "kems_produit";
        public const string FIELD_PRODUIT_CODE = "pro_code";
        public const string FIELD_PRODUIT_NOMPHOTO = "pro_nomphoto";
        public const string FIELD_PRODUIT_NOM = "pro_nom";
        public const string FIELD_PRODUIT_GENDCOD = "pro_codabar";
        public const string FIELD_PRODUIT_PVC = "pro_pvc";
        public const string FIELD_PRODUIT_CODERAYON = "prm_rayon_code";
        public const string FIELD_PRODUIT_FAM1 = "prm_fam1_code";//famille
        public const string FIELD_PRODUIT_FAM2 = "prm_fam2_code";//fournisseur
        public const string FIELD_PRODUIT_FAM3 = "prm_fam3_code";
        public const string FIELD_PRODUIT_FAM4 = "prm_fam4_code";
        public const string FIELD_PRODUIT_FAM5 = "prm_fam5_code";
        public const string FIELD_PRODUIT_FAM6 = "prm_fam6_code";
        public const string FIELD_PRODUIT_LARGEUR = "pro_dim_largeur";//en mm
        public const string FIELD_PRODUIT_HAUTEUR = "pro_dim_hauteur";//en mm
        public const string FIELD_PRODUIT_LONGUEUR = "pro_dim_longueur";//en mm
        public const string FIELD_PRODUIT_ISCONC = "pro_isconc";
        public const string FIELD_PRODUIT_PRIXACHAT = "pro_prixachat";
        public const string FIELD_PRODUIT_FREE1 = "pro_free1";
        public const string FIELD_PRODUIT_COND = "pro_cond";
        public const string FIELD_PRODUIT_SUIVI = "pro_suivi";
        public const string FIELD_PRODUIT_HP = "pro_hp";        //pour commande truffaut
        #endregion

        #region TABLENAME_KITENT
        /************************************************************************/
        /* kems_KITENT                                                                     */
        /************************************************************************/
        //Etb¤NumeroKit¤SuffixeKit¤Article¤Libelle¤magasin¤ENCOD
        public const string TABLENAME_KITENT = "kems_KITENT";
        public const string FIELD_KITENT_ETB        = "Etb";
        public const string FIELD_KITENT_NUMEROKIT  = "NumeroKit";
        public const string FIELD_KITENT_SUFFIXEKIT = "SuffixeKit";
        public const string FIELD_KITENT_ARTICLE    = "Article";
        public const string FIELD_KITENT_LIBELLE    = "Libelle";
        public const string FIELD_KITENT_MAGASIN    = "magasin";
        public const string FIELD_KITENT_ENCOD      = "ENCOD";
        #endregion

        #region TABLENAME_KITLIN
        /************************************************************************/
        /* kems_KITLIN                                                                     */
        /************************************************************************/
        //LNCOD¤Etb¤NumeroKit¤SuffixeKit¤Libelle¤type¤Code article¤Quantité
        public const string TABLENAME_KITLIN = "kems_KITLIN";
        public const string FIELD_KITLIN_LNCOD      = "LNCOD";
        public const string FIELD_KITLIN_ETB        = "Etb";
        public const string FIELD_KITLIN_NUMEROKIT  = "NumeroKit";
        public const string FIELD_KITLIN_SUFFIXEKIT = "SuffixeKit";
        public const string FIELD_KITLIN_LIBELLE    = "Libelle";
        public const string FIELD_KITLIN_TYPE       = "type";
        public const string FIELD_KITLIN_CODEART    = "Codeart";
        public const string FIELD_KITLIN_QTE        = "Qte";
        #endregion

        #region KEMS_DATA
        /************************************************************************/
        /* table kems_data                                                                     */
        /************************************************************************/
        public const string TABLENAME_KEMSDATA = "kems_data";            //table des données saisies 
        public const string TABLENAME_KEMSDATA_TEMP = "kems_tmpdata";   //table de travail temps réel
        public const string TABLENAME_KEMSDATA_HISTO = "kems_histodata";   //table de historiques
        public const string FIELD_KD_soc_code = "soc_code";             //1
        public const string FIELD_KD_cli_code = "cli_code";             //2
        public const string FIELD_KD_pro_code = "pro_code";             //3
        public const string FIELD_KD_vis_code = "vis_code";             //4
        public const string FIELD_KD_cde_code = "cde_code";             //5
        public const string FIELD_KD_dat_type = "dat_type";             //6
        public const string FIELD_KD_dat_idx01 = "dat_idx01";           //7
        public const string FIELD_KD_dat_idx02 = "dat_idx02";           //8
        public const string FIELD_KD_dat_idx03 = "dat_idx03";           //9
        public const string FIELD_KD_dat_idx04 = "dat_idx04";           //10
        public const string FIELD_KD_dat_idx05 = "dat_idx05";           //11
        public const string FIELD_KD_dat_idx06 = "dat_idx06";           //12
        public const string FIELD_KD_dat_idx07 = "dat_idx07";           //13
        public const string FIELD_KD_dat_idx08 = "dat_idx08";           //14
        public const string FIELD_KD_dat_idx09 = "dat_idx09";           //15
        public const string FIELD_KD_dat_idx10 = "dat_idx10";           //16
        public const string FIELD_KD_dat_data01 = "dat_data01";         //17
        public const string FIELD_KD_dat_data02 = "dat_data02";         //18
        public const string FIELD_KD_dat_data03 = "dat_data03";         //19
        public const string FIELD_KD_dat_data04 = "dat_data04";         //20
        public const string FIELD_KD_dat_data05 = "dat_data05";         //21
        public const string FIELD_KD_dat_data06 = "dat_data06";         //22
        public const string FIELD_KD_dat_data07 = "dat_data07";         //23
        public const string FIELD_KD_dat_data08 = "dat_data08";         //24
        public const string FIELD_KD_dat_data09 = "dat_data09";         //25
        public const string FIELD_KD_dat_data10 = "dat_data10";         //26
        public const string FIELD_KD_dat_data11 = "dat_data11";         //27
        public const string FIELD_KD_dat_data12 = "dat_data12";         //28
        public const string FIELD_KD_dat_data13 = "dat_data13";         //29
        public const string FIELD_KD_dat_data14 = "dat_data14";         //30
        public const string FIELD_KD_dat_data15 = "dat_data15";         //31
        public const string FIELD_KD_dat_data16 = "dat_data16";         //32
        public const string FIELD_KD_dat_data17 = "dat_data17";         //33
        public const string FIELD_KD_dat_data18 = "dat_data18";         //34
        public const string FIELD_KD_dat_data19 = "dat_data19";         //35
        public const string FIELD_KD_dat_data20 = "dat_data20";         //36
        public const string FIELD_KD_dat_data21 = "dat_data21";         //37
        public const string FIELD_KD_dat_data22 = "dat_data22";         //38
        public const string FIELD_KD_dat_data23 = "dat_data23";         //39
        public const string FIELD_KD_dat_data24 = "dat_data24";         //40
        public const string FIELD_KD_dat_data25 = "dat_data25";         //41
        public const string FIELD_KD_dat_data26 = "dat_data26";         //42
        public const string FIELD_KD_dat_data27 = "dat_data27";         //43
        public const string FIELD_KD_dat_data28 = "dat_data28";         //44
        public const string FIELD_KD_dat_data29 = "dat_data29";         //45
        public const string FIELD_KD_dat_data30 = "dat_data30";         //46
        public const string FIELD_KD_val_data31 = "val_data31";         //47
        public const string FIELD_KD_val_data32 = "val_data32";         //48
        public const string FIELD_KD_val_data33 = "val_data33";         //49
        public const string FIELD_KD_val_data34 = "val_data34";         //50
        public const string FIELD_KD_val_data35 = "val_data35";         //51
        public const string FIELD_KD_val_data36 = "val_data36";         //52
        public const string FIELD_KD_val_data37 = "val_data37";         //53
        public const string FIELD_KD_val_data38 = "val_data38";         //54
        public const string FIELD_KD_val_data39 = "val_data39";         //55
        public const string FIELD_KD_val_data40 = "val_data40";         //56
        public const string FIELD_KD_user_code = "user_code";           //57
        public const string FIELD_KD_date_insert = "date_insert";        //58
        public const string FIELD_KD_date_update = "date_update";        //59
        public const string FIELD_KD_id = "id";        //60
        public const string FIELD_KD_FLAG = "flag";        //60
        #endregion

        #region KD_TYPE_RLETG_55
        //table des etageres sauvées
        public const int KD_TYPE_RLETG = 55;
        public const string FIELD_RL_ETG_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RL_ETG_VISCODE = FIELD_KD_vis_code;
        public const string FIELD_RL_ETG_SOCCODE = FIELD_KD_soc_code;
        public const string FIELD_RL_ETG_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RL_ETG_ELTCODE = FIELD_KD_dat_idx01;
        public const string FIELD_RL_ETG_NO = FIELD_KD_dat_idx02;
        public const string FIELD_RL_ETG_ORDER = FIELD_KD_dat_idx03;
        public const string FIELD_RL_ETG_HEIGHT = FIELD_KD_dat_data01;
        public const string FIELD_RL_ETG_WIDTH = FIELD_KD_dat_data02;
        public const string FIELD_RL_ETG_FACING = FIELD_KD_dat_data03;
        #endregion

        #region KD_TYPE_RLIMGFCG_56
        //vue sur la table KD
        //table des facing graphique sauvées
        public const int KD_TYPE_RLIMGFCG = 56;
        public const string FIELD_RL_IMGFCG_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RL_IMGFCG_VISCODE = FIELD_KD_vis_code;
        public const string FIELD_RL_IMGFCG_SOCCODE = FIELD_KD_soc_code;
        public const string FIELD_RL_IMGFCG_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RL_IMGFCG_PROCODE = FIELD_KD_pro_code;
        public const string FIELD_RL_IMGFCG_ELTCODE = FIELD_KD_dat_idx01;
        public const string FIELD_RL_IMGFCG_NOETG = FIELD_KD_dat_idx02;
        public const string FIELD_RL_IMGFCG_POSITION = FIELD_KD_dat_idx03;
        public const string FIELD_RL_IMGFCG_PRODTYPE = FIELD_KD_dat_idx04;
        public const string FIELD_RL_IMGFCG_HEIGHT = FIELD_KD_dat_data01;
        public const string FIELD_RL_IMGFCG_WIDTH = FIELD_KD_dat_data02;
        public const string FIELD_RL_IMGFCG_IMAGEPATH = FIELD_KD_dat_data03;
        public const string FIELD_RL_IMGFCG_KNOWNSIZE = FIELD_KD_dat_data04;
        #endregion

        #region KD_TYPE_RLINFOS_58
        //vue sur la table KD
        //sauvegarde des infos relevées
        public const int KD_TYPE_RLINFOS = 58;
        public const string FIELD_RL_INFOS_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RL_INFOS_VISCODE = FIELD_KD_vis_code;
        public const string FIELD_RL_INFOS_SOCCODE = FIELD_KD_soc_code;
        public const string FIELD_RL_INFOS_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RL_INFOS_PROCODE = FIELD_KD_pro_code;
        public const string FIELD_RL_INFOS_PVC = FIELD_KD_dat_data01;
        public const string FIELD_RL_INFOS_FCG = FIELD_KD_dat_data02;
        public const string FIELD_RL_INFOS_PRESENCE = FIELD_KD_dat_data03;
        public const string FIELD_RL_INFOS_PROMO = FIELD_KD_dat_data04;
        public const string FIELD_RL_INFOS_ISREFER = FIELD_KD_dat_data05;
        public const string FIELD_RL_INFOS_COMMENT = FIELD_KD_dat_data06;
        #endregion

        #region KD_TYPE_RLENTETE_59
        //KD table entete de RL
        public const int KD_TYPE_RLENTETE = 59;
        public const string FIELD_RLENTETE_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RLENTETE_CLICODE  = FIELD_KD_cli_code;
        public const string FIELD_RLENTETE_VISCODE  = FIELD_KD_vis_code;
        public const string FIELD_RLENTETE_COMMENT = FIELD_KD_dat_data01;
        public const string FIELD_RLENTETE_COMMENTNEXTVIS = FIELD_KD_dat_data02;
        public const string FIELD_RLENTETE_DATE         = FIELD_KD_dat_idx01;//date du RL
        #endregion

        #region KD_TYPE_RAYONCLI_60
        //KD table des infos typo rayon du client
        public const int KD_TYPE_RAYONCLI = 60;
        public const string FIELD_RAYCLI_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RAYCLI_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RAYCLI_RAYCODE = FIELD_KD_dat_idx01;
        public const string FIELD_RAYCLI_TYPO = FIELD_KD_dat_data01;
        public const string FIELD_RAYCLI_DATEMODIF = FIELD_KD_dat_data02;
        #endregion

        #region KD_TYPE_DSC_61
        //KD fichier de configuration de l'application Danem Suite ConFig
        public const int KD_TYPE_DSC = 61;
        public const string FIELD_DSC_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_DSC_CODEPARAM = FIELD_KD_dat_idx01;
        public const string FIELD_DSC_COMMENT = FIELD_KD_dat_data01;
        public const string FIELD_DSC_ISACTIF = FIELD_KD_dat_data02;
        public const string FIELD_DSC_ISTODO = FIELD_KD_dat_data03;
        public const string FIELD_DSC_ISMODIF = FIELD_KD_dat_data04;
        public const string FIELD_DSC_VAL1 = FIELD_KD_dat_data05;
        public const string FIELD_DSC_VAL2 = FIELD_KD_dat_data06;
        #endregion

        #region KD_TYPE_RDV_62
        //KD fichier des RDV
        public const int KD_TYPE_RDV = 62;
        public const string FIELD_RDV_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RDV_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RDV_DATE = FIELD_KD_dat_idx01;
        public const string FIELD_RDV_HEURE = FIELD_KD_dat_idx02;
        public const string FIELD_RDV_KEY = FIELD_KD_dat_idx03;
        public const string FIELD_RDV_RS = FIELD_KD_dat_data01;
        public const string FIELD_RDV_CP = FIELD_KD_dat_data02;
        public const string FIELD_RDV_COMMENT = FIELD_KD_dat_data03;
        #endregion

        #region KD_TYPE_AXE_63
        //KD axes d'analyses
        public const int KD_TYPE_AXE = 63;
        public const string FIELD_AXE_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_AXE_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_AXE_DATERDV = FIELD_KD_dat_idx01;
        #endregion

        #region KD_TYPE_VISITE_64
        //KD table visite
        public const int KD_TYPE_VISITE = 64;
        public const string FIELD_VISITE_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_VISITE_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_VISITE_VISCODE = FIELD_KD_vis_code;
        public const string FIELD_VISITE_DATE = FIELD_KD_dat_idx01;//date de la visite
        public const string FIELD_VISITE_BILAN = FIELD_KD_dat_data01;
        public const string FIELD_VISITE_OBJECTIFNEXT = FIELD_KD_dat_data02;
        #endregion

        #region KD_TYPE_DASHBOARD_65
        //KD table dashboard
        public const int KD_TYPE_DASHBOARD = 65;
        public const string FIELD_DASHBOARD_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_DASHBOARD_TABNUM = FIELD_KD_dat_idx01;
        public const string FIELD_DASHBOARD_ARMOIRE_NUM = FIELD_KD_dat_idx02;
        public const string FIELD_DASHBOARD_TABNAME = FIELD_KD_dat_data01;
        public const string FIELD_DASHBOARD_NBRROW = FIELD_KD_dat_data02;
        public const string FIELD_DASHBOARD_NBRCOL = FIELD_KD_dat_data03;
        #endregion

        #region KD_TYPE_DASHLAYOUT_66
        //KD table dashboard layout place
        public const int KD_TYPE_DASHLAYOUT = 66;
        public const string FIELD_DASHLAYOUT_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_DASHLAYOUT_TABNUM = FIELD_KD_dat_idx01;
        public const string FIELD_DASHLAYOUT_ARMOIRE_NUM = FIELD_KD_dat_idx02;
        public const string FIELD_DASHLAYOUT_NAME = FIELD_KD_dat_data01;
        public const string FIELD_DASHLAYOUT_PLACE = FIELD_KD_dat_data02;
        public const string FIELD_DASHLAYOUT_ROWSPAN = FIELD_KD_dat_data04;
        public const string FIELD_DASHLAYOUT_COLSPAN = FIELD_KD_dat_data05;
        #endregion

        #region KD_TYPE_ZCHALAND_67
        //KD table zone de chalandise
        public const int KD_TYPE_ZCHALAND = 67;
        public const string FIELD_ZCHALAND_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_ZCHALAND_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_ZCHALAND_CODECLI_NEAR = FIELD_KD_dat_idx01;
        public const string FIELD_ZCHALAND_DISTANCE = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_HORAIRES_68
        //table des horaires
        public const int KD_TYPE_HORAIRES = 68;
        public const string FIELD_HORA_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_HORA_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_HORA_JOUR = FIELD_KD_dat_idx01;
        public const string FIELD_HORA_AM_FROM = FIELD_KD_dat_data01;
        public const string FIELD_HORA_AM_TO = FIELD_KD_dat_data02;
        public const string FIELD_HORA_PM_FROM = FIELD_KD_dat_data03;
        public const string FIELD_HORA_PM_TO = FIELD_KD_dat_data04;
        #endregion

        #region KD_TYPE_RDVAPLACER_69
        //table des rdv à placer
        public const int KD_TYPE_RDVAPLACER = 69;
        public const string FIELD_RDVAPLACER_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_RDVAPLACER_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_RDVAPLACER_DATEDEMANDE = FIELD_KD_dat_idx01;
        public const string FIELD_RDVAPLACER_NIVEAUURGENCE = FIELD_KD_dat_idx02;
        public const string FIELD_RDVAPLACER_RS = FIELD_KD_dat_data01;
        public const string FIELD_RDVAPLACER_CP = FIELD_KD_dat_data02;
        public const string FIELD_RDVAPLACER_VILLE = FIELD_KD_dat_data03;
        public const string FIELD_RDVAPLACER_FROM = FIELD_KD_dat_data04;
        public const string FIELD_RDVAPLACER_COMMENTAIRE = FIELD_KD_dat_data05;
        #endregion

        #region KD_TYPE_CLIBANQUE_70
        //coordonnées bancaires
        public const int KD_TYPE_CLIBANQUE = 70;
        public const string FIELD_CLIBANQUE_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_CLIBANQUE_CODEREP = FIELD_KD_dat_idx01;
        public const string FIELD_CLIBANQUE_TITULAIRE = FIELD_KD_dat_data01;
        public const string FIELD_CLIBANQUE_DOMICILIATION = FIELD_KD_dat_data02;
        public const string FIELD_CLIBANQUE_CODEBANQUE = FIELD_KD_dat_data03;
        public const string FIELD_CLIBANQUE_CODEGUICHET = FIELD_KD_dat_data04;
        public const string FIELD_CLIBANQUE_NUMCOMPTE = FIELD_KD_dat_data05;
        public const string FIELD_CLIBANQUE_CLERIB = FIELD_KD_dat_data06;
        public const string FIELD_CLIBANQUE_IBAN = FIELD_KD_dat_data07;
        public const string FIELD_CLIBANQUE_FLAG = FIELD_KD_dat_data08;
        public const string FIELD_CLIBANQUE_BIC = FIELD_KD_dat_data09;
        
        #endregion

        #region KD_TYPE_WS_AUTH_765
        //table ws_auth web service
        public const int KD_TYPE_WS_AUTH = 765;
        public const string FIELD_WS_AUTH_CODE = FIELD_KD_dat_idx01;
        public const string FIELD_WS_AUTH_LOGIN = FIELD_KD_dat_data01;
        public const string FIELD_WS_AUTH_PWD = FIELD_KD_dat_data02;
        public const string FIELD_WS_AUTH_ADRESS = FIELD_KD_dat_data03;
        public const string FIELD_WS_AUTH_NBRCONNOK = FIELD_KD_dat_data04;
        public const string FIELD_WS_AUTH_DATECONNOK = FIELD_KD_dat_data05;
        #endregion

        #region KD_TYPE_USERGROUPE_71
        //table ws_auth web service
        public const int KD_TYPE_USERGROUPE = 71;
        public const string FIELD_USERGROUPE_CODEUSER = FIELD_KD_dat_idx01;
        public const string FIELD_USERGROUPE_CODEGROUPE =  FIELD_KD_dat_idx02; 
        #endregion


        #region KD_TYPE_CDEAPREPA_ENT_73
        //entetes commandes à préparer

        public const int KD_TYPE_CDEAPREPA_ETAT_BLOQUE1 = 10;  //bloqué 1 er niveau
        public const int KD_TYPE_CDEAPREPA_ETAT_LIBRE = 0;  //non affecté, jamais faite
        public const int KD_TYPE_CDEAPREPA_ETAT_PDA_SEND = 1; // envoi au pda
        public const int KD_TYPE_CDEAPREPA_ETAT_PDA_RECUE = 11; // reçue sur le pda
        public const int KD_TYPE_CDEAPREPA_ETAT_PDA_ENCOURSPREPA = 12; // en cours de prépa sur le pda
        public const int KD_TYPE_CDEAPREPA_ETAT_ANNULE = 2;  //annulee
        public const int KD_TYPE_CDEAPREPA_ETAT_TERMINE = 3; //termine, meme incomplete
        public const int KD_TYPE_CDEAPREPA_ETAT_PAUSE = 4;  //en pause, a terminer un autre jour
        public const int KD_TYPE_CDEAPREPA_ETAT_RESERVE = 5;  //réservée, le préparateur est affecté mais pas encore envoyée
        public const int KD_TYPE_CDEAPREPA_ETAT_VALIDEFIN = 6;  //valide pour l'export
        public const int KD_TYPE_CDEAPREPA_ETAT_CLOSE = 99;  //exportée, donc non modifiable normallement
        public const int KD_TYPE_CDEAPREPA_ETAT_ERRDEJATRAITE = 98;  //cde deja traitée
        public const int KD_TYPE_CDEAPREPA_ETAT_TEMPSTATUS = 97;  //status temporaire

        public const string KD_TYPE_CDEAPREPA_ETAT_BLOQUE1_STR = "Bloquée";  //non affecté, jamais faite
        public const string KD_TYPE_CDEAPREPA_ETAT_LIBRE_STR = "Libre";  //non affecté, jamais faite
        public const string KD_TYPE_CDEAPREPA_ETAT_PDA_SEND_STR = "Envoyée";
        public const string KD_TYPE_CDEAPREPA_ETAT_PDA_RECUE_STR = "Reçue pda";
        public const string KD_TYPE_CDEAPREPA_ETAT_PDA_ENCOURSPREPA_STR = "En cours";
        public const string KD_TYPE_CDEAPREPA_ETAT_ANNULE_STR = "Annulée";  //annulee
        public const string KD_TYPE_CDEAPREPA_ETAT_TERMINE_STR = "Terminée"; //termine, meme incomplete
        public const string KD_TYPE_CDEAPREPA_ETAT_PAUSE_STR = "En pause";  //en pause, a terminer un autre jour
        public const string KD_TYPE_CDEAPREPA_ETAT_VALIDEFIN_STR = "Validée";  //
        public const string KD_TYPE_CDEAPREPA_ETAT_RESERVE_STR = "Réservée";  //
        public const string KD_TYPE_CDEAPREPA_ETAT_CLOSE_STR = "Close";
        public const string KD_TYPE_CDEAPREPA_ETAT_ERRDEJATRAITE_STR = "Déjà traitée";  //cde deja traitée

        public const int KD_TYPE_CDEAPREPA_ENT = 73;
        public const string FIELD_CDEPREPA_ENT_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_CDEPREPA_ENT_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_CDEPREPA_ENT_CDEPERE = FIELD_KD_dat_idx01;//si la cde est cassée en plusieurs on garde le numéro original
        public const string FIELD_CDEPREPA_ENT_NOMCLI = FIELD_KD_dat_data01;
        public const string FIELD_CDEPREPA_ENT_ISRELIQUAT = FIELD_KD_dat_data02;//le client accepte t'il les reliquats
        public const string FIELD_CDEPREPA_ENT_NIVEAUURG = FIELD_KD_dat_data03;
        public const string FIELD_CDEPREPA_ENT_COMMENTCDE = FIELD_KD_dat_data04;
        public const string FIELD_CDEPREPA_ENT_ETAT = FIELD_KD_dat_data05;
        public const string FIELD_CDEPREPA_ENT_CODEPREPARATEUR = FIELD_KD_dat_data06;
        public const string FIELD_CDEPREPA_ENT_NOMPREPARATEUR = FIELD_KD_dat_data07;
        public const string FIELD_CDEPREPA_ENT_DATECDE = FIELD_KD_dat_data08;
        public const string FIELD_CDEPREPA_ENT_DATELIVR = FIELD_KD_dat_data09;
        public const string FIELD_CDEPREPA_ENT_NBRCOLIS = FIELD_KD_dat_data10;
        public const string FIELD_CDEPREPA_ENT_POIDSTOTAL = FIELD_KD_dat_data11;
        public const string FIELD_CDEPREPA_ENT_OKEXPORT = FIELD_KD_dat_data12;
        public const string FIELD_CDEPREPA_ENT_ISLIVRPARTIELLE = FIELD_KD_dat_data13;
        public const string FIELD_CDEPREPA_ENT_CODETRANSPORTEUR = FIELD_KD_dat_data14;
        public const string FIELD_CDEPREPA_ENT_FACTUREREGROUP = FIELD_KD_dat_data15;//0 non, 1 oui       regroupement facture
        public const string FIELD_CDEPREPA_ENT_NBRMORCEAU = FIELD_KD_dat_data16;//en combien la commande est morcellée
        public const string FIELD_CDEPREPA_ENT_CODEREGROUP = FIELD_KD_dat_data17;//regroupement des cdes pour prépa en paquet
        public const string FIELD_CDEPREPA_ENT_TYPECMD = FIELD_KD_dat_data18;//(tof)pour gestion cmd pro/particulier (scrap)
        public const string FIELD_CDEPREPA_ENT_PRODVOL = FIELD_KD_dat_data19;//(tof)pour gestion cmd avec produit volumineux (scrap)
        public const string FIELD_CDEPREPA_ENT_GROUPEPREPA = FIELD_KD_dat_data20;//groupe de preparateur
        public const string FIELD_CDEPREPA_ENT_SUMQTE = FIELD_KD_dat_data21;//somme des qtés , info pour le pda
        public const string FIELD_CDEPREPA_ENT_NBRLIN = FIELD_KD_dat_data22;//nombre de ligne , info pour le pda
        public const string FIELD_CDEPREPA_ENT_RELIQDELETED = FIELD_KD_dat_data23;//Reliquat effacé effectivmeent
        public const string FIELD_CDEPREPA_ENT_CODEPREPAMULTICBAC = FIELD_KD_dat_data24;//code qui permet d'ientifier les cdes préparées ensemble
        public const string FIELD_CDEPREPA_ENT_CODEBOITE_PRINC = FIELD_KD_dat_data25;//boite ou bac
        public const string FIELD_CDEPREPA_ENT_CODEBOITE_LISTE = FIELD_KD_dat_data26;//boite ou bac supplementaire sep ;
        public const string FIELD_CDEPREPA_ENT_REFCDECLIENT = FIELD_KD_dat_data27;//Référence cde client
        public const string FIELD_CDEPREPA_ENT_ISSTAT = FIELD_KD_dat_data28;// doit on comptabiliser ce bon dans les stats 1 / 0
        public const string FIELD_CDEPREPA_ENT_CODEIMPORT = FIELD_KD_dat_data29;// numéro d'inmport
        public const string FIELD_CDEPREPA_ENT_PURCENTREGROUP = FIELD_KD_val_data31;// //pourcentage de regroupement des cdes par paquet
        public const string FIELD_CDEPREPA_ENT_NBRIMPBL = FIELD_KD_val_data32;// Nbr impression BL
        public const string FIELD_CDEPREPA_ENT_NUMCDEINITIALE = FIELD_KD_dat_data30;// numéro d'inmport
        public const string FIELD_CDEPREPA_ENT_CODEREP = FIELD_KD_dat_idx02;
        public const string FIELD_CDEPREPA_ENT_CDE_CODE_MCFILLE = FIELD_KD_dat_idx03;        //Numero de mega commande fille 
        public const string FIELD_CDEPREPA_ENT_PLUTONTYPE = FIELD_KD_val_data33;        //Specifique mega-commande, pour conversion du type de ligne lors de l'import/export 
        //Lors de l'export du mega commande (113 et 114), pluton convertit les lignes pour que le pda les voient comme une commande normal (73 et 74), mais garde dans PLUTONTYPE le code original
        //A l'import, pluton ce sert de se champs pour detecter qu'on est sur une megacommande et faire la conversion inverse
        public const string FIELD_CDEPREPA_ENT_BACVIRTUEL = FIELD_KD_val_data34;        //Numero de bac virtuel, pour les mega-commande (commence à 1, en utilisant le numcdepere pour le tri)     
        //Ajout 'navision' (dugas)
        public const string FIELD_CDEPREPA_ENT_TRANSPORTEUR = FIELD_KD_dat_idx04;     
        public const string FIELD_CDEPREPA_ENT_TYPE_ORDRE = FIELD_KD_dat_idx05;     
        public const string FIELD_CDEPREPA_ENT_FIRME = FIELD_KD_dat_idx06;
        public const string FIELD_CDEPREPA_ENT_NUMEXP = FIELD_KD_dat_idx07;
        public const string FIELD_CDEPREPA_ENT_LBLSOC = FIELD_KD_dat_idx08;
        public const string FIELD_CDEPREPA_ENT_INFOCOMP = FIELD_KD_dat_data14;      //Utilisation du champs 'code transporteur' (spe paritys)
        public const string FIELD_CDEPREPA_ENT_ORDREPREPA = FIELD_KD_val_data35;   //ORDRE DE LA PREPA   
     

        #endregion

        #region KD_TYPE_CDEAPREPA_LIN_74
        //lignes commandes à préparer
        public const int KD_TYPE_CDEAPREPA_LIN = 74;

        public const string FIELD_CDEPREPA_LIN_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_CDEPREPA_LIN_CODEART = FIELD_KD_pro_code;
        public const string FIELD_CDEPREPA_LIN_CODABAR = FIELD_KD_dat_idx01;
        public const string FIELD_CDEPREPA_LIN_CODECDEPERE = FIELD_KD_dat_idx02;
        public const string FIELD_CDEPREPA_LIN_NOMART = FIELD_KD_dat_data01;
        public const string FIELD_CDEPREPA_LIN_AJOUTMANU = FIELD_KD_dat_data02;//1/0 ajout manuel dans le backoffice
        public const string FIELD_CDEPREPA_LIN_COMMENTLIN = FIELD_KD_dat_data04;
        public const string FIELD_CDEPREPA_LIN_PRIXUNIT = FIELD_KD_dat_data05;
        public const string FIELD_CDEPREPA_LIN_DATEHEURE = FIELD_KD_dat_data07;
        public const string FIELD_CDEPREPA_LIN_DEPOT = FIELD_KD_dat_data10;
        public const string FIELD_CDEPREPA_LIN_ZONE = FIELD_KD_dat_data11;
        public const string FIELD_CDEPREPA_LIN_ALLEE = FIELD_KD_dat_data12;
        public const string FIELD_CDEPREPA_LIN_ELEMENT = FIELD_KD_dat_data13;
        public const string FIELD_CDEPREPA_LIN_ETAGERE = FIELD_KD_dat_data14;
        public const string FIELD_CDEPREPA_LIN_CASIER = FIELD_KD_dat_data15;
        public const string FIELD_CDEPREPA_LIN_UNITE = FIELD_KD_dat_data17;
        public const string FIELD_CDEPREPA_LIN_NBRDECIMAL = FIELD_KD_dat_data18;
        public const string FIELD_CDEPREPA_LIN_TOLERANCE = FIELD_KD_dat_data19; //tolerance
        public const string FIELD_CDEPREPA_LIN_ISRUPTURE = FIELD_KD_dat_data20; //1=rupture
        public const string FIELD_CDEPREPA_LIN_ISBIPED = FIELD_KD_dat_data21; //1=bip used, 0=bip unused
        public const string FIELD_CDEPREPA_LIN_REFFOUR = FIELD_KD_dat_data22;
        public const string FIELD_CDEPREPA_LIN_LBLUNITEPREPA = FIELD_KD_dat_data23;//ajout pour version sage
        public const string FIELD_CDEPREPA_LIN_PASEXPORTERP = FIELD_KD_dat_data28; //si 1 on prepare mais on exporte pas vers l'erp
        public const string FIELD_CDEPREPA_LIN_CODEIMPORT = FIELD_KD_dat_data29; //code import
        public const string FIELD_CDEPREPA_LIN_QTEAPRREPA = FIELD_KD_val_data31;
        public const string FIELD_CDEPREPA_LIN_QTEPREPA = FIELD_KD_val_data32;
        public const string FIELD_CDEPREPA_LIN_STOCK = FIELD_KD_val_data33;
        public const string FIELD_CDEPREPA_LIN_CODELIN = FIELD_KD_val_data34;
        public const string FIELD_CDEPREPA_LIN_VU = FIELD_KD_val_data35; //1/0
        public const string FIELD_CDEPREPA_LIN_EFFACEE = FIELD_KD_val_data36; //flag qui dit que  la ligne est obsolete
        public const string FIELD_CDEPREPA_LIN_CONDITIONNEMENT = FIELD_KD_val_data37; //nouveau champs 16/12/13
        public const string FIELD_CDEPREPA_LIN_PLUTONTYPE = FIELD_KD_val_data38;        //Specifique mega-commande, pour conversion du type de ligne lors de l'import/export 
        //Lors de l'export du mega commande (113 et 114), pluton convertit les lignes pour que le pda les voient comme une commande normal (73 et 74), mais garde dans PLUTONTYPE le code original
        //A l'import, pluton ce sert de se champs pour detecter qu'on est sur une megacommande et faire la conversion inverse
        public const string FIELD_CDEPREPA_LIN_QTEDISPATCH= FIELD_KD_val_data39;        //Specifique mega-commande, pour savoir ou en ai le dispatch, et savoir quand c'est terminé
        public const string FIELD_CDEPREPA_LIN_TYPEKIT = FIELD_KD_dat_idx10;
        public const string FIELD_CDEPREPA_LIN_NUMKIT = FIELD_KD_dat_idx09;     //nouveau champ, pour lié les ligne kit aux composants associées
        public const string FIELD_CDEPREPA_LIN_UNITECMD = FIELD_KD_dat_idx08;     //nouveau champ, pour non agregation des mega-commande (26/08/14), voir 2146543469312
        public const string FIELD_CDEPREPA_LIN_QTEPREPA_MAJLOT = FIELD_KD_val_data40;   //Pour les kits, on garde la qnt calculé, en fonction des kits complet/incomplet
        //DUGAS, ne fonctionne pas si les lots/kits sont activé pour le client
        public const string FIELD_CDEPREPA_LIN_CODELIN2 = FIELD_KD_val_data40;    //Pour dugas, utilisation de ce champs pour le 'deuxieme' numero de ligne...
        #endregion

        #region KD_TYPE_COMPTEUR_75
        public const int KD_TYPE_COMPTEUR = 75;
        public const string FIELD_COMPTEUR_ID = FIELD_KD_dat_idx01;             //identifiant du compteur
        public const string FIELD_COMPTEUR_VAL = FIELD_KD_val_data31;           //compteur
        public const string FIELD_COMPTEUR_DATEUPDATE = FIELD_KD_date_update;   //date de mise à jour si on veut remettre le compteur à 0 en changeant de jour
        #endregion

        #region KD_TYPE_CDEPREPA_COMMENT_76
        /************************************************************************/
        /* commentaire de cde, multiligne                                                                     */
        /************************************************************************/
        public const int KD_TYPE_CDEPREPA_COMMENT = 76;
        public const string FIELD_CDEPREPA_COMMENT_NUMCDE = FIELD_KD_cde_code;
        public const string FIELD_CDEPREPA_COMMENT_NUMLIN = FIELD_KD_val_data31;
        public const string FIELD_CDEPREPA_COMMENT_TEXTE = FIELD_KD_dat_data01;
#endregion

        #region KD_TYPE_CDEPREPA_CONTENEUR_77
        /************************************************************************/
        /* generation des conteneurs de cdes                                                                */
        /************************************************************************/
        public const int KD_TYPE_CDEPREPA_CONTENEUR = 77;
        public const string FIELD_CDEPREPA_CONTENEUR_CODE = FIELD_KD_dat_idx01;
        #endregion

        #region KD_TYPE_STOCK_78
        /************************************************************************/
        /* STOCK
        /************************************************************************/
        public const int KD_TYPE_STOCK = 78;
        public const string FLD_STOCK_SOC_CODE = FIELD_KD_soc_code;
        public const string FLD_STOCK_PRO_CODE = FIELD_KD_pro_code;
        public const string FLD_STOCK_DEPOT = FIELD_KD_dat_data10;
        public const string FLD_STOCK_ZONE = FIELD_KD_dat_data11;
        public const string FLD_STOCK_ALLEE = FIELD_KD_dat_data12;
        public const string FLD_STOCK_ELEMENT = FIELD_KD_dat_data13;
        public const string FLD_STOCK_ETAGERE = FIELD_KD_dat_data14;
        public const string FLD_STOCK_CASIER = FIELD_KD_dat_data15;
        public const string FLD_STOCK_DATEDERINVENT = FIELD_KD_dat_data16;
        public const string FLD_STOCK_QTE_MINI = FIELD_KD_val_data31;
        public const string FLD_STOCK_QTE_MAXI = FIELD_KD_val_data32;
        public const string FLD_STOCK_QTE = FIELD_KD_val_data33;
        public const string FLD_STOCK_QTE_RESERVE = FIELD_KD_val_data34;
        public const string FLD_STOCK_QTE_COMMANDE = FIELD_KD_val_data35;
        public const string FLD_STOCK_QTE_PREPA = FIELD_KD_val_data36;
        public const string FLD_STOCK_PRIXACHAT = FIELD_KD_val_data37;

        #endregion

        #region KD_TYPE_NOTES_79
        /************************************************************************/
        /* NOTES INTERNES GLOBALES
        /************************************************************************/
        public const int KD_TYPE_NOTES = 79;
        public const string FLD_NOTES_SOC_CODE = FIELD_KD_soc_code;
        public const string FLD_NOTES_CLI_CODE = FIELD_KD_cli_code;
        public const string FLD_NOTES_TEXTE = FIELD_KD_dat_data01;
        public const string FLD_NOTES_DATE = FIELD_KD_date_insert;
        #endregion

        #region KD_TYPE_INFOUSER_81
        /************************************************************************/
        /* INFO USER
        /************************************************************************/
        public const int KD_TYPE_INFOUSER = 81;
        public const string FLD_INFOUSER_CODEUSER = FIELD_KD_user_code;
        public const string FLD_INFOUSER_LOGIN_SESSION=FIELD_KD_dat_data01;
        public const string FLD_INFOUSER_LEVEL= FIELD_KD_dat_data02;
        public const string FLD_INFOUSER_DATELASTCHECKIN = FIELD_KD_dat_data03;//date/heure pour signaler la présence 

        public const int TIMEELAPSE_CHECKIN    = 1000*60*3;
        public const int INFOUSER_LEVEL_DANEM=9999;
        public const int INFOUSER_LEVEL_ADMIN=99;
        #endregion

        #region KD_TYPE_DROITSUSER_82
        /************************************************************************/
        /* DROITS USER PLUTON
        /************************************************************************/
        public const int KD_TYPE_DROITSUSER = 82;
        public const string FLD_DROITSUSER_CODEUSER = FIELD_KD_dat_idx01;
        public const string FLD_DROITSUSER_MODULE = FIELD_KD_dat_idx02;
        public const string FLD_DROITSUSER_DROIT = FIELD_KD_dat_data01; //1 = oui, 2= non, pas d'enregistrements =  non
        #endregion

        #region KD_TYPE_ENTCDE_83
        //entetes commandes
        public const int KD_TYPE_ENTCDE = 83;
        public const string FIELD_ENTCDE_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_ENTCDE_CODECDE = FIELD_KD_cde_code;//code cde danem
        public const string FIELD_ENTCDE_NOMCLI = FIELD_KD_dat_data01;
        public const string FIELD_ENTCDE_CODECDE_SPE = FIELD_KD_dat_data02;//codecde spécifique au client
        public const string FIELD_ENTCDE_REFCDE = FIELD_KD_dat_data03;
        public const string FIELD_ENTCDE_COMMENTCDE = FIELD_KD_dat_data04;
        public const string FIELD_ENTCDE_ETAT = FIELD_KD_dat_data05;
        public const string FIELD_ENTCDE_CODEUSER = FIELD_KD_dat_data06;
        public const string FIELD_ENTCDE_TYPEDOC = FIELD_KD_dat_data07;
        public const string FIELD_ENTCDE_DATECDE = FIELD_KD_dat_data08;
        public const string FIELD_ENTCDE_DATELIVR = FIELD_KD_dat_data09;

        public const String FIELD_ENTCDE_CODEREGL = FIELD_KD_dat_data10;
        public const String FIELD_ENTCDE_ISPRINT = FIELD_KD_dat_data11;//1/0
        public const String FIELD_ENTCDE_CONDLIVR= FIELD_KD_dat_data12;
        public const String FIELD_ENTCDE_ISRELIQUAT = FIELD_KD_dat_data13;//O/N
        public const String FIELD_ENTCDE_CDEMARCHE = FIELD_KD_dat_data14;//1/0

        public const string FIELD_ENTCDE_MNTHT = FIELD_KD_val_data31;

        public const String FIELD_ENTCDE_MNTTVA1 = FIELD_KD_val_data32;
        public const String FIELD_ENTCDE_MNTTVA2 = FIELD_KD_val_data33;
        public const String FIELD_ENTCDE_MNTTC = FIELD_KD_val_data34;

        public const String FIELD_ENTCDE_REMISE1 = FIELD_KD_val_data35;
        public const String FIELD_ENTCDE_REMISE2 = FIELD_KD_val_data36;


        #endregion


        #region KD_TYPE_LIGNECDE_84
        //table  lingne de commande/devis/...
        public const int KD_TYPE_LIGNECDE = 84;
        public const string FIELD_LIGNECDE_SOCCODE = FIELD_KD_soc_code;
        public const string FIELD_LIGNECDE_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_LIGNECDE_CDECODE = FIELD_KD_cde_code;
        public const string FIELD_LIGNECDE_VISCODE = FIELD_KD_vis_code;
        public const string FIELD_LIGNECDE_PROCODE = FIELD_KD_pro_code;
        public const string FIELD_LIGNECDE_REPCODE = FIELD_KD_dat_idx01;
        public const string FIELD_LIGNECDE_DATE = FIELD_KD_dat_idx02;
        public const string FIELD_LIGNECDE_TYPEPIECE = FIELD_KD_dat_idx03;
        public const string FIELD_LIGNECDE_CODABAR = FIELD_KD_dat_idx04;
        public const string FIELD_LIGNECDE_NUMLIGNE = FIELD_KD_dat_data01;
        public const string FIELD_LIGNECDE_DESIGNATION = FIELD_KD_dat_data02;
        public const string FIELD_LIGNECDE_UV = FIELD_KD_dat_data03;
        public const string FIELD_LIGNECDE_QTECDE = FIELD_KD_dat_data04;
        public const string FIELD_LIGNECDE_PRIX = FIELD_KD_dat_data05;
        public const string FIELD_LIGNECDE_MNTUNITHT = FIELD_KD_dat_data06;
        public const string FIELD_LIGNECDE_REMISE = FIELD_KD_dat_data07;
        public const string FIELD_LIGNECDE_MNTUNITNETHT = FIELD_KD_dat_data08;
        public const string FIELD_LIGNECDE_MNTTOTALHT = FIELD_KD_dat_data09;
        public const string FIELD_LIGNECDE_MNTTOTALTTC = FIELD_KD_dat_data10;
        public const string FIELD_LIGNECDE_LOT = FIELD_KD_dat_data11;
        public const string FIELD_LIGNECDE_SERIE = FIELD_KD_dat_data12;
        public const string FIELD_LIGNECDE_COMMENT = FIELD_KD_dat_data13;
        public const String FIELD_LIGNECDE_QTEGR = FIELD_KD_dat_data14;
        public const String FIELD_LIGNECDE_PRIXMODIF = FIELD_KD_dat_data15;
        public const String FIELD_LIGNECDE_REMISEMODIF = FIELD_KD_dat_data16;
        public const String FIELD_LIGNECDE_MNTUNITTTC = FIELD_KD_dat_data17;
        #endregion 

        #region KD_TYPE_REMISE_HDR_85
        public const int KD_TYPE_REMISE_HDR = 85;
        #endregion
        
        #region KD_TYPE_REMISE_LIN_86
        public const int KD_TYPE_REMISE_LIN = 86;
        #endregion
        
        #region KD_TYPE_TARIF_HDR_87
        public const int KD_TYPE_TARIF_HDR = 87;
        #endregion
        
        #region KD_TYPE_TARIF_LIN_88
        public const int KD_TYPE_TARIF_LIN = 88;
        #endregion

        #region KD_TYPE_LOGWS_89
        public const int KD_TYPE_LOGWS= 89;
        #endregion

        #region KD_TYPE_HISTOFACT_90

        public const int KD_TYPE_HISTOFACT= 90;
        public const string FIELD_HISTOFACT_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_HISTOFACT_CDECODE = FIELD_KD_cde_code;
        public const string FIELD_HISTOFACT_FACTCODE = FIELD_KD_dat_idx01;
        public const string FIELD_HISTOFACT_DATE = FIELD_KD_dat_idx02;
        public const string FIELD_HISTOFACT_MNTHT = FIELD_KD_val_data31;
        #endregion 

        #region KD_TYPE_HISTOFACTLIN_91

        public const int KD_TYPE_HISTOFACTLIN = 91;
        public const string FIELD_HISTOFACTLIN_CLICODE = FIELD_KD_cli_code;
        public const string FIELD_HISTOFACTLIN_CDECODE = FIELD_KD_cde_code;
        public const string FIELD_HISTOFACTLIN_FACTCODE = FIELD_KD_dat_idx01;
        public const string FIELD_HISTOFACTLIN_PROCODE = FIELD_KD_pro_code;
        public const string FIELD_HISTOFACTLIN_QTEFACT = FIELD_KD_val_data31;
        public const string FIELD_HISTOFACTLIN_NUMLIN = FIELD_KD_dat_data01;
        #endregion 

        #region KD_TYPE_CDERECEPT_ENT_93
        //entetes commandes à receptionner

        public const int KD_TYPE_CDERECEPT_ETAT_BLOQUE1 = 10;  //bloqué 1 er niveau
        public const int KD_TYPE_CDERECEPT_ETAT_LIBRE = 0;  //non affecté, jamais faite
        public const int KD_TYPE_CDERECEPT_ETAT_PDA_SEND = 1; // envoi au pda
        public const int KD_TYPE_CDERECEPT_ETAT_PDA_RECUE = 11; // reçue sur le pda
        public const int KD_TYPE_CDERECEPT_ETAT_PDA_ENCOURSPREPA = 12; // en cours de prépa sur le pda
        public const int KD_TYPE_CDERECEPT_ETAT_ANNULE = 2;  //annulee
        public const int KD_TYPE_CDERECEPT_ETAT_TERMINE = 3; //termine, meme incomplete
        public const int KD_TYPE_CDERECEPT_ETAT_PAUSE = 4;  //en pause, a terminer un autre jour
        public const int KD_TYPE_CDERECEPT_ETAT_RESERVE = 5;  //réservée, le préparateur est affecté mais pas encore envoyée
        public const int KD_TYPE_CDERECEPT_ETAT_VALIDEFIN = 6;  //valide pour l'export
        public const int KD_TYPE_CDERECEPT_ETAT_CLOSE = 99;  //exportée, donc non modifiable normallement
        public const int KD_TYPE_CDERECEPT_ETAT_ERRDEJATRAITE = 98;  //cde deja traitée
        public const int KD_TYPE_CDERECEPT_ETAT_TEMPSTATUS = 97;  //status temporaire

        public const string KD_TYPE_CDERECEPT_ETAT_BLOQUE1_STR = "Bloquée";  //non affecté, jamais faite
        public const string KD_TYPE_CDERECEPT_ETAT_LIBRE_STR = "Libre";  //non affecté, jamais faite
        public const string KD_TYPE_CDERECEPT_ETAT_PDA_SEND_STR = "Envoyée";
        public const string KD_TYPE_CDERECEPT_ETAT_PDA_RECUE_STR = "Reçue pda";
        public const string KD_TYPE_CDERECEPT_ETAT_PDA_ENCOURSPREPA_STR = "En cours";
        public const string KD_TYPE_CDERECEPT_ETAT_ANNULE_STR = "Annulée";  //annulee
        public const string KD_TYPE_CDERECEPT_ETAT_TERMINE_STR = "Terminée"; //termine, meme incomplete
        public const string KD_TYPE_CDERECEPT_ETAT_PAUSE_STR = "En pause";  //en pause, a terminer un autre jour
        public const string KD_TYPE_CDERECEPT_ETAT_VALIDEFIN_STR = "Validée";  //
        public const string KD_TYPE_CDERECEPT_ETAT_RESERVE_STR = "Réservée";  //
        public const string KD_TYPE_CDERECEPT_ETAT_CLOSE_STR = "Close";
        public const string KD_TYPE_CDERECEPT_ETAT_ERRDEJATRAITE_STR = "Déjà traitée";  //cde deja traitée

        public const int KD_TYPE_CDERECEPT_ENT = 93;
        public const string FIELD_CDERECEPT_ENT_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_CDERECEPT_ENT_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_CDERECEPT_ENT_CDEPERE = FIELD_KD_dat_idx01;//si la cde est cassée en plusieurs on garde le numéro original
        public const string FIELD_CDERECEPT_ENT_NOMCLI = FIELD_KD_dat_data01;
        public const string FIELD_CDERECEPT_ENT_ISRELIQUAT = FIELD_KD_dat_data02;
        public const string FIELD_CDERECEPT_ENT_NIVEAUURG = FIELD_KD_dat_data03;
        public const string FIELD_CDERECEPT_ENT_COMMENTCDE = FIELD_KD_dat_data04;
        public const string FIELD_CDERECEPT_ENT_ETAT = FIELD_KD_dat_data05;
        public const string FIELD_CDERECEPT_ENT_CODEPREPARATEUR = FIELD_KD_dat_data06;
        public const string FIELD_CDERECEPT_ENT_NOMPREPARATEUR = FIELD_KD_dat_data07;
        public const string FIELD_CDERECEPT_ENT_DATECDE = FIELD_KD_dat_data08;
        public const string FIELD_CDERECEPT_ENT_DATELIVR = FIELD_KD_dat_data09;
        public const string FIELD_CDERECEPT_ENT_NBRCOLIS = FIELD_KD_dat_data10;
        public const string FIELD_CDERECEPT_ENT_POIDSTOTAL = FIELD_KD_dat_data11;
        public const string FIELD_CDERECEPT_ENT_OKEXPORT = FIELD_KD_dat_data12;
        public const string FIELD_CDERECEPT_ENT_ISLIVRPARTIELLE = FIELD_KD_dat_data13;
        public const string FIELD_CDERECEPT_ENT_CODETRANSPORTEUR = FIELD_KD_dat_data14;
        public const string FIELD_CDERECEPT_ENT_FACTUREREGROUP = FIELD_KD_dat_data15;//0 non, 1 oui       regroupement facture
        public const string FIELD_CDERECEPT_ENT_NBRMORCEAU = FIELD_KD_dat_data16;//en combien la commande est morcellée
        public const string FIELD_CDERECEPT_ENT_CODEREGROUP = FIELD_KD_dat_data17;//regroupement des cdes pour prépa en paquet
        public const string FIELD_CDERECEPT_ENT_TYPECMD = FIELD_KD_dat_data18;//(tof)pour gestion cmd pro/particulier (scrap)
        public const string FIELD_CDERECEPT_ENT_PRODVOL = FIELD_KD_dat_data19;//(tof)pour gestion cmd avec produit volumineux (scrap)
        public const string FIELD_CDERECEPT_ENT_REGROUPSKINET = FIELD_KD_dat_data20;//(tof)code regroupement, pour skynet (scrap)

        public const string FIELD_CDERECEPT_ENT_CODEPREPAMULTICBAC = FIELD_KD_dat_data24;//code qui permet d'ientifier les cdes préparées ensemble
        public const string FIELD_CDERECEPT_ENT_CODEBOITE_PRINC = FIELD_KD_dat_data25;//boite ou bac
        public const string FIELD_CDERECEPT_ENT_CODEBOITE_LISTE = FIELD_KD_dat_data26;//boite ou bac supplementaire sep ;
        public const string FIELD_CDERECEPT_ENT_CODEIMPORT = FIELD_KD_dat_data29;// numéro d'inmport
        public const string FIELD_CDERECEPT_ENT_PURCENTREGROUP = FIELD_KD_val_data31;// //pourcentage de regroupement des cdes par paquet

        #endregion

        #region KD_TYPE_CDERECEPT_LIN_94
        //lignes commandes à préparer
        public const int KD_TYPE_CDERECEPT_LIN = 94;

        public const string FIELD_CDERECEPT_LIN_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_CDERECEPT_LIN_CODEART = FIELD_KD_pro_code;
        public const string FIELD_CDERECEPT_LIN_CODABAR = FIELD_KD_dat_idx01;
        public const string FIELD_CDERECEPT_LIN_CODECDEPERE = FIELD_KD_dat_idx02;
        public const string FIELD_CDERECEPT_LIN_NOMART = FIELD_KD_dat_data01;
        public const string FIELD_CDERECEPT_LIN_AJOUTMANU = FIELD_KD_dat_data02;//1/0 ajout manuel dans le backoffice
        public const string FIELD_CDERECEPT_LIN_COMMENTLIN = FIELD_KD_dat_data04;
        public const string FIELD_CDERECEPT_LIN_PRIXUNIT = FIELD_KD_dat_data05;
        public const string FIELD_CDERECEPT_LIN_DATEHEURE = FIELD_KD_dat_data07;
        public const string FIELD_CDERECEPT_LIN_DEPOT = FIELD_KD_dat_data10;
        public const string FIELD_CDERECEPT_LIN_ZONE = FIELD_KD_dat_data11;
        public const string FIELD_CDERECEPT_LIN_ALLEE = FIELD_KD_dat_data12;
        public const string FIELD_CDERECEPT_LIN_ELEMENT = FIELD_KD_dat_data13;
        public const string FIELD_CDERECEPT_LIN_ETAGERE = FIELD_KD_dat_data14;
        public const string FIELD_CDERECEPT_LIN_CASIER = FIELD_KD_dat_data15;
        public const string FIELD_CDERECEPT_LIN_UNITE = FIELD_KD_dat_data17;
        public const string FIELD_CDERECEPT_LIN_NBRDECIMAL = FIELD_KD_dat_data18;
        public const string FIELD_CDERECEPT_LIN_TOLERANCE = FIELD_KD_dat_data19; //tolerance
        public const string FIELD_CDERECEPT_LIN_ISRUPTURE = FIELD_KD_dat_data20; //1=rupture
        public const string FIELD_CDERECEPT_LIN_ISBIPED = FIELD_KD_dat_data21; //1=bip used, 0=bip unused
        public const string FIELD_CDERECEPT_LIN_REFFOUR = FIELD_KD_dat_data22; //1=bip used, 0=bip unused
        public const string FIELD_CDERECEPT_LIN_PASEXPORTERP = FIELD_KD_dat_data28; //si 1 on prepare mais on exporte pas vers l'erp
        public const string FIELD_CDERECEPT_LIN_CODEIMPORT = FIELD_KD_dat_data29; //code import
        public const string FIELD_CDERECEPT_LIN_QTEARECEPT = FIELD_KD_val_data31;
        public const string FIELD_CDERECEPT_LIN_QTERECEPT = FIELD_KD_val_data32;
        public const string FIELD_CDERECEPT_LIN_STOCK = FIELD_KD_val_data33;
        public const string FIELD_CDERECEPT_LIN_CODELIN = FIELD_KD_val_data34;
        public const string FIELD_CDERECEPT_LIN_VU = FIELD_KD_val_data35; //1/0
        public const string FIELD_CDERECEPT_LIN_EFFACEE = FIELD_KD_val_data36; //flag qui dit que  la ligne est obsolete
        public const string FIELD_CDERECEPT_LIN_QTEUVFOURN = FIELD_KD_val_data37; //qté d'achat fournisseur
        #endregion

        #region KD_TYPE_INVENTAIRE_ENT_95
        //entetes commandes à receptionner

        public const int KD_TYPE_INVENTAIRE_ETAT_BLOQUE1 = 10;  //bloqué 1 er niveau
        public const int KD_TYPE_INVENTAIRE_ETAT_LIBRE = 0;  //non affecté, jamais faite
        public const int KD_TYPE_INVENTAIRE_ETAT_PDA_SEND = 1; // envoi au pda
        public const int KD_TYPE_INVENTAIRE_ETAT_PDA_RECUE = 11; // reçue sur le pda
        public const int KD_TYPE_INVENTAIRE_ETAT_PDA_ENCOURSPREPA = 12; // en cours de prépa sur le pda
        public const int KD_TYPE_INVENTAIRE_ETAT_ANNULE = 2;  //annulee
        public const int KD_TYPE_INVENTAIRE_ETAT_TERMINE = 3; //termine, meme incomplete
        public const int KD_TYPE_INVENTAIRE_ETAT_PAUSE = 4;  //en pause, a terminer un autre jour
        public const int KD_TYPE_INVENTAIRE_ETAT_RESERVE = 5;  //réservée, le préparateur est affecté mais pas encore envoyée
        public const int KD_TYPE_INVENTAIRE_ETAT_VALIDEFIN = 6;  //valide pour l'export
        public const int KD_TYPE_INVENTAIRE_ETAT_CLOSE = 99;  //exportée, donc non modifiable normallement
        public const int KD_TYPE_INVENTAIRE_ETAT_ERRDEJATRAITE = 98;  //cde deja traitée
        public const int KD_TYPE_INVENTAIRE_ETAT_TEMPSTATUS = 97;  //status temporaire

        public const string KD_TYPE_INVENTAIRE_ETAT_BLOQUE1_STR = "Bloquée";  //non affecté, jamais faite
        public const string KD_TYPE_INVENTAIRE_ETAT_LIBRE_STR = "Libre";  //non affecté, jamais faite
        public const string KD_TYPE_INVENTAIRE_ETAT_PDA_SEND_STR = "Envoyée";
        public const string KD_TYPE_INVENTAIRE_ETAT_PDA_RECUE_STR = "Reçue pda";
        public const string KD_TYPE_INVENTAIRE_ETAT_PDA_ENCOURSPREPA_STR = "En cours";
        public const string KD_TYPE_INVENTAIRE_ETAT_ANNULE_STR = "Annulée";  //annulee
        public const string KD_TYPE_INVENTAIRE_ETAT_TERMINE_STR = "Terminée"; //termine, meme incomplete
        public const string KD_TYPE_INVENTAIRE_ETAT_PAUSE_STR = "En pause";  //en pause, a terminer un autre jour
        public const string KD_TYPE_INVENTAIRE_ETAT_VALIDEFIN_STR = "Validée";  //
        public const string KD_TYPE_INVENTAIRE_ETAT_RESERVE_STR = "Réservée";  //
        public const string KD_TYPE_INVENTAIRE_ETAT_CLOSE_STR = "Close";
        public const string KD_TYPE_INVENTAIRE_ETAT_ERRDEJATRAITE_STR = "Déjà traitée";  //cde deja traitée

        public const int KD_TYPE_INVENTAIRE_ENT = 95;
        public const string FIELD_INVENTAIRE_ENT_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_INVENTAIRE_ENT_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_INVENTAIRE_ENT_CDEPERE = FIELD_KD_dat_idx01;//si la cde est cassée en plusieurs on garde le numéro original
        public const string FIELD_INVENTAIRE_ENT_NOMCLI = FIELD_KD_dat_data01;
        public const string FIELD_INVENTAIRE_ENT_ISRELIQUAT = FIELD_KD_dat_data02;
        public const string FIELD_INVENTAIRE_ENT_NIVEAUURG = FIELD_KD_dat_data03;
        public const string FIELD_INVENTAIRE_ENT_COMMENTCDE = FIELD_KD_dat_data04;
        public const string FIELD_INVENTAIRE_ENT_ETAT = FIELD_KD_dat_data05;
        public const string FIELD_INVENTAIRE_ENT_CODEPREPARATEUR = FIELD_KD_dat_data06;
        public const string FIELD_INVENTAIRE_ENT_NOMPREPARATEUR = FIELD_KD_dat_data07;
        public const string FIELD_INVENTAIRE_ENT_DATECDE = FIELD_KD_dat_data08;
        public const string FIELD_INVENTAIRE_ENT_DATELIVR = FIELD_KD_dat_data09;
        public const string FIELD_INVENTAIRE_ENT_NBRCOLIS = FIELD_KD_dat_data10;
        public const string FIELD_INVENTAIRE_ENT_POIDSTOTAL = FIELD_KD_dat_data11;
        public const string FIELD_INVENTAIRE_ENT_OKEXPORT = FIELD_KD_dat_data12;
        public const string FIELD_INVENTAIRE_ENT_ISLIVRPARTIELLE = FIELD_KD_dat_data13;
        public const string FIELD_INVENTAIRE_ENT_CODETRANSPORTEUR = FIELD_KD_dat_data14;
        public const string FIELD_INVENTAIRE_ENT_FACTUREREGROUP = FIELD_KD_dat_data15;//0 non, 1 oui       regroupement facture
        public const string FIELD_INVENTAIRE_ENT_NBRMORCEAU = FIELD_KD_dat_data16;//en combien la commande est morcellée
        public const string FIELD_INVENTAIRE_ENT_CODEREGROUP = FIELD_KD_dat_data17;//regroupement des cdes pour prépa en paquet
        public const string FIELD_INVENTAIRE_ENT_TYPECMD = FIELD_KD_dat_data18;//(tof)pour gestion cmd pro/particulier (scrap)
        public const string FIELD_INVENTAIRE_ENT_PRODVOL = FIELD_KD_dat_data19;//(tof)pour gestion cmd avec produit volumineux (scrap)
        public const string FIELD_INVENTAIRE_ENT_REGROUPSKINET = FIELD_KD_dat_data20;//(tof)code regroupement, pour skynet (scrap)

        public const string FIELD_INVENTAIRE_ENT_CODEPREPAMULTICBAC = FIELD_KD_dat_data24;//code qui permet d'ientifier les cdes préparées ensemble
        public const string FIELD_INVENTAIRE_ENT_CODEBOITE_PRINC = FIELD_KD_dat_data25;//boite ou bac
        public const string FIELD_INVENTAIRE_ENT_CODEBOITE_LISTE = FIELD_KD_dat_data26;//boite ou bac supplementaire sep ;
        public const string FIELD_INVENTAIRE_ENT_CODEIMPORT = FIELD_KD_dat_data29;// numéro d'inmport
        public const string FIELD_INVENTAIRE_ENT_PURCENTREGROUP = FIELD_KD_val_data31;// //pourcentage de regroupement des cdes par paquet

        #endregion

        #region KD_TYPE_INVENTAIRE_LIN_96
        //lignes commandes à préparer
        public const int KD_TYPE_INVENTAIRE_LIN = 96;

        public const string FIELD_INVENTAIRE_LIN_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_INVENTAIRE_LIN_CODEART = FIELD_KD_pro_code;
        public const string FIELD_INVENTAIRE_LIN_CODABAR = FIELD_KD_dat_idx01;
        public const string FIELD_INVENTAIRE_LIN_CODECDEPERE = FIELD_KD_dat_idx02;
        public const string FIELD_INVENTAIRE_LIN_NOMART = FIELD_KD_dat_data01;
        public const string FIELD_INVENTAIRE_LIN_COMMENTLIN = FIELD_KD_dat_data04;
        public const string FIELD_INVENTAIRE_LIN_PRIXUNIT = FIELD_KD_dat_data05;
        public const string FIELD_INVENTAIRE_LIN_DATEHEURE = FIELD_KD_dat_data07;
        public const string FIELD_INVENTAIRE_LIN_DEPOT = FIELD_KD_dat_data10;
        public const string FIELD_INVENTAIRE_LIN_ZONE = FIELD_KD_dat_data11;
        public const string FIELD_INVENTAIRE_LIN_ALLEE = FIELD_KD_dat_data12;
        public const string FIELD_INVENTAIRE_LIN_ELEMENT = FIELD_KD_dat_data13;
        public const string FIELD_INVENTAIRE_LIN_ETAGERE = FIELD_KD_dat_data14;
        public const string FIELD_INVENTAIRE_LIN_CASIER = FIELD_KD_dat_data15;
        public const string FIELD_INVENTAIRE_LIN_UNITE = FIELD_KD_dat_data17;//si plusieurs unités on sépare avec du PIPE
        public const string FIELD_INVENTAIRE_LIN_NBRDECIMAL = FIELD_KD_dat_data18;
        public const string FIELD_INVENTAIRE_LIN_TOLERANCE = FIELD_KD_dat_data19; //tolerance
        public const string FIELD_INVENTAIRE_LIN_ISPASTROUVE = FIELD_KD_dat_data20; //1=article pas trouvé, donc pas envoyé à SM
        public const string FIELD_INVENTAIRE_LIN_ISBIPED = FIELD_KD_dat_data21; //1=bip used, 0=bip unused
        public const string FIELD_INVENTAIRE_LIN_PCB = FIELD_KD_dat_data23; //PCB correspondant à l'unité
        public const string FIELD_INVENTAIRE_LIN_PASEXPORTERP = FIELD_KD_dat_data28; //si 1 on prepare mais on exporte pas vers l'erp
        public const string FIELD_INVENTAIRE_LIN_CODEIMPORT = FIELD_KD_dat_data29; //code import
        public const string FIELD_INVENTAIRE_LIN_QTEAPRREPA = FIELD_KD_val_data31;
        public const string FIELD_INVENTAIRE_LIN_QTEPREPA = FIELD_KD_val_data32;
        public const string FIELD_INVENTAIRE_LIN_STOCK = FIELD_KD_val_data33;
        public const string FIELD_INVENTAIRE_LIN_CODELIN = FIELD_KD_val_data34;
        public const string FIELD_INVENTAIRE_LIN_VU = FIELD_KD_val_data35; //1/0
        public const string FIELD_INVENTAIRE_LIN_EFFACEE = FIELD_KD_val_data36; //flag qui dit que  la ligne est obsolete
        #endregion

        #region KD_TYPE_CDEPREPA_COMMENT_97
        /************************************************************************/
        /* commentaire de cde, multiligne                                                                     */
        /************************************************************************/
        public const int KD_TYPE_CDERECEPT_COMMENT = 97;
        public const string FIELD_CDERECEPT_COMMENT_NUMCDE = FIELD_KD_cde_code;
        public const string FIELD_CDERECEPT_COMMENT_NUMLIN = FIELD_KD_val_data31;
        public const string FIELD_CDERECEPT_COMMENT_TEXTE = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_ENQUETE_QUESTIONS_98
        /************************************************************************/
        /* Questions de l'enquete */
        /************************************************************************/
        public const int KD_TYPE_ENQUETE_QUESTIONS = 98;
        public const string FIELD_ENQUETE_QUESTIONS_CODE = FIELD_KD_dat_idx02;
        public const string FIELD_ENQUETE_QUESTIONS_CODEENQUETE= FIELD_KD_dat_idx01;
        public const string FIELD_ENQUETE_QUESTIONS_LBL = FIELD_KD_dat_data01;
        public const string FIELD_ENQUETE_QUESTIONS_TYPE = FIELD_KD_dat_data02;
        public const string FIELD_ENQUETE_QUESTIONS_ACTIVE = FIELD_KD_dat_data03; // 1/0
        public const string FIELD_ENQUETE_QUESTIONS_ORDRE = FIELD_KD_val_data31;

        #endregion

        #region KD_TYPE_ENQUETE_CHOIXREPONSES_99
        /************************************************************************/
        /* choix de réponses pour les choix uniques et choix multiples*/
        /************************************************************************/
        public const int KD_TYPE_ENQUETE_CHOIXREPONSES = 99;
        public const string FIELD_ENQUETE_CHOIXREPONSES_CODE = FIELD_KD_dat_idx02;
        public const string FIELD_ENQUETE_CHOIXREPONSES_CODEQUESTION = FIELD_KD_dat_idx01;
        public const string FIELD_ENQUETE_CHOIXREPONSES_LBL = FIELD_KD_dat_data01;
        public const string FIELD_ENQUETE_CHOIXREPONSES_ACTIVE = FIELD_KD_dat_data03; // 1/0
        public const string FIELD_ENQUETE_CHOIXREPONSES_ORDRE = FIELD_KD_val_data31;

        #endregion

        #region KD_TYPE_ENQUETE_ENQUETE_100
        /************************************************************************/
        /* enquete */
        /************************************************************************/
        public const int KD_TYPE_ENQUETE= 100;
        public const string FIELD_ENQUETE_CODE = FIELD_KD_dat_idx01;
        public const string FIELD_ENQUETE_LBL = FIELD_KD_dat_data01;
        public const string FIELD_ENQUETE_ACTIVE = FIELD_KD_dat_data03; // 1/0
        public const string FIELD_ENQUETE_COMMENT = FIELD_KD_dat_data04;    
        public const string FIELD_ENQUETE_ORDRE = FIELD_KD_val_data31;

        #endregion

        #region KD_TYPE_ENQUETE_QUESTIONS_REPONSES_101
        /************************************************************************/
        /* reponses enquete */
        /************************************************************************/
        public const int KD_TYPE_ENQUETE_QUESTIONS_REPONSES = 101;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_NUMVIS = FIELD_KD_vis_code;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_DATE = FIELD_KD_dat_data01;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_ENQUETECODE = FIELD_KD_dat_idx01;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_ENQUETELBL = FIELD_KD_dat_data01;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_QUESTIONCODE = FIELD_KD_dat_idx02;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_QUESTIONLBL= FIELD_KD_dat_data02;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_REPONSECODE= FIELD_KD_dat_idx03;
        public const string FIELD_ENQUETE_QUESTIONS_REPONSES_REPONSELBL= FIELD_KD_dat_data03;

        #endregion

        #region KD_TYPE_PREPACDE_ETAT_102
        /************************************************************************/
        /* on garde les prépa qui ont été débloquée dans une autre table, comme cela si on efface l'enregistrement principale on a une sauvegarde de l'état */
        /************************************************************************/
        public const int KD_TYPE_PREPACDE_ETAT = 102;
        public const string FIELD_PREPACDE_ETAT_CDE_CODE= FIELD_KD_cde_code;
        public const string FIELD_PREPACDE_ETAT_VALEUR = FIELD_KD_dat_data05;
        #endregion

        #region KD_TYPE_CDEFOUR_CREATION_ENT_103
        /**
         * création de bon de cdes fournisseurs
         * */
        public const string PREFIX_CDEFOUR_CREATION_ENT_FOURCODE = "CS";
        public const int KD_TYPE_CDEFOUR_CREATION_ENT = 103;

        public const string FIELD_CDEFOUR_CREATION_ENT_CDECODE = FIELD_KD_cde_code;
        public const string FIELD_CDEFOUR_CREATION_ENT_CDECODE_PERE = FIELD_KD_dat_idx01;
        public const string FIELD_CDEFOUR_CREATION_ENT_FOURCODE = FIELD_KD_dat_idx02;        
        public const string FIELD_CDEFOUR_CREATION_ENT_FOURFAX = FIELD_KD_dat_data01;
        public const string FIELD_CDEFOUR_CREATION_ENT_DATE= FIELD_KD_dat_data02;
        public const string FIELD_CDEFOUR_CREATION_ENT_COMMENT= FIELD_KD_dat_data03;
        public const string FIELD_CDEFOUR_CREATION_ENT_FOURNOM = FIELD_KD_dat_data04;
        public const string FIELD_CDEFOUR_CREATION_ENT_FOURMAIL= FIELD_KD_dat_data05;
        #endregion

     

        #region KD_TYPE_CDEFOUR_CREATION_LIN_104
        /**
         * création de bon de cdes fournisseurs
         * */
        public const int KD_TYPE_CDEFOUR_CREATION_LIN = 104;
        public const string FIELD_CDEFOUR_CREATION_LIN_CDECODE = FIELD_KD_cde_code;
        public const string FIELD_CDEFOUR_CREATION_LIN_CDECODE_PERE = FIELD_KD_dat_idx02;
        public const string FIELD_CDEFOUR_CREATION_LIN_CDEPREPA_CODEPERE = FIELD_KD_dat_idx03;//code de la ce prepa dans laquelle la ligne a été trouvée
        public const string FIELD_CDEFOUR_CREATION_LIN_PROCODE= FIELD_KD_pro_code;
        public const string FIELD_CDEFOUR_CREATION_LIN_NOMART = FIELD_KD_dat_data01;
        public const string FIELD_CDEFOUR_CREATION_LIN_CB = FIELD_KD_dat_data02;
        public const string FIELD_CDEFOUR_CREATION_LIN_QTECDE= FIELD_KD_val_data31;
        public const string FIELD_CDEFOUR_CREATION_LIN_DATE = FIELD_KD_date_insert;
        #endregion

        #region KD_TYPE_REFFOURNISSEUR_105
        /**
         * les codes articles fournisseurs
         * */
        public const int KD_TYPE_REFFOURN= 105;
        public const string FIELD_REFFOURN_PROCODE= FIELD_KD_pro_code;
        public const string FIELD_REFFOURN_FOURNCODE = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_MAJDATA_TIMESTAMP_106
        /**
         * mise à jour des données
         * */
        public const string MAJDATA_STOCK = "stock";
        public const string MAJDATA_PROD = "prod";
        public const string MAJDATA_CLI = "cli";

        public const int KD_TYPE_MAJDATA = 106;

        public const string FIELD_MAJDATA_ID = FIELD_KD_dat_idx01;
        public const string FIELD_MAJDATA_UPDATE = FIELD_KD_date_update;
        #endregion

        #region KD_TYPE_PATHFINDER_PLACE_107
        /**
         * coordonnées des emplacements dans le pathfinder
         * */
        public const int KD_TYPE_PATHFINDER_PLACE = 107;

        public const string FIELD_PATHFINDER_PLACE_SCHEMA = FIELD_KD_dat_idx01;//nom du schém associé
        public const string FIELD_PATHFINDER_PLACE_EMPLACEMENT = FIELD_KD_dat_idx02;
        public const string FIELD_PATHFINDER_PLACE_X = FIELD_KD_dat_data01;
        public const string FIELD_PATHFINDER_PLACE_Y = FIELD_KD_dat_data02;
        #endregion


        #region KD_TYPE_CLIENTSPE_108
        /**
         *Pour paritys, client speciaux avec leurs correspondance client serieM
         * */
        public const int KD_TYPE_CLIENTSPE = 108;

        public const string FIELD_CLIENTSPE_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_CLIENTSPE_ENSEIGNE = FIELD_KD_dat_idx01;
        public const string FIELD_CLIENTSPE_CODESPE = FIELD_KD_dat_idx02;
        public const string FIELD_CLIENTSPE_CODECLI = FIELD_KD_dat_idx03;
        public const string FIELD_CLIENTSPE_NOM = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_CATALOGUE_109
        /**
         *Pour paritys, client speciaux avec leurs correspondance client serieM
         * */
        public const int KD_TYPE_CATALOGUE = 109;

        public const string FIELD_CATALOGUE_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_CATALOGUE_ID = FIELD_KD_dat_idx01;
        public const string FIELD_CATALOGUE_NOM = FIELD_KD_dat_data01;
        public const string FIELD_CATALOGUE_ACTIF = FIELD_KD_dat_data02;
        #endregion


        #region KD_TYPE_CATALOGUESEND_110
        /**
         *Pour paritys, client speciaux avec leurs correspondance client serieM
         * */
        public const int KD_TYPE_CATALOGUESEND = 110;

        public const string FIELD_CATALOGUESEND_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_CATALOGUESEND_ID = FIELD_KD_dat_idx01;
        public const string FIELD_CATALOGUESEND_CODECLI = FIELD_KD_dat_idx02;
        public const string FIELD_CATALOGUESEND_DATEENVOI = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_MULTIFAM_111
        /**
         *Pour paritys, table des multiple, par famille et par enseigne (utilisé pour MAJ les quantité des fichiers truffaut et mondial tissu)
         * */
        public const int KD_TYPE_MULTIFAM = 111;
        public const string FIELD_MULTIFAM_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_MULTIFAM_ENS = FIELD_KD_dat_idx01;
        public const string FIELD_MULTIFAM_FAMILLE = FIELD_KD_dat_idx02;
        public const string FIELD_MULTIFAM_MULTIPLE = FIELD_KD_dat_data01;
        #endregion

        #region KD_TYPE_CONDITIONNEMENT
        /**
         *Pour paritys, table des multiple, par famille et par enseigne (utilisé pour MAJ les quantité des fichiers truffaut et mondial tissu)
         * */
        public const int KD_TYPE_PROCOND = 112;
        public const string FIELD_PROCOND_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_PROCOND_CODE = FIELD_KD_pro_code;
        public const string FIELD_PROCOND_LBL = FIELD_KD_dat_data01;
        public const string FIELD_PROCOND_CB = FIELD_KD_dat_data02;
        public const string FIELD_PROCOND_PRINCIPAL = FIELD_KD_dat_data03;
        public const string FIELD_PROCOND_QTE = FIELD_KD_val_data31;
        #endregion

        #region KD_TYPE_ANDRONEGOS_ENTCDE_83
        public const int KD_TYPE_ANDRONEGOS_ENTCDE = 83;
        public const int KD_TYPE_ANDRONEGOS_LINCDE = 84;
        public const string FIELD_ANDRONEGOS_ENTCDE_SOCCODE = FIELD_KD_soc_code;
        public const string FIELD_ANDRONEGOS_ENTCDE_CODEREP = FIELD_KD_dat_idx01;
        public const string FIELD_ANDRONEGOS_ENTCDE_MNTFRAIS = FIELD_KD_dat_idx06;
        public const string FIELD_ANDRONEGOS_ENTCDE_CODECLI = FIELD_KD_cli_code;
        public const string FIELD_ANDRONEGOS_ENTCDE_CODECDE = FIELD_KD_cde_code;
        public const string FIELD_ANDRONEGOS_ENTCDE_NOMCLI = FIELD_KD_dat_data01;
        public const string FIELD_ANDRONEGOS_ENTCDE_CODECDE_SPE = FIELD_KD_dat_data02;
        public const string FIELD_ANDRONEGOS_ENTCDE_REFCDE = FIELD_KD_dat_data03;
        public const string FIELD_ANDRONEGOS_ENTCDE_COMMENTCDE = FIELD_KD_dat_data04;
        public const string FIELD_ANDRONEGOS_ENTCDE_ETAT = FIELD_KD_dat_data05;
        public const string FIELD_ANDRONEGOS_ENTCDE_SEND = FIELD_KD_dat_data06;//1 par défaut en arrivant du pda, 2 si vu par le client
        public const string FIELD_ANDRONEGOS_ENTCDE_TYPEDOC = FIELD_KD_dat_data07;
        public const string FIELD_ANDRONEGOS_ENTCDE_DATECDE = FIELD_KD_dat_data08;
        public const string FIELD_ANDRONEGOS_ENTCDE_DATELIVR = FIELD_KD_dat_data09;
        public const string FIELD_ANDRONEGOS_ENTCDE_ISPRINT = FIELD_KD_dat_data11;
        public const string FIELD_ANDRONEGOS_ENTCDE_CONDLIVR = FIELD_KD_dat_data12;
        public const string FIELD_ANDRONEGOS_ENTCDE_ISRELIQUAT = FIELD_KD_dat_data13;
        public const string FIELD_ANDRONEGOS_ENTCDE_CDEMARCHE = FIELD_KD_dat_data14;
        public const string FIELD_ANDRONEGOS_ENTCDE_NBLIVR = FIELD_KD_dat_data15;
        public const string FIELD_ANDRONEGOS_ENTCDE_ISEDITSURFACT = FIELD_KD_dat_data16;
        public const string FIELD_ANDRONEGOS_ENTCDE_ADRLIV = FIELD_KD_dat_data17;
        public const string FIELD_ANDRONEGOS_ENTCDE_DATEHEUREDEBUT = FIELD_KD_dat_data18;
        public const string FIELD_ANDRONEGOS_ENTCDE_DATEHEUREFIN = FIELD_KD_dat_data19;
        public const string FIELD_ANDRONEGOS_ENTCDE_REMISE = FIELD_KD_dat_data20;
        public const string FIELD_ANDRONEGOS_ENTCDE_ESCOMPTE = FIELD_KD_dat_data21;
        public const string FIELD_ANDRONEGOS_ENTCDE_R_REGL = FIELD_KD_dat_data22;
        public const string FIELD_ANDRONEGOS_ENTCDE_R_COND = FIELD_KD_dat_data23;
        public const string FIELD_ANDRONEGOS_ENTCDE_R_NBJOURS = FIELD_KD_dat_data24;
        public const string FIELD_ANDRONEGOS_ENTCDE_R_CODEREGL = FIELD_KD_dat_data25;
        public const string FIELD_ANDRONEGOS_ENTCDE_ECHEANCE = FIELD_KD_dat_data26;
        public const string FIELD_ANDRONEGOS_ENTCDE_PORT = FIELD_KD_dat_data27;
        public const string FIELD_ANDRONEGOS_ENTCDE_DEPOT = FIELD_KD_dat_data28;
        public const string FIELD_ANDRONEGOS_ENTCDE_SAISON = FIELD_KD_dat_data29;
        public const string FIELD_ANDRONEGOS_ENTCDE_MNTHT = FIELD_KD_val_data31;
        public const string FIELD_ANDRONEGOS_ENTCDE_MNTTVA1 = FIELD_KD_val_data32;
        public const string FIELD_ANDRONEGOS_ENTCDE_MNTTVA2 = FIELD_KD_val_data33;
        public const string FIELD_ANDRONEGOS_ENTCDE_MNTTC = FIELD_KD_val_data34;
        public const string FIELD_ANDRONEGOS_ENTCDE_REMISE1 = FIELD_KD_val_data35;
        public const string FIELD_ANDRONEGOS_ENTCDE_REMISE2 = FIELD_KD_val_data36;
        public const string FIELD_ANDRONEGOS_ENTCDE_FLAGEXPORT = FIELD_KD_FLAG;
        #endregion



        //Specifique daniCreation, historique des commandes
        #region KD_TYPE_DANI_990_et_991
        public const int KD_TYPE_DANIENT = 990;

        public const string FIELD_DANIENT_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_DANIENT_codesoc = FIELD_KD_soc_code;
        public const string FIELD_DANIENT_numdoc = FIELD_KD_cde_code;
        public const string FIELD_DANIENT_numdocdef = FIELD_KD_dat_data01;
        public const string FIELD_DANIENT_codecli = FIELD_KD_cli_code;
        public const string FIELD_DANIENT_date = FIELD_KD_dat_data02;
        public const string FIELD_DANIENT_dateliv = FIELD_KD_dat_data03;
        public const string FIELD_DANIENT_refcli = FIELD_KD_dat_data04;
        public const string FIELD_DANIENT_remise = FIELD_KD_val_data31;
        public const string FIELD_DANIENT_mntremise = FIELD_KD_val_data32;
        public const string FIELD_DANIENT_escompte = FIELD_KD_val_data33;
        public const string FIELD_DANIENT_mntescompte = FIELD_KD_val_data34;
        public const string FIELD_DANIENT_tarif = FIELD_KD_val_data35;
        public const string FIELD_DANIENT_totalht = FIELD_KD_val_data36;
        public const string FIELD_DANIENT_totaltva = FIELD_KD_val_data37;
        public const string FIELD_DANIENT_portht = FIELD_KD_val_data38;
        public const string FIELD_DANIENT_porttva = FIELD_KD_dat_data12 ;
        public const string FIELD_DANIENT_fraisht = FIELD_KD_val_data40;
        public const string FIELD_DANIENT_fraistva = FIELD_KD_dat_data13;
        public const string FIELD_DANIENT_totalttc = FIELD_KD_val_data39 ;
        public const string FIELD_DANIENT_coderegl = FIELD_KD_dat_data05;
        public const string FIELD_DANIENT_coderep = FIELD_KD_dat_data06;
        public const string FIELD_DANIENT_tranfert = FIELD_KD_dat_data07;
        public const string FIELD_DANIENT_numdocgestion = FIELD_KD_dat_data08;
        public const string FIELD_DANIENT_datemod = FIELD_KD_dat_data09;
        public const string FIELD_DANIENT_piecetransfert = FIELD_KD_dat_data10;
        public const string FIELD_DANIENT_coderepenrg = FIELD_KD_dat_data11;

        public const int KD_TYPE_DANILIN = 991;

        public const string FIELD_DANILIN_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_DANILIN_codesoc = FIELD_KD_soc_code;
        public const string FIELD_DANILIN_numdoc = FIELD_KD_cde_code;
        public const string FIELD_DANILIN_codecli = FIELD_KD_cli_code;
        public const string FIELD_DANILIN_numlin = FIELD_KD_dat_idx01;
        public const string FIELD_DANILIN_codeart = FIELD_KD_pro_code;
        public const string FIELD_DANILIN_designation = FIELD_KD_dat_data01;
        public const string FIELD_DANILIN_totalcolis = FIELD_KD_val_data31;
        public const string FIELD_DANILIN_nbrcolis = FIELD_KD_val_data32;
        public const string FIELD_DANILIN_qnt = FIELD_KD_val_data33;
        public const string FIELD_DANILIN_pubrut = FIELD_KD_val_data34;
        public const string FIELD_DANILIN_remise = FIELD_KD_val_data35;
        public const string FIELD_DANILIN_punet = FIELD_KD_val_data36;
        public const string FIELD_DANILIN_total = FIELD_KD_val_data37;
        public const string FIELD_DANILIN_tva = FIELD_KD_val_data38;
        public const string FIELD_DANILIN_longueur = FIELD_KD_dat_data02;
        public const string FIELD_DANILIN_largeur = FIELD_KD_dat_data03;
        public const string FIELD_DANILIN_epaisseur = FIELD_KD_dat_data04;
        public const string FIELD_DANILIN_coeffact = FIELD_KD_dat_data05;



        #endregion


        //SPECIFIQUEPARITYS
        #region KD_TYPE_PARITYS_CROISEMENT_998_999
        public const int KD_TYPE_CROISEMENTTRUFFAUT = 998;

        public const string FIELD_TRUFFAUT_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_TRUFFAUT_CODEART_U = FIELD_KD_dat_idx01;
        public const string FIELD_TRUFFAUT_GENCODE_U = FIELD_KD_dat_idx02;
        public const string FIELD_TRUFFAUT_CORDART_BOITE = FIELD_KD_dat_idx03;
        public const string FIELD_TRUFFAUT_GENCODE_BOITE = FIELD_KD_dat_idx04;

        
        public const int KD_TYPE_CROISEMENTMONDIAL = 999;

        public const string FIELD_MT_DATATYPE = FIELD_KD_dat_type;
        public const string FIELD_MT_CODEART = FIELD_KD_pro_code;
        public const string FIELD_MT_CB = FIELD_KD_dat_idx01;
        #endregion

        #region KD_TYPE_CDEAPREPA_ENTMC_113_114_megacommande_paritys
        //Mega commande
        //Utilisation des defines pour les type 73 et 74
        public const int KD_TYPE_CDEAPREPA_ENT_MC = 113;
        public const int KD_TYPE_CDEAPREPA_LIN_MC = 114;

        //Attention, un nouveau champs (Num mega commande fille a été ajouté dans l'entete

        #endregion




        public const string USERIDconst = "'USERID'";
        //recherche produit dans le relevé
        public const string QUERY1 = "SELECT distinct ref.pro_code AS ref_pro_code, kems_produit.*,saisie.dat_data01 as pvc,saisie.dat_data02 as fcg,saisie.dat_data03 as presence,saisie.dat_data04 as promo,saisie.dat_data06 as comment,histo.dat_data01 as ppc_histo FROM ((kems_produit INNER JOIN KEMS_refer AS ref ON (kems_produit.pro_code = ref.pro_code AND ref.prm_assort_code='$$C6$$')) LEFT JOIN KEMS_tmpData as saisie ON (kems_produit.pro_code = saisie.pro_code AND saisie.dat_type=58)) left join kems_histodata as histo on (kems_produit.pro_code=histo.pro_code AND histo.dat_type=58 AND histo.vis_code = '$$C4$$') WHERE  kems_produit.pro_code like '$$C1$$%' AND  kems_produit.pro_nom like '%$$C2$$%' AND kems_produit.prm_rayon_code like '%$$C3$$' AND kems_produit.pro_codabar like '%$$C5$$%' $$C7$$ $$C8$$ $$C9$$ $$C10$$ ORDER BY kems_produit.prm_fam3_code";
        
        public const string VIEWNAME_RPT_PREPACDE_MANAGER1="view_prepacde_manager1"+USERIDconst;
        public const string VIEW_RPT_PREPACDE_MANAGER1 = "CREATE VIEW "+VIEWNAME_RPT_PREPACDE_MANAGER1+" as SELECT lin.val_data32 AS qtePrepa, hdr.cde_code as numcde,   hdr.cli_code, hdr.dat_idx01 AS numcde_pere, hdr.dat_data01 AS nomcli, hdr.dat_data08 AS datecde, hdr.dat_data09 AS datelivr,  lin.pro_code, lin.dat_idx01 AS cb, lin.dat_data01 AS nomart, lin.val_data31 AS qteaprep,  lin.dat_data10 + lin.dat_data11 + lin.dat_data12 + lin.dat_data13 + lin.dat_data14 + lin.dat_data15 AS Expr1 FROM     KEMS_Data AS hdr INNER JOIN KEMS_Data AS lin ON hdr.cde_code = lin.cde_code WHERE     (hdr.dat_type = 73) AND (lin.dat_type = 74) ";
        public const string VIEW_CDEHDR_83 = "CREATE VIEW VIEW_kd_cdehdr_83 as SELECT     cli_code, cde_code, dat_data01 AS nomcli, dat_data03 AS refcde, dat_data08 AS datecde, dat_data09 AS datelivr, val_data31 AS mntht FROM  KEMS_Data WHERE     (dat_type = 83)";
        public const string VIEW_CDELIN_84 = "create view VIEW_kd_cdelin_84 as SELECT     pro_code, cde_code, dat_data02 AS design, dat_data04 AS qtecde, dat_data05 AS prix, dat_data06 AS mntht FROM KEMS_Data WHERE     (dat_type = 84)";

        public const string FILENAME_CDEPREPA="kd_prepacde_";
        public const string FILENAME_INVENTAIRE = "kd_invent_";
        public const string FILENAME_CDERECEPT = "kd_receptcde_";
    }
}
