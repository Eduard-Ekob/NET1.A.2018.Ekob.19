using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XMLProcesses
{
    /// <summary>
    /// This parse source string which contains URI
    /// </summary>
    public static class UriToXmlParser
    {   
    /// <summary>
    /// This parse URI-string
    /// </summary>
    /// <param name="sr">Take streamreader text stream</param>
    /// <returns>XML documents</returns>
        public static XDocument Parse(StreamReader sr)
        {
            string uriSourceFormat;
            XDocument xDoc = new XDocument();
            while ((uriSourceFormat = sr.ReadLine()) != null)
            {              
                xDoc = XmlConverter.XmlConvert(UriProvider.CreateUriFromString(uriSourceFormat));
            }

            return xDoc;
        }
    }
}