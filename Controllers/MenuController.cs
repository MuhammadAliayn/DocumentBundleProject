using InPlace4.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace InPlace4.Controllers
{
    public class MenuController : Controller
    {
        private __mLoggedUser mLoggedUser;
        __RestClient RestClient = new __RestClient("http://192.168.99.21:8099/");
        //public System.Web.UI.WebControls.MenuItem SubMenuItem { get; private set; }
        public object SubMenus { get; private set; }

        // GET: Menu
        public ActionResult SideMenu()
        {
            //mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            //List<InPlace4.Models.MenuItem> menuItems = new List<InPlace4.Models.MenuItem>();
            //string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            //Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("MenuName", "Main");

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            //string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetMenu", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            //__mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            //if (mError.State == true)
            //{
            //    //gestione errore
            //    //ClearMenu();
            //    //ErrorTextBox.Text = mError.Message;
            //}
            //else
            //{
            //    mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
            //    __mMenu mMenu = JsonConvert.DeserializeObject<__mMenu>(JsonResponse);

            //    //UpdateMenu(mMenu);
            //    //UpdateForm(mError, mLoggedUser);
            //}


            List<InPlace4.Models.MenuItem> menuItems = new List<InPlace4.Models.MenuItem>();
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            Params.Add("MenuName", "Main");

            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetMenu", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ClearMenu();
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                __mMenu mMenu = JsonConvert.DeserializeObject<__mMenu>(JsonResponse);
                var obj = JObject.Parse(mMenu.JsonMenu);

                foreach (var item in obj)
                {
                    foreach (var a in item.Value)
                    {
                        if (((Newtonsoft.Json.Linq.JProperty)a).Name == "OptionName")
                            menuItems.Add(new InPlace4.Models.MenuItem { LinkName = (string)((Newtonsoft.Json.Linq.JProperty)a).Value });
                    }
                }
            }
            return PartialView("SideMenu", menuItems);
            //return PartialView("SideMenu");
        }

        public ActionResult Menu()
        {
//            mLoggedUser = (__mLoggedUser)Session["mLoggedUser"];
            //List<InPlace4.Models.MenuItem> menuItems = new List<InPlace4.Models.MenuItem>();
            __mMenu mMenu = new __mMenu();
            string JsonRequest = JsonConvert.SerializeObject(mLoggedUser);
            Dictionary<string, string> Params = new Dictionary<string, string>();
            //Params.Add("MenuName", "Header");
            Params.Add("MenuName", "Main");
            //__RestClient RestClient = new __RestClient("https://192.168.99.21:8099/");
            string JsonResponse = RestClient.PostCallMicroService("/api_inplace/GetMenu", (mLoggedUser == null ? null : JsonRequest), Params, (mLoggedUser == null ? null : mLoggedUser.JwtToken)).Replace("}{", ",");
            __mError mError = JsonConvert.DeserializeObject<__mError>(JsonResponse);
            if (mError.State == true)
            {
                //gestione errore
                //ClearMenu();
                //ErrorTextBox.Text = mError.Message;
            }
            else
            {
                mLoggedUser = JsonConvert.DeserializeObject<__mLoggedUser>(JsonResponse);
                mMenu = JsonConvert.DeserializeObject<__mMenu>(JsonResponse);

                //CreateMenu(mMenu.JsonMenu);
                //UpdateForm(mError, mLoggedUser);
            }
            return PartialView("SideMenu", CreateMenu(mMenu.JsonMenu));
        }
        public List<InPlace4.Models.MenuItem> CreateMenu(String JsonMenu)
        {

            __mMenu mMenu = new __mMenu();

            mMenu.JsonMenu = JsonMenu;


            mMenu.OnMenu += OnMenu;
            mMenu.OnSubMenu += OnSubMenu;
            mMenu.OnOption += OnOption;

            return mMenu.ParseMenu();
        }

        //private MenuStrip Menu;

        //private Dictionary<string, ToolStripMenuItem> SubMenus;

        private void OnMenu(string MenuIndex)
        {
            //MessageBox.Show(MenuIndex, "Menu Name:", MessageBoxButtons.OK);

            //Menu = new MenuStrip();
            //SubMenus = new Dictionary<string, ToolStripMenuItem>();
        }

        private void OnSubMenu(string SubMenuIndex, JsonElement SubMenuElement)
        {
            //MessageBox.Show(SubMenuIndex, "SubMenu Index:", MessageBoxButtons.OK);

            string SubMenuName = SubMenuIndex.Substring(0, SubMenuIndex.LastIndexOf("."));

            JsonElement.ObjectEnumerator Enum = SubMenuElement.EnumerateObject();
            Enum.Reset();
            Enum.MoveNext();

            //if (Enum.Current.Value.Equals("True"))
            {
                Enum.MoveNext();
                Enum.MoveNext();

                //ToolStripMenuItem SubMenuItem = new ToolStripMenuItem();
                //SubMenuItem.Text = Enum.Current.Value.ToString();

                //if (SubMenuName.Length == 1) Menu.Items.Add(SubMenuItem);
                //else SubMenus[SubMenuName].DropDownItems.Add(SubMenuItem);

                //SubMenus.Add(SubMenuIndex, SubMenuItem);
            }
        }

        private void OnOption(string OptionIndex, JsonElement OptionElement)
        {
            //MessageBox.Show(OptionIndex, "Option Index:", MessageBoxButtons.OK);

            string SubMenuName = OptionIndex.Substring(0, OptionIndex.LastIndexOf("."));

            JsonElement.ObjectEnumerator Enum = OptionElement.EnumerateObject();
            Enum.Reset();
            Enum.MoveNext();

            //if (Enum.Current.Value.Equals("True"))
            {
                Enum.MoveNext();
                Enum.MoveNext();

                //ToolStripMenuItem SubMenuItem = new ToolStripMenuItem();
                //SubMenuItem.Text = Enum.Current.Value.ToString();

                //if (SubMenuName.Length == 1) Menu.Items.Add(SubMenuItem);
                //else SubMenus[SubMenuName].DropDownItems.Add(SubMenuItem);
            }
        }
    }
}
