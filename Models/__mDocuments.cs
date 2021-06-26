using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace InPlace4.Models
{
    public class __mDocuments
    {
        public string JsonDataset;

        public bool GetDataSet(ref DataSet DS)
        {
            bool Result = false;
            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonDataset);
                StringReader sr = new StringReader(doc.InnerXml);
                DS = new DataSet();
                DS.ReadXml(sr, XmlReadMode.ReadSchema);
                Result = true;
            }
            catch
            {
                Result = false;
            }
            return Result;
        }

        public DataSet GetDataSet()
        {
            DataSet DS = new DataSet();
            try
            {
                XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonDataset);
                StringReader sr = new StringReader(doc.InnerXml);
                DS = new DataSet();
                DS.ReadXml(sr, XmlReadMode.ReadSchema);
                
            }
            catch
            {
                
            }
            return DS;
        }
    }
}