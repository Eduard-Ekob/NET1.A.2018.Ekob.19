using System;
using System.Text;
using NLog;

namespace XMLProcesses
{
    /// <summary>
    /// This provide URI
    /// </summary>
    public static class UriProvider
    {
        private static char[] divideSymb = { '?', '=', '&' };
        /// <summary>
        /// This provide URI from format <scheme>://<host>/<URL-path>?<parameters>
        /// </summary>
        /// <param name="urlSourceFormat">source string</param>
        /// <returns>URI</returns>
        public static URL CreateUriFromString(string urlSourceFormat)
        {
            StringBuilder sb = new StringBuilder(urlSourceFormat);
            sb.Replace("<", string.Empty);
            sb.Replace(">", string.Empty);
            Uri createdUri;
            try
            {
                createdUri = new Uri(sb.ToString());
            }
            catch
            {
                string errorMessage = "String format is not valid";
                Logging logger = new Logging();
                logger.Log(errorMessage);
                throw new ArgumentException(errorMessage);
            }

            if (!UrlValidation(createdUri))
            {
                string errorMessage = "Url format is not valid";
                Logging logger = new Logging();
                logger.Log(errorMessage);
                throw new ArgumentException(errorMessage);
            }

            URL url = new URL();
            url.hostname = createdUri.Host;
            url.segments = createdUri.Segments;          
            if (createdUri.Query != null)
            {
                StringBuilder qrSb = new StringBuilder(createdUri.Query);
                qrSb.Replace("/", "?");
                string[] query = qrSb.ToString().Split(divideSymb);
                for (int i = 0; i < query.Length - 1; i++)
                {
                    url.key = query[i];
                    url.value = query[i + 1];
                }
            }

            return url;
        }

        private static bool UrlValidation(Uri url)
        {
            if ((url.Scheme != Uri.UriSchemeHttp) && (url.Scheme != Uri.UriSchemeHttps))
            {
                string errorMessage = "Wrong URL Scheme";
                Logging logger = new Logging();
                logger.Log(errorMessage);
                throw new ArgumentException(errorMessage);
                return false;
            }

            if (url.Fragment != string.Empty)
            {
                string errorMessage = "URL format must not present";
                Logging logger = new Logging();
                logger.Log(errorMessage);
                throw new ArgumentException(errorMessage);
                return false;
            }

            return true;
        }
    }
}