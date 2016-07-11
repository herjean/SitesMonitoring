namespace WebsiteMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            SiteMonitor.PingUrls(Settings1.Default.SitesToMonitor);
        }
    }
}
