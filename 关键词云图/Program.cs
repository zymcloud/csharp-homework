using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCloudSharp;

namespace WordCloudTestApp
{
	class Program
	{
        /// <summary>
        /// The main entry point for the application.
       /// </summary>
        [STAThread]
		static void Main()
		{
            for (int i = 2010; i <= 2020; i++)
            {
                for(int j = 1; j <= 12; j++)
                {
                    getmonth2(i,j);
                }
                    
            }
            /* for(int i = 2010; i <= 2020; i++)
              {
                  *//*for(int j = 0; j < 4; j++)
                  {
                      getseason2(i, 3*j+1, 3*j+3);
                  }*//*
                  getyear(i);
              }*/

            /* getseason(2014, 4, 6);
             getseason(2014, 7, 9);
             getseason(2014,10,12);*/
            /* getmonth(2013, 1);
             getmonth(2013, 2);*/
            Console.ReadLine();
            /*   getmonth(2010, 9);*/
            /* string str1="vsvbsiv - sonvsdb  dvs- vsobvs vcsdgycsdv";
             var a = str1.IndexOf("dvs- vsobvs", StringComparison.CurrentCultureIgnoreCase);
             Console.WriteLine(a);
             Console.ReadLine();*/
        }
        static void getyear(int year)
        {
            String path1 = "D:\\vs源代码\\data\\" + year + "\\" + 1;
            String path2 = "D:\\vs源代码\\data\\" + year + "\\" + 2;
            String path3 = "D:\\vs源代码\\data\\" + year + "\\" + 3;
            String path4 = "D:\\vs源代码\\data\\" + year + "\\" + 4;
            String path5 = "D:\\vs源代码\\data\\" + year + "\\" + 5;
            String path6 = "D:\\vs源代码\\data\\" + year + "\\" + 6;
            String path7 = "D:\\vs源代码\\data\\" + year + "\\" + 7;
            String path8 = "D:\\vs源代码\\data\\" + year + "\\" + 8;
            String path9 = "D:\\vs源代码\\data\\" + year + "\\" + 9;
            String path10 = "D:\\vs源代码\\data\\" + year + "\\" + 10;
            String path11 = "D:\\vs源代码\\data\\" + year + "\\" + 11;
            String path12 = "D:\\vs源代码\\data\\" + year + "\\" + 12;
           
            DirectoryInfo root1 = new DirectoryInfo(path1);
            DirectoryInfo root2 = new DirectoryInfo(path2);
            DirectoryInfo root3 = new DirectoryInfo(path3);
            DirectoryInfo root4 = new DirectoryInfo(path4);
            DirectoryInfo root5 = new DirectoryInfo(path5);
            DirectoryInfo root6 = new DirectoryInfo(path6);
            DirectoryInfo root7 = new DirectoryInfo(path7);
            DirectoryInfo root8 = new DirectoryInfo(path8);
            DirectoryInfo root9 = new DirectoryInfo(path9);
            DirectoryInfo root10 = new DirectoryInfo(path10);
            DirectoryInfo root11 = new DirectoryInfo(path11);
            DirectoryInfo root12 = new DirectoryInfo(path12);
            FileInfo[] files1 = root1.GetFiles();
            FileInfo[] files2 = root2.GetFiles();
            FileInfo[] files3 = root3.GetFiles();
            FileInfo[] files4 = root4.GetFiles();
            FileInfo[] files5 = root5.GetFiles();
            FileInfo[] files6 = root6.GetFiles();
            FileInfo[] files7 = root7.GetFiles();
            FileInfo[] files8 = root8.GetFiles();
            FileInfo[] files9 = root9.GetFiles();
            FileInfo[] files10 = root10.GetFiles();
            FileInfo[] files11 = root11.GetFiles();
            FileInfo[] files12= root12.GetFiles();
            String text = "";
            foreach (FileInfo file in files1)
            {
                Message message = new Message(file.FullName);  
            }
            foreach (FileInfo file in files2)
            {
                Message message = new Message(file.FullName);                   
            }
            foreach (FileInfo file in files3)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files4)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files5)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files6)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files7)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files8)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files9)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files10)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files11)
            {
                Message message = new Message(file.FullName);
            }
            foreach (FileInfo file in files12)
            {
                Message message = new Message(file.FullName);
            }
            Dictionary<String, int> dictionary2 = Message.dictonary2.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            List<string> words = new List<string>();
            List<int> value = new List<int>();
            int j = 0;
            foreach (var x in dictionary2)
            {
                words.Add(x.Key);
                value.Add(x.Value * 10);
                Console.WriteLine(x.Key + ":" + x.Value * 10 + "-" + Message.dictonary[x.Key]);
                j++;
                if (j == 100)
                {
                    break;
                }
            }
            Message.dictonary = new Dictionary<string, string>();
            Message.dictonary2 = new Dictionary<string, int>();
            String path13 = "D:\\vs源代码\\data\\image\\" + year;
            MyWorldCloud myWorldCloud = new MyWorldCloud();
            bool a = myWorldCloud.drawwordcloud(words, value, path13, year+ ".jpeg");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(year + ":" + " " + a);
            Console.WriteLine("------------------------------------------------------");
        }
        static void getseason(int year, int month1,int month2)
        {
            String path1 = "D:\\vs源代码\\data\\" + year + "\\" + month1;
            String path2 = "D:\\vs源代码\\data\\" + year + "\\" + (month1+1);
            String path3 = "D:\\vs源代码\\data\\" + year + "\\" + (month1+2);
            DirectoryInfo root1 = new DirectoryInfo(path1);
            DirectoryInfo root2 = new DirectoryInfo(path2);
            DirectoryInfo root3 = new DirectoryInfo(path3);
            FileInfo[] files1 = root1.GetFiles();
            FileInfo[] files2 = root2.GetFiles();
            FileInfo[] files3 = root3.GetFiles();
            String text = "";
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions pOptions = new ParallelOptions() { CancellationToken = cts.Token };
            pOptions.MaxDegreeOfParallelism = 40;//设置并发线程数量
            foreach (FileInfo file in files1)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            foreach (FileInfo file in files2)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            foreach (FileInfo file in files3)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            HashSet<string> set = new HashSet<string>();
            foreach (var node in Message.dictonary2)
            {
                if (node.Value > 3)
                {
                    set.Add(node.Key);
                    Console.WriteLine(node);
                }
            }
            Console.WriteLine(set.Count);
            Parallel.ForEach(set, i =>
            {
                int num = GetAppearTimes(text, i);
                dictionary.Add(i, num + Message.dictonary2[i] * 5);
                Console.WriteLine(i + ":" + num + Message.dictonary2[i] * 5 + "-" + Message.dictonary[i] + "-" + Message.dictonary2[i]);
                /*Console.WriteLine(i.Key + ":" + num);*/
            });
            /*foreach (var x in Message.dictonary)
            {
                int num = GetAppearTimes(text, x.Key);

                dictionary.Add(x.Key, num + 1);
                Console.WriteLine(x.Key + ":" + num);
            }*/

            dictionary = dictionary.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            List<string> words = new List<string>();
            List<int> value = new List<int>();
            Console.WriteLine("-------------------------------");
            int di_num = 0;
            foreach (var x in dictionary)
            {
                words.Add(x.Key);
                value.Add(x.Value);
                Console.WriteLine(x.Key + ":" + x.Value + "-" + Message.dictonary[x.Key] + "-" + Message.dictonary2[x.Key]);
                di_num++;
                if (di_num == 250)
                {
                    break;
                }
            }
            Message.dictonary = new Dictionary<string, string>();
            Message.dictonary2 = new Dictionary<string, int>();
            String path4 = "D:\\vs源代码\\data\\image\\" + year;
            MyWorldCloud myWorldCloud = new MyWorldCloud();
            bool a = myWorldCloud.drawwordcloud(words, value, path4, month1+"-"+month2 + ".jpeg");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(year + ":" + month1 + "-" + month2 + " " + a);
            Console.WriteLine("------------------------------------------------------");
            /*Console.ReadLine();*/
            /*for ()
                Message message = new Message("D:\\vs源代码\\data\\2010\\18499685.txt");
            message.print();
            Console.ReadLine();*/
        }
        static void getseason2(int year, int month1,int month2)
        {
            String path1 = "D:\\vs源代码\\data\\" + year + "\\" + month1;
            String path2 = "D:\\vs源代码\\data\\" + year + "\\" + (month1 + 1);
            String path3 = "D:\\vs源代码\\data\\" + year + "\\" + (month1 + 2);
            DirectoryInfo root1 = new DirectoryInfo(path1);
            DirectoryInfo root2 = new DirectoryInfo(path2);
            DirectoryInfo root3 = new DirectoryInfo(path3);
            FileInfo[] files1 = root1.GetFiles();
            FileInfo[] files2 = root2.GetFiles();
            FileInfo[] files3 = root3.GetFiles();
            String text = "";
            foreach (FileInfo file in files1)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            foreach (FileInfo file in files2)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            foreach (FileInfo file in files3)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            Dictionary<String, int> dictionary2 = Message.dictonary2.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            /* Parallel.ForEach(Message.dictonary,i=>
             {
                 int num = GetAppearTimes(text, i.Key);
                 dictionary.Add(i.Key, num + 1);
                 Console.WriteLine(i.Key + ":" + num);
             });*/
            /* foreach (var x in Message.dictonary)
             {
                 int num = GetAppearTimes(text, x.Key);

                 dictionary.Add(x.Key, num + 1);
                 Console.WriteLine(x.Key + ":" + num);
             }*/
            List<string> words = new List<string>();
            List<int> value = new List<int>();
            int j = 0;
            foreach (var x in dictionary2)
            {
                words.Add(x.Key);
                value.Add(x.Value * 10);
                Console.WriteLine(x.Key + ":" + x.Value*10 + "-" + Message.dictonary[x.Key]);
                j++;
                if (j == 100)
                {
                    break;
                }
            }
            Message.dictonary = new Dictionary<string, string>();
            Message.dictonary2 = new Dictionary<string, int>();
            String path4 = "D:\\vs源代码\\data\\image\\" + year;
            MyWorldCloud myWorldCloud = new MyWorldCloud();
            bool a = myWorldCloud.drawwordcloud(words, value, path4, month1+"-"+month2 + ".jpeg");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(year + ":" + month1 + "-" + month2 + " " + a);
            Console.WriteLine("------------------------------------------------------");
            /*Console.ReadLine();*/
            /*for ()
                Message message = new Message("D:\\vs源代码\\data\\2010\\18499685.txt");
            message.print();
            Console.ReadLine();*/
        }
        static void getmonth(int year,int month)
        {
            
            String path = "D:\\vs源代码\\data\\" + year + "\\" + month;
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            String text = "";
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions pOptions = new ParallelOptions() { CancellationToken = cts.Token };
            pOptions.MaxDegreeOfParallelism = 40;//设置并发线程数量
            foreach (FileInfo file in files)
            {
                Message message = new Message(file.FullName);
                text += " " + message.content;
                /* Message.moveFiles("D:\\vs源代码\\data\\" + year + "\\" + message.id + ".txt",
                             "D:\\vs源代码\\data\\" + year + "\\" + message.time.month);*/
            }
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            HashSet<string> set = new HashSet<string>();
            foreach (var node in Message.dictonary2)
            {
                if (node.Value>1)
                {
                    set.Add(node.Key);
                    Console.WriteLine(node);
                }
            }
            Console.WriteLine(set.Count);
            Parallel.ForEach(set, i =>
             {
                 int num = GetAppearTimes(text, i);
                 dictionary.Add(i, num + Message.dictonary2[i] * 5);
                 /*Console.WriteLine(i.Key + ":" + num);*/
             });
            /*foreach (var x in Message.dictonary)
            {
                int num = GetAppearTimes(text, x.Key);

                dictionary.Add(x.Key, num + 1);
                Console.WriteLine(x.Key + ":" + num);
            }*/

            dictionary = dictionary.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            List<string> words = new List<string>();
            List<int> value = new List<int>();
            int di_num = 0;
            foreach (var x in dictionary)
            {
                words.Add(x.Key);
                value.Add(x.Value);
                Console.WriteLine(x.Key + ":" + x.Value + "-" + Message.dictonary[x.Key] + "-" + Message.dictonary2[x.Key]);
                di_num++;
                if (di_num == 250)
                {
                    break;
                }
            }
            Message.dictonary = new Dictionary<string, string>();
            Message.dictonary2 = new Dictionary<string, int>();
            String path2 = "D:\\vs源代码\\data\\image\\" + year;
            MyWorldCloud myWorldCloud = new MyWorldCloud();
            bool a=myWorldCloud.drawwordcloud(words, value, path2, month + ".jpeg");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(year+":"+month+" "+a);
            Console.WriteLine("------------------------------------------------------");
            /*Console.ReadLine();*/
            /*for ()
                Message message = new Message("D:\\vs源代码\\data\\2010\\18499685.txt");
            message.print();
            Console.ReadLine();*/
        }
        static void getmonth2(int year, int month)
        {
            String path = "D:\\vs源代码\\data\\" + year + "\\" + month;
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles();
            /* for(int i = 0; i < 100; i++)
             {
                 Message message = new Message(files[i].FullName);
                *//* message.print();*//*
             }*/
            String text = "";
            foreach (FileInfo file in files)
            {
                Message message = new Message(file.FullName);       
            }
            Dictionary<String, int> dictionary = new Dictionary<string, int>();   
            Dictionary<String, int> dictionary2 = Message.dictonary2.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            List<string> words = new List<string>();
            List<int> value = new List<int>();
            int j = 0;
            foreach (var x in dictionary2)
            {
                words.Add(x.Key);
                value.Add(x.Value * x.Value);
                Console.WriteLine(x.Key + ":" + x.Value * x.Value + "-" + Message.dictonary[x.Key]);
                j++;
                if (j == 100)
                {
                    break;
                }   
            }
            Message.dictonary = new Dictionary<string, string>();
            Message.dictonary2 = new Dictionary<string, int>();
            String path2 = "D:\\vs源代码\\data\\image\\" + year;
            MyWorldCloud myWorldCloud = new MyWorldCloud();
            bool a = myWorldCloud.drawwordcloud(words, value, path2, month + ".jpeg");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(year + ":" + month + " " + a);
            Console.WriteLine("------------------------------------------------------");
        }
        static int GetAppearTimes(string str1, string str2)
        {
            int i = 0;
           /* CompareInfo Compare = CultureInfo.InvariantCulture.CompareInfo;*/
            while (str1.IndexOf(str2, StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                str1 = str1.Substring(str1.IndexOf(str2, StringComparison.CurrentCultureIgnoreCase) + str2.Length);
                i++;
            }
            /*while (str1.IndexOf(str2, CompareOptions.IgnoreCase) >= 0)
            {
                str1 = str1.Substring(str1.IndexOf(str2) + str2.Length);
                i++;
            }*/
            return i;
        }
       
    }
}
