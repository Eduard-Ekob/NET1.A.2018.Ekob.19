using System;
using System.Xml.Linq;

namespace XMLProcesses
{
    /// <summary>
    /// This convert URL to XML document
    /// </summary>
    public static class XmlConverter
    {
        private static XDocument xDoc;
        private static XElement root = new XElement("urlAdresses");
        public static XDocument CreateXmlDocument()
        {
            xDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                root);
            return xDoc;
        }
        /// <summary>
        /// URL to XML Converter
        /// </summary>
        /// <param name="url">Source URL</param>
        /// <returns>XML document</returns>
        public static XDocument XmlConvert(URL url)
        {
            if (xDoc == null)
            {
                CreateXmlDocument();
            }

            XElement parametersXml = null;
            XElement uri = null;
            if (url.segments != null)
            {
                uri = new XElement("uri");
                for (int i = 0; i < url.segments.Length; i++)
                {
                    string segment = url.segments[i].Replace("/", string.Empty);
                    segment = segment.Replace(" ", string.Empty);
                    if (segment != string.Empty)
                    {
                        uri.Add(new XElement("segment",
                            segment));
                    }
                }
            }

            if (url.value != null)
            {
                parametersXml = new XElement("parameters", 
                    new XElement("parameter", 
                        new XAttribute("value", url.value), 
                        new XAttribute("key", url.key)));
            }

            XElement uriXml = new XElement("urlAdress",
                new XElement("host", 
                    new XAttribute("name", url.hostname)));
            if (uri != null)
            {
                uriXml.Add(uri);
            }

            if (url.key != null)
            {
                uriXml.Add(parametersXml);
            }    
            
            root.Add(uriXml);
            return xDoc;
        }
    }
}
