using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TskTestGeo
{
    class Program
    {
        static void Main(string[] args)
        {
            OSM osm = new OSM();
            Console.WriteLine("Введите Адрес:");
            string address = Console.ReadLine();
            Console.WriteLine("Частота точек:");
            int freq = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите имя файла для сохранения результата:");
            string filepath = Console.ReadLine();
            Console.WriteLine("Сохранение результата в файл...");
            string result = GetPage(osm.GetUrl(address));
            SaveToFile(GetPoints(result), freq, filepath);
            GetPoints(result);
            Console.WriteLine("Результат сохранен!");
            System.Diagnostics.Process.Start("notepad.exe", Path.Combine(Environment.CurrentDirectory, filepath));
        }

        static string GetPage(string _url)
        {
            WebClient webClient = new WebClient();
            UserAgent userAgent = new UserAgent();
            webClient.Headers.Add(userAgent.GetAgent(Agent.Chrome));
            return webClient.DownloadString(_url);
        }


        static List<string> GetPoints(string str)
        {
            int idx = str.IndexOf(":[[[");
            str = str.Substring(idx + 3);
            idx = str.IndexOf("]]}}");
            str = str.Substring(0, idx);
            string[] points = str.Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();
            foreach (var s in points)
            {
                string sss = s.Replace("[", "").Replace("]", "");
                list.Add(sss);
            }
            return list;
        }

        static void SaveToFile(List<string> list, int freq, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, fileName), false, Encoding.UTF8))
            {
                for (int i = 0; i < list.Count; i += freq)
                {
                    sw.WriteLine(list[i]);
                }
            }
        }

    }
}
