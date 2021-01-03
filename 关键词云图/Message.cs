using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudTestApp
{
    class Message
    {
        /*static public HashSet<String> set=new HashSet<string>();*/
        static public Dictionary<String, String> dictonary = new Dictionary<string, string>();
        static public Dictionary<String, int> dictonary2 = new Dictionary<string, int>();
        public String id;
        public Time time;
        public String content;
        public List<String> keywords;
        void getKeywords(String s)
        {
            if (s == "")
            {
                return;
            }
            String[] strings = s.Split(new char[] { ';'});
            int num = strings.Length - 1;
            strings[num] = strings[num].Substring(0,strings[num].Length-1);
            keywords = new List<string>();
            foreach(String str in strings)
            {
                if (str == "")
                {
                    continue;
                }
                String word = str.Trim();
                word = word.ToLower();
                keywords.Add(word);
                if (dictonary.Keys.Contains(word))
                {
                    /*dictonary[word]++;*/
                    dictonary2[word]++;
                }
                else
                {
                    /*Console.WriteLine(id+word);*/
                    dictonary.Add(word,id);
                    dictonary2.Add(word,1);
                }
            }
        }
        void printkeywords()
        {
            Console.Write("关键词：");
            foreach(String s in keywords)
            {
                Console.Write(s+" ");
            }
            Console.WriteLine();
        }
        public Message(String path)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                id=file.ReadLine();
                time=new Time(id,file.ReadLine());
                content=file.ReadLine();
                if (content == "")
                {
                    /*set.Add(id);*/
                    Console.WriteLine(id+"内容为空");
                }
                getKeywords(file.ReadLine());
            }
        }
        public void print()
        {
            Console.WriteLine("id:"+id);
            Console.WriteLine("时间:"+time.year+"."+time.month);
            Console.WriteLine("内容:"+content);
            printkeywords();
        }
        public static void moveFiles(string file, string destFolder)
        {
             FileInfo fileinfo = new FileInfo(file);
             fileinfo.MoveTo(Path.Combine(destFolder, fileinfo.Name));
           /* foreach (FileInfo file in files) // Directory.GetFiles(srcFolder)
             {
                 if (file.Extension == ".png")
                 {
                     file.MoveTo(Path.Combine(destFolder, file.Name));
                 }
                 // will move all files without if stmt 
                 //file.MoveTo(Path.Combine(destFolder, file.Name));
             }*/
        }
}

    class Time
    {
        public int year;
        public int month;
        static List<String> months = new List<String> {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };
        public Time(String id,String text)
        {
            String[] strs = text.Split(new char[] { ' '});
            if (strs.Length==1)
            {
                /*Message.set.Add(id);*/
                Console.WriteLine(id +"月份为空");
               int.TryParse(strs[0],out year);
            }
            else
            {
                try { 
                    year = int.Parse(strs[0]); 
                }catch(Exception e)
                {
                   /* Message.set.Add(id);*/
                    Console.WriteLine(id + "格式不合格");
                    Console.WriteLine(text);
                    return;
                }
                try
                {
                    month=months.IndexOf(strs[1])+1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(text);
                    return;
                }

            }
        }
    }
}
