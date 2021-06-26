using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace InPlace4.Models
{
    class __mMenu
    {
        List<InPlace4.Models.MenuItem> menuItems = new List<InPlace4.Models.MenuItem>();

        public String JsonMenu;

        public event __OnMenu OnMenu;

        public delegate void __OnMenu(string MenuName);

        public event __OnSubMenu OnSubMenu;

        public delegate void __OnSubMenu(string SubMenuIndex, JsonElement SubMenuElement);

        public event __OnOption OnOption;

        public delegate void __OnOption(string OptionIndex, JsonElement OptionElement);

        public bool Parse()
        {
            bool Result = false;
            try
            {
                JsonDocument doc = JsonDocument.Parse(JsonMenu);
                JsonElement root = doc.RootElement;
                JsonElement.ObjectEnumerator Enum = doc.RootElement.EnumerateObject();

                Enum.Reset();
                Enum.MoveNext();

                Result = __Navigate(Enum);
            }
            catch (Exception e)
            {
                Result = false;
            }

            return Result;
        }
        private bool __Navigate(JsonElement.ObjectEnumerator Enum)
        {
            bool Result = false;
            if (Enum.Current.Name.Equals("ObjectType"))
            {
                switch (Enum.Current.Value.ToString())
                {
                    case "Menu":
                        {
                            Enum.MoveNext();

                            if (OnMenu != null) OnMenu(Enum.Current.Name);

                            JsonElement.ObjectEnumerator NewEnum = Enum.Current.Value.EnumerateObject();
                            NewEnum.Reset();
                            NewEnum.MoveNext();
                            Result = __Navigate(NewEnum);

                            if (Result)
                            {
                                if (Enum.MoveNext()) Result = __Navigate(Enum);
                                else Result = true;
                            }
                        }
                        break;

                    case "SubMenu":
                        {
                            Enum.MoveNext();

                            if (OnSubMenu != null) OnSubMenu(Enum.Current.Name, Enum.Current.Value);

                            JsonElement.ObjectEnumerator NewEnum = Enum.Current.Value.EnumerateObject();
                            NewEnum.Reset();
                            NewEnum.MoveNext();
                            Result = __Navigate(NewEnum);

                            if (Result)
                            {
                                if (Enum.MoveNext()) Result = __Navigate(Enum);
                                else Result = true;
                            }
                        }
                        break;

                    case "Option":
                        {
                            Enum.MoveNext();

                            if (OnOption != null) OnOption(Enum.Current.Name, Enum.Current.Value);

                            if (Enum.MoveNext()) Result = __Navigate(Enum);
                            else Result = true;
                        }
                        break;

                    default: Result = false; break;
                }
            }
            return Result;
        }
        public List<MenuItem> ParseMenu()
        {
            List<MenuItem> Result = new List<MenuItem>();
            try
            {
                JsonDocument doc = JsonDocument.Parse(JsonMenu);
                JsonElement root = doc.RootElement;
                JsonElement.ObjectEnumerator Enum = doc.RootElement.EnumerateObject();

                Enum.Reset();
                Enum.MoveNext();

                Result = __NavigateMenu(Enum);
            }
            catch (Exception e)
            {
                Result.DefaultIfEmpty();
            }

            return Result;
        }
        private List<MenuItem> __NavigateMenu(JsonElement.ObjectEnumerator Enum)
        {
            
            string Result = "";
            if (Enum.Current.Name.Equals("ObjectType"))
            {
                switch (Enum.Current.Value.ToString())
                {
                    case "Menu":
                        {
                            Enum.MoveNext();

                            if (OnMenu != null) OnMenu(Enum.Current.Name);

                            JsonElement.ObjectEnumerator NewEnum = Enum.Current.Value.EnumerateObject();
                            NewEnum.Reset();
                            NewEnum.MoveNext();
                            menuItems = __NavigateMenu(NewEnum);

                            if (string.IsNullOrEmpty(Result))
                            {
                                if (Enum.MoveNext()) menuItems = __NavigateMenu(Enum);
                                else Result = "";
                            }
                        }
                        break;

                    case "SubMenu":
                        {
                            Enum.MoveNext();

                            if (OnSubMenu != null) OnSubMenu(Enum.Current.Name, Enum.Current.Value);

                            JsonElement.ObjectEnumerator NewEnum = Enum.Current.Value.EnumerateObject();
                            NewEnum.Reset();
                            NewEnum.MoveNext();
                            menuItems = __NavigateMenu(NewEnum);

                            if (!string.IsNullOrEmpty(Result))
                            {
                                if (Enum.MoveNext()) menuItems = __NavigateMenu(Enum);
                                else Result = "";
                            }
                        }
                        break;

                    case "Option":
                        {
                            Enum.MoveNext();

                            if (OnOption != null) OnOption(Enum.Current.Name, Enum.Current.Value);

                            
                            var mlist = JsonConvert.DeserializeObject<SideMenu>(Enum.Current.Value.ToString());

                            menuItems.Add(new MenuItem { LinkName = mlist.OptionName, Icon = mlist.CssIcon });
                            
                            if (Enum.MoveNext()) menuItems = __NavigateMenu(Enum);
                            else Result = "";
                        }
                        break;

                    default: menuItems.DefaultIfEmpty(); break;
                }
            }
            return menuItems;
        }
        

    }


    public class SideMenu
    {
        public bool Active { get; set; }
        public string URL { get; set; }
        public string OptionName { get; set; }
        public string CssIcon { get; set; }
    }

}