﻿// ----------------------------------------------------------------------------
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
using System.IO;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  Various functions for dealing with XML files.
    /// </summary>
    internal class XMLFunctions {
        /// <summary>
        ///  Read an `s id=` string from AspyrConfig and return its value. Employs fallback measures if the
        ///  string is not found.
        /// </summary>
        /// <param name="sIDKey"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static string AspyrGetString(string sIDKey, string fallback = "") {
            // This variable is what string we're going to return.
            // This is mainly used for if the tag actually exists.
            string returnString = "";

            // We now want to read through this file and see if the
            // given tag exists. If it does, we'll give it back.
            XmlTextReader textReader = new XmlTextReader(V3LauncherConstants.AspyrConfigDir);
            while (textReader.Read()) {
                // What type of node is this?
                switch (textReader.NodeType) {
                    // Element nodes are what we want to look inside of.
                    case XmlNodeType.Element:
                        // Read the attribute and figure out if the "id" attribute has the given key.
                        // If it is the key we specified, read the string, and ready it for return.
                        if (textReader.GetAttribute("id") == sIDKey) {
                            returnString = textReader.ReadString();
                            break;
                        }
                        break;
                }
            }
            // Did we find the string we want?
            // If we did, give it back. Also close the file too!
            textReader.Close();
            if (returnString != "") return returnString;

            // If we didn't find the tag we wanted, let's add it in.
            // Also assign that tag to our fallback value.
            switch (sIDKey) {
                case "Keyboard_Guitar":
                    fallback = V3LauncherConstants.ASPYR_INPUT_GUITAR_DEFAULT;
                    break;

                case "Keyboard_Drum":
                    fallback = V3LauncherConstants.ASPYR_INPUT_DRUMS_BACKUP;
                    break;

                case "Keyboard_Mic":
                    fallback = V3LauncherConstants.ASPYR_INPUT_MIC_BACKUP;
                    break;

                case "Keyboard_Menu":
                    fallback = V3LauncherConstants.ASPYR_INPUT_MENU_BACKUP;
                    break;
            }
            AspyrWriteString(sIDKey, fallback);
            return fallback;
        }

        /// <summary>
        ///  Write a value to the given `s id=` tag in AspyrConfig. The tag is created if it doesn't exist.
        /// </summary>
        /// <param name="sIDKey"></param>
        /// <param name="value"></param>
        public static void AspyrWriteString(string sIDKey, string value) {
            // Open the XML document and read its contents.
            // We're literally treating the XML file as a text document for
            // importing the XML into xml.LoadXml().
            XmlDocument xml = new XmlDocument();
            string xmlContent = File.ReadAllText(V3LauncherConstants.AspyrConfigDir);
            xml.LoadXml(xmlContent);

            // The root node is the "r" tag in AspyrConfig.
            XmlNode root = xml.DocumentElement;

            // Check if the given node already exists.
            if (root.HasChildNodes) {
                // Iterate through the child nodes, and we want to read each of their attributes.
                for (var i = 0; i < root.ChildNodes.Count; i++) {
                    // What value is assigned to the "id" attribute in this tag/node?
                    // It could be null, so it cannot be null in order for us to
                    // write something.
                    var attribute = root.ChildNodes[i].Attributes["id"].Value;
                    // We found the tag we want, let's write it into our file.
                    if (attribute != null && attribute == sIDKey) {
                        // The InnerText property is what we want to write.
                        // Write it, then exit out of execution.
                        Console.WriteLine($"Found value {sIDKey}, setting to value {value}");
                        root.ChildNodes[i].InnerText = value;
                        xml.Save(V3LauncherConstants.AspyrConfigDir);
                        return;
                    }
                }
            }

            // If the given "s id=" tag did not exist, let's create it.
            XmlElement elem = xml.CreateElement("s");
            elem.SetAttribute("id", sIDKey);
            elem.InnerText = value;

            // Append in the tag and save it to the disk.
            root.AppendChild(elem);
            xml.Save(V3LauncherConstants.AspyrConfigDir);
        }
    }
}
