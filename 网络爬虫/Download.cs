using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace 网络爬虫
{
    class Download
    {
        public static Stream DownloadFile(String url)
        {
                HttpWebRequest Myrq = (HttpWebRequest)WebRequest.Create(url);
                Myrq.KeepAlive = false;
                Myrq.Timeout = 100 * 1000;
                Myrq.Method = "GET";
                Myrq.Host = url.Split('/')[2];
                Myrq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
                Myrq.Referer = "https://pubmed.ncbi.nlm.nih.gov/";
                Myrq.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Mobile Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)Myrq.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("爬取失败");
                    return null;
                }
            return response.GetResponseStream();
        }
        public static Boolean DownloadFile(String url, String filename,String Reference)
        {
            HttpWebRequest Myrq = (HttpWebRequest)WebRequest.Create(url);
            Myrq.KeepAlive = true;
            Myrq.Timeout = 30 * 1000;
            Myrq.Method = "GET";
            Myrq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            if (Reference.Equals(""))
            {
                Myrq.Referer = "https://pubmed.ncbi.nlm.nih.gov/";
            }
            else
            {
                Myrq.Referer = Reference;
            }
            Myrq.Host = url.Split('/')[2];
            Myrq.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Mobile Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)Myrq.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("爬取失败");
                return false;
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                response.GetResponseStream().CopyTo(fs);
            }
            return true;
        }
    }
}
