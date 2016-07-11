using System;
using System.Collections.Specialized;
using System.Net;

namespace WebsiteMonitoring
{
    internal static class SiteMonitor
    {
        internal static void PingUrls(StringCollection urlsToPing)
        {
            foreach (string url in urlsToPing)
            {
                try
                {
                    var webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
                    webRequest.Method = WebRequestMethods.Http.Get;


                    using (var webResponse = webRequest.GetResponse() as HttpWebResponse)
                    {
                        if (webResponse.StatusCode != HttpStatusCode.OK)
                        {
                            throw new WebException(string.Format("The response returned error code {0}: {1}", webResponse.StatusCode, webResponse.StatusDescription));
                        }
                        else
                        {
                            Console.WriteLine("Site: " + url + " is Up");
                        }
                    }
                }
                catch (WebException webException)
                {
                    LogWebException(url, webException);
                }
            }
        }

        private static void LogWebException(string url, WebException webException)
        {
            //TODO: Log, Notify, etc. 
        }

    }
}
