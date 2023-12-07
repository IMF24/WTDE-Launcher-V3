// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       X M L       F U N C T I O N S
//
//    Various functions for dealing with XML files.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Various functions for dealing with XML files.
    /// </summary>
    internal class XMLFunctions {
        public static string AspyrGetString(string sIDKey, string fallback = "") {
            string returnString = "";
            XmlTextReader textReader = new XmlTextReader(V3LauncherConstants.AspyrConfigDir);
            while (textReader.Read()) {
                switch (textReader.NodeType) {
                    case XmlNodeType.Element:
                        if (textReader.GetAttribute("id") == sIDKey) {
                            returnString = textReader.ReadString();
                            break;
                        }
                        break;
                }
            }
            // Did we find the string we want?
            textReader.Close();
            if (returnString != "") return returnString;

            // If not, it wasn't found, so let's add it in.
            AspyrWriteString(sIDKey, fallback);
            return fallback;
        }

        public static void AspyrWriteString(string sIDKey, string value) {
            // Open the XML document and read its contents.
            XmlDocument xml = new XmlDocument();
            string xmlContent = File.ReadAllText(V3LauncherConstants.AspyrConfigDir);
            xml.LoadXml(xmlContent);

            // The root node is the "r" tag in AspyrConfig.
            XmlNode root = xml.DocumentElement;

            // Check if the given node already exists.
            if (root.HasChildNodes) {
                for (var i = 0; i < root.ChildNodes.Count; i++) {
                    var attribute = root.ChildNodes[i].Attributes["id"].Value;
                    if (attribute != null && attribute == sIDKey) {
                        root.ChildNodes[i].InnerText = value;
                        xml.Save(V3LauncherConstants.AspyrConfigDir);
                        return;
                    }
                }
            }

            // Otherwise, we want to make a new node.
            XmlElement elem = xml.CreateElement("s");
            elem.SetAttribute("id", sIDKey);
            elem.InnerText = value;

            root.AppendChild(elem);

            xml.Save(V3LauncherConstants.AspyrConfigDir);
        }
    }
}
