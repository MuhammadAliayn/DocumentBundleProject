using InPlace4.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InPlace4.Controllers
{
    public class LoginController : Controller
    {
        private __mLoggedUser mLoggedUser;
        __RestClient RestClient = new __RestClient("http://192.168.99.21:8099/");
        // GET: Login
        public ActionResult Login(__mLogin mLogin)
        {
            string JsonRequest = JsonConvert.SerializeObject(mLogin);
            //string JsonResponse = System.IO.File.ReadAllText("C:/Users/Pc/source/repos/InPlaceVersion3/InPlaceVersion3/Json/GetAllDossiers.txt");

            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/Login", JsonRequest).Replace("}{", ",");
            //            string JsonResponse = string.Format(@"
            //  ""State"": false,
            //  ""Message"": ""OK"",
            //  ""ClientHost"": ""localhost:44380"",
            //  ""PK_UserEmail"": ""Back_Admin"",
            //  ""SessionId"": ""1F1701C410834D269DD3BF570B53B1D3"",
            //  ""UserCompany"": ""Company_1"",
            //  ""Site"": ""BackInplace"",
            //  ""Role"": ""ADMIN"",
            //  ""JwtToken"": ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJCYWNrX0FkbWluIiwiZW1haWwiOiJCYWNrX0FkbWluIiwiZXhwIjoxNjE0OTY4MzA2LCJpc3MiOiJtZWRpYXRpY2FzcGEuaXQiLCJhdWQiOiJtZWRpYXRpY2FzcGEuaXQifQ.jfEJLIwsPE2ADJzVBawf-0ceVyYZw_--imqS7hmn1aw"",
            //  ""JwtStartSession"": ""05/03/2021 17:18:26"",
            //  ""JwtEndSession"": null,
            //  ""JwtExpiryTimeInMinutes"": ""120"",
            //  ""AlfrescoToken"": ""VElDS0VUXzJiMWZiMTg3ZmU1ZWUxNTc1YTIzOThmNTM1ZDUzMGI4Y2FlZTg5MGY="",
            //  ""JsonPostParams"": null
            //").Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);

            if (mError.State == true)
            {
                //gestione errore
                return View("Login");
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
//                Session["mLoggedUser"] = mLoggedUser;
                //ViewData["UserID"] = mLoggedUser.SessionId;
                //Session["UserID"] = mLoggedUser.Email;
                //Session["UserName"] = mLoggedUser.Name;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut(__mLogin mLogin)
        {
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];


            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);


            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/Logout", (mLoggedUser == null ? null : JsonRequest), JwtToken: (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
//                Response.Cache.SetCacheability(HttpCacheability.NoCache);
//                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
//                Response.Cache.SetNoStore();
//                Session.Abandon();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
//                Response.Cache.SetCacheability(HttpCacheability.NoCache);
//                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
//                Response.Cache.SetNoStore();
//                Session.Abandon();
                return RedirectToAction("Login", "Home");
            }
        }

        private void UpdateSessionsButton_Click(object sender, EventArgs e)
        {
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);


            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/UpdateSessions", (mLoggedUser == null ? null : JsonRequest), JwtToken: (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);

                //UpdateForm(mError, mLoggedUser);
            }
        }

    }
}
