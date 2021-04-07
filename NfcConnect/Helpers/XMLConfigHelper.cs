using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NfcConnect.Helpers
{
    class XMLConfigHelper
    {
        #region memebers

        XmlDocument _ConfigurationFile = new XmlDocument();

        #endregion

        #region ctor
        public XMLConfigHelper(string xmlPath)
        {
            RefreshConfiguration(xmlPath);
        }
        
        #endregion

        #region methods

        public IEnumerable<XmlNode> GetConfigurationElements(string XmlNodePath, out XmlNode returnNode, XmlNode startNodePath = null)
        {
            if (startNodePath == null)
            {

                returnNode = _ConfigurationFile.DocumentElement;
            }
            else
            {
                returnNode = startNodePath.SelectSingleNode(XmlNodePath);
            }
            List<XmlNode> result = new List<XmlNode>();
            foreach (XmlNode nodeElement in returnNode.ChildNodes)
            {
                result.Add(nodeElement);
            }
            return result;
        }
        public IEnumerable<XmlNode> GetConfigurationElements(string XmlNodePath, out XmlNode returnNode, string startNodePath = null)
        {
            if (startNodePath == null)
            {
                returnNode = _ConfigurationFile.DocumentElement;
            }
            else 
            {
                returnNode = _ConfigurationFile.SelectSingleNode(startNodePath + "/" + XmlNodePath); 
            }
            List<XmlNode> result = new List<XmlNode>();
            foreach (XmlNode nodeElement in returnNode.ChildNodes)
            {
                result.Add(nodeElement);
            }
            return result;
        }
        public void RefreshConfiguration(string xmlPath)
        {
            _ConfigurationFile.Load(xmlPath);
        }

        #endregion
    }
}
