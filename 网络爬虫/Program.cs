using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace 网络爬虫
{
    class Program
    {
       static String[] urls = { "Carcinomas%2C+Hepatocellular",
                          "Hepatocellular+Carcinomas" ,
                          "Liver+Cell+Carcinoma%2C+Adult",
                          "Liver+Cancer%2C+Adult",
                          "Adult+Liver+Cancer",
                           "Cancer%2C+Adult+Liver",
                           "Liver+Cancers%2C+Adult",
                           "Liver+Cell+Carcinoma",
                           "Carcinomas%2C+Liver+Cell",
                           "Cell+Carcinoma%2C+Liver",
                           "Liver+Cell+Carcinomas",
                           "Hepatocellular+Carcinoma",
                           "Hepatoma"
                         };
        static HashSet<String> set = new HashSet<string>();
        private static object lockObj = new object();
        private static object lockObj2 = new object();
        private static int[] num = new int[5];
        private static void initial()
        {
            String path = @"D:\vs源代码\网络爬虫\网络爬虫\bin\Debug\netcoreapp3.1\data";
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (string file in files)
            {
                string filename= System.IO.Path.GetFileNameWithoutExtension(file);
                Console.WriteLine(filename);
                set.Add(filename);
            }
        }
        static void insert(int id,String url)
        {
            Console.WriteLine(url);
            Stream stream = Download.DownloadFile(url);
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                String str = reader.ReadToEnd();
                /*string regex = "href=[\\\"\\\'](http:\\/\\/|\\.\\/|\\/)?\\w+(\\.\\w+)*(\\/\\w+(\\.\\w+)?)*(\\/|\\?\\w*=\\w*(&\\w*=\\w*)*)?[\\\"\\\']";*/
             /*   string regex2 = "href=[\\\"\\\']\\/\\d+\\/[\\\"\\\']";*/
                string regex3 = "<span class=\\\"value\\\">[0-9,]+<\\/span>";
               /* Regex re = new Regex(regex2);
                MatchCollection matches = re.Matches(str);
                System.Collections.IEnumerator enu = matches.GetEnumerator();
                while (enu.MoveNext() && enu.Current != null)
                {
                    Match match = (Match)(enu.Current);
                    String value = match.Value;
                    Console.WriteLine(id+":"+value.Split("/")[1]);
                    lock (lockObj)
                    {
                        set.Add(value.Split("/")[1]);
                    }
                }*/
                Regex re2 = new Regex(regex3);
                MatchCollection matches2 = re2.Matches(str);
                System.Collections.IEnumerator enu2 = matches2.GetEnumerator();
                /* while (enu2.MoveNext() && enu2.Current != null)
                 {*/
                enu2.MoveNext();
                Match match2 = (Match)(enu2.Current);
                String value2 = match2.Value; 
                String[] strings = value2.Split(new char[] { '<', '>', ',' });
                num[id - 1] = int.Parse(strings[2] + strings[3]);
                Console.WriteLine(id + ":" + strings[2] + strings[3]);
                //}
            }
        }
        static HashSet<string>[] set2;
        private static void initial2()
        {
            set2 = new HashSet<string>[11];
            for(int i = 0; i < 11; i++)
            {
                set2[i] = new HashSet<string>();
            }
            for(int i = 0; i < 11; i++)
            {
                String path = @"D:\vs源代码\网络爬虫\网络爬虫\bin\Debug\netcoreapp3.1\"+(2010+i);
                string[] files = Directory.GetFiles(path, "*.txt");
                foreach (string file in files)
                {
                    string filename = System.IO.Path.GetFileNameWithoutExtension(file);
                    Console.WriteLine(filename);
                    set2[i].Add(filename);
                }
            }
        }
        class InnerObject
        {

            public int id;
            public int page;
            public String url;
            public InnerObject(int id, int page, String url)
            {
                this.id = id;
                this.page = page;
                this.url = url;
            }
        }
        static void insert2(/*InnerObject obj*/int id, int i, String url)
        { 
                int page = i;
                String currenturl = url + "&page=" + page;
                
                Stream stream=null;
                try
                {
                    stream = Download.DownloadFile(currenturl);
                } catch (Exception e)
                {
                    Console.WriteLine(id+" "+page+"申请网页失败");
                    return;
                }
                
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    String str = "";
                    try
                    {
                        str = reader.ReadToEnd();
                    }
                     catch (Exception e)
                    {
                        Console.WriteLine(id + ":" + page + ":"+ "超时");
                        Console.WriteLine(e.Message);
                         return;
                    }
                    string regex2 = "href=[\\\"\\\']\\/\\d+\\/[\\\"\\\']";
                    Regex re = new Regex(regex2);
                    MatchCollection matches = re.Matches(str);
                    System.Collections.IEnumerator enu = matches.GetEnumerator();
                    int x = 1;
                    while (enu.MoveNext() && enu.Current != null)
                    {
                        Match match = (Match)(enu.Current);
                        String value = match.Value.Split("/")[1];
                        lock (lockObj)
                        {
                            if (set.Contains(value))
                            {
                                Console.WriteLine(currenturl);
                                Console.WriteLine(id + ":" + page + ":" + (x++) + ":" + value+"已存在");
                                continue;
                            }
                            else
                            {
                                set.Add(value);
                                Console.WriteLine(currenturl);
                                Console.WriteLine(id + ":" + page + ":" + (x++) + ":" + value);  
                            }   
                        }
                        getMessage(value);
                    }
                }     
        }
        static void insert3(/*InnerObject obj*/int id, int i, String url,int year)
        {
            int page = i;
            String currenturl = url + year+"-"+year+"&page=" + page;
            Stream stream = null;
            try
            {
                stream = Download.DownloadFile(currenturl);
            }
            catch (Exception e)
            {
                Console.WriteLine(year + ":"+id + " " + page + " "+"申请网页失败");
                return;
            }
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                String str = "";
                try
                {
                    str = reader.ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine(year + ":"+id + ":" + page +":"+ "超时");
                    Console.WriteLine(e.Message);
                    return;
                }
                string regex2 = "href=[\\\"\\\']\\/\\d+\\/[\\\"\\\']";
                Regex re = new Regex(regex2);
                MatchCollection matches = re.Matches(str);
                System.Collections.IEnumerator enu = matches.GetEnumerator();
                int x = 1;
                while (enu.MoveNext() && enu.Current != null)
                {
                    Match match = (Match)(enu.Current);
                    String value = match.Value.Split("/")[1];
                    lock (lockObj)
                    {
                        if (set2[year-2010].Contains(value))
                        {
                            Console.WriteLine(currenturl);
                            Console.WriteLine(year + ":" + id + ":" + page + ":" + (x++) + ":" + value + "已存在");
                            continue;
                        }
                        else
                        {
                            set2[year - 2010].Add(value);
                            Console.WriteLine(currenturl);
                            Console.WriteLine(year + ":" + id + ":" + page + ":" + (x++) + ":" + value);
                        }
                    }
                    getMessage(value,year);
                }
            }
        }
        static void getMessage(String value)
        {
            String url = "https://pubmed.ncbi.nlm.nih.gov/" + value + "/";
            Stream stream = null;
            try
            {
                stream = Download.DownloadFile(url);
            }
            catch (Exception e)
            {
                Console.WriteLine("编号:"+value + "申请网页失败");
                return;
            }
            string date = "", content = "",key="";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                String str = "";
                try
                {
                    str = reader.ReadToEnd();
                }catch(Exception e)
                {
                    Console.WriteLine("编号:" + value + "超时");
                    Console.WriteLine(e.Message);
                    return;
                }
                string regex3 = "<span class=\\\"cit\\\">[^;]+";
                string regex = "<div class=\"abstract-content selected\"\\s+id=\"enc-abstract\">\\s+<p>\\s+[^~]+?</p>";
                string regex4 = "<div class=\"abstract-content selected\"\\s+id=\"enc-abstract\">\\s+<p>\\s+[^~]+?</div>";
                string regex2 = "<strong class=\"sub-title\">[^~]+?</p>";
                string regex5 = "<strong class=\"sub-title\">\\s+Keywords:\\s+</strong>[^~]+?</p>";
                Regex re3 = new Regex(regex3);
                MatchCollection matches3 = re3.Matches(str);
                System.Collections.IEnumerator enu3 = matches3.GetEnumerator();
                while (enu3.MoveNext() && enu3.Current != null)
                {
                    Match match = (Match)(enu3.Current);
                    String result = match.Value;
                    String[] strings = result.Split('>');
                    date = strings[1];
                    /*Console.WriteLine(strings[1]);*/
                }
                Regex re = new Regex(regex4);
                MatchCollection matches = re.Matches(str);
                System.Collections.IEnumerator enu = matches.GetEnumerator();             
                while (enu.MoveNext() && enu.Current != null)
                {
                    Match match = (Match)(enu.Current);
                    string resultvalue = match.Value;
                    String result = ContentReplace(resultvalue);
                    content = result;
                    /*Console.WriteLine(resultvalue);
                    Console.WriteLine("------------------"); 
                    Console.WriteLine(content);
                    Console.WriteLine("------------------");*/
                   
                }
                Regex re2 = new Regex(regex5);
                MatchCollection matches2 = re2.Matches(str);
                System.Collections.IEnumerator enu2 = matches2.GetEnumerator();
                while (enu2.MoveNext() && enu2.Current != null)
                {
                    Match match = (Match)(enu2.Current);
                    string resultvalue = match.Value;
                    /* string[] results = Regex.Split(resultvalue, "</strong>", RegexOptions.IgnoreCase);
                     string[] results2 = Regex.Split(results[1], "</p>", RegexOptions.IgnoreCase);
                     string result = results2[0].Trim();*/
                    String result = ContentReplace(resultvalue);
                    key = result.Split(':')[1];
                    /*Console.WriteLine(key);
                    Console.WriteLine("------------------");*/
                }

            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("data\\" + value + ".txt"))
            {
                file.WriteLine(value);
                file.WriteLine(date);
                file.WriteLine(content);
                file.WriteLine(key);
            }
            Console.WriteLine(value+".txt" + "存储成功");
        }

        static void getMessage(String value,int year)
        {
            String url = "https://pubmed.ncbi.nlm.nih.gov/" + value + "/";
            Stream stream = null;
            try
            {
                stream = Download.DownloadFile(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(year + ":" + "编号:" + value + "申请网页失败");
                return;
            }
            string date = "", content = "", key = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                String str = "";
                try
                {
                    str = reader.ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine(year + ":" + "编号:" + value + "超时");
                    Console.WriteLine(e.Message);
                    return;
                }
                string regex3 = "<span class=\\\"cit\\\">[^;]+";
                string regex = "<div class=\"abstract-content selected\"\\s+id=\"enc-abstract\">\\s+<p>\\s+[^~]+?</p>";
                string regex4 = "<div class=\"abstract-content selected\"\\s+id=\"enc-abstract\">\\s+<p>\\s+[^~]+?</div>";
                string regex2 = "<strong class=\"sub-title\">[^~]+?</p>";
                string regex5 = "<strong class=\"sub-title\">\\s+Keywords:\\s+</strong>[^~]+?</p>";
                Regex re3 = new Regex(regex3);
                MatchCollection matches3 = re3.Matches(str);
                System.Collections.IEnumerator enu3 = matches3.GetEnumerator();
                while (enu3.MoveNext() && enu3.Current != null)
                {
                    Match match = (Match)(enu3.Current);
                    String result = match.Value;
                    String[] strings = result.Split('>');
                    date = strings[1];
                    /*Console.WriteLine(strings[1]);*/
                }
                Regex re = new Regex(regex4);
                MatchCollection matches = re.Matches(str);
                System.Collections.IEnumerator enu = matches.GetEnumerator();
                while (enu.MoveNext() && enu.Current != null)
                {
                    Match match = (Match)(enu.Current);
                    string resultvalue = match.Value;
                    String result = ContentReplace(resultvalue);
                    content = result;
                    /*Console.WriteLine(resultvalue);
                    Console.WriteLine("------------------"); 
                    Console.WriteLine(content);
                    Console.WriteLine("------------------");*/

                }
                Regex re2 = new Regex(regex5);
                MatchCollection matches2 = re2.Matches(str);
                System.Collections.IEnumerator enu2 = matches2.GetEnumerator();
                while (enu2.MoveNext() && enu2.Current != null)
                {
                    Match match = (Match)(enu2.Current);
                    string resultvalue = match.Value;
                    /* string[] results = Regex.Split(resultvalue, "</strong>", RegexOptions.IgnoreCase);
                     string[] results2 = Regex.Split(results[1], "</p>", RegexOptions.IgnoreCase);
                     string result = results2[0].Trim();*/
                    String result = ContentReplace(resultvalue);
                    key = result.Split(':')[1];
                    /*Console.WriteLine(key);
                    Console.WriteLine("------------------");*/
                }

            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(year+"\\" + value + ".txt"))
            {
                file.WriteLine(value);
                file.WriteLine(date);
                file.WriteLine(content);
                file.WriteLine(key);
            }
            Console.WriteLine(year + ":" + value + ".txt" + "存储成功");
        }
        public static string ContentReplace(string input)
        {
            input = Regex.Replace(input, @"<([^>]*)>", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(quot);", "", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(amp);", "&", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(lt);", "<", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(gt);", ">", RegexOptions.IgnoreCase);
            input = Regex.Replace(input, @"&(nbsp);", " ", RegexOptions.IgnoreCase);
            //处理答案序号
            input = Regex.Replace(input, @"$、", "", RegexOptions.IgnoreCase);
            input.Replace("<", "");
            input.Replace(">", "");
            input.Replace("\r\n", "");
            //去两端空格，中间多余空格
            input = Regex.Replace(input.Trim(), "\\s+", " ");
            return input;
        }
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            //initial();
            initial2();
           /* Task[] tasks = new Task[5];

            for (int i = 0; i < urls.Length; i++)
            {
                int id = i + 1;
                String url = "https://pubmed.ncbi.nlm.nih.gov/?term=" + urls[i] + "&filter=years.2010-2021";
                tasks[i] = new Task(() => insert(id, url));
                tasks[i].Start();
            }
            Task.WaitAll(tasks);*/
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions pOptions = new ParallelOptions() { CancellationToken = cts.Token };
            pOptions.MaxDegreeOfParallelism = 40;//设置并发线程数量
                int i = 1;
                int id = i + 1;
                /*String url = "https://pubmed.ncbi.nlm.nih.gov/?term=" + urls[i] + "&filter=years.2010-2021";
                Parallel.For(0, 1000, pOptions, (item) =>
                {
                    insert2(id, item, url);
                });*/
                String url2 = "https://pubmed.ncbi.nlm.nih.gov/?term=" + urls[i] + "&filter=years.";
                Parallel.For(0, 1000, pOptions, (item) =>
                {
                    insert3(id, item, url2,2010);
                    insert3(id, item, url2,2011);
                    insert3(id, item, url2,2012);
                    insert3(id, item, url2,2013);
                    insert3(id, item, url2,2014);
                    insert3(id, item, url2,2015);
                    insert3(id, item, url2,2016);
                    insert3(id, item, url2,2017);
                    insert3(id, item, url2,2018);
                    insert3(id, item, url2,2019);
                    insert3(id, item, url2,2020);
                });
            /*for(int j = 0; j <1000; j++)
             {
                 insert2(id,j,url);
             }*/
            /*  for (int j = 0; j < num[i]; j++)
              {
                  int id = i + 1;
                  String url = "https://pubmed.ncbi.nlm.nih.gov/?term=" + urls[i] + "&filter=years.2010-2021";
                  int firstpage = j * length + 1;
                  int lastpage = (j + 1) * length;
                  if (lastpage == urls.Length)
                  {
                      lastpage = urls.Length - 1;
                  }

                  Parallel.Invoke();
                  ThreadPool.QueueUserWorkItem(o => insert2(id, firstpage, lastpage, url));
                  tasks2[j] = new Task(() => insert2(id, firstpage, lastpage, url));
                  tasks2[j].Start();
              }
              Task.WaitAll(tasks2);*/
            /* }  */
        }
        /* static void Main(String[] args)
         {
             getMessage("26457020");
         }*/
    }
}
