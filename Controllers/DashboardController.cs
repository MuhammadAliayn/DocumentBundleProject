using InPlace4.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InPlace4.Controllers
{
    public class DashboardController : Controller
    {
        private bool connection_open;
        private MySqlConnection connection;
        private __mLoggedUser mLoggedUser;
        __RestClient RestClient = new __RestClient("http://192.168.99.21:8099/");
        // GET: Dashboard
        public ActionResult vwDashboard()
        {
            DataSet DS = new DataSet();
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            string IdPortfolio = "6";//PortfoliosComboBox.Text.Substring(PortfoliosComboBox.Text.IndexOf("[") + 1, PortfoliosComboBox.Text.IndexOf("]") - (PortfoliosComboBox.Text.IndexOf("[") + 1));

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("IdPortfolio", IdPortfolio);
            Params.Add("GroupBy", "Originator");


            List<DocumentCount> list = new List<DocumentCount>();
            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDossiers", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            //string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/GetOriginatorDossier.txt");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDossiers mDossiers = JsonConvert.DeserializeObject<__mDossiers>(JsonResponse);

                //var deserialized = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, dynamic>>>(mDossiers.JsonDataset);
                //List<object> value = deserialized.SelectMany(result => result.Value).Cast<object>().ToList();
                //string word = value[1].ToString().Replace("[Table, [", "").Replace("]]", "")
                //    .Replace("\"", "").Replace(System.Environment.NewLine, "").Replace(":", "")
                //    .Replace("{    ", "").Replace("},", ":").Replace("}", "");
                //string[] countDoc = word.Split(new string[] { ":" }, StringSplitOptions.None);


                //foreach (var item in countDoc)
                //{
                //    string[] split = item.Split(',');
                //    list.Add(new DocumentCount { Name = split[0].Replace("Originator ", "").TrimEnd().TrimStart(), GroupName = split[0].Replace("Originator ", "").Replace("_", " ").TrimEnd().TrimStart(), DocCount = split[1].Replace("Total ", "").TrimEnd().TrimStart() });
                //}
                DS = mDossiers.GetDataSet();
            }
            return PartialView("PvwDashboard", DS);
        }

        public ActionResult PvwGruppoDettaglio()
        {

            return PartialView("PvwGruppoDettaglio");
        }
        private void GetDossiers(object sender, EventArgs e)
        {
            string IdPortfolio = "6";//PortfoliosComboBox.Text.Substring(PortfoliosComboBox.Text.IndexOf("[") + 1, PortfoliosComboBox.Text.IndexOf("]") - (PortfoliosComboBox.Text.IndexOf("[") + 1));

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("IdPortfolio", IdPortfolio);
            Params.Add("GroupBy", "Originator");
            //if (AllRadioButton.Checked) Params.Add("GroupBy", "All");
            //else if (OriginatorRadioButton.Checked) Params.Add("GroupBy", "Originator");
            //else if (ScoreRadioButton.Checked) Params.Add("GroupBy", "Score");

            __RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDossiers", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDossiers mDossiers = JsonConvert.DeserializeObject<__mDossiers>(JsonResponse);

                DataSet DS = mDossiers.GetDataSet();
                //if (!mDossiers.GetDataSet(ref DS)) ErrorTextBox.Text = "mDossiers.GetDataSet - GetDossiers Failed!";
                //else
                //{

                //    //UpdateDossiers(DS);
                //}

            }
        }

        [HttpGet]
        public ActionResult GetOriginatorDossiers(string id)
        {
            DataSet DS = new DataSet();
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            string IdPortfolio = "6";//BANCA_MALATESTIANA//PortfoliosComboBox.Text.Substring(PortfoliosComboBox.Text.IndexOf("[") + 1, PortfoliosComboBox.Text.IndexOf("]") - (PortfoliosComboBox.Text.IndexOf("[") + 1));
            string Originator = id;// DossiersListBox.Text.Replace("Originator: ", "");

            if (string.IsNullOrEmpty(id))
            {
                Originator = "BANCA_MALATESTIANA";
            }

            //Originator = Originator.Substring(0, Originator.IndexOf(" -"));

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("IdPortfolio", IdPortfolio);
            Params.Add("Originator", Originator);

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetOriginatorDossiers", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            //string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/GetDossierDocumentOnclick.txt");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDossiers mDossiers = JsonConvert.DeserializeObject<__mDossiers>(JsonResponse);

                DS = mDossiers.GetDataSet();
            }
            return PartialView("~/Views/Shared/PvwGruppoDettaglio.cshtml", DS);
        }

        private void GetScoreDossiers()
        {
            string IdPortfolio = "";//PortfoliosComboBox.Text.Substring(PortfoliosComboBox.Text.IndexOf("[") + 1, PortfoliosComboBox.Text.IndexOf("]") - (PortfoliosComboBox.Text.IndexOf("[") + 1));
            string Originator = "";// DossiersListBox.Text.Replace("Score: ", "");
            Originator = Originator.Substring(0, Originator.IndexOf(" -"));

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("IdPortfolio", IdPortfolio);
            Params.Add("Score", Originator);

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetScoreDossiers", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDossiers mDossiers = JsonConvert.DeserializeObject<__mDossiers>(JsonResponse);

                DataSet DS = null;
                //if (!mDossiers.GetDataSet(ref DS)) ErrorTextBox.Text = " mDossiers.GetDataSet - GetOriginatorDossiers Failed!";
                //else
                //{

                //    UpdateFilteredDossiers(DS);
                //}

            }
        }

        public ActionResult GetGroupDocuments(string Dossier)
        {
            bool Clustered = true;
            string Cluster = null;
            int Page = 0, Rows = 0;
            DataSet DS = new DataSet();
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("Dossier", Dossier);
            Params.Add("Clustered", Clustered.ToString());

            Params.Add("Cluster", Cluster);

            if (Page > 0 && Rows > 0)
            {
                Params.Add("Page", Page.ToString());
                Params.Add("Rows", Rows.ToString());
            }
            else
            {
                Params.Add("Page", null);
                Params.Add("Rows", null);
            }

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDocuments", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            //string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/getclusterdocument.txt");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDocuments mDocuments = JsonConvert.DeserializeObject<__mDocuments>(JsonResponse);

                DS = mDocuments.GetDataSet();
            }
            return PartialView("~/Views/Shared/PvwFascicolo.cshtml", DS);
        }

        public ActionResult GetDocumentsFascicoli(string Dossier, bool Clustered, string Cluster, int Page = 0, int Rows = 0)
        {

            //Get_Connection();


            ////string sqlCmd = "select * from anagrafica";
            //string Query = "";
            //if (string.IsNullOrEmpty(Cluster))
            //{
            //    Query = @"
            //                               select
            //                                    CD.id, 
            //                                    CD.Label,
            //                                    CD.descrizione,
            //                                    count(cluster_documentale) as Total

            //                               from
            //                                    documento D inner join cluster_documentale CD
            //                                    on D.cluster_documentale = CD.id

            //                               where
            //                                   D.id_fascicolo = '" + Dossier + @"'

            //                               group by 
            //                                   D.cluster_documentale

            //                               order by
            //                                   D.cluster_documentale

            //                               ;
            //                            ";
            //}
            //else
            //{
            //    Query = @"
            //                               select
            //                                    *
            //                               from
            //                                    documento 

            //                               where
            //                                   id_fascicolo = '" + Dossier + @"' and
            //                                   cluster_documentale = " + Cluster + @"

            //                               order by
            //                                   NomeDocumento

            //                               ;
            //                            ";
            //}






            //MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            //adr.SelectCommand.CommandType = CommandType.Text;
            ////DataTable dt = new DataTable();



            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            //DataSet DS = new DataSet();
            //adr.Fill(DS);
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("Dossier", Dossier);
            Params.Add("Clustered", Clustered.ToString());
            DataSet DS = new DataSet();
            Params.Add("Cluster", Cluster);

            if (Page > 0 && Rows > 0)
            {
                Params.Add("Page", Page.ToString());
                Params.Add("Rows", Rows.ToString());
            }
            else
            {
                Params.Add("Page", null);
                Params.Add("Rows", null);
            }

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDocuments", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            //string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/GetDocuments.txt");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDocuments mDocuments = JsonConvert.DeserializeObject<__mDocuments>(JsonResponse);

                //DataSet DS = null;
                //if (!mDocuments.GetDataSet(ref DS)) ErrorTextBox.Text = " mDocuments.GetDataSet - GetDocuments Failed!";
                //else
                //{

                //    UpdateDocuments(DS, Clustered, Cluster, Rows);
                //}

                mDocuments.GetDataSet(ref DS);

            }
            DS.DataSetName = Dossier;
            //if (Cluster == null) Result = PartialView("~/Views/DettaglioFasciocolo.cshtml", DS);
            //else Result = PartialView("~/Views/VisualizeDocuments.cshtml", DS);

            if (Cluster == null) Result = PartialView("~/Views/VisualizeDossier.cshtml", DS);
            else Result = PartialView("~/Views/VisualizeDocuments.cshtml", DS);

            //Result = View("~/Views/Home/DettaglioFasciocolo");
            return Result;
        }

        public ActionResult GetDocuments(string Dossier, bool Clustered, string Cluster, int Page = 0, int Rows = 0)
        {

            //Get_Connection();


            //string sqlCmd = "select * from anagrafica";
            //string Query = "";
            //if (string.IsNullOrEmpty(Cluster))
            //{
            //    Query = @"
            //                               select
            //                                    CD.id, 
            //                                    CD.Label,
            //                                    CD.descrizione,
            //                                    count(cluster_documentale) as Total

            //                               from
            //                                    documento D inner join cluster_documentale CD
            //                                    on D.cluster_documentale = CD.id

            //                               where
            //                                   D.id_fascicolo = '" + Dossier + @"'

            //                               group by 
            //                                   D.cluster_documentale

            //                               order by
            //                                   D.cluster_documentale

            //                               ;
            //                            ";
            //}
            //else
            //{
            //    Query = @"
            //                               select
            //                                    *
            //                               from
            //                                    documento 

            //                               where
            //                                   id_fascicolo = '" + Dossier + @"' and
            //                                   cluster_documentale = " + Cluster + @"

            //                               order by
            //                                   NomeDocumento

            //                               ;
            //                            ";
            //}






            //MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            //adr.SelectCommand.CommandType = CommandType.Text;
            //DataTable dt = new DataTable();



            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            DataSet DS = new DataSet();
            //adr.Fill(DS);
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("Dossier", Dossier);
            Params.Add("Clustered", Clustered.ToString());

            Params.Add("Cluster", Cluster);

            if (Page > 0 && Rows > 0)
            {
                Params.Add("Page", Page.ToString());
                Params.Add("Rows", Rows.ToString());
            }
            else
            {
                Params.Add("Page", null);
                Params.Add("Rows", null);
            }

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            //string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDocuments", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/GetDocuments.txt");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mDocuments mDocuments = JsonConvert.DeserializeObject<__mDocuments>(JsonResponse);

                //DataSet DS = null;
                //if (!mDocuments.GetDataSet(ref DS)) ErrorTextBox.Text = " mDocuments.GetDataSet - GetDocuments Failed!";
                //else
                //{

                //    UpdateDocuments(DS, Clustered, Cluster, Rows);
                //}

                mDocuments.GetDataSet(ref DS);

            }
            DS.DataSetName = Dossier;
            if (Cluster == null) Result = PartialView("~/Views/VisualizeDossier.cshtml", DS);
            else Result = PartialView("~/Views/VisualizeDocuments.cshtml", DS);


            return Result;
        }
        public ActionResult GetPreview(string Filename, string AlfrescoNode)
        {
            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];

            __mDocumentFile mDocumentFile = new __mDocumentFile();
            mDocumentFile.FileName = Filename;
            mDocumentFile.AlfrescoNode = AlfrescoNode;

            mLoggedUser.JsonPostParams = JsonConvert.SerializeObject(mDocumentFile);

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDocumentFile", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                mDocumentFile = JsonConvert.DeserializeObject<__mDocumentFile>(JsonResponse);

                //System.IO.File.WriteAllBytes(@"C:\Users\DELL\Desktop\InPlaceVersion3\InPlaceVersion3\Downloads\" + mDocumentFile.FileName, mDocumentFile.File);
//                System.IO.File.WriteAllBytes(Server.MapPath(@"\Downloads\" + mDocumentFile.FileName), mDocumentFile.File);

                Result = PartialView("~/Views/PdfPreview.cshtml", mDocumentFile);
            }

            return Result;
        }
        public ActionResult GetAssets(string Dossier)
        {

            //Get_Connection();
            //string Query = @"
            //                        select 
            //                         *
            //                        from 
            //                         fascicolo F inner join Asset A 
            //                            on F.id_asset = A.id

            //                        limit 1
            //                        ;	                                                 
            //                    ";

            //MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            //adr.SelectCommand.CommandType = CommandType.Text;
            ////DataTable dt = new DataTable();



            //ActionResult Result = null;
            //mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            //DataSet DS = new DataSet();
            //adr.Fill(DS);



            //    if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            //    {
            //        var dataTable = JsonConvert.DeserializeObject<DataTable>(DS.Tables[0].Rows[0]["DatiSupplementari"].ToString());
            //        DS.Tables.Clear();
            //        DS.Tables.Add(dataTable);
            //    }





            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("Dossier", Dossier);

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetAssets", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mAssets mAssets = JsonConvert.DeserializeObject<__mAssets>(JsonResponse);
                DataSet DS = null;
                mAssets.GetDataSet(ref DS);

                Result = PartialView("~/Views/Assets.cshtml", DS);
            }
            //Result = PartialView("~/Views/Assets.cshtml", DS);
            return Result;
        }

        ////private void Get_Connection()
        //{
        //    connection_open = false;

        //    connection = new MySqlConnection();
        //    //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        //    //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
        //    if (Open_Local_Connection())
        //    {
        //        connection_open = true;
        //    }
        //    else
        //    {
        //        //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
        //        //					 Application::Exit();
        //    }

        //    //MySqlCommand cmd = new MySqlCommand();
        //    //cmd.Connection = connection;
        //    //cmd.CommandText = string.Format("select * from anagrafica");

        //    //MySqlDataReader reader = cmd.ExecuteReader();


        //    //const string DB_CONN_STR = "Server=127.0.0.1;Uid=foo_dbo;Pwd=pass;Database=foo_db;";

        //    //MySqlConnection cn = new MySqlConnection(DB_CONN_STR);

        //}

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpGet]
        public string CreateDDLPortafoglio()
        {
            string dd = "<label class='text-black font-w500' >Portafoglio</label><select id='inputState' class='form-control default-select'><option selected> Choose...</ option >";
            //Get_Connection();
            string Query = "select id,descrizione from portafoglio";
            MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            DataTable dt = new DataTable();

            adr.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dd += "<option value='" + dr["id"].ToString() + "' > " + dr["descrizione"].ToString() + " </ option >";
            }
            dd += "</select>";

            return dd;
        }


        [HttpGet]
        public string GetddltopPortafoglio()
        {
            string dd = "";
            //Get_Connection();
            string Query = "select id,descrizione from portafoglio";
            MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            DataTable dt = new DataTable();

            adr.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dd += "<a class='dropdown-item' data-assigned-id='" + dr["id"].ToString() + "' href='#'>" + dr["descrizione"].ToString() + "</a>";
            }

            return dd;
        }

        [HttpGet]
        public string GetddltopCluster()
        {
            string dd = "";
            //Get_Connection();
            string Query = "select id,descrizione from cluster_documentale";
            MySqlDataAdapter adr = new MySqlDataAdapter(Query, connection);
            DataTable dt = new DataTable();

            adr.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dd += "<a class='dropdown-item' data-assigned-id='" + dr["id"].ToString() + "' href='#'>" + dr["descrizione"].ToString() + "</a>";
            }


            return dd;
        }

        public ActionResult SaveNotes(string Dossier, string Notes)
        {
            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");
            Params.Add("DossierId", Dossier);
            Params.Add("Note", Notes);

            __RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/AddDossierNote", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                Result = Content("OK");
            }
            return Result;
        }


        public ActionResult GetNotes(string Dossier)
        {
            ActionResult Result = null;
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];

            __mNotes mNotes = new __mNotes();
            mNotes.DossierId = Dossier;

            mLoggedUser.JsonPostParams = JsonConvert.SerializeObject(mNotes);

            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("Company", "Company_1");



            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetDossierNotes", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                mNotes = JsonConvert.DeserializeObject<__mNotes>(JsonResponse);

                DataSet DS = null;
                mNotes.GetDataSet(ref DS);

                Result = PartialView("~/Views/NotesList.cshtml", DS);
            }
            return Result;
        }
    }
}
